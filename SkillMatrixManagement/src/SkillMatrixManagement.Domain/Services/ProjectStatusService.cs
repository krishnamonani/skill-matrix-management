using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace SkillMatrixManagement.Services
{
    public class ProjectStatusService : DomainService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProjectStatusService> _logger;

        public ProjectStatusService(
            IProjectRepository projectRepository,
            IProjectEmployeeRepository projectEmployeeRepository,
            IUserRepository userRepository,
            ILogger<ProjectStatusService> logger)
        {
            _projectRepository = projectRepository;
            _projectEmployeeRepository = projectEmployeeRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task UpdateProjectStatusAsync(Guid projectId, string status)
        {
            try
            {
                await _projectRepository.UpdateProjectStatusAsync(projectId, status);
                
                // If project is marked as completed or on hold, release all developers
                if (status == ProjectConstants.Status.Completed || status == ProjectConstants.Status.OnHold)
                {
                    _logger.LogInformation($"Releasing developers from project {projectId} due to status change to {status}");
                    await ReleaseAllAssignedUsersFromProjectAsync(projectId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating project status for project {projectId}");
                throw;
            }
        }

        public async Task CheckExpiredProjectsAsync()
        {
            try
            {
                var expiredProjects = await _projectRepository.GetExpiredProjectsAsync();
                foreach (var project in expiredProjects)
                {
                    _logger.LogInformation($"Auto-completing expired project: {project.Id} - {project.ProjectName}");
                    await UpdateProjectStatusAsync(project.Id, ProjectConstants.Status.Completed);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking expired projects");
                throw;
            }
        }

        public async Task ReleaseAllAssignedUsersFromProjectAsync(Guid projectId)
        {
            try
            {
                var usersAssigned = await _projectEmployeeRepository.GetByProjectIdAsync(projectId);
                if (usersAssigned == null || !usersAssigned.Any())
                {
                    return;
                }

                foreach (var user in usersAssigned)
                {
                    try
                    {
                        // Reset the user's percentages
                        user.AssignibilityPerncentage = 0;
                        user.BillablePerncentage = 0;
                        user.AvailabilityPerncentage = 100;
                        
                        // Use the correct enum value for IsAvailable
                        user.IsAvailable = SkillMatrixManagement.Constants.ProjectStatusEnum.AVAILABLE;
                        
                        // Update the user
                        await _userRepository.UpdateAsync(user);
                        
                        _logger.LogInformation($"Released user {user.Id} from project {projectId}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error releasing user {user.Id} from project {projectId}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error releasing users from project {projectId}");
                throw;
            }
        }
    }
}
