using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.NotificationDTO
{
    public class UpdateNotificationDto
    {
        [Required]
        [StringLength(256)]
        public string NotificationName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public bool IsQueued { get; set; }
        public bool IsDelivered { get; set; }

        public DateTime? DeliveredAt { get; set; }
    }
}
