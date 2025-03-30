using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.EmployeeSkillDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;
using static SkillMatrixManagement.SkillMatrixManagementDomainErrorCodes;

namespace SkillMatrixManagement.Services
{
    public interface IEmployeeSkillService: IApplicationService
    {
        Task<ServiceResponse<EmployeeSkillDto>> CreateAsync(CreateEmployeeSkillDto input);
        Task<ServiceResponse<EmployeeSkillDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<EmployeeSkillDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<EmployeeSkillPagedResultDto>> GetPagedListAsync(EmployeeSkillFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateEmployeeSkillDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreEmployeeSkillAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<EmployeeSkillLookupDto>>> GetLookupAsync();

        Task<ServiceResponse<List<EmployeeSkillDto>>> GetSkillsByUserAsync(Guid userId);
    }
}
