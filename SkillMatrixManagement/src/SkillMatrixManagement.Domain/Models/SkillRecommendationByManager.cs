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
    public class SkillRecommendationByManager: FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("SkillId")]
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        [ForeignKey("UserId")]
        public Guid SkillRecommenderId { get; set; }
        public virtual User SkillRecommender { get; set; }

        public string Comment { get; set; }
    }
}
