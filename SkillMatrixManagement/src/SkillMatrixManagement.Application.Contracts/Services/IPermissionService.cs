using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.PermissionDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IPermissionService : IApplicationService
    {
        Task<ServiceResponse<PermissionDto>> CreateAsync(CreatePermissionDto input);
        Task<ServiceResponse<PermissionDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<PermissionDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<PermissionPagedResultDto>> GetPagedListAsync(PermissionFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdatePermissionDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestorePermissionAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<PermissionLookupDto>>> GetLookupAsync();
    }
}
