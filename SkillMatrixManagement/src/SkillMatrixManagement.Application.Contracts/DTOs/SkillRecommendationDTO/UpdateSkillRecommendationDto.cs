using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillRecommendationDTO
{
    public class UpdateSkillRecommendationDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RecommendedSkillId { get; set; }

        [Required]
        [Range(0, 1)]
        public float ConfidenceScore { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }

        [StringLength(100)]
        public string? AlgorithmUsed { get; set; }
    }
}
