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
    public class ProficiencyLevelRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, ProficiencyLevel, Guid>, IProficiencyLevelRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public ProficiencyLevelRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        // Create a new Proficiency Level
        public async Task<ProficiencyLevel> CreateAsync(ProficiencyLevel proficiencyLevel)
        {
            // Input validation
            Check.NotNull(proficiencyLevel, nameof(proficiencyLevel));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Check for duplicates
            var exists = await dbContext.Set<ProficiencyLevel>()
                .AnyAsync(p => p.Level == proficiencyLevel.Level && !p.IsDeleted);
            if (exists)
                throw new BusinessException("PROF-001", "A proficiency level with this name already exists");

            var result = await dbContext.Set<ProficiencyLevel>().AddAsync(proficiencyLevel);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Get Proficiency Level by ID
        public async Task<ProficiencyLevel> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Proficiency Level ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var proficiencyLevel = await dbContext.Set<ProficiencyLevel>()
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted)
                ?? throw new BusinessException("PROF-002", "Proficiency level not found");

            return proficiencyLevel;
        }

        // Get All Proficiency Levels
        public async Task<List<ProficiencyLevel>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<ProficiencyLevel>()
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        // Update Proficiency Level
        public async Task UpdateAsync(ProficiencyLevel proficiencyLevel)
        {
            Check.NotNull(proficiencyLevel, nameof(proficiencyLevel));

            if (proficiencyLevel.Id == Guid.Empty)
                throw new ArgumentException("Proficiency Level ID cannot be empty", nameof(proficiencyLevel));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var existingProficiencyLevel = await dbContext.Set<ProficiencyLevel>()
                .FirstOrDefaultAsync(p => p.Id == proficiencyLevel.Id && !p.IsDeleted)
                ?? throw new BusinessException("PROF-003", "Proficiency level not found for update");

            dbContext.Entry(existingProficiencyLevel).CurrentValues.SetValues(proficiencyLevel);
            await dbContext.SaveChangesAsync();
        }

        // Soft Delete Proficiency Level
        public async Task DeleteAsync(Guid proficiencyLevelId)
        {
            await SoftDeleteAsync(proficiencyLevelId);
        }

        public async Task SoftDeleteAsync(Guid proficiencyLevelId)
        {
            if (proficiencyLevelId == Guid.Empty)
                throw new ArgumentException("Proficiency Level ID cannot be empty", nameof(proficiencyLevelId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var proficiencyLevel = await dbContext.Set<ProficiencyLevel>()
                .FirstOrDefaultAsync(p => p.Id == proficiencyLevelId && !p.IsDeleted)
                ?? throw new BusinessException("PROF-004", "Proficiency level not found for soft deletion");

            if (proficiencyLevel.IsDeleted)
                throw new BusinessException("PROF-005", "Proficiency level is already deleted");

            proficiencyLevel.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        // Permanent Delete Proficiency Level
        public async Task PermanentDeleteAsync(Guid proficiencyLevelId)
        {
            if (proficiencyLevelId == Guid.Empty)
                throw new ArgumentException("Proficiency Level ID cannot be empty", nameof(proficiencyLevelId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var proficiencyLevel = await dbContext.Set<ProficiencyLevel>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == proficiencyLevelId);

            if (proficiencyLevel == null)
                throw new BusinessException("PROF-006", "Proficiency level not found for permanent deletion");

            dbContext.Set<ProficiencyLevel>().Remove(proficiencyLevel);
            await dbContext.SaveChangesAsync();
        }

        // Restore Soft Deleted Proficiency Level
        public async Task RestoreProficiencyLevelAsync(Guid proficiencyLevelId)
        {
            if (proficiencyLevelId == Guid.Empty)
                throw new ArgumentException("Proficiency Level ID cannot be empty", nameof(proficiencyLevelId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var proficiencyLevel = await dbContext.Set<ProficiencyLevel>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == proficiencyLevelId)
                ?? throw new BusinessException("PROF-007", "Proficiency level not found for restoration");

            if (!proficiencyLevel.IsDeleted)
                throw new BusinessException("PROF-008", "Proficiency level is not deleted, cannot be restored");

            proficiencyLevel.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        // Get Proficiency Levels by Level
        public async Task<List<ProficiencyLevel>> GetProficiencyLevelsByLevelAsync(ProficiencyEnum level)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            return await dbContext.Set<ProficiencyLevel>()
                .Where(p => p.Level == level && !p.IsDeleted)
                .ToListAsync();
        }

        // Override to include navigation properties
        public override async Task<IQueryable<ProficiencyLevel>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<ProficiencyLevel>();
        }
    }
}
