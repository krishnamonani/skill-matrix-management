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
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Repositories;

namespace SkillMatrixManagement.Repositories.Implementations
{
    public class SkillRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Skill, Guid>, ISkillRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Skill> CreateAsync(Skill skill)
        {
            Check.NotNull(skill, nameof(skill));
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var exists = await dbContext.Set<Skill>().AnyAsync(s => s.Name == skill.Name && !s.IsDeleted);
            if (exists)
                throw new BusinessException("Skill-001", "A skill with this name already exists");

            var result = await dbContext.Set<Skill>().AddAsync(skill);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Skill> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Skill ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Set<Skill>().FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted)
                ?? throw new BusinessException("Skill-002", "Skill not found");

            return skill;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Skill>().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(Skill skill)
        {
            Check.NotNull(skill, nameof(skill));
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<Skill>().FirstOrDefaultAsync(s => s.Id == skill.Id && !s.IsDeleted)
                ?? throw new BusinessException("Skill-003", "Skill not found for update");

            dbContext.Set<Skill>().Update(skill);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid skillId)
        {
            await SoftDeleteAsync(skillId);
        }

        public async Task SoftDeleteAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Set<Skill>().FirstOrDefaultAsync(s => s.Id == skillId && !s.IsDeleted)
                ?? throw new BusinessException("Skill-004", "Skill not found for soft deletion");

            skill.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Set<Skill>().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillId);

            if (skill == null)
                throw new BusinessException("Skill-005", "Skill not found for permanent deletion");

            dbContext.Set<Skill>().Remove(skill);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreSkillAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Set<Skill>().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillId)
                ?? throw new BusinessException("Skill-006", "Skill not found for restoration");

            if (!skill.IsDeleted)
                throw new BusinessException("Skill-007", "Skill is not deleted, cannot be restored");

            skill.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
