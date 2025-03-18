using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class RolePermission : FullAuditedEntity<Guid>
    {
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }

}
