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
    public class Notification : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string NotificationName { get; set; }

        public string Description { get; set; }

        [ForeignKey("DepartmentId")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("UserId")]
        public Guid CreatedBy { get; set; }
        public virtual User Creator { get; set; }

        public bool IsQueued { get; set; } = false;
        public bool IsDelivered { get; set; } = false;

        public DateTime? DeliveredAt { get; set; }
    }

}
