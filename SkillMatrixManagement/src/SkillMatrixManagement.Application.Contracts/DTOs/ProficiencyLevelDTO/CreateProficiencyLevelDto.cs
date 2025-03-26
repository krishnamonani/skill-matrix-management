using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.ProficiencyLevelDTO
{
    public class CreateProficiencyLevelDto
    {
        [Required]
        public ProficiencyEnum Level { get; set; }

        [StringLength(500)] // Optional limit for description
        public string Description { get; set; }
    }
}
