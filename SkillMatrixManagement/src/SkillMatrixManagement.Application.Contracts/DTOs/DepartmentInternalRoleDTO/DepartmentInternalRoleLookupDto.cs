using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO
{
    public class DepartmentInternalRoleLookupDto
    {
        public Guid Id { get; set; }
        public DepartmentRoleEnum RoleName { get; set; }
        public string DepartmentRole { get; set; }
    }
}
