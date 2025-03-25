using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class SkilISubtopicRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext,SkillSubtopic , Guid>, ISkillSubtopicRepository
    {
        readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkilISubtopicRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider):base(dbContextProvider) {
        
            _dbContextProvider = dbContextProvider;
        }

        public async Task<SkillSubtopic> CreateAsync(SkillSubtopic skillSubtopic)
        {
            if ( skillSubtopic==null)
            {
                throw new Exception("Invalid Skill content!");
            }
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.SkillSubtopics.AddAsync(skillSubtopic);
            await dbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task DeleteAsync(Guid skillSubtopicId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.SkillSubtopics.FindAsync(skillSubtopicId);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<SkillSubtopic>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.SkillSubtopics.ToListAsync();
        }

        public async Task<SkillSubtopic> GetByIdAsync(Guid id)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            return await dbContext.SkillSubtopics.FindAsync(id) ?? throw new Exception("ID is not found");
        }

        public async Task PermanentDeleteAsync(Guid skillSubtopicId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.SkillSubtopics.FindAsync(skillSubtopicId);
            if (entity != null)
            {
                dbContext.SkillSubtopics.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RestoreSkillSubtopicAsync(Guid skillSubtopicId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.SkillSubtopics.IgnoreQueryFilters().FirstOrDefaultAsync(e => e.Id == skillSubtopicId);
            if (entity != null && entity.IsDeleted)
            {
                entity.IsDeleted = false;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task SoftDeleteAsync(Guid skillSubtopicId)
        {
            await DeleteAsync(skillSubtopicId);
        }

        public async Task UpdateAsync(SkillSubtopic skillSubtopic)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            //dbContext.SkillSubtopics.Update(skillSubtopic);
            var entity=await dbContext.SkillSubtopics.FindAsync(skillSubtopic.Id);
            if (entity == null)
            {
                throw new Exception($"Skill is  not found.");
            };
            dbContext.Entry(entity).CurrentValues.SetValues(skillSubtopic);
            await dbContext.SaveChangesAsync();
        }
    }
}
