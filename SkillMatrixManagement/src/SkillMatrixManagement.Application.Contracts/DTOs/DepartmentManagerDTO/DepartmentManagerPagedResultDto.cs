using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentManagerDTO
{
    public class DepartmentManagerPagedResultDto : PagedResultDto<DepartmentManagerDto>
    {
        public DepartmentManagerPagedResultDto(long totalCount, IReadOnlyList<DepartmentManagerDto> items)
            : base(totalCount, items)
        {
        }
    }
}
