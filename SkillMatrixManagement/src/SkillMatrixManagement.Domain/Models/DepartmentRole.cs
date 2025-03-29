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
    public class DepartmentRole : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("DepartmentId")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("UserId")]
        public Guid InternalRoleId { get; set; }
        public virtual DepartmentInternalRole InternalRole { get; set; }

    }

}
