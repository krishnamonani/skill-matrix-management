using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillRecommendationDTO
{
    public class SkillRecommendationPagedResultDto : PagedResultDto<SkillRecommendationDto>
    {
        public SkillRecommendationPagedResultDto(long totalCount, IReadOnlyList<SkillRecommendationDto> items)
            : base(totalCount, items)
        {
        }
    }
}
