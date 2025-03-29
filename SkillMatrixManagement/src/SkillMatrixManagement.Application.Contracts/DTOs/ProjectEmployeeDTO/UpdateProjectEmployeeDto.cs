using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.ProjectEmployeeDTO
{
    public class UpdateProjectEmployeeDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }
    }
}
