using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.AiTeamRecommendationDTO
{
    public class EmployeeDetailDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public string? Department { get; set; }
        public string? Designation { get; set; }
        public List<Dictionary<string, string>> Skills { get; set; }
        public string ProjectStatus { get; set; } // A = 2, S = 1, B = 0
    }
}
