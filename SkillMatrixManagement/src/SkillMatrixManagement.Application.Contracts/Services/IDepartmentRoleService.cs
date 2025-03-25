using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.DepartmentRoleDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IDepartmentRoleService: IApplicationService
    {
        Task<ServiceResponse<DepartmentRoleDto>> CreateAsync(CreateDepartmentRoleDto input);
        Task<ServiceResponse<DepartmentRoleDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<DepartmentRoleDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<DepartmentRolePagedResultDto>> GetPagedListAsync(DepartmentRoleFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentRoleDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreDepartmentRoleAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<DepartmentRoleLookupDto>>> GetLookupAsync();
    }
}
