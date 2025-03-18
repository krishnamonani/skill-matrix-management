using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class DepartmentRole : FullAuditedEntity<Guid>
    {
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid InternalRoleId { get; set; }
        public virtual DepartmentInternalRole InternalRole { get; set; }

    }

}
