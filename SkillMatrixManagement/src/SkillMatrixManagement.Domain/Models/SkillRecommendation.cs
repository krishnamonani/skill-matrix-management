using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class SkillRecommendation : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("SkillId")]
        public Guid RecommendedSkillId { get; set; }
        public virtual Skill RecommendedSkill { get; set; }

        public float ConfidenceScore { get; set; }

        public DateTime GeneratedAt { get; set; }

        public string? AlgorithmUsed { get; set; }
    }
}
