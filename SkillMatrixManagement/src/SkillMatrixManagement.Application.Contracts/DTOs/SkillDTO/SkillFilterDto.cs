using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillDTO
{
    public class SkillFilterDto : PagedAndSortedResultRequestDto
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Description { get; set; }
        public Guid? InternalRoleId { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
