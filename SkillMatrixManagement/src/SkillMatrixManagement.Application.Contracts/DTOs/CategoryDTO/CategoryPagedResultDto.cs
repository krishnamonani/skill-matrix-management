using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.CategoryDTO
{
    // Paged Response DTO
    public class CategoryPagedResultDto : PagedResultDto<CategoryDto>
    {
        public CategoryPagedResultDto(long totalCount, IReadOnlyList<CategoryDto> items)
            : base(totalCount, items)
        {
        }
    }
}
