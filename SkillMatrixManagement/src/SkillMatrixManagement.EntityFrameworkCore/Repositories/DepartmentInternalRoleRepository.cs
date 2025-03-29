using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class DepartmentInternalRoleRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, DepartmentInternalRole, Guid>, IDepartmentInternalRoleRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public DepartmentInternalRoleRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
        // Create a new department internal role
        public async Task<DepartmentInternalRole> CreateAsync(DepartmentInternalRole departmentInternalRole)
        {
            Check.NotNull(departmentInternalRole, nameof(departmentInternalRole));
            if (!Enum.IsDefined(typeof(DepartmentInternalRole), departmentInternalRole.RoleName))
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.INVALID_ROLE_NAME, "Invalid department interenalrole name specified");
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var exists = await dbContext.Set<DepartmentInternalRole>().AnyAsync(r => r.RoleName == departmentInternalRole.RoleName && !r.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.ROLE_ALREADY_EXIST, "Department internal role already exists");


            var result = await dbContext.Set<DepartmentInternalRole>().AddAsync(departmentInternalRole);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Retrieve a department internal role by its ID
        public async Task<DepartmentInternalRole> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var deptRole = await dbContext.Set<DepartmentInternalRole>().FindAsync(id)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.ROLE_NOT_FOUND, "Role not found");
            return deptRole;
        }
        // Retrieve all department internal roles
        public async Task<List<DepartmentInternalRole>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentInternalRole>().Where(r => !r.IsDeleted).ToListAsync();
        }
        // Update a department internal role
        public async Task UpdateAsync(DepartmentInternalRole departmentInternalRole)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            Check.NotNull(departmentInternalRole, nameof(departmentInternalRole));
            if (departmentInternalRole.Id == Guid.Empty)
                throw new ArgumentException("Department Internal ID cannot be empty", nameof(departmentInternalRole.Id));
            if (!Enum.IsDefined(typeof(DepartmentInternalRole), departmentInternalRole.RoleName)) throw new BusinessException("DEP_ROLE-004", "Invalid department internal role name specified");

            //Check Existence 
            var existing = await dbContext.Set<DepartmentInternalRole>().FirstOrDefaultAsync(r => r.Id == departmentInternalRole.Id && !r.IsDeleted) ?? throw new BusinessException("DEP_ROLE-005", "Depaertment internal Role not found for update");

            //check for duplicates
            var duplicateExists = await dbContext.Set<DepartmentInternalRole>().AnyAsync(r => r.RoleName == departmentInternalRole.RoleName && r.Id != departmentInternalRole.Id && !r.IsDeleted);
            if (duplicateExists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.INVALID_ROLE_NAME_FOR_UPDATE, "Department internal role already exists");


            dbContext.Set<DepartmentInternalRole>().Update(departmentInternalRole);
            await dbContext.SaveChangesAsync();
        }
        // Delete a department internal role
        public async Task DeleteAsync(Guid departmentInternalRoleId)
        {
            await SoftDeleteAsync(departmentInternalRoleId);
        }
        // Soft delete a department internal role
        public async Task SoftDeleteAsync(Guid departmentInternalRoleId)
        {
            if (departmentInternalRoleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(departmentInternalRoleId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<DepartmentInternalRole>().FindAsync(departmentInternalRoleId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.ROLE_NOT_FOUND, "Role not found");
            if (role.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.ROLE_ALREADY_DELETED, "Role is already deleted");
            role.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }
        // Permanently delete a department internal role
        public async Task PermanentDeleteAsync(Guid departmentInternalRoleId)
        {
            if (departmentInternalRoleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(departmentInternalRoleId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<DepartmentInternalRole>().IgnoreQueryFilters().FirstOrDefaultAsync(r => r.Id == departmentInternalRoleId);

            if (role == null)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.ROLE_NOT_FOUND, "Role not found for deletion");

            dbContext.Set<DepartmentInternalRole>().Remove(role);
            await dbContext.SaveChangesAsync();
        }
        // Restore a department internal role
        public async Task RestoreDepartmentInternalRoleAsync(Guid departmentInternalRoleId)
        {
            if (departmentInternalRoleId == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(departmentInternalRoleId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var role = await dbContext.Set<DepartmentInternalRole>().IgnoreQueryFilters().FirstOrDefaultAsync(r => r.Id == departmentInternalRoleId);

            if (role == null || !role.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentInternalRole.ROLE_NOT_FOUND_OR_NOT_DELETED, "Role not found or not deleted");

            role.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }
        // Retrieve all department internal roles including deleted ones
        public async Task<List<DepartmentInternalRole>> GetAllRolesAsync(bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<DepartmentInternalRole>().IgnoreQueryFilters().ToListAsync() : dbContext.Set<DepartmentInternalRole>().ToListAsync());
        }

        // Pagination and Filtering
        public async Task<List<DepartmentInternalRole>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<DepartmentInternalRole>().IgnoreQueryFilters() : dbContext.Set<DepartmentInternalRole>())
                .Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        // Counting
        public async Task<int> CountAsync(bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<DepartmentInternalRole>().IgnoreQueryFilters().CountAsync() : dbContext.Set<DepartmentInternalRole>().CountAsync());
        }
    }
}
