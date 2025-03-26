using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillRecommendationDTO;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ISkillRecommendationService : IApplicationService
    {
        Task<ServiceResponse<SkillRecommendationDto>> CreateAsync(CreateSkillRecommendationDto input);
        Task<ServiceResponse<SkillRecommendationDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<SkillRecommendationDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<SkillRecommendationPagedResultDto>> GetPagedListAsync(SkillRecommendationFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillRecommendationDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreSkillRecommendationAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<SkillRecommendationLookupDto>>> GetLookupAsync();
    }
}
