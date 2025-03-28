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
    public class EmployeeSkillRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, EmployeeSkill, Guid>, IEmployeeSkillRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public EmployeeSkillRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<EmployeeSkill> CreateAsync(EmployeeSkill employeeSkill)
        {
            //Check.NotNull(employeeSkill, nameof(employeeSkill));

            //var dbContext = await _dbContextProvider.GetDbContextAsync();

            //// Check for duplicates
            //var exists = await dbContext.Set<EmployeeSkill>()
            //    .AnyAsync(es => es.UserId == employeeSkill.UserId && es.CoreSkillName == employeeSkill.CoreSkillName && !es.IsDeleted);
            //if (exists)
            //    throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_ALREADY_EXISTS);

            //var result = await dbContext.Set<EmployeeSkill>().AddAsync(employeeSkill);
            ////var result = await dbContext.EmployeeSkills.AddAsync(employeeSkill);
            //var isChanged = await dbContext.SaveChangesAsync() > 0;
            //return result.Entity;
            if (employeeSkill == null)
            {
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_CAN_NOT_BE_NULL);
            }
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity =await dbContext.EmployeeSkills.AddAsync(employeeSkill);
            await dbContext.SaveChangesAsync();
            return entity.Entity;

        }

        public async Task<EmployeeSkill> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.INVALID_EMPLOYEE_SKILL_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var employeeSkill = await dbContext.Set<EmployeeSkill>()
                .FirstOrDefaultAsync(es => es.Id == id && !es.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_NOT_FOUND);

            return employeeSkill;
        }

        public async Task<List<EmployeeSkill>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<EmployeeSkill>()
                .Where(es => !es.IsDeleted)
                .ToListAsync();
        }

        public async Task UpdateAsync(EmployeeSkill employeeSkill)
        {
            Check.NotNull(employeeSkill, nameof(employeeSkill));
            if (employeeSkill.Id == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.INVALID_EMPLOYEE_SKILL_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<EmployeeSkill>()
                .FirstOrDefaultAsync(es => es.Id == employeeSkill.Id && !es.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_NOT_FOUND);

            dbContext.Set<EmployeeSkill>().Update(employeeSkill);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid employeeSkillId)
        {
            await SoftDeleteAsync(employeeSkillId);
        }

        public async Task SoftDeleteAsync(Guid employeeSkillId)
        {
            if (employeeSkillId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.INVALID_EMPLOYEE_SKILL_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var employeeSkill = await dbContext.Set<EmployeeSkill>()
                .FirstOrDefaultAsync(es => es.Id == employeeSkillId && !es.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_NOT_FOUND);

            employeeSkill.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid employeeSkillId)
        {
            if (employeeSkillId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.INVALID_EMPLOYEE_SKILL_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var employeeSkill = await dbContext.Set<EmployeeSkill>()
                .FirstOrDefaultAsync(es => es.Id == employeeSkillId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_NOT_FOUND);

            dbContext.Set<EmployeeSkill>().Remove(employeeSkill);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreEmployeeSkillAsync(Guid employeeSkillId)
        {
            if (employeeSkillId == Guid.Empty)
                throw new ArgumentException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.INVALID_EMPLOYEE_SKILL_ID);

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var employeeSkill = await dbContext.Set<EmployeeSkill>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(es => es.Id == employeeSkillId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_NOT_FOUND);

            if (!employeeSkill.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.EmployeeSkill.EMPLOYEE_SKILL_NOT_DELETED);

            employeeSkill.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeSkill>> GetSkillsByUserAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<EmployeeSkill>()
                .Where(es => es.UserId == userId && !es.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<EmployeeSkill>> GetSkillsBySkillAsync(string coreSkillName)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<EmployeeSkill>()
                .Where(es => es.CoreSkillName.ToLower() == coreSkillName.ToLower() && !es.IsDeleted)
                .ToListAsync();
        }

        // Endorsement-related methods
        public async Task<List<EmployeeSkill>> GetEndorsedSkillsByUserAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<EmployeeSkill>()
                .Where(es => es.EndorsedBy == userId && !es.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<EmployeeSkill>> GetSkillsEndorsedForUserAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<EmployeeSkill>()
                .Where(es => es.UserId == userId && es.EndorsedBy != null && !es.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<EmployeeSkill>> GetSkillsByEndorserAsync(Guid endorserId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<EmployeeSkill>()
                .Where(es => es.EndorsedBy == endorserId && !es.IsDeleted)
                .ToListAsync();
        }

        public override async Task<IQueryable<EmployeeSkill>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<EmployeeSkill>();
        }
    }
}
