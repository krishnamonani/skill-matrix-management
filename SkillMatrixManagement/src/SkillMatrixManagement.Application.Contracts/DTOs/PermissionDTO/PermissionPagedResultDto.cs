using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.PermissionDTO
{
    public class PermissionPagedResultDto : PagedResultDto<PermissionDto>
    {
        public PermissionPagedResultDto(long totalCount, IReadOnlyList<PermissionDto> items)
            : base(totalCount, items)
        {
        }
    }
}
