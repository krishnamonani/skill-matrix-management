using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.EmployeeSkillDTO
{
    public class EmployeeSkillPagedResultDto : PagedResultDto<EmployeeSkillDto>
    {
        public EmployeeSkillPagedResultDto(long totalCount, IReadOnlyList<EmployeeSkillDto> items)
            : base(totalCount, items)
        {

        }
    }
}
