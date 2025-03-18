using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class Skill : AuditedAggregateRoot<Guid>
    {
        [StringLength(256)]
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Description { get; set; }

        public Guid InternalRoleId { get; set; }
        public virtual DepartmentInternalRole InternalRole { get; set; }

    }

}
