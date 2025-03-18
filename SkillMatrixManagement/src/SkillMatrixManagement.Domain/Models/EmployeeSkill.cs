using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class EmployeeSkill : FullAuditedEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public ProficiencyEnum SelfAssessedProficiencyId { get; set; }

        public ProficiencyEnum? ManagerAssignedProficiencyId { get; set; }

        public Guid? EndorsedBy { get; set; }
        public virtual User Endorser { get; set; }

        public DateTime? EndorsedAt { get; set; }

        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public Dictionary<string, ProficiencyEnum> SkillDescription { get; set; }

    }

}
