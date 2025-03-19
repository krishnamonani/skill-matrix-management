using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class ReportAnalytics : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        public ReportTypeEnum ReportType { get; set; }

        [ForeignKey("UserId")]
        public Guid GeneratedBy { get; set; }
        public virtual User GeneratedByUser { get; set; }

        public DateTime GeneratedAt { get; set; }

        public Dictionary<string, string> DataSnapshot { get; set; }
    }

}
