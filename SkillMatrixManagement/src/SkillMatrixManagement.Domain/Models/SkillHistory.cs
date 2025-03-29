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
    public class SkillHistory : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("SkillId")]
        public Guid SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public ProficiencyEnum ChangedProficiencyLevel { get; set; }

        public string Comment { get; set; }

        public int UserIdBasedVersion { get; set; }

    }

}
