using Microsoft.EntityFrameworkCore;
using Nito.AsyncEx;
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
    public class SkillRepository:EfCoreRepository<SkillMatrixManagementApplicationDbContext, Skill,Guid >, ISkillRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public SkillRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider):base(dbContextProvider) 
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Skill> CreateAsync(Skill skill)
        {
            if (skill==null) throw new ArgumentNullException(nameof(skill));

            var dbContext =await _dbContextProvider.GetDbContextAsync();
            await dbContext.Skills.AddAsync(skill);
            await dbContext.SaveChangesAsync();
            return skill;
        }

        public async Task DeleteAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Skills.FindAsync(skillId);
            if (skill != null)
            {
                dbContext.Skills.Remove(skill);
                await dbContext.SaveChangesAsync();
            }

        }


        public async Task<List<Skill>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Skills.Include(s => s.Category)
                                         .Include(s => s.InternalRole)
                                         .Include(s => s.EmployeeSkills)
                                         .ToListAsync();
        
        }


        public async Task<Skill?> GetByIdAsync(Guid id)
        {
            var dbContext = await  _dbContextProvider.GetDbContextAsync();
            var res=await dbContext.Skills.Include(s => s.Category)
                                         .Include(s => s.InternalRole)
                                         .Include(s => s.EmployeeSkills)
                                         .FirstOrDefaultAsync(s => s.Id == id);
            return res;
        }

        public async Task PermanentDeleteAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Skills.FindAsync(skillId);
            
            if (skill != null)
            {
                dbContext.Skills.Remove(skill);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RestoreSkillAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Skills.IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == skillId);
            if (skill != null && skill.IsDeleted)
            {
                skill.IsDeleted = false;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($" the skill with  skill id  {skillId} is already activated");
            }

        }

        public async Task SoftDeleteAsync(Guid skillId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var skill = await dbContext.Skills.FindAsync(skillId);
            if (skill != null)
            {
                skill.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Skill skill)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            dbContext.Skills.Update(skill);
            await dbContext.SaveChangesAsync();

        }
    }
}
