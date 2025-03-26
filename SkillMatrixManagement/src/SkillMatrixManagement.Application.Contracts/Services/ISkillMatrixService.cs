using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillMatrixDTO;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ISkillMatrixService : IApplicationService
    {
        Task<ServiceResponse<SkillMatrixDto>> CreateAsync(CreateSkillMatrixDto input);
        Task<ServiceResponse<SkillMatrixDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<SkillMatrixDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<SkillMatrixPagedResultDto>> GetPagedListAsync(SkillMatrixFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillMatrixDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreSkillMatrixAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<SkillMatrixLookupDto>>> GetLookupAsync();
    }
}
