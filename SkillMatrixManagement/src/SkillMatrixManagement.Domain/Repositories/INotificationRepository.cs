using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface INotificationRepository : IBasicRepository<Notification, Guid>
    {
        // CRUD Methods
        Task<Notification> CreateAsync(Notification notification);
        Task<Notification> GetByIdAsync(Guid id);
        Task<List<Notification>> GetAllAsync();
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(Guid notificationId); // Soft delete
        Task PermanentDeleteAsync(Guid notificationId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid notificationId); // Soft delete a notification
        Task RestoreNotificationAsync(Guid notificationId); // Restore a soft-deleted notification

        // Custom Methods
        Task<List<Notification>> GetNotificationsByDepartmentAsync(Guid departmentId);
        Task<List<Notification>> GetNotificationsByUserAsync(Guid userId);
    }
}
