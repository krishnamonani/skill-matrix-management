using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.SkillDTO;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillMatrixDTO
{
    public class SkillMatrixDto : FullAuditedEntityDto<Guid>
    {
        public Guid DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; } // Optional inclusion of Department details

        public Guid SkillId { get; set; }
        public SkillDto? Skill { get; set; } // Optional inclusion of Skill details

        public ProficiencyEnum ExpectedProficiencyId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
