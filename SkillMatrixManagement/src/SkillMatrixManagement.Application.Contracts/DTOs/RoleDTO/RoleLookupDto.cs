using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.RoleDTO
{
    public class RoleLookupDto
    {
        public Guid Id { get; set; }
        public RoleEnum Name { get; set; }
    }
}
