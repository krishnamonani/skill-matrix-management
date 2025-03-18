using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class User : AuditedAggregateRoot<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid? TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public Guid? InternalRoleId { get; set; }
        public virtual DepartmentInternalRole InternalRole { get; set; }

        public bool IsAvailable { get; set; }
        public string? ProfilePhoto { get; set; }

    }

}
