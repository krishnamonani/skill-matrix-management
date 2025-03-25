using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.NotificationDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface INotificationService : IApplicationService
    {
        Task<ServiceResponse<NotificationDto>> CreateAsync(CreateNotificationDto input);
        Task<ServiceResponse<NotificationDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<List<NotificationDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<NotificationPagedResultDto>> GetPagedListAsync(NotificationFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateNotificationDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreNotificationAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<NotificationLookupDto>>> GetLookupAsync();
    }
}
