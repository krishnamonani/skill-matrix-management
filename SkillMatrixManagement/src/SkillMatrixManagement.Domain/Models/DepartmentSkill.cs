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
   public class DepartmentSkill:FullAuditedAggregateRoot<Guid>, ISoftDelete
    {

        [ForeignKey("departmentId")]

        public Guid departmentId { get; set; }
        public Department Department { get; set; }

        public string DepartmentName { get; set; }


        [ForeignKey("SkillId")]

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public string SkillName { get; set; }

    }
}
