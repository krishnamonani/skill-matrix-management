using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.Repositories
{
    class NotificationRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Notification, Guid>, INotificationRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public NotificationRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
        // Create Notification
        public async Task<Notification> CreateAsync(Notification notification)
        {
            // Input validation
            Check.NotNull(notification, nameof(notification));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Add the notification
            var result = await dbContext.Set<Notification>().AddAsync(notification);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Get Notification by ID
        public async Task<Notification> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Notification ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var notification = await dbContext.Set<Notification>()
                .FirstOrDefaultAsync(n => n.Id == id && !n.IsDeleted)
                ?? throw new BusinessException("NOTIF-001", "Notification not found");

            return notification;
        }

        // Get All Notifications
        public async Task<List<Notification>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Notification>()
                .Where(n => !n.IsDeleted)
                .ToListAsync();
        }

        // Update Notification
        public async Task UpdateAsync(Notification notification)
        {
            Check.NotNull(notification, nameof(notification));

            if (notification.Id == Guid.Empty)
                throw new ArgumentException("Notification ID cannot be empty", nameof(notification));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var existingNotification = await dbContext.Set<Notification>()
                .FirstOrDefaultAsync(n => n.Id == notification.Id && !n.IsDeleted)
                ?? throw new BusinessException("NOTIF-002", "Notification not found for update");

            dbContext.Entry(existingNotification).CurrentValues.SetValues(notification);
            await dbContext.SaveChangesAsync();
        }


        // Soft Delete Notification
        public async Task DeleteAsync(Guid notificationId)
        {
            await SoftDeleteAsync(notificationId);
        }

        public async Task SoftDeleteAsync(Guid notificationId)
        {
            if (notificationId == Guid.Empty)
                throw new ArgumentException("Notification ID cannot be empty", nameof(notificationId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var notification = await dbContext.Set<Notification>()
                .FirstOrDefaultAsync(n => n.Id == notificationId && !n.IsDeleted)
                ?? throw new BusinessException("NOTIF-003", "Notification not found for soft deletion");

            if (notification.IsDeleted)
                throw new BusinessException("NOTIF-004", "Notification is already deleted");

            notification.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        // Permanent Delete Notification
        public async Task PermanentDeleteAsync(Guid notificationId)
        {
            if (notificationId == Guid.Empty)
                throw new ArgumentException("Notification ID cannot be empty", nameof(notificationId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var notification = await dbContext.Set<Notification>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(n => n.Id == notificationId);

            if (notification == null)
                throw new BusinessException("NOTIF-005", "Notification not found for permanent deletion");

            dbContext.Set<Notification>().Remove(notification);
            await dbContext.SaveChangesAsync();
        }

        // Restore Soft Deleted Notification
        public async Task RestoreNotificationAsync(Guid notificationId)
        {
            if (notificationId == Guid.Empty)
                throw new ArgumentException("Notification ID cannot be empty", nameof(notificationId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var notification = await dbContext.Set<Notification>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(n => n.Id == notificationId)
                ?? throw new BusinessException("NOTIF-006", "Notification not found for restoration");

            if (!notification.IsDeleted)
                throw new BusinessException("NOTIF-007", "Notification is not deleted, cannot be restored");

            notification.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        // Get Notifications by Department
        public async Task<List<Notification>> GetNotificationsByDepartmentAsync(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
                throw new ArgumentException("Department ID cannot be empty", nameof(departmentId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Notification>()
                .Where(n => n.DepartmentId == departmentId && !n.IsDeleted)
                .ToListAsync();
        }

        // Get Notifications by User
        public async Task<List<Notification>> GetNotificationsByUserAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Notification>()
                .Where(n => n.CreatedBy == userId && !n.IsDeleted)
                .ToListAsync();
        }

        // Override to include navigation properties
        public override async Task<IQueryable<Notification>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<Notification>();
        }
    }
}