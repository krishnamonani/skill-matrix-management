using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class DepartmentManager : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("DepartmentId")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("UserId")]
        public Guid ManagerId { get; set; }
        public virtual User Manager { get; set; }
    }

}
