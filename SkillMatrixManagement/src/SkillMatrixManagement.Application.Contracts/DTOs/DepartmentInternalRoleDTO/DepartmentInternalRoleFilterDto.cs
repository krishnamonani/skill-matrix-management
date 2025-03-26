using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO
{
    public class DepartmentInternalRoleFilterDto : PagedAndSortedResultRequestDto
    {
        public DepartmentRoleEnum? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public RolePositionEnum? Position { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
