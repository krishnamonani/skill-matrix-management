using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ProjectDTO
{
    public class ProjectFilterDto : PagedAndSortedResultRequestDto
    {
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDateStart { get; set; }
        public DateTime? StartDateEnd { get; set; }
        public DateTime? ExpectedEndDateStart { get; set; }
        public DateTime? ExpectedEndDateEnd { get; set; }
        public bool? IsDelayed { get; set; }
        public bool? IsOngoing { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
