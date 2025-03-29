using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.ProficiencyLevelDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IProficiencyLevelService : IApplicationService
    {
        Task<ServiceResponse<ProficiencyLevelDto>> CreateAsync(CreateProficiencyLevelDto input);
        Task<ServiceResponse<ProficiencyLevelDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<ProficiencyLevelDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<ProficiencyLevelPagedResultDto>> GetPagedListAsync(ProficiencyLevelFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateProficiencyLevelDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreProficiencyLevelAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<ProficiencyLevelLookupDto>>> GetLookupAsync();
    }
}
