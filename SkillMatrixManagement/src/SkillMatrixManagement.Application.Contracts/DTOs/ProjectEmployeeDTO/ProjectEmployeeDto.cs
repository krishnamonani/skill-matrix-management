using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.ProjectDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ProjectEmployeeDTO
{
    public class ProjectEmployeeDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public UserDto? User { get; set; } // Optional inclusion of User details

        public Guid ProjectId { get; set; }
        public ProjectDto? Project { get; set; } // Optional inclusion of Project details

        //public Guid CreatedBy { get; set; }
        public UserDto? Creator { get; set; } // Optional inclusion of Creator details

        public bool IsDeleted { get; set; }
    }
}
