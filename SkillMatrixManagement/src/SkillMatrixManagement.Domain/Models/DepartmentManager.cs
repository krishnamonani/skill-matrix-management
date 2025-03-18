using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class DepartmentManager : FullAuditedEntity<Guid>
    {
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid ManagerId { get; set; }
        public virtual User Manager { get; set; }

        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }

}
