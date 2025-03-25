using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.NotificationDTO
{
    public class CreateNotificationDto
    {
        [Required]
        [StringLength(256)]
        public string NotificationName { get; set; }

        [StringLength(500)] // Optional limit for description
        public string Description { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        public bool IsQueued { get; set; } = false;
        public bool IsDelivered { get; set; } = false;

        public DateTime? DeliveredAt { get; set; }
    }
}
