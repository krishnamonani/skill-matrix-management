using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.ProjectEmployeeDTO;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IProjectEmployeeRepository : IBasicRepository<ProjectEmployee, Guid>
    {
        // CRUD Methods
        Task<ProjectEmployee> CreateAsync(ProjectEmployee projectEmployee);
        Task<ProjectEmployee> GetByIdAsync(Guid id);
        Task<List<ProjectEmployee>> GetAllAsync();
        Task UpdateAsync(ProjectEmployee projectEmployee);
        Task DeleteAsync(Guid projectEmployeeId); // Soft delete
        Task PermanentDeleteAsync(Guid projectEmployeeId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid projectEmployeeId); // Soft delete a project employee
        Task RestoreProjectEmployeeAsync(Guid projectEmployeeId); // Restore a soft-deleted project employee

        // Custom Methods
        Task<List<AssingedUserProjectDTO>> GetByProjectIdAsync(Guid projectId);// Get all employees for a specific project
        Task<List<ProjectEmployee>> GetByUserIdAsync(Guid userId); // Get all projects assigned to a specific user

        Task<ProjectEmployee> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false); // Pagination & Filtering
         Task<Boolean> IsExistTheUserIdProjectIdAsync(Guid userId, Guid projectId);

        


    }
}
