using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.ProjectEmployeeDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;


namespace SkillMatrixManagement.Services
{
    public interface IProjectEmployeeService : IApplicationService
    {
        Task<ServiceResponse<ProjectEmployeeDto>> CreateAsync(CreateProjectEmployeeDto input);
        Task<ServiceResponse<ProjectEmployeeDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<ProjectEmployeeDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<ProjectEmployeePagedResultDto>> GetPagedListAsync(ProjectEmployeeFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateProjectEmployeeDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreProjectEmployeeAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<ProjectEmployeeLookupDto>>> GetLookupAsync();

        Task<ServiceResponse<List<Guid>>> AssignEmployeesToProjectAsync(Guid projectId, List<Guid> employeeIds);

    }
}
