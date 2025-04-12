using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiSkillRecommendationDTO
{
    public class SkillRecommendationRequestDto
    {
        [Required]
        public string? Role { get; set; }
        [Required]
        public int? NumberOfRecommendations { get; set; } = 5;
        [Required]
        public List<string>? Skills { get; set; }
        [Required]
        public string Experience { get; set; } = "0";
    }
}
