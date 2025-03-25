using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillSubtopicDTO;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ISkillSubtopicService : IApplicationService
    {
        Task<ServiceResponse<SkillSubtopicDto>> CreateAsync(CreateSkillSubtopicDto input);
        Task<ServiceResponse<SkillSubtopicDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<SkillSubtopicDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<SkillSubtopicPagedResultDto>> GetPagedListAsync(SkillSubtopicFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillSubtopicDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreSkillSubtopicAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<SkillSubtopicLookupDto>>> GetLookupAsync();
    }
}
