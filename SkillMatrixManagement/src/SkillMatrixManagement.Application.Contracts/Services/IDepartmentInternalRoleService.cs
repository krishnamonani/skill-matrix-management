using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IDepartmentInternalRoleService: IApplicationService
    {
        Task<ServiceResponse<DepartmentInternalRoleDto>> CreateAsync(CreateDepartmentInternalRoleDto input);
        Task<ServiceResponse<DepartmentInternalRoleDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<DepartmentInternalRoleDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<DepartmentInternalRolePagedResultDto>> GetPagedListAsync(DepartmentInternalRoleFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentInternalRoleDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreDepartmentInternalRoleAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<DepartmentInternalRoleLookupDto>>> GetLookupAsync();
    }
}
