using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO
{
    public class CreateDepartmentInternalRoleDto
    {
        [Required]
        [StringLength(100)]
        public DepartmentRoleEnum RoleName { get; set; }

        [StringLength(500)] // Optional limit for description
        public string? RoleDescription { get; set; }

        [Required]
        public RolePositionEnum Position { get; set; }
    }
}
