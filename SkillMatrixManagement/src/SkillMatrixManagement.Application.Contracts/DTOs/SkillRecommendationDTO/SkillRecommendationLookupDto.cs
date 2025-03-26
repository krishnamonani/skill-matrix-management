using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.SkillRecommendationDTO
{
    public class SkillRecommendationLookupDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RecommendedSkillId { get; set; }
    }
}
