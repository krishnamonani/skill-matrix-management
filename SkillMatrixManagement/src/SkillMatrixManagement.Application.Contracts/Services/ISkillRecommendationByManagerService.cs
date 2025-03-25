using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillRecommendationByManagerDTO;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ISkillRecommendationByManagerService : IApplicationService
    {
        Task<ServiceResponse<SkillRecommendationByManagerDto>> CreateAsync(CreateSkillRecommendationByManagerDto input);
        Task<ServiceResponse<SkillRecommendationByManagerDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<SkillRecommendationByManagerDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<SkillRecommendationByManagerPagedResultDto>> GetPagedListAsync(SkillRecommendationByManagerFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillRecommendationByManagerDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreSkillRecommendationByManagerAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<SkillRecommendationByManagerLookupDto>>> GetLookupAsync();
    }
}
