using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class RoleRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Role, Guid>, IRoleRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public RoleRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            // Input validation
            Check.NotNull(role, nameof(role));
            if (!Enum.IsDefined(typeof(RoleEnum), role.Name))
                throw new BusinessException("ROLE-001", "Invalid role name specified");

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check for duplicates
            var exists = await dbContext.Set<Role>()
                .AnyAsync(r => r.Name == role.Name && !r.IsDeleted);
            if (exists)
                throw new BusinessException("ROLE-002", "A role with this name already exists");

            var result = await dbContext.Set<Role>().AddAsync(role);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            // Input validation
            if (id == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<Role>()
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted)
                ?? throw new BusinessException("ROLE-004", "Role not found");

            return role;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Role>()
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            // Input validation
            Check.NotNull(role, nameof(role));
            if (role.Id == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(role));
            if (!Enum.IsDefined(typeof(RoleEnum), role.Name))
                throw new BusinessException("ROLE-011", "Invalid role name specified");

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check existence
            var existing = await dbContext.Set<Role>()
                .FirstOrDefaultAsync(r => r.Id == role.Id && !r.IsDeleted)
                ?? throw new BusinessException("ROLE-012", "Role not found for update");

            // Check for duplicate names
            var duplicateExists = await dbContext.Set<Role>()
                .AnyAsync(r => r.Name == role.Name && r.Id != role.Id && !r.IsDeleted);
            if (duplicateExists)
                throw new BusinessException("ROLE-013", "Another role with this name already exists");

            dbContext.Set<Role>().Update(role);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid roleId)
        {
            await SoftDeleteAsync(roleId);
        }

        public async Task SoftDeleteAsync(Guid roleId)
        {
            // Input validation
            if (roleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(roleId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<Role>()
                .FirstOrDefaultAsync(r => r.Id == roleId && !r.IsDeleted)
                ?? throw new BusinessException("ROLE-009", "Role not found for soft deletion");

            if (role.IsDeleted)
                throw new BusinessException("ROLE-010", "Role is already deleted");

            role.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid roleId)
        {
            // Input validation
            if (roleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(roleId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<Role>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == roleId);

            if (role == null)
                throw new BusinessException("ROLE-005", "Role not found for permanent deletion");

            dbContext.Set<Role>().Remove(role);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreRoleAsync(Guid roleId)
        {
            // Input validation
            if (roleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(roleId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<Role>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == roleId)
                ?? throw new BusinessException("ROLE-006", "Role not found for restoration");

            if (!role.IsDeleted)
                throw new BusinessException("ROLE-007", "Role is not deleted, cannot be restored");

            // Check for duplicates
            var exists = await dbContext.Set<Role>()
                .AnyAsync(r => r.Name == role.Name && !r.IsDeleted);
            if (exists)
                throw new BusinessException("ROLE-008", "Cannot restore: A role with this name already exists");

            role.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public override async Task<IQueryable<Role>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<Role>();
        }
    }
}