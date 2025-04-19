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
   public  class DepartmentSkillRepository:EfCoreRepository<SkillMatrixManagementApplicationDbContext, DepartmentSkill, Guid>, IDepartmentSkillRepository
    {
        readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public DepartmentSkillRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider):base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
        
        
        public async Task<List<DepartmentSkill>> GetSkillsByDepartmentIdAsync(Guid DepartmentID)
        {
            if (DepartmentID == Guid.Empty)
            {
                throw new Exception("Skills Not found");
            }
            var dbContext = await _dbContextProvider.GetDbContextAsync();
          return await dbContext.DepartmentSkills.Where(de => de.departmentId == DepartmentID).ToListAsync();
        }
    }
}
