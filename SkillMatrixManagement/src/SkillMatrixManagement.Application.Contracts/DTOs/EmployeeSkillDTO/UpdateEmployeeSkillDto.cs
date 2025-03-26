using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.EmployeeSkillDTO
{
    public class UpdateEmployeeSkillDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid SkillId { get; set; }

        [Required]
        public ProficiencyEnum SelfAssessedProficiency { get; set; }

        public ProficiencyEnum? ManagerAssignedProficiency { get; set; }

        public Guid? EndorsedBy { get; set; }

        public DateTime? EndorsedAt { get; set; }

        public Dictionary<string, ProficiencyEnum>? SkillDescription { get; set; }
    }
}
