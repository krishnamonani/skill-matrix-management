using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.SkillDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.EmployeeSkillDTO
{
    public class EmployeeSkillDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public UserDto? User { get; set; } // Optional inclusion of User details

        [Required]
        public string CoreSkillName { get; set; }
        public SkillDto? Skill { get; set; } // Optional inclusion of Skill details

        public ProficiencyEnum SelfAssessedProficiency { get; set; }
        public ProficiencyEnum? ManagerAssignedProficiency { get; set; }

        public Guid? EndorsedBy { get; set; }
        public UserDto? Endorser { get; set; } // Optional inclusion of Endorser details

        public DateTime? EndorsedAt { get; set; }

        //public Dictionary<string, ProficiencyEnum> SkillDescription { get; set; }

        public bool IsDeleted { get; set; }
    }
}
