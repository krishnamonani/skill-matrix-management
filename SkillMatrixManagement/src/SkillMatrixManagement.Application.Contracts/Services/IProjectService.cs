using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.ProjectDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IProjectService : IApplicationService
    {
        Task<ServiceResponse<ProjectDto>> CreateAsync(CreateProjectDto input);
        Task<ServiceResponse<ProjectDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<ProjectDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<ProjectPagedResultDto>> GetPagedListAsync(ProjectFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateProjectDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreProjectAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<ProjectLookupDto>>> GetLookupAsync();
        Task<ServiceResponse> UpdateProjectStatusAsync(Guid id, UpdateProjectStatusDto input);
    }
}
