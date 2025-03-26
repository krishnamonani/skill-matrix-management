using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ProficiencyLevelDTO
{
    public class ProficiencyLevelPagedResultDto : PagedResultDto<ProficiencyLevelDto>
    {
        public ProficiencyLevelPagedResultDto(long totalCount, IReadOnlyList<ProficiencyLevelDto> items)
            : base(totalCount, items)
        {
        }
    }
}
