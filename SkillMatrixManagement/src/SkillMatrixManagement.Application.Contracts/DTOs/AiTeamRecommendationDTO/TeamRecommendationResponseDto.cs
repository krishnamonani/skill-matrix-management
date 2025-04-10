using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiTeamRecommendationDTO
{
    public class TeamRecommendationResponseDto
    {
        public ICollection<EmployeeDetailDto> Employees { get; set; }
        public string Description { get; set; }
    }
}
