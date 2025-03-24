using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentManagerDTO
{
    public class DepartmentManagerDto : FullAuditedEntityDto<Guid>
    {
        public Guid DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; } // Optional inclusion of Department details

        public Guid ManagerId { get; set; }
        public UserDto? Manager { get; set; } // Optional inclusion of User details

        public bool IsDeleted { get; set; }
    }
}
