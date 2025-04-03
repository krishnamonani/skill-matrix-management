using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class UserFilterDto : PagedAndSortedResultRequestDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Experience { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? InternalRoleId { get; set; }
        public ProjectStatusEnum? IsAvailable { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
