using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentRoleDTO
{
    public class DepartmentRoleFilterDto : PagedAndSortedResultRequestDto
    {
        public Guid? DepartmentId { get; set; }
        public Guid? InternalRoleId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
