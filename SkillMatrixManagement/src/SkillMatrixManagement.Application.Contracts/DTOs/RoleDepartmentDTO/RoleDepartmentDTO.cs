using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.RoleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.RoleDepartmentDTO
{
   public class RoleDepartmentDTO
    {
  
        public Guid RoleId { get; set; }
        //public  RoleDto? Role { get; set; }

        public RoleEnum RoleName { get; set; }

        public Guid DepartmentId { get; set; }
        //public virtual DepartmentDto? Department { get; set; }

        public string DepartmentName { get; set; }
    }
}
