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
    public class SkillSubtopic : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("SkillId")]
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public string Name { get; set; }

        public Dictionary<string, string>? Description { get; set; }

        public ProficiencyEnum? ReqExpertiseLevelId { get; set; }

    }

}
