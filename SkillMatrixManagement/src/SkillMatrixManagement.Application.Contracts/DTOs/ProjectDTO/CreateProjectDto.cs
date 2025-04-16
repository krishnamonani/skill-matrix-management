using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.ProjectDTO
{
    public class CreateProjectDto
    {
        [Required]
        [StringLength(256)]
        public string ProjectName { get; set; }

        [StringLength(500)] // Optional limit for description
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpectedEndDate { get; set; }
        public string Status { get; set; }

        public bool IsDelayed { get; set; } = false;
        public bool IsOngoing { get; set; } = true;
    }
}
