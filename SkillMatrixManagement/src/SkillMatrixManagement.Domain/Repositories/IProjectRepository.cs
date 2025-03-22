using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IProjectRepository : IBasicRepository<Project, Guid>
    {
        // CRUD Methods
        Task<Project> CreateAsync(Project project);
        Task<Project> GetByIdAsync(Guid id);
        Task<List<Project>> GetAllAsync();
        Task UpdateAsync(Project project);
        Task DeleteAsync(Guid projectId); // Soft delete
        Task PermanentDeleteAsync(Guid projectId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid projectId); // Soft delete a project
        Task RestoreProjectAsync(Guid projectId); // Restore a soft-deleted project

        // Custom Methods
        Task<List<Project>> GetDelayedProjectsAsync(); // Get delayed projects
        Task<List<Project>> GetOngoingProjectsAsync(); // Get ongoing projects
    }
}
