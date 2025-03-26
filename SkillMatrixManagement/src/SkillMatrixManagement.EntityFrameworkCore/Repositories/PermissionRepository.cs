using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.Repositories
{
    public class PermissionRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Permission, Guid>, IPermissionRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public PermissionRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        // Create a new Permission
        public async Task<Permission> CreateAsync(Permission permission)
        {
            // Input validation
            Check.NotNull(permission, nameof(permission));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check for duplicates
            var exists = await dbContext.Set<Permission>()
                .AnyAsync(p => p.Name == permission.Name && !p.IsDeleted);
            if (exists)
                throw new BusinessException("PERM-001", "A permission with this name already exists");

            var result = await dbContext.Set<Permission>().AddAsync(permission);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Get Permission by ID
        public async Task<Permission> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Permission ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var permission = await dbContext.Set<Permission>()
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted)
                ?? throw new BusinessException("PERM-002", "Permission not found");

            return permission;
        }

        // Get All Permissions
        public async Task<List<Permission>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Permission>()
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        // Update Permission
        public async Task UpdateAsync(Permission permission)
        {
            Check.NotNull(permission, nameof(permission));

            if (permission.Id == Guid.Empty)
                throw new ArgumentException("Permission ID cannot be empty", nameof(permission));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var existingPermission = await dbContext.Set<Permission>()
                .FirstOrDefaultAsync(p => p.Id == permission.Id && !p.IsDeleted)
                ?? throw new BusinessException("PERM-003", "Permission not found for update");

            dbContext.Entry(existingPermission).CurrentValues.SetValues(permission);
            await dbContext.SaveChangesAsync();
        }

        // Soft Delete Permission
        public async Task DeleteAsync(Guid permissionId)
        {
            await SoftDeleteAsync(permissionId);
        }

        public async Task SoftDeleteAsync(Guid permissionId)
        {
            if (permissionId == Guid.Empty)
                throw new ArgumentException("Permission ID cannot be empty", nameof(permissionId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var permission = await dbContext.Set<Permission>()
                .FirstOrDefaultAsync(p => p.Id == permissionId && !p.IsDeleted)
                ?? throw new BusinessException("PERM-004", "Permission not found for soft deletion");

            if (permission.IsDeleted)
                throw new BusinessException("PERM-005", "Permission is already deleted");

            permission.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        // Permanent Delete Permission
        public async Task PermanentDeleteAsync(Guid permissionId)
        {
            if (permissionId == Guid.Empty)
                throw new ArgumentException("Permission ID cannot be empty", nameof(permissionId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var permission = await dbContext.Set<Permission>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == permissionId);

            if (permission == null)
                throw new BusinessException("PERM-006", "Permission not found for permanent deletion");

            dbContext.Set<Permission>().Remove(permission);
            await dbContext.SaveChangesAsync();
        }

        // Restore Soft Deleted Permission
        public async Task RestorePermissionAsync(Guid permissionId)
        {
            if (permissionId == Guid.Empty)
                throw new ArgumentException("Permission ID cannot be empty", nameof(permissionId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var permission = await dbContext.Set<Permission>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == permissionId)
                ?? throw new BusinessException("PERM-007", "Permission not found for restoration");

            if (!permission.IsDeleted)
                throw new BusinessException("PERM-008", "Permission is not deleted, cannot be restored");

            permission.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        // Get Permissions by Name
        public async Task<List<Permission>> GetPermissionsByNameAsync(PermissionEnum permissionName)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            return await dbContext.Set<Permission>()
                .Where(p => p.Name == permissionName && !p.IsDeleted)
                .ToListAsync();
        }

        // Override to include navigation properties
        public override async Task<IQueryable<Permission>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<Permission>();
        }
    }
}
