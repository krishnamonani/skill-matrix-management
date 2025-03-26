using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.RoleDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IRoleService : IApplicationService
    {
        Task<ServiceResponse<RoleDto>> CreateAsync(CreateRoleDto input);
        Task<ServiceResponse<RoleDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<RoleDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<RolePagedResultDto>> GetPagedListAsync(RoleFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateRoleDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreRoleAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<RoleLookupDto>>> GetLookupAsync();
    }
}
