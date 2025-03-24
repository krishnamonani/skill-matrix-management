using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.ReportAnalyticsDTO
{
    public class ReportAnalyticsLookupDto
    {
        public Guid Id { get; set; }
        public ReportTypeEnum ReportType { get; set; }
    }
}
