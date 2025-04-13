using SkillMatrixManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillHistoryDTO
{
    public class SkillHistoryLookupDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CoreSkillName { get; set; }
        public ProficiencyEnum ChangedProficiencyLevel { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
