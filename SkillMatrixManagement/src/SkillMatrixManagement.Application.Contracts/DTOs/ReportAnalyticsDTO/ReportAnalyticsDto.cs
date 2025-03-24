using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ReportAnalyticsDTO
{
    public class ReportAnalyticsDto : FullAuditedEntityDto<Guid>
    {
        public ReportTypeEnum ReportType { get; set; }

        public Guid GeneratedBy { get; set; }
        public UserDto? GeneratedByUser { get; set; } // Optional inclusion of User details

        public DateTime GeneratedAt { get; set; }

        public Dictionary<string, string> DataSnapshot { get; set; }

        public bool IsDeleted { get; set; }
    }
}
