using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface ISkillRepository : IBasicRepository<Skill, Guid>
    {
        // CRUD Methods
        Task<Skill> CreateAsync(Skill skill);
        Task<Skill> GetByIdAsync(Guid id);
        Task<List<Skill>> GetAllAsync();
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Guid skillId); // Soft delete
        Task PermanentDeleteAsync(Guid skillId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid skillId); // Soft delete a skill
        Task RestoreSkillAsync(Guid skillId); // Restore a soft-deleted skill

        Task<IQueryable<Skill>> WithDetailsAsync();

    }
}
