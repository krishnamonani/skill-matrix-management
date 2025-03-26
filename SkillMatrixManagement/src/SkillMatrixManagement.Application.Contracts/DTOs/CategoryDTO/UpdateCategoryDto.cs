using SkillMatrixManagement.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.CategoryDTO
{
    // Update Request DTO
    public class UpdateCategoryDto
    {
        [Required]
        public CategoryEnum CategoryName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool IsUpdated { get; set; } = true;
    }
}
