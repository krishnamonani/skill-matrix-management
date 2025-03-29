using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.RoleDTO
{
    public class UpdateRoleDto
    {
        [Required]
        public RoleEnum Name { get; set; }
    }
}
