using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.RolePermissionDTO
{
    public class RolePermissionPagedResultDto : PagedResultDto<RolePermissionDto>
    {
        public RolePermissionPagedResultDto(long totalCount, IReadOnlyList<RolePermissionDto> items)
            : base(totalCount, items)
        {
        }
    }
}
