using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IUserRepository : IBasicRepository<User, Guid>
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid userId); // Soft delete
        Task PermanentDeleteAsync(Guid userId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid userId); // Soft delete a user
        Task RestoreUserAsync(Guid userId); // Restore a soft-deleted user

        Task<IQueryable<User>> WithDetailsAsync();
    }
}
