using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillGapDTO
{
    public class SkillSuggestionsBasedOnDepartmentCurrentSkillResponseDto
    {
        public List<string> DepartmentSkills { get; set; }
        public List<List<string>> DepartmentCoreSkills { get; set; }
        public List<string> EmployeeCoreSkills { get; set; }
    }

    public class SkillSuggestionsBasedOnDepartmentCurrentSkillResponseWithEmployeeNmaesDto : SkillSuggestionsBasedOnDepartmentCurrentSkillResponseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Designation { get; set; }
    }
}
