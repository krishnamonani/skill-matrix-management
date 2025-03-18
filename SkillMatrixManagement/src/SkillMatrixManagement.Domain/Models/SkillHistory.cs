using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class SkillHistory : FullAuditedEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public Guid ChangedProficiencyLevelId { get; set; }
        public virtual ProficiencyLevel ProficiencyLevel { get; set; }

        public string Comment { get; set; }

        public int UserIdBasedVersion { get; set; }

    }

}
