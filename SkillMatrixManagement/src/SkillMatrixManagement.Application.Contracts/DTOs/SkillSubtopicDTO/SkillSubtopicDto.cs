using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.SkillDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillSubtopicDTO
{
    public class SkillSubtopicDto : FullAuditedEntityDto<Guid>
    {
        public Guid SkillId { get; set; }
        public SkillDto? Skill { get; set; } // Optional inclusion of Skill details

        public string Name { get; set; }

        public Dictionary<string, string>? Description { get; set; }

        public ProficiencyEnum? ReqExpertiseLevelId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
