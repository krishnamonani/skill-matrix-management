using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.SkillMatrixDTO
{
    public class SkillMatrixPagedResultDto : PagedResultDto<SkillMatrixDto>
    {
        public SkillMatrixPagedResultDto(long totalCount, IReadOnlyList<SkillMatrixDto> items)
            : base(totalCount, items)
        {
        }
    }
}
