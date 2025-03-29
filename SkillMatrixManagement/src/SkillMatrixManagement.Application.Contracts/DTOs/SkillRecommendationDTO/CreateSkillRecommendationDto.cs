using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillRecommendationDTO
{
    public class CreateSkillRecommendationDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RecommendedSkillId { get; set; }

        [Required]
        [Range(0, 1)] // Assuming ConfidenceScore is a probability between 0 and 1
        public float ConfidenceScore { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }

        [StringLength(100)] // Optional limit for AlgorithmUsed
        public string? AlgorithmUsed { get; set; }
    }
}
