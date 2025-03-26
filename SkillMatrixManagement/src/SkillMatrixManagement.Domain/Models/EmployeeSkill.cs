using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class EmployeeSkill : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public string CoreSkillName { get; set; }

        public ProficiencyEnum SelfAssessedProficiency { get; set; }
        public ProficiencyEnum? ManagerAssignedProficiency { get; set; }

        [ForeignKey("UserId")]
        public Guid? EndorsedBy { get; set; }
        public virtual User Endorser { get; set; }

        public DateTime? EndorsedAt { get; set; }


        public Dictionary<string, ProficiencyEnum> SkillDescription { get; set; }

    }

}
