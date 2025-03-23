using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.DepartmentDTO
{
    public class CreateDepartmentDto
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(500)] // Optional limit for description
        public string Description { get; set; }
    }
}
