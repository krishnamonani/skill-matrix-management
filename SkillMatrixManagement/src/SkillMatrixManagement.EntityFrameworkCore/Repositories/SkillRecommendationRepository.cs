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
    public class SkillRecommendationRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, SkillRecommendation, Guid>, ISkillRecommendationRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillRecommendationRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<SkillRecommendation> CreateAsync(SkillRecommendation skillRecommendation)
        {
            Check.NotNull(skillRecommendation, nameof(skillRecommendation));
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var exists = await dbContext.Set<SkillRecommendation>().AnyAsync(s => s.RecommendedSkill == skillRecommendation.RecommendedSkill && !s.IsDeleted);

            if (exists)
                throw new BusinessException("SR-001", "A skill recommendation with the same name already exists");

            var result = await dbContext.Set<SkillRecommendation>().AddAsync(skillRecommendation);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SkillRecommendation> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Skill Recommendation ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillRecommendation = await dbContext.Set<SkillRecommendation>().FindAsync(id)
                ?? throw new BusinessException("SR-002", "Skill recommendation not found");

            return skillRecommendation;
        }

        public async Task<List<SkillRecommendation>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<SkillRecommendation>().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(SkillRecommendation skillRecommendation)
        {
            Check.NotNull(skillRecommendation, nameof(skillRecommendation));
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<SkillRecommendation>().FirstOrDefaultAsync(s => s.Id == skillRecommendation.Id && !s.IsDeleted)
                ?? throw new BusinessException("SR-003", "Skill recommendation not found for update");

            dbContext.Set<SkillRecommendation>().Update(skillRecommendation);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid skillRecommendationId)
        {
            await SoftDeleteAsync(skillRecommendationId);
        }

        public async Task SoftDeleteAsync(Guid skillRecommendationId)
        {
            if (skillRecommendationId == Guid.Empty)
                throw new ArgumentException("Skill Recommendation ID cannot be empty", nameof(skillRecommendationId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillRecommendation = await dbContext.Set<SkillRecommendation>().FindAsync(skillRecommendationId)
                ?? throw new BusinessException("SR-004", "Skill recommendation not found");

            if (skillRecommendation.IsDeleted)
                throw new BusinessException("SR-005", "Skill recommendation is already deleted");

            skillRecommendation.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid skillRecommendationId)
        {
            if (skillRecommendationId == Guid.Empty)
                throw new ArgumentException("Skill Recommendation ID cannot be empty", nameof(skillRecommendationId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillRecommendation = await dbContext.Set<SkillRecommendation>().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillRecommendationId);

            if (skillRecommendation == null)
                throw new BusinessException("SR-006", "Skill recommendation not found for deletion");

            dbContext.Set<SkillRecommendation>().Remove(skillRecommendation);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreSkillRecommendationAsync(Guid skillRecommendationId)
        {
            if (skillRecommendationId == Guid.Empty)
                throw new ArgumentException("Skill Recommendation ID cannot be empty", nameof(skillRecommendationId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skillRecommendation = await dbContext.Set<SkillRecommendation>().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillRecommendationId);

            if (skillRecommendation == null || !skillRecommendation.IsDeleted)
                throw new BusinessException("SR-007", "Skill recommendation not found or not deleted");

            skillRecommendation.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
