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
    public class SkillRecommendationByManagerRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, SkillRecommendationByManager, Guid>, ISkillRecommendationByManagerRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillRecommendationByManagerRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<SkillRecommendationByManager> CreateAsync(SkillRecommendationByManager skillRecommendationByManager)
        {
            Check.NotNull(skillRecommendationByManager, nameof(skillRecommendationByManager));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var result = await dbContext.Set<SkillRecommendationByManager>().AddAsync(skillRecommendationByManager);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SkillRecommendationByManager> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var recommendation = await dbContext.Set<SkillRecommendationByManager>().FindAsync(id)
                ?? throw new BusinessException("SRM-001", "Skill recommendation not found");

            return recommendation;
        }

        public async Task<List<SkillRecommendationByManager>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<SkillRecommendationByManager>().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(SkillRecommendationByManager skillRecommendationByManager)
        {
            Check.NotNull(skillRecommendationByManager, nameof(skillRecommendationByManager));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            dbContext.Set<SkillRecommendationByManager>().Update(skillRecommendationByManager);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid skillRecommendationByManagerId)
        {
            await SoftDeleteAsync(skillRecommendationByManagerId);
        }

        public async Task SoftDeleteAsync(Guid skillRecommendationByManagerId)
        {
            if (skillRecommendationByManagerId == Guid.Empty)
                throw new ArgumentException("ID cannot be empty", nameof(skillRecommendationByManagerId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var recommendation = await dbContext.Set<SkillRecommendationByManager>().FindAsync(skillRecommendationByManagerId)
                ?? throw new BusinessException("SRM-002", "Skill recommendation not found for deletion");

            if (recommendation.IsDeleted)
                throw new BusinessException("SRM-003", "Skill recommendation is already deleted");

            recommendation.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid skillRecommendationByManagerId)
        {
            if (skillRecommendationByManagerId == Guid.Empty)
                throw new ArgumentException("ID cannot be empty", nameof(skillRecommendationByManagerId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var recommendation = await dbContext.Set<SkillRecommendationByManager>().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillRecommendationByManagerId);

            if (recommendation == null)
                throw new BusinessException("SRM-004", "Skill recommendation not found for permanent deletion");

            dbContext.Set<SkillRecommendationByManager>().Remove(recommendation);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreSkillRecommendationAsync(Guid skillRecommendationByManagerId)
        {
            if (skillRecommendationByManagerId == Guid.Empty)
                throw new ArgumentException("ID cannot be empty", nameof(skillRecommendationByManagerId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var recommendation = await dbContext.Set<SkillRecommendationByManager>().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillRecommendationByManagerId);

            if (recommendation == null || !recommendation.IsDeleted)
                throw new BusinessException("SRM-005", "Skill recommendation not found or not deleted");

            recommendation.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
