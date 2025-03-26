using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillMatrixDTO
{
    public class SkillMatrixLookupDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid SkillId { get; set; }
    }
}
