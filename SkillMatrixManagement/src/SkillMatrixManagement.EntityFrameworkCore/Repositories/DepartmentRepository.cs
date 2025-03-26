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
namespace SkillMatrixManagement.Repositories
{
    public class DepartmentRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Department, Guid>, IDepartmentRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public DepartmentRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Department> CreateAsync(Department department)
        {
            // Input validation
            Check.NotNull(department, nameof(department));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check for duplicates
            var exists = await dbContext.Set<Department>()
                .AnyAsync(d => d.Name == department.Name && !d.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_ALREADY_EXISTS);

            var result = await dbContext.Set<Department>().AddAsync(department);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.Department.INVALID_DEPARTMENT_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var department = await dbContext.Set<Department>()
                .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_NOT_FOUND);

            return department;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Department>()
                .Where(d => !d.IsDeleted)
                .ToListAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            Check.NotNull(department, nameof(department));
            if (department.Id == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.Department.INVALID_DEPARTMENT_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<Department>()
                .FirstOrDefaultAsync(d => d.Id == department.Id && !d.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_NOT_FOUND);

            var duplicateExists = await dbContext.Set<Department>()
                .AnyAsync(d => d.Name == department.Name && d.Id != department.Id && !d.IsDeleted);
            if (duplicateExists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_ALREADY_EXISTS);

            dbContext.Set<Department>().Update(department);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid departmentId)
        {
            await SoftDeleteAsync(departmentId);
        }

        public async Task SoftDeleteAsync(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.Department.INVALID_DEPARTMENT_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var department = await dbContext.Set<Department>()
                .FirstOrDefaultAsync(d => d.Id == departmentId && !d.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_NOT_FOUND);

            if (department.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_ALREADY_DELETED);

            department.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreDepartmentAsync(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.Department.INVALID_DEPARTMENT_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var department = await dbContext.Set<Department>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(d => d.Id == departmentId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_NOT_FOUND);

            if (!department.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_NOT_DELETED);

            var exists = await dbContext.Set<Department>()
                .AnyAsync(d => d.Name == department.Name && !d.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_ALREADY_EXISTS);

            department.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public override async Task<IQueryable<Department>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<Department>();
            }
    
            public async Task PermanentDeleteAsync(Guid departmentId)
            {
                if (departmentId == Guid.Empty)
                    throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.Department.INVALID_DEPARTMENT_ID);
    
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                var department = await dbContext.Set<Department>()
                    .FirstOrDefaultAsync(d => d.Id == departmentId && !d.IsDeleted)
                    ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Department.DEPARTMENT_NOT_FOUND);
    
                dbContext.Set<Department>().Remove(department);
                await dbContext.SaveChangesAsync();
            }
    
            public async Task<List<Department>> GetAllDepartmentsAsync(bool includeDeleted = false)
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                if (includeDeleted)
                {
                    return await dbContext.Set<Department>()
                        .IgnoreQueryFilters()
                        .ToListAsync();
                }
                return await dbContext.Set<Department>()
                    .Where(d => !d.IsDeleted)
                    .ToListAsync();
            }
    
            public async Task<List<Department>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false)
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                if (includeDeleted)
                {
                    return await dbContext.Set<Department>()
                        .IgnoreQueryFilters()
                        .Skip(skipCount)
                        .Take(maxResultCount)
                        .ToListAsync();
                }
                return await dbContext.Set<Department>()
                    .Where(d => !d.IsDeleted)
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
    
            public async Task<int> CountAsync(bool includeDeleted = false)
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                if (includeDeleted)
                {
                    return await dbContext.Set<Department>()
                        .IgnoreQueryFilters()
                        .CountAsync();
                }
                return await dbContext.Set<Department>()
                    .Where(d => !d.IsDeleted)
                    .CountAsync();
            }
        }
    }
