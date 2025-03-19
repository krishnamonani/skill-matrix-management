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
    public class RolePermission : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("PermissionId")]
        public Guid PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }

}
