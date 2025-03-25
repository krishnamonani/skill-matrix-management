using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.NotificationDTO
{
    public class NotificationFilterDto : PagedAndSortedResultRequestDto
    {
        public string? NotificationName { get; set; }
        public string? Description { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsQueued { get; set; }
        public bool? IsDelivered { get; set; }
        public DateTime? DeliveredAtStart { get; set; }
        public DateTime? DeliveredAtEnd { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
