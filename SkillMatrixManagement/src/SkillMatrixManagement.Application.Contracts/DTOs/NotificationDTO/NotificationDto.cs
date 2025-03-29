using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.NotificationDTO
{
    public class NotificationDto : FullAuditedEntityDto<Guid>
    {
        public string NotificationName { get; set; }
        public string Description { get; set; }

        public Guid DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; } // Optional inclusion of Department details

        public Guid CreatedBy { get; set; }
        public UserDto? Creator { get; set; } // Optional inclusion of Creator details

        public bool IsQueued { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
