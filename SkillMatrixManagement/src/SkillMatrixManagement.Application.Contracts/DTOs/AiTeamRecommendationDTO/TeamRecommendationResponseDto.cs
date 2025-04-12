using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiTeamRecommendationDTO
{
    public class TeamRecommendationResponseDto
    {
        public string project { get; set; }
        public ICollection<EmployeeDetailDto> team { get; set; }
        public string justification { get; set; }
    }
}
