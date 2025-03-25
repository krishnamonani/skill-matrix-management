using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class RolePermissionRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, RolePermission, Guid>, IRolePermissionRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public RolePermissionRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        // Create a new role permission
        public async Task<RolePermission> CreateAsync(RolePermission rolePermission)
        {
            Check.NotNull(rolePermission, nameof(rolePermission));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var exists = await dbContext.Set<RolePermission>()
                .AnyAsync(rp => rp.RoleId == rolePermission.RoleId && rp.Permission == rolePermission.Permission && !rp.IsDeleted);

            if (exists)
                throw new BusinessException("ROLE_PERM-001", "Permission already assigned to this role");

            var result = await dbContext.Set<RolePermission>().AddAsync(rolePermission);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Get role permission by ID
        public async Task<RolePermission> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Role Permission ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var rolePermission = await dbContext.Set<RolePermission>().FindAsync(id)
                ?? throw new BusinessException("ROLE_PERM-002", "Role Permission not found");

            return rolePermission;
        }

        // Get all role permissions
        public async Task<List<RolePermission>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<RolePermission>().Where(rp => !rp.IsDeleted).ToListAsync();
        }

        // Update role permission
        public async Task UpdateAsync(RolePermission rolePermission)
        {
            Check.NotNull(rolePermission, nameof(rolePermission));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<RolePermission>()
                .FirstOrDefaultAsync(rp => rp.Id == rolePermission.Id && !rp.IsDeleted)
                ?? throw new BusinessException("ROLE_PERM-003", "Role Permission not found for update");

            dbContext.Set<RolePermission>().Update(rolePermission);
            await dbContext.SaveChangesAsync();
        }

        // Soft Delete role permission
        public async Task DeleteAsync(Guid rolePermissionId)
        {
            await SoftDeleteAsync(rolePermissionId);
        }

        // Soft Delete role permission
        public async Task SoftDeleteAsync(Guid rolePermissionId)
        {
            if (rolePermissionId == Guid.Empty)
                throw new ArgumentException("Role Permission ID cannot be empty", nameof(rolePermissionId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var rolePermission = await dbContext.Set<RolePermission>().FindAsync(rolePermissionId)
                ?? throw new BusinessException("ROLE_PERM-004", "Role Permission not found");

            if (rolePermission.IsDeleted)
                throw new BusinessException("ROLE_PERM-005", "Role Permission is already deleted");

            rolePermission.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        // Permanent Delete role permission
        public async Task PermanentDeleteAsync(Guid rolePermissionId)
        {
            if (rolePermissionId == Guid.Empty)
                throw new ArgumentException("Role Permission ID cannot be empty", nameof(rolePermissionId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var rolePermission = await dbContext.Set<RolePermission>().IgnoreQueryFilters()
                .FirstOrDefaultAsync(rp => rp.Id == rolePermissionId);

            if (rolePermission == null)
                throw new BusinessException("ROLE_PERM-006", "Role Permission not found for deletion");

            dbContext.Set<RolePermission>().Remove(rolePermission);
            await dbContext.SaveChangesAsync();
        }

        // Restore a soft-deleted role permission
        public async Task RestoreRolePermissionAsync(Guid rolePermissionId)
        {
            if (rolePermissionId == Guid.Empty)
                throw new ArgumentException("Role Permission ID cannot be empty", nameof(rolePermissionId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var rolePermission = await dbContext.Set<RolePermission>().IgnoreQueryFilters()
                .FirstOrDefaultAsync(rp => rp.Id == rolePermissionId);

            if (rolePermission == null || !rolePermission.IsDeleted)
                throw new BusinessException("ROLE_PERM-007", "Role Permission not found or not deleted");

            rolePermission.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
