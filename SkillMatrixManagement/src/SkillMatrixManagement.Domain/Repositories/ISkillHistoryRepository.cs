using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface ISkillHistoryRepository : IBasicRepository<SkillHistory, Guid>
    {
        // CRUD Methods
        Task<SkillHistory> CreateAsync(SkillHistory skillHistory);
        Task<SkillHistory> GetByIdAsync(Guid id);
        Task<List<SkillHistory>> GetAllAsync();
        Task UpdateAsync(SkillHistory skillHistory);
        Task DeleteAsync(Guid skillHistoryId); // Soft delete
        Task PermanentDeleteAsync(Guid skillHistoryId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid skillHistoryId); // Soft delete a skill history
        Task RestoreSkillHistoryAsync(Guid skillHistoryId); // Restore a soft-deleted skill history
        Task<IQueryable<SkillHistory>> WithDetailsAsync();
    }
}
