using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentRoleDTO
{
    public class DepartmentRolePagedResultDto : PagedResultDto<DepartmentRoleDto>
    {
        public DepartmentRolePagedResultDto(long totalCount, IReadOnlyList<DepartmentRoleDto> items)
            : base(totalCount, items)
        {
        }
    }
}
