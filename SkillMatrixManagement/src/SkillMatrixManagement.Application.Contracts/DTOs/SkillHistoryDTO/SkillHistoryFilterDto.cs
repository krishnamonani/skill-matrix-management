using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillHistoryDTO
{
    public class SkillHistoryFilterDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public string? CoreSkillName { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
