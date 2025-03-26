using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillSubtopicDTO
{
    public class SkillSubtopicFilterDto : PagedAndSortedResultRequestDto
    {
        public Guid? SkillId { get; set; }
        public string? Name { get; set; }
        public ProficiencyEnum? ReqExpertiseLevelId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
