using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IDepartmentService : IApplicationService
    {
        Task<ServiceResponse<DepartmentDto>> CreateAsync(CreateDepartmentDto input);
        Task<ServiceResponse<DepartmentDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<DepartmentDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<DepartmentPagedResultDto>> GetPagedListAsync(DepartmentFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreDepartmentAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<DepartmentLookupDto>>> GetLookupAsync();
    }
}
