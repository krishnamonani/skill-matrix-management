using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillRecommendationDTO
{
    public class SkillRecommendationFilterDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? RecommendedSkillId { get; set; }
        public float? ConfidenceScoreMin { get; set; }
        public float? ConfidenceScoreMax { get; set; }
        public DateTime? GeneratedAtStart { get; set; }
        public DateTime? GeneratedAtEnd { get; set; }
        public string? AlgorithmUsed { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
