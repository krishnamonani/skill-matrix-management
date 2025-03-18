using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class Department : AuditedAggregateRoot<Guid>
    {
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

    }

}
