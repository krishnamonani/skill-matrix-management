using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.PermissionDTO
{
    public class PermissionLookupDto
    {
        public Guid Id { get; set; }
        public PermissionEnum Name { get; set; }
    }
}
