using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.SkillHistoryDTO
{
    public class CreateSkillHistoryDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string CoreSkillName { get; set; }

        [Required]
        public ProficiencyEnum ChangedProficiencyLevel { get; set; }

    }
}
