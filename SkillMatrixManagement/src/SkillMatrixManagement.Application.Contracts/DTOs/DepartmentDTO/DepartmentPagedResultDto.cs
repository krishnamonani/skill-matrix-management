using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentDTO
{
    public class DepartmentPagedResultDto : PagedResultDto<DepartmentDto>
    {
        public DepartmentPagedResultDto(long totalCount, IReadOnlyList<DepartmentDto> items)
            : base(totalCount, items)
        {
        }
    }
}
