using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiSkillRecommendationDTO
{
    public class SkillRecommendationResponseDto
    {
        //public List<Dictionary<string, string>>? skills { get; set; }
        public List<string> skills { get; set; }
        public List<string> reasons { get; set; }
    }
}
