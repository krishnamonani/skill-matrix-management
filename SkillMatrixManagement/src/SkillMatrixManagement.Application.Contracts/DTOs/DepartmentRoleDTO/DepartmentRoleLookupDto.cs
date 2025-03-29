using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.DepartmentRoleDTO
{
    public class DepartmentRoleLookupDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid InternalRoleId { get; set; }
    }
}
