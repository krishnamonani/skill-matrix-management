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
        public Guid SkillId { get; set; }

        [Required]
        public ProficiencyEnum ChangedProficiencyLevel { get; set; }

        [StringLength(500)] // Optional limit for comment
        public string Comment { get; set; }

        [Required]
        public int UserIdBasedVersion { get; set; }
    }
}
