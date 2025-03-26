using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.ReportAnalyticsDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IReportAnalyticsService : IApplicationService
    {
        Task<ServiceResponse<ReportAnalyticsDto>> CreateAsync(CreateReportAnalyticsDto input);
        Task<ServiceResponse<ReportAnalyticsDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<ReportAnalyticsDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<ReportAnalyticsPagedResultDto>> GetPagedListAsync(ReportAnalyticsFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateReportAnalyticsDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreReportAnalyticsAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<ReportAnalyticsLookupDto>>> GetLookupAsync();
    }
}
