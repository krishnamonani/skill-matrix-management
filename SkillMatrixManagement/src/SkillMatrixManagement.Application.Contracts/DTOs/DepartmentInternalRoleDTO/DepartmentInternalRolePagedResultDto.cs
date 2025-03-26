using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO
{
    public class DepartmentInternalRolePagedResultDto : PagedResultDto<DepartmentInternalRoleDto>
    {
        public DepartmentInternalRolePagedResultDto(long totalCount, IReadOnlyList<DepartmentInternalRoleDto> items)
            : base(totalCount, items)
        {
        }
    }
}
