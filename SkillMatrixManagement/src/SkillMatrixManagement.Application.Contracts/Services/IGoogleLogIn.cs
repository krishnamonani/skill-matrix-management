using SkillMatrixManagement.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IGoogleLogIn:IApplicationService
    {
        Task<ServiceResponse> GetGoogleLogInAsync(string email);
    }
}
