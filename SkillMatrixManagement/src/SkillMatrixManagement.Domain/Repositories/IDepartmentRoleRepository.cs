using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IDepartmentRoleRepository : IBasicRepository<DepartmentRole, Guid>
    {
        // CRUD Methods
        Task<DepartmentRole> CreateAsync(DepartmentRole departmentRole);
        Task<DepartmentRole> GetByIdAsync(Guid id);
        Task<List<DepartmentRole>> GetAllAsync();
        Task UpdateAsync(DepartmentRole departmentRole);
        Task DeleteAsync(Guid departmentRoleId); // Soft delete
        Task PermanentDeleteAsync(Guid departmentRoleId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid departmentRoleId); // Soft delete a department role
        Task RestoreDepartmentRoleAsync(Guid departmentRoleId); // Restore a soft-deleted department role

        // Custom Methods
        Task<List<DepartmentRole>> GetRolesByDepartmentAsync(Guid departmentId);
        Task<List<DepartmentRole>> GetRolesByInternalRoleAsync(Guid internalRoleId);
    }
}
