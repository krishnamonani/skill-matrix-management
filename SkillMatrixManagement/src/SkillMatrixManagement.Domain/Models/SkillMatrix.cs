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
    public class SkillMatrix : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("DepartmentId")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("SkillId")]
        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public ProficiencyEnum ExpectedProficiencyId { get; set; }
    }

}
