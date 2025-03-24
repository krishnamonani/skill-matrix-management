using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.PermissionDTO;
using SkillMatrixManagement.DTOs.RoleDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.RolePermissionDTO
{
    public class RolePermissionDto : FullAuditedEntityDto<Guid>
    {
        public Guid RoleId { get; set; }
        public RoleDto? Role { get; set; } // Optional inclusion of Role details

        public Guid PermissionId { get; set; }
        public PermissionDto? Permission { get; set; } // Optional inclusion of Permission details
    }
}
