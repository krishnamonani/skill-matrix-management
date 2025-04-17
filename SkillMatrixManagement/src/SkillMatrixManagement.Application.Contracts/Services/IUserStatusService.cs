
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared; 
using SkillMatrixManagement.DTOs;
using Volo.Abp.Application.Services;   
namespace SkillMatrixManagement.Services 
{
    public interface IUserStatusService : IApplicationService 
    {
        Task<ServiceResponse<UserRolesDto>> GetCurrentUserStatusAndRolesAsync(string userNameOrEmailAddress);
    }
}