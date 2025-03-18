using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class SkillMatrix : AuditedAggregateRoot<Guid>
    {

        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }  

        public Guid SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public ProficiencyEnum ExpectedProficiencyId { get; set; }
    }

}
