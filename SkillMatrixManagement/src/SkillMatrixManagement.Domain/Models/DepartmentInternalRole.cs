using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class DepartmentInternalRole : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [StringLength(100)]
        public DepartmentRoleEnum RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public RolePositionEnum Position { get; set; }

    }

}
