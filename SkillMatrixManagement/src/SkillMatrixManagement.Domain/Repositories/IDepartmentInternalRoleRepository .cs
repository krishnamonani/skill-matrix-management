using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IDepartmentInternalRoleRepository : IBasicRepository<DepartmentInternalRole, Guid>
    {
        // CRUD Methods
        Task<DepartmentInternalRole> CreateAsync(DepartmentInternalRole departmentInternalRole);
        Task<DepartmentInternalRole> GetByIdAsync(Guid id);
        Task<List<DepartmentInternalRole>> GetAllAsync();
        Task UpdateAsync(DepartmentInternalRole departmentInternalRole);
        Task DeleteAsync(Guid departmentInternalRoleId); // Soft delete
        Task PermanentDeleteAsync(Guid departmentInternalRoleId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid departmentInternalRoleId); // Soft delete a role
        Task RestoreDepartmentInternalRoleAsync(Guid departmentInternalRoleId); // Restore a soft-deleted role

        // Custom Methods
        Task<List<DepartmentInternalRole>> GetAllRolesAsync(bool includeDeleted = false); // Get all roles, optionally including deleted ones

        // Pagination and Filtering
        Task<List<DepartmentInternalRole>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false);
        Task<int> CountAsync(bool includeDeleted = false); // Count all roles, optionally including deleted ones
    }
}
