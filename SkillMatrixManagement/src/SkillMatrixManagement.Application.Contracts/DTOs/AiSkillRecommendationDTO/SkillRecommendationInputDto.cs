using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiSkillRecommendationDTO
{
    public class SkillRecommendationInputDto
    {
        [Required]
        public string Role { get; set; }
        [Required]
        public int NumberOfRecommendations { get; set; } = 3;
        [Required]
        public string[] Skills { get; set; }
    }
}
