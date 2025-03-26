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
    public class DepartmentRoleRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, DepartmentRole, Guid>, IDepartmentRoleRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public DepartmentRoleRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<DepartmentRole> CreateAsync(DepartmentRole departmentRole)
        {
            Check.NotNull(departmentRole, nameof(departmentRole));
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var exists = await dbContext.Set<DepartmentRole>()
                .AnyAsync(dr => dr.DepartmentId == departmentRole.DepartmentId && dr.InternalRoleId == departmentRole.InternalRoleId && !dr.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_ALREADY_EXISTS);

            var result = await dbContext.Set<DepartmentRole>().AddAsync(departmentRole);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<DepartmentRole> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.INVALID_DEPARTMENT_ROLE_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentRole = await dbContext.Set<DepartmentRole>()
                .FirstOrDefaultAsync(dr => dr.Id == id && !dr.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_NOT_FOUND);

            return departmentRole;
        }

        public async Task<List<DepartmentRole>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentRole>().Where(dr => !dr.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(DepartmentRole departmentRole)
        {
            Check.NotNull(departmentRole, nameof(departmentRole));
            if (departmentRole.Id == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.INVALID_DEPARTMENT_ROLE_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<DepartmentRole>()
                .FirstOrDefaultAsync(dr => dr.Id == departmentRole.Id && !dr.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_NOT_FOUND);

            dbContext.Set<DepartmentRole>().Update(departmentRole);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid departmentRoleId)
        {
            await SoftDeleteAsync(departmentRoleId);
        }

        public async Task SoftDeleteAsync(Guid departmentRoleId)
        {
            if (departmentRoleId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.INVALID_DEPARTMENT_ROLE_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentRole = await dbContext.Set<DepartmentRole>()
                .FirstOrDefaultAsync(dr => dr.Id == departmentRoleId && !dr.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_NOT_FOUND);

            departmentRole.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid departmentRoleId)
        {
            if (departmentRoleId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.INVALID_DEPARTMENT_ROLE_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentRole = await dbContext.Set<DepartmentRole>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(dr => dr.Id == departmentRoleId);

            if (departmentRole == null)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_NOT_FOUND);

            dbContext.Set<DepartmentRole>().Remove(departmentRole);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreDepartmentRoleAsync(Guid departmentRoleId)
        {
            if (departmentRoleId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.INVALID_DEPARTMENT_ROLE_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentRole = await dbContext.Set<DepartmentRole>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(dr => dr.Id == departmentRoleId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_NOT_FOUND);

            if (!departmentRole.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentRole.DEPARTMENT_ROLE_NOT_DELETED);

            departmentRole.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<DepartmentRole>> GetRolesByDepartmentAsync(Guid departmentId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentRole>()
                .Where(dr => dr.DepartmentId == departmentId && !dr.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<DepartmentRole>> GetRolesByInternalRoleAsync(Guid internalRoleId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentRole>()
                .Where(dr => dr.InternalRoleId == internalRoleId && !dr.IsDeleted)
                .ToListAsync();
        }

        public override async Task<IQueryable<DepartmentRole>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<DepartmentRole>();
        }
    }
}