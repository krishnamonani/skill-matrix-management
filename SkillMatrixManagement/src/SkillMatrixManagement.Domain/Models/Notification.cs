using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class Notification : FullAuditedEntity<Guid>
    {
        public string NotificationName { get; set; }

        public string Description { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid CreatedBy { get; set; }
        public virtual User Creator { get; set; }

        public bool IsQueued { get; set; } = false;
        public bool IsDelivered { get; set; } = false;

        public DateTime? DeliveredAt { get; set; }
    }

}
