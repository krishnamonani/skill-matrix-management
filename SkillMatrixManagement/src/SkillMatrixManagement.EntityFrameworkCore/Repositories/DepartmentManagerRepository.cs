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
    public class DepartmentManagerRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, DepartmentManager, Guid>, IDepartmentManagerRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public DepartmentManagerRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
        public async Task<DepartmentManager> CreateAsync(DepartmentManager departmentManager)
        {
            Check.NotNull(departmentManager, nameof(departmentManager));


            var dbContext = await _dbContextProvider.GetDbContextAsync();
            await dbContext.Set<DepartmentManager>().AddAsync(departmentManager);
            await dbContext.SaveChangesAsync();
            return departmentManager;
        }

        public async Task<DepartmentManager> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Department Manager ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentManager>().FirstOrDefaultAsync(dm => dm.Id == id && !dm.IsDeleted)
                   ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentManager.DEPARTMENT_MANAGER_NOT_FOUND, "Department Manager not found");
        }

        public async Task<List<DepartmentManager>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentManager>().Where(dm => !dm.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(DepartmentManager departmentManager)
        {
            Check.NotNull(departmentManager, nameof(departmentManager));
            if (departmentManager.Id == Guid.Empty)
                throw new ArgumentException("Department Manager ID cannot be empty", nameof(departmentManager));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<DepartmentManager>().FirstOrDefaultAsync(dm => dm.Id == departmentManager.Id && !dm.IsDeleted) ?? throw new BusinessException("DM-002", "Department Manager not found for update");

            dbContext.Set<DepartmentManager>().Update(departmentManager);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid departmentManagerId) => await SoftDeleteAsync(departmentManagerId);

        public async Task SoftDeleteAsync(Guid departmentManagerId)
        {
            if (departmentManagerId == Guid.Empty)
                throw new ArgumentException("Department Manager ID cannot be empty", nameof(departmentManagerId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentManager = await dbContext.Set<DepartmentManager>().FirstOrDefaultAsync(dm => dm.Id == departmentManagerId && !dm.IsDeleted) ?? throw new BusinessException("DM-003", "Department Manager not found for soft deletion");

            departmentManager.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid departmentManagerId)
        {
            if (departmentManagerId == Guid.Empty)
                throw new ArgumentException("Department Manager ID cannot be empty", nameof(departmentManagerId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentManager = await dbContext.Set<DepartmentManager>().IgnoreQueryFilters().FirstOrDefaultAsync(dm => dm.Id == departmentManagerId);

            if (departmentManager == null)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentManager.DEPARTMENT_MANAGER_NOT_FOUND_FOR_PERMANENT_DELETE, "Department Manager not found for permanent deletion");

            dbContext.Set<DepartmentManager>().Remove(departmentManager);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreDepartmentManagerAsync(Guid departmentManagerId)
        {
            if (departmentManagerId == Guid.Empty)
                throw new ArgumentException("Department Manager ID cannot be empty", nameof(departmentManagerId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var departmentManager = await dbContext.Set<DepartmentManager>().IgnoreQueryFilters().FirstOrDefaultAsync(dm => dm.Id == departmentManagerId) ?? throw new BusinessException("DM-005", "Department Manager not found for restoration");

            if (!departmentManager.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.DepartmentManager.DEPARTMENT_MANAGER_NOT_DELETED, "Department Manager is not deleted, cannot be restored");

            departmentManager.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<DepartmentManager>> GetManagersByDepartmentAsync(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
                throw new ArgumentException("Department ID cannot be empty", nameof(departmentId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentManager>().Where(dm => dm.DepartmentId == departmentId && !dm.IsDeleted).ToListAsync();
        }

        public async Task<List<DepartmentManager>> GetManagersByUserAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<DepartmentManager>().Where(dm => dm.ManagerId == userId && !dm.IsDeleted).ToListAsync();
        }
    }
}

