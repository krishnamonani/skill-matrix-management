using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.UserDTO;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SkillMatrixManagement.Services
{
    public interface IUserService : IApplicationService
    {
        Task<ServiceResponse<UserDto>> CreateAsync(CreateUserDto input);
        Task<ServiceResponse<UserDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<UserDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<UserPagedResultDto>> GetPagedListAsync(UserFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateUserDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreUserAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<UserLookupDto>>> GetLookupAsync();
        Task<IdentityUserDto> CreateEmployeeAsync(CreateEmployeeDto input);
    }
}
