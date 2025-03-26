using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static SkillMatrixManagement.SkillMatrixManagementDomainErrorCodes;

namespace SkillMatrixManagement.Repositories
{
    public class SkillSubtopicRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext,SkillSubtopic , Guid>, ISkillSubtopicRepository
    {
        readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillSubtopicRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider):base(dbContextProvider) {
        
            _dbContextProvider = dbContextProvider;
        }

        public async Task<SkillSubtopic> CreateAsync(SkillSubtopic skillSubtopic)
        {
            if ( skillSubtopic==null)
            {
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillSubtopicErrorCodes.SkillSubtopicInvalid);
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

            if (entity == null)
            {
                throw new BusinessException(SkillSubtopicErrorCodes.SkillSubtopicNotFoundForDelete);
                //throw new Exception("id not found!");
            }

            if (entity != null)
            {
                entity.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<SkillSubtopic>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.SkillSubtopics.IgnoreQueryFilters().ToListAsync();
        }

        public async Task<SkillSubtopic> GetByIdAsync(Guid id)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            return await dbContext.SkillSubtopics.FindAsync(id) ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.SkillSubtopicErrorCodes.SkillSubtopicNotFound);
        }

        public async Task PermanentDeleteAsync(Guid skillSubtopicId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var entity = await dbContext.SkillSubtopics.FindAsync(skillSubtopicId);
            if (entity == null)
            {
                throw new BusinessException(SkillSubtopicErrorCodes.SkillSubtopicNotFoundForPermanentDelete);
            }
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
            if (entity == null)
            {
                throw new BusinessException(SkillSubtopicErrorCodes.SkillSubtopicNotFound);
            }
            if (!entity.IsDeleted)
            {
                throw new BusinessException(SkillSubtopicErrorCodes.SkillSubtopicAlreadyDeleted);
            }

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
                throw new BusinessException(SkillSubtopicErrorCodes.SkillSubtopicNotFoundForUpdate);
            };
            dbContext.Entry(entity).CurrentValues.SetValues(skillSubtopic);
            await dbContext.SaveChangesAsync();
        }
    }
}
