using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillRecommendationByManagerDTO
{
    public class SkillRecommendationByManagerPagedResultDto : PagedResultDto<SkillRecommendationByManagerDto>
    {
        public SkillRecommendationByManagerPagedResultDto(long totalCount, IReadOnlyList<SkillRecommendationByManagerDto> items)
            : base(totalCount, items)
        {
        }
    }
}
