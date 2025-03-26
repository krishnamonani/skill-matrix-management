using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.SkillSubtopicDTO
{
    public class CreateSkillSubtopicDto
    {
        [Required]
        public Guid SkillId { get; set; }

        [Required]
        [StringLength(256)] // Assuming a reasonable limit for Name
        public string Name { get; set; }

        public Dictionary<string, string>? Description { get; set; }

        public ProficiencyEnum? ReqExpertiseLevelId { get; set; }
    }
}
