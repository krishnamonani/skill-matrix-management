using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillDTO
{
    public class SkillPagedResultDto : PagedResultDto<SkillDto>
    {
        public SkillPagedResultDto(long totalCount, IReadOnlyList<SkillDto> items)
            : base(totalCount, items)
        {
        }
    }
}
