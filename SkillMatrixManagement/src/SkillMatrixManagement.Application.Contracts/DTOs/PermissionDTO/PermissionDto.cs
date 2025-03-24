using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.PermissionDTO
{
    public class PermissionDto : FullAuditedEntityDto<Guid>
    {
        public PermissionEnum Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
