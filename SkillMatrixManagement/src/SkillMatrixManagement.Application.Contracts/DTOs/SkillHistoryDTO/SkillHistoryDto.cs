using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.SkillDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillHistoryDTO
{
    public class SkillHistoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public UserDto? User { get; set; } // Optional inclusion of User details

        public Guid SkillId { get; set; }
        public SkillDto? Skill { get; set; } // Optional inclusion of Skill details

        public ProficiencyEnum ChangedProficiencyLevel { get; set; }

        public string Comment { get; set; }

        public int UserIdBasedVersion { get; set; }
    }
}
