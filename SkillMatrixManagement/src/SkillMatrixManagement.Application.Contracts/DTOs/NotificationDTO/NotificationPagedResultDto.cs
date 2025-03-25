using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.NotificationDTO
{
    public class NotificationPagedResultDto : PagedResultDto<NotificationDto>
    {
        public NotificationPagedResultDto(long totalCount, IReadOnlyList<NotificationDto> items)
            : base(totalCount, items)
        {
        }
    }
}
