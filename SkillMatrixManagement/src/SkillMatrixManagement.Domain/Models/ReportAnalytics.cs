using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class ReportAnalytics : FullAuditedEntity<Guid>
    {
        public string ReportType { get; set; }
        public Guid GeneratedBy { get; set; }
        public virtual User GeneratedByUser { get; set; }

        public DateTime GeneratedAt { get; set; }

        public Dictionary<string, string> DataSnapshot { get; set; }
    }

}
