using SkillMatrixManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.CategoryDTO
{
    // Filter DTO for searching categories
    public class CategoryFilterDto : PagedAndSortedResultRequestDto
    {
        public CategoryEnum? CategoryName { get; set; }
        public string? Description { get; set; }
        public bool? IsUpdated { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
