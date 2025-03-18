using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class SkillSubtopic : FullAuditedEntity<Guid>
    {
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProficiencyEnum ReqExpertiseLevelId { get; set; }

    }

}
