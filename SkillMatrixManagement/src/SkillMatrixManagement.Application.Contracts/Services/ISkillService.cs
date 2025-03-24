using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillDTO;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ISkillService : IApplicationService
    {
        Task<ServiceResponse<SkillDto>> CreateAsync(CreateSkillDto input);
        Task<ServiceResponse<SkillDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<SkillDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<SkillPagedResultDto>> GetPagedListAsync(SkillFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreSkillAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<SkillLookupDto>>> GetLookupAsync();
    }
}
