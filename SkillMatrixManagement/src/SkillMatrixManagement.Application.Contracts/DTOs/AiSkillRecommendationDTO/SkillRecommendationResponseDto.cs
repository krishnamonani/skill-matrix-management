using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiSkillRecommendationDTO
{
    public class SkillRecommendationResponseDto
    {
        public List<string> RecommendedSkills { get; set; }
        public List<string> Reasons { get; set; }
    }
}
