using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class SkillRecommendation : FullAuditedEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid RecommendedSkillId { get; set; }
        public virtual Skill RecommendedSkill { get; set; }

        public float ConfidenceScore { get; set; }

        public DateTime GeneratedAt { get; set; }

        public string? AlgorithmUsed { get; set; }
    }
}
