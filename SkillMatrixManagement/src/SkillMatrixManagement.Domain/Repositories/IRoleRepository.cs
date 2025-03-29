using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IRoleRepository : IBasicRepository<Role, Guid>
    {
        // CRUD Methods
        Task<Role> CreateAsync(Role role);
        Task<Role> GetByIdAsync(Guid id);
        Task<List<Role>> GetAllAsync();
        Task UpdateAsync(Role role);
        Task DeleteAsync(Guid roleId); // Soft delete
        Task PermanentDeleteAsync(Guid roleId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid roleId); // Soft delete a role
        Task RestoreRoleAsync(Guid roleId); // Restore a soft-deleted role
        Task<IQueryable<Role>> WithDetailsAsync();
    }
}
