using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.ProficiencyLevelDTO
{
    public class ProficiencyLevelLookupDto
    {
        public Guid Id { get; set; }
        public ProficiencyEnum Level { get; set; }
    }
}
