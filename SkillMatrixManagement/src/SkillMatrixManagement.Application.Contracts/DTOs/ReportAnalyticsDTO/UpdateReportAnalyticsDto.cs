using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.ReportAnalyticsDTO
{
    public class UpdateReportAnalyticsDto
    {
        [Required]
        public ReportTypeEnum ReportType { get; set; }

        [Required]
        public Guid GeneratedBy { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }

        [Required]
        public Dictionary<string, string> DataSnapshot { get; set; }
    }
}
