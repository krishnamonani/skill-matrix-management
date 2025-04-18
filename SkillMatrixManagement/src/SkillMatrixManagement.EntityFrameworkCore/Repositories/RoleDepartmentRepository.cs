using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class RoleDepartmentRepository: EfCoreRepository<SkillMatrixManagementApplicationDbContext, RoleDepartment, Guid>, IRoleDepartmentRepository
    {
        readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public RoleDepartmentRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider):base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<RoleDepartment>> GetDepartMentByRoleIdAsync(Guid Roleid)
        {
            if (Roleid == Guid.Empty)
            {
                throw new Exception("Role Not Found");
            }
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var RoleDept=dbContext.RoleDepartments.Where(r => r.RoleId == Roleid).ToList();
            return RoleDept;
        }
    }
}
