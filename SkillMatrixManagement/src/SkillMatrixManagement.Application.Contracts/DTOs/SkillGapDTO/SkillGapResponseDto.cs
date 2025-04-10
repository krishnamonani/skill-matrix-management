using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillGapDTO
{
    public class SkillGapResponseDto
    {
        public List<string> Skills { get; set; }
        public List<string> EmployeeProficiency { get; set; }
        public List<string> DepartmentRequiredProficiency { get; set; }
    }
}
