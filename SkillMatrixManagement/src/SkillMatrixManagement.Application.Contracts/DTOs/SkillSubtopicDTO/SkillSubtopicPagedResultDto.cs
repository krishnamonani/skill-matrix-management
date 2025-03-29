using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillSubtopicDTO
{
    public class SkillSubtopicPagedResultDto : PagedResultDto<SkillSubtopicDto>
    {
        public SkillSubtopicPagedResultDto(long totalCount, IReadOnlyList<SkillSubtopicDto> items)
            : base(totalCount, items)
        {
        }
    }
}
