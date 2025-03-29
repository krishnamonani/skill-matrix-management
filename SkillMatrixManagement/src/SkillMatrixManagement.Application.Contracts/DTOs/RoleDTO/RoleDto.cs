using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.RoleDTO
{
    public class RoleDto : FullAuditedEntityDto<Guid>
    {
        public RoleEnum Name { get; set; }
        public string RoleNameString { get; set; }
        public bool IsDeleted { get; set; }
    }
}
