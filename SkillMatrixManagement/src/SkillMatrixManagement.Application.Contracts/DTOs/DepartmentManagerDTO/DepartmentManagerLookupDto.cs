using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.DepartmentManagerDTO
{
    public class DepartmentManagerLookupDto
    {
        public Guid Id { get; set; }
        public Guid ManagerId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
