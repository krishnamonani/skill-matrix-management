using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
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

        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [Range(0, 100)]
        public int Experience { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("DepartmentId")]
        public Guid? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        //[ForeignKey("RoleId")]
        //public Guid? InternalRoleId { get; set; }
        //public virtual DepartmentInternalRole InternalRole { get; set; }

        [ForeignKey("SkillId")]
        public Guid? SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public ProjectStatusEnum IsAvailable { get; set; }
        public string? ProfilePhoto { get; set; }

        [Range(0, 100)]
        public int AssignibilityPerncentage { get; set; } = 0;
        [Range(0, 100)]
        public int BillablePerncentage { get; set; } = 0;
        [Range(0, 100)]
        public int AvailabilityPerncentage { get; set; } = 100;


        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public int BillablePercentage { get; internal set; }
    }

}
