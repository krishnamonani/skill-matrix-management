using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IRoleDepartmentRepository:IBasicRepository<RoleDepartment, Guid>
    {
        Task<List<RoleDepartment>> GetDepartMentByRoleIdAsync(Guid Roleid);

    }
}
