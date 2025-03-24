using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.PermissionDTO
{
    public class UpdatePermissionDto
    {
        [Required]
        public PermissionEnum Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
