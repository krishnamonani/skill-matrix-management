using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.DepartmentManagerDTO
{
    public class CreateDepartmentManagerDto
    {
        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }
    }
}
