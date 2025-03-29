using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentRoleDTO
{
    public class DepartmentRoleDto : FullAuditedEntityDto<Guid>
    {
        public Guid DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; } // Optional inclusion of Department details

        public Guid InternalRoleId { get; set; }
        public DepartmentInternalRoleDto? InternalRole { get; set; } // Optional inclusion of InternalRole details

        public bool IsDeleted { get; set; }
    }
}
