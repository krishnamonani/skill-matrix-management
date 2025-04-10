using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
using SkillMatrixManagement.DTOs.EmployeeSkillDTO;
using SkillMatrixManagement.DTOs.RoleDTO;
using SkillMatrixManagement.DTOs.SkillDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class UserDto : FullAuditedEntityDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }

        public Guid RoleId { get; set; }
        public RoleDto? Role { get; set; } // Optional inclusion of Role details

        public Guid? DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; } // Optional inclusion of Department details

        //public Guid? InternalRoleId { get; set; }
        //public DepartmentInternalRoleDto? InternalRole { get; set; } // Optional inclusion of InternalRole details

        public Guid? SkillId { get; set; }
        public SkillDto? skill { get; set; }

        public ProjectStatusEnum IsAvailable { get; set; }
        public string? ProfilePhoto { get; set; }

        public ICollection<EmployeeSkillDto>? EmployeeSkills { get; set; } // Optional inclusion of EmployeeSkills
    }
}
