using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillRecommendationByManagerDTO
{
    public class UpdateSkillRecommendationByManagerDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid SkillId { get; set; }

        [Required]
        public Guid SkillRecommenderId { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }
    }
}
