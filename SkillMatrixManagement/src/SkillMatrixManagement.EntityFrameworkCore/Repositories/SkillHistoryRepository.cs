using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class SkillHistoryRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, SkillHistory, Guid>, ISkillHistoryRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillHistoryRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<SkillHistory> CreateAsync(SkillHistory skillHistory)
        {
            // Input validation
            Check.NotNull(skillHistory, nameof(skillHistory));
            if (skillHistory.UserId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-001", "UserId cannot be empty");
            if (skillHistory.SkillId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-002", "SkillId cannot be empty");
            if (!Enum.IsDefined(typeof(ProficiencyEnum), skillHistory.ChangedProficiencyLevel))
                throw new BusinessException("SKILLHISTORY-003", "Invalid proficiency level specified");

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>().AddAsync(skillHistory);
            await dbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<SkillHistory> GetByIdAsync(Guid id)
        {
            // Input validation
            if (id == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-004", "SkillHistory ID cannot be empty");

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillHistory = await dbContext.Set<SkillHistory>()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted)
                ?? throw new BusinessException("SKILLHISTORY-005", "SkillHistory not found");

            return skillHistory;
        }

        public async Task<List<SkillHistory>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<SkillHistory>()
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task UpdateAsync(SkillHistory skillHistory)
        {
            // Input validation
            Check.NotNull(skillHistory, nameof(skillHistory));
            if (skillHistory.Id == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-006", "SkillHistory ID cannot be empty");
            if (skillHistory.UserId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-007", "UserId cannot be empty");
            if (skillHistory.SkillId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-008", "SkillId cannot be empty");
            if (!Enum.IsDefined(typeof(ProficiencyEnum), skillHistory.ChangedProficiencyLevel))
                throw new BusinessException("SKILLHISTORY-009", "Invalid proficiency level specified");

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check existence
            var existing = await dbContext.Set<SkillHistory>()
                .FirstOrDefaultAsync(x => x.Id == skillHistory.Id && !x.IsDeleted)
                ?? throw new BusinessException("SKILLHISTORY-010", "SkillHistory not found for update");

            // Update specific fields
            existing.ChangedProficiencyLevel = skillHistory.ChangedProficiencyLevel;
            existing.Comment = skillHistory.Comment;
            existing.UserIdBasedVersion = skillHistory.UserIdBasedVersion;
            // Note: Not updating UserId or SkillId as they should be immutable for history records

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid skillHistoryId)
        {
            await SoftDeleteAsync(skillHistoryId);
        }

        public async Task SoftDeleteAsync(Guid skillHistoryId)
        {
            // Input validation
            if (skillHistoryId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-011", "SkillHistory ID cannot be empty");

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>()
                .FirstOrDefaultAsync(x => x.Id == skillHistoryId && !x.IsDeleted)
                ?? throw new BusinessException("SKILLHISTORY-012", "SkillHistory not found for soft deletion");

            if (entity.IsDeleted)
                throw new BusinessException("SKILLHISTORY-013", "SkillHistory is already deleted");

            entity.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid skillHistoryId)
        {
            // Input validation
            if (skillHistoryId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-014", "SkillHistory ID cannot be empty");

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == skillHistoryId);

            if (entity == null)
                throw new BusinessException("SKILLHISTORY-015", "SkillHistory not found for permanent deletion");

            dbContext.Set<SkillHistory>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreSkillHistoryAsync(Guid skillHistoryId)
        {
            // Input validation
            if (skillHistoryId == Guid.Empty)
                throw new BusinessException("SKILLHISTORY-016", "SkillHistory ID cannot be empty");

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == skillHistoryId)
                ?? throw new BusinessException("SKILLHISTORY-017", "SkillHistory not found for restoration");

            if (!entity.IsDeleted)
                throw new BusinessException("SKILLHISTORY-018", "SkillHistory is not deleted, cannot be restored");

            entity.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public override async Task<IQueryable<SkillHistory>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<SkillHistory>()
                .Include(x => x.User)
                .Include(x => x.Skill);
        }
    }
}