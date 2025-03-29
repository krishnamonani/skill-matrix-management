using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.CategoryDTO;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
using SkillMatrixManagement.DTOs.EmployeeSkillDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillDTO
{
    public class SkillDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryDto? Category { get; set; } // Optional inclusion of Category details

        public string Description { get; set; }

        public Guid InternalRoleId { get; set; }
        public DepartmentInternalRoleDto? InternalRole { get; set; } // Optional inclusion of InternalRole details

        public List<EmployeeSkillDto>? EmployeeSkills { get; set; } // Optional inclusion of EmployeeSkills

        public bool IsDeleted { get; set; }
    }
}
