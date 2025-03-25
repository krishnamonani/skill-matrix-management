using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.DepartmentManagerDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IDepartmentManagerService: IApplicationService
    {
        Task<ServiceResponse<DepartmentManagerDto>> CreateAsync(CreateDepartmentManagerDto input);
        Task<ServiceResponse<DepartmentManagerDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<DepartmentManagerDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<DepartmentManagerPagedResultDto>> GetPagedListAsync(DepartmentManagerFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentManagerDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreDepartmentManagerAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<DepartmentManagerLookupDto>>> GetLookupAsync();
    }
}
