using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.RolePermissionDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IRolePermissionService : IApplicationService
    {
        Task<ServiceResponse<RolePermissionDto>> CreateAsync(CreateRolePermissionDto input);
        Task<ServiceResponse<RolePermissionDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<RolePermissionDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<RolePermissionPagedResultDto>> GetPagedListAsync(RolePermissionFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateRolePermissionDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreRolePermissionAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<RolePermissionLookupDto>>> GetLookupAsync();
    }
}
