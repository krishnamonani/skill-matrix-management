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

namespace SkillMatrixManagement.Repositories
{
    public class SkillMatrixRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, SkillMatrix, Guid>, ISkillMatrixRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillMatrixRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<SkillMatrix> CreateAsync(SkillMatrix skillMatrix)
        {
            // Input validation
            Check.NotNull(skillMatrix, nameof(skillMatrix));
            if (skillMatrix.DepartmentId == Guid.Empty)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.DEPARTMENT_ID_CAN_NOT_BE_EMPTY, "DepartmentId cannot be empty");
            if (skillMatrix.SkillId == Guid.Empty)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_ID_CAN_NOT_BE_EMPTY, "SkillId cannot be empty");

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check for duplicate combination
            var exists = await dbContext.Set<SkillMatrix>()
                .AnyAsync(sm => sm.DepartmentId == skillMatrix.DepartmentId &&
                              sm.SkillId == skillMatrix.SkillId &&
                              !sm.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_COMBINATION_ALREADY_EXIST, "This skill matrix combination already exists");

            var result = await dbContext.Set<SkillMatrix>().AddAsync(skillMatrix);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SkillMatrix> GetByIdAsync(Guid id)
        {
            // Input validation
            if (id == Guid.Empty)
                throw new ArgumentException("SkillMatrix ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillMatrix = await dbContext.Set<SkillMatrix>()
                .Include(sm => sm.Department)
                .Include(sm => sm.Skill)
                .FirstOrDefaultAsync(sm => sm.Id == id && !sm.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_NOT_FOUND, "SkillMatrix not found");

            return skillMatrix;
        }

        public async Task<List<SkillMatrix>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<SkillMatrix>()
                .Where(sm => !sm.IsDeleted)
                .Include(sm => sm.Department)
                .Include(sm => sm.Skill)
                .ToListAsync();
        }

        public async Task UpdateAsync(SkillMatrix skillMatrix)
        {
            // Input validation
            Check.NotNull(skillMatrix, nameof(skillMatrix));
            if (skillMatrix.Id == Guid.Empty)
                throw new ArgumentException("SkillMatrix ID cannot be empty", nameof(skillMatrix));
            if (skillMatrix.DepartmentId == Guid.Empty)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.DEPARTMENT_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE, "DepartmentId cannot be empty");
            if (skillMatrix.SkillId == Guid.Empty)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE, "SkillId cannot be empty");

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check existence
            var existing = await dbContext.Set<SkillMatrix>()
                .FirstOrDefaultAsync(sm => sm.Id == skillMatrix.Id && !sm.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_NOT_FOUND_FOR_UPDATE, "SkillMatrix not found for update");

            // Check for duplicate combination
            var duplicateExists = await dbContext.Set<SkillMatrix>()
                .AnyAsync(sm => sm.DepartmentId == skillMatrix.DepartmentId &&
                              sm.SkillId == skillMatrix.SkillId &&
                              sm.Id != skillMatrix.Id &&
                              !sm.IsDeleted);
            if (duplicateExists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.DUPLICATE_SKILL_MATRIX_COMBINATION, "Another skill matrix with this combination already exists");

            dbContext.Set<SkillMatrix>().Update(skillMatrix);
            await dbContext.SaveChangesAsync();
        }

        // only used for the soft delete
        public async Task DeleteAsync(Guid skillMatrixId)
        {
            await SoftDeleteAsync(skillMatrixId);
        }

        public async Task SoftDeleteAsync(Guid skillMatrixId)
        {
            // Input validation
            if (skillMatrixId == Guid.Empty)
                throw new ArgumentException("SkillMatrix ID cannot be empty", nameof(skillMatrixId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillMatrix = await dbContext.Set<SkillMatrix>()
                .FirstOrDefaultAsync(sm => sm.Id == skillMatrixId && !sm.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_NOT_FOUND_FOR_SOFT_DELETION, "SkillMatrix not found for soft deletion");

            if (skillMatrix.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_ALREADY_DELETED, "SkillMatrix is already deleted");

            skillMatrix.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid skillMatrixId)
        {
            // Input validation
            if (skillMatrixId == Guid.Empty)
                throw new ArgumentException("SkillMatrix ID cannot be empty", nameof(skillMatrixId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillMatrix = await dbContext.Set<SkillMatrix>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(sm => sm.Id == skillMatrixId);

            if (skillMatrix == null)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_NOT_FOUND_FOR_PERMANENT_DELETION, "SkillMatrix not found for permanent deletion");

            dbContext.Set<SkillMatrix>().Remove(skillMatrix);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreSkillMatrixAsync(Guid skillMatrixId)
        {
            // Input validation
            if (skillMatrixId == Guid.Empty)
                throw new ArgumentException("SkillMatrix ID cannot be empty", nameof(skillMatrixId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillMatrix = await dbContext.Set<SkillMatrix>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(sm => sm.Id == skillMatrixId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_NOT_FOUND_FOR_RESTORATION, "SkillMatrix not found for restoration");

            if (!skillMatrix.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.SKILL_MATRIX_NOT_DELETED, "SkillMatrix is not deleted, cannot be restored");

            // Check for duplicate combination
            var exists = await dbContext.Set<SkillMatrix>()
                .AnyAsync(sm => sm.DepartmentId == skillMatrix.DepartmentId &&
                              sm.SkillId == skillMatrix.SkillId &&
                              !sm.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillMatrix.DUPLICATE_SKILL_MATRIX_COMBINATION_ON_RESTORE, "Cannot restore: This skill matrix combination already exists");

            skillMatrix.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public override async Task<IQueryable<SkillMatrix>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<SkillMatrix>()
                .Include(sm => sm.Department)
                .Include(sm => sm.Skill);
        }
    }
}