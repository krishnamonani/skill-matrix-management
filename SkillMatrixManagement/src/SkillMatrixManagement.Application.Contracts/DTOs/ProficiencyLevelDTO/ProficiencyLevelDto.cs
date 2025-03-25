using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ProficiencyLevelDTO
{
    public class ProficiencyLevelDto : FullAuditedEntityDto<Guid>
    {
        public ProficiencyEnum Level { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
