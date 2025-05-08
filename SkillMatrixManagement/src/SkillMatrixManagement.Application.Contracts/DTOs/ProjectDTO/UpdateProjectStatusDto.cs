using System;
using System.ComponentModel.DataAnnotations;

namespace SkillMatrixManagement.DTOs.ProjectDTO
{
    public class UpdateProjectStatusDto
    {
        [Required]
        public string Status { get; set; }
    }
}
