using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                throw new ArgumentException("UserId cannot be empty", nameof(skillHistory.UserId));
            if (skillHistory.SkillId == Guid.Empty)
                throw new ArgumentException("SkillId cannot be empty", nameof(skillHistory.SkillId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>().AddAsync(skillHistory);
            await dbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<SkillHistory> GetByIdAsync(Guid id)
        {
            // Input validation
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillHistory = await dbContext.Set<SkillHistory>()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted)
                ?? throw new EntityNotFoundException(typeof(SkillHistory), id);

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
                throw new ArgumentException("Id cannot be empty", nameof(skillHistory.Id));
            if (skillHistory.UserId == Guid.Empty)
                throw new ArgumentException("UserId cannot be empty", nameof(skillHistory.UserId));
            if (skillHistory.SkillId == Guid.Empty)
                throw new ArgumentException("SkillId cannot be empty", nameof(skillHistory.SkillId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            dbContext.Set<SkillHistory>().Update(skillHistory);
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
                throw new ArgumentException("SkillHistoryId cannot be empty", nameof(skillHistoryId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>()
                .FirstOrDefaultAsync(x => x.Id == skillHistoryId && !x.IsDeleted)
                ?? throw new EntityNotFoundException(typeof(SkillHistory), skillHistoryId);

            entity.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid skillHistoryId)
        {
            // Input validation
            if (skillHistoryId == Guid.Empty)
                throw new ArgumentException("SkillHistoryId cannot be empty", nameof(skillHistoryId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == skillHistoryId);

            if (entity != null)
            {
                dbContext.Set<SkillHistory>().Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RestoreSkillHistoryAsync(Guid skillHistoryId)
        {
            // Input validation
            if (skillHistoryId == Guid.Empty)
                throw new ArgumentException("SkillHistoryId cannot be empty", nameof(skillHistoryId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.Set<SkillHistory>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == skillHistoryId)
                ?? throw new EntityNotFoundException(typeof(SkillHistory), skillHistoryId);

            if (!entity.IsDeleted)
                throw new BusinessException("SkillMatrix:0001", "This skill history is not deleted");

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
