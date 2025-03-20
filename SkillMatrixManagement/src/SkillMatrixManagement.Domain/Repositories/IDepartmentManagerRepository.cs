using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IDepartmentManagerRepository : IBasicRepository<DepartmentManager, Guid>
    {
        // CRUD Methods
        Task<DepartmentManager> CreateAsync(DepartmentManager departmentManager);
        Task<DepartmentManager> GetByIdAsync(Guid id);
        Task<List<DepartmentManager>> GetAllAsync();
        Task UpdateAsync(DepartmentManager departmentManager);
        Task DeleteAsync(Guid departmentManagerId); // Soft delete
        Task PermanentDeleteAsync(Guid departmentManagerId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid departmentManagerId); // Soft delete a department manager
        Task RestoreDepartmentManagerAsync(Guid departmentManagerId); // Restore a soft-deleted department manager

        // Custom Methods
        Task<List<DepartmentManager>> GetManagersByDepartmentAsync(Guid departmentId);
        Task<List<DepartmentManager>> GetManagersByUserAsync(Guid userId);
    }
}
