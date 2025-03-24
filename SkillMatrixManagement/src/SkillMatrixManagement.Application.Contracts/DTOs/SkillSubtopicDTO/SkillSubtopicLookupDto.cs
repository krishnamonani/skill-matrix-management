using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillSubtopicDTO
{
    public class SkillSubtopicLookupDto
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public string Name { get; set; }
    }
}
