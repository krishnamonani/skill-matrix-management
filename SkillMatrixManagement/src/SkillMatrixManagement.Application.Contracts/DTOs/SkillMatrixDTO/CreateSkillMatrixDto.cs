using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.SkillMatrixDTO
{
    public class CreateSkillMatrixDto
    {
        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid SkillId { get; set; }

        [Required]
        public ProficiencyEnum ExpectedProficiencyId { get; set; }
    }
}
