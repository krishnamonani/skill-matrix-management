using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class User : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("DepartmentId")]
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("RoleId")]
        public Guid? InternalRoleId { get; set; }
        public virtual DepartmentInternalRole InternalRole { get; set; }

        public bool IsAvailable { get; set; }
        public string? ProfilePhoto { get; set; }


        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    }

}
