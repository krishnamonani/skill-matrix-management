using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IRolePermissionRepository : IBasicRepository<RolePermission, Guid>
    {
        // CRUD Methods
        Task<RolePermission> CreateAsync(RolePermission rolePermission);
        Task<RolePermission> GetByIdAsync(Guid id);
        Task<List<RolePermission>> GetAllAsync();
        Task UpdateAsync(RolePermission rolePermission);
        Task DeleteAsync(Guid rolePermissionId); // Soft delete
        Task PermanentDeleteAsync(Guid rolePermissionId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid rolePermissionId); // Soft delete a role permission
        Task RestoreRolePermissionAsync(Guid rolePermissionId); // Restore a soft-deleted role permission
    }
}
