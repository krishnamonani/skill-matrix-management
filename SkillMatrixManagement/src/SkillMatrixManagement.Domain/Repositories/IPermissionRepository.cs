using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IPermissionRepository : IBasicRepository<Permission, Guid>
    {
        // CRUD Methods
        Task<Permission> CreateAsync(Permission permission);
        Task<Permission> GetByIdAsync(Guid id);
        Task<List<Permission>> GetAllAsync();
        Task UpdateAsync(Permission permission);
        Task DeleteAsync(Guid permissionId); // Soft delete
        Task PermanentDeleteAsync(Guid permissionId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid permissionId); // Soft delete a permission
        Task RestorePermissionAsync(Guid permissionId); // Restore a soft-deleted permission

        // Custom Methods
        Task<List<Permission>> GetPermissionsByNameAsync(PermissionEnum permissionName);
    }
}
