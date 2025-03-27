using SkillMatrixManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.CategoryDTO
{
    // Base DTO for Category
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public CategoryEnum CategoryName { get; set; }
        public string CategoryNameString {get; set; }
        public string Description { get; set; }
        public bool IsUpdated { get; set; }
    }
}
