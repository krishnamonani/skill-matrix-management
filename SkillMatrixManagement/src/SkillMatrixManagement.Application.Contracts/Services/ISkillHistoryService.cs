using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillHistoryDTO;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ISkillHistoryService : IApplicationService
    {
        Task<ServiceResponse<SkillHistoryDto>> CreateAsync(CreateSkillHistoryDto input);
        Task<ServiceResponse<SkillHistoryDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<SkillHistoryDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<SkillHistoryPagedResultDto>> GetPagedListAsync(SkillHistoryFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillHistoryDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreSkillHistoryAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<SkillHistoryLookupDto>>> GetLookupAsync();
    }
}
