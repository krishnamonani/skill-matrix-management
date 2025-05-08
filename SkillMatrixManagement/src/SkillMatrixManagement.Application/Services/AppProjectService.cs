using AutoMapper;
using SkillMatrixManagement.DTOs.ProjectDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using SkillMatrixManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppProjectService : ApplicationService, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IProjectEmployeeRepository _projectEmployeeRepositry;
        private readonly ProjectStatusService _projectStatusService;

        public AppProjectService(
            IProjectRepository projectRepository, 
            IMapper mapper, 
            IProjectEmployeeRepository projectEmployeeRepositry,
            ProjectStatusService projectStatusService)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _projectEmployeeRepositry = projectEmployeeRepositry;
            _projectStatusService = projectStatusService;
        }

        public async Task<ServiceResponse<ProjectDto>> CreateAsync(CreateProjectDto input)
        {
            try
            {
                var project = _mapper.Map<Project>(input);
                project.IsDeleted = false;

                var createdEntity = await _projectRepository.CreateAsync(project);
                var dto = _mapper.Map<ProjectDto>(createdEntity);

                return ServiceResponse<ProjectDto>.SuccessResult(dto, 201, "Project created successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<ProjectDto>.Failure(ex.Message, ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProjectDto>.Failure($"Error creating project: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<ProjectDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    return ServiceResponse<ProjectDto>.Failure("Project not found.", 404);
                }

                var dto = _mapper.Map<ProjectDto>(project);
                return ServiceResponse<ProjectDto>.SuccessResult(dto, 200, "Project retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProjectDto>.Failure($"Error retrieving project: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<ProjectDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                if (!includeDeleted)
                {
                    projects = projects.Where(p => !p.IsDeleted).ToList();
                }

                var dtos = _mapper.Map<List<ProjectDto>>(projects);
                return ServiceResponse<List<ProjectDto>>.SuccessResult(dtos, 200, "Projects retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProjectDto>>.Failure($"Error retrieving projects: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<ProjectPagedResultDto>> GetPagedListAsync(ProjectFilterDto input)
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();

                // Apply filters
                if (!string.IsNullOrEmpty(input.ProjectName))
                    projects = projects.Where(p => p.ProjectName.Contains(input.ProjectName, StringComparison.OrdinalIgnoreCase)).ToList();
                if (input.IsDeleted.HasValue)
                    projects = projects.Where(p => p.IsDeleted == input.IsDeleted).ToList();

                // Apply sorting
                projects = input.Sorting?.ToLower() switch
                {
                    "projectname desc" => projects.OrderByDescending(p => p.ProjectName).ToList(),
                    _ => projects.OrderBy(p => p.ProjectName).ToList()
                };

                // Apply pagination
                var totalCount = projects.Count;
                var items = projects.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

                var result = new ProjectPagedResultDto(totalCount, _mapper.Map<List<ProjectDto>>(items));
                return ServiceResponse<ProjectPagedResultDto>.SuccessResult(result, 200, "Paged projects retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProjectPagedResultDto>.Failure($"Error retrieving paged projects: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateProjectDto input)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    return ServiceResponse.Failure("Project not found.", 404);
                }

                // Check if status is changing to Completed or On Hold
                bool statusChanged = !string.IsNullOrEmpty(input.Status) && 
                                    project.Status != input.Status && 
                                    (input.Status == ProjectConstants.Status.Completed || 
                                     input.Status == ProjectConstants.Status.OnHold);
                
                _mapper.Map(input, project);
                await _projectRepository.UpdateAsync(project);
                
                // If status changed to Completed or On Hold, release developers
                if (statusChanged)
                {
                    await _projectStatusService.ReleaseAllAssignedUsersFromProjectAsync(id);
                }

                return ServiceResponse.SuccessResult(204, "Project updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error updating project: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> UpdateProjectStatusAsync(Guid id, UpdateProjectStatusDto input)
        {
            try
            {
                await _projectStatusService.UpdateProjectStatusAsync(id, input.Status);
                return ServiceResponse.SuccessResult(204, $"Project status updated to {input.Status} successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error updating project status: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                await _projectRepository.SoftDeleteAsync(id);
                var ProjectEmployeeList =await _projectEmployeeRepositry.GetAllAsync();
                var DeletedProject = ProjectEmployeeList.Where(pe => pe.ProjectId == id);
                
                foreach(var project in DeletedProject)
                {
                    await _projectEmployeeRepositry.DeleteAsync(project.Id);
                }
               
                return ServiceResponse.SuccessResult(204, "Project soft deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error soft deleting project: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                await _projectRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(204, "Project permanently deleted.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error permanently deleting project: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> RestoreProjectAsync(Guid id)
        {
            try
            {
                await _projectRepository.RestoreProjectAsync(id);
                return ServiceResponse.SuccessResult(204, "Project restored successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error restoring project: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                if (!includeDeleted)
                {
                    projects = projects.Where(p => !p.IsDeleted).ToList();
                }

                int count = projects.Count;
                return ServiceResponse<int>.SuccessResult(count, 200, "Project count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Error counting projects: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<ProjectLookupDto>>> GetLookupAsync()
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                var lookup = projects.Select(p => new ProjectLookupDto { Id = p.Id, ProjectName = p.ProjectName }).ToList();
                return ServiceResponse<List<ProjectLookupDto>>.SuccessResult(lookup, 200, "Project lookup data retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProjectLookupDto>>.Failure($"Error retrieving lookup data: {ex.Message}", 500);
            }
        }

    }
}