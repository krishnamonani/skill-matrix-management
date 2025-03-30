using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO
{
    public class DepartmentInternalRoleDto : FullAuditedEntityDto<Guid>
    {
        public DepartmentRoleEnum RoleName { get; set; }
        public string DepartmentRole { get; set; }
        public string? RoleDescription { get; set; }
        public RolePositionEnum Position { get; set; }
        public string RolePosition { get; set; }
        public bool IsDeleted { get; set; }
    }
}
