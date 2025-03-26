using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.ProjectDTO
{
    public class ProjectPagedResultDto : PagedResultDto<ProjectDto>
    {
        public ProjectPagedResultDto(long totalCount, IReadOnlyList<ProjectDto> items)
            : base(totalCount, items)
        {
        }
    }
}
