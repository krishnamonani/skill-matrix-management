using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ReportAnalyticsDTO
{
    public class ReportAnalyticsPagedResultDto : PagedResultDto<ReportAnalyticsDto>
    {
        public ReportAnalyticsPagedResultDto(long totalCount, IReadOnlyList<ReportAnalyticsDto> items)
            : base(totalCount, items)
        {
        }
    }
}
