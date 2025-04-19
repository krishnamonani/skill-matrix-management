using SkillMatrixManagement.Constants;
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
    public class RoleDepartment:FullAuditedAggregateRoot<Guid>, ISoftDelete
    {

        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public RoleEnum RoleName { get; set; }

        [ForeignKey("DepartmentId")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string DepartmentName { get; set; }

        

        


    }
}
