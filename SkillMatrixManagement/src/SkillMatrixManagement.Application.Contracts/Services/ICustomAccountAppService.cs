using SkillMatrixManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ICustomAccountAppService : IApplicationService
    {
        Task<CustomLoginResultDto> CustomLoginAsync(LoginDTO login);
    }


}
