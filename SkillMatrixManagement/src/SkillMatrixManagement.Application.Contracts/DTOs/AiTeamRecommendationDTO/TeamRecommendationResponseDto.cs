using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiTeamRecommendationDTO
{
    public class EmployeeResponse
    {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public string Role { get; set; }
      public string ProjectStatus { get; set; }
      public string Justification { get; set; }
    }
    public class TeamRecommendationResponseDto
    {
        public ICollection<EmployeeResponse> Team { get; set; }
    }
}
