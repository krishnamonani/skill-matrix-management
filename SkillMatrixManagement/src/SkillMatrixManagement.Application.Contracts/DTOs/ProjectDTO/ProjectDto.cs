using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ProjectDTO
{
    public class ProjectDto : FullAuditedEntityDto<Guid>
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public bool IsDelayed { get; set; }
        public bool IsOngoing { get; set; }
        public bool IsDeleted { get; set; }
    }
}
