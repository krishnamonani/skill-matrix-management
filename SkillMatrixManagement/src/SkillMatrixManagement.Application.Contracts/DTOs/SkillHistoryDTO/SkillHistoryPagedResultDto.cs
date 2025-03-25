using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillHistoryDTO
{
    public class SkillHistoryPagedResultDto : PagedResultDto<SkillHistoryDto>
    {
        public SkillHistoryPagedResultDto(long totalCount, IReadOnlyList<SkillHistoryDto> items)
            : base(totalCount, items)
        {
        }
    }
}
