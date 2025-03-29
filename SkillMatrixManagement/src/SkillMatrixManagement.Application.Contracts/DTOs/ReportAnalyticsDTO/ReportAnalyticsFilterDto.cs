using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ReportAnalyticsDTO
{
    public class ReportAnalyticsFilterDto : PagedAndSortedResultRequestDto
    {
        public ReportTypeEnum? ReportType { get; set; }
        public Guid? GeneratedBy { get; set; }
        public DateTime? GeneratedAtStart { get; set; }
        public DateTime? GeneratedAtEnd { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
