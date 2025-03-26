using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillDTO
{
    public class CreateSkillDto
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [StringLength(500)] // Optional limit for description
        public string Description { get; set; }

        [Required]
        public Guid InternalRoleId { get; set; }
    }
}
