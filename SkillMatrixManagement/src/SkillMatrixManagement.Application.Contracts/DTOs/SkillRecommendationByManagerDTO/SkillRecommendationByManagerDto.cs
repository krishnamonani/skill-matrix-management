using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.SkillDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillRecommendationByManagerDTO
{
    public class SkillRecommendationByManagerDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public UserDto? User { get; set; } // Optional inclusion of User details

        public Guid SkillId { get; set; }
        public SkillDto? Skill { get; set; } // Optional inclusion of Skill details

        public Guid SkillRecommenderId { get; set; }
        public UserDto? SkillRecommender { get; set; } // Optional inclusion of Recommender details

        public string Comment { get; set; }

        public bool IsDeleted { get; set; }
    }
}
