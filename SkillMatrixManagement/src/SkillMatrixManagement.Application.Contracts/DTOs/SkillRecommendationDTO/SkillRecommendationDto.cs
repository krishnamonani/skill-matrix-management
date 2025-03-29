using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.SkillDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillRecommendationDTO
{
    public class SkillRecommendationDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public UserDto? User { get; set; } // Optional inclusion of User details

        public Guid RecommendedSkillId { get; set; }
        public SkillDto? RecommendedSkill { get; set; } // Optional inclusion of Skill details

        public float ConfidenceScore { get; set; }

        public DateTime GeneratedAt { get; set; }

        public string? AlgorithmUsed { get; set; }

        public bool IsDeleted { get; set; }
    }
}
