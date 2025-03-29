using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class UserPagedResultDto : PagedResultDto<UserDto>
    {
        public UserPagedResultDto(long totalCount, IReadOnlyList<UserDto> items)
            : base(totalCount, items)
        {
        }
    }
}
