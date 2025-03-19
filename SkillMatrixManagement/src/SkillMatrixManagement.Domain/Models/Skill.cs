using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class Skill : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [StringLength(256)]
        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Description { get; set; }

        [ForeignKey("RoleId")]
        public Guid InternalRoleId { get; set; }
        public virtual DepartmentInternalRole InternalRole { get; set; }


        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    }

}
