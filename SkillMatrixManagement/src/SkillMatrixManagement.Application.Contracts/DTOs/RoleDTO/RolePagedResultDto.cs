using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.RoleDTO
{
    public class RolePagedResultDto : PagedResultDto<RoleDto>
    {
        public RolePagedResultDto(long totalCount, IReadOnlyList<RoleDto> items)
            : base(totalCount, items)
        {
        }
    }
}
