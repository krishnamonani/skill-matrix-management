using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface ISkillSubtopicRepository : IBasicRepository<SkillSubtopic, Guid>
    {
        // CRUD Methods
        Task<SkillSubtopic> CreateAsync(SkillSubtopic skillSubtopic);
        Task<SkillSubtopic> GetByIdAsync(Guid id);
        Task<List<SkillSubtopic>> GetAllAsync();
        Task UpdateAsync(SkillSubtopic skillSubtopic);
        Task DeleteAsync(Guid skillSubtopicId); // Soft delete
        Task PermanentDeleteAsync(Guid skillSubtopicId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid skillSubtopicId); // Soft delete a skill subtopic
        Task RestoreSkillSubtopicAsync(Guid skillSubtopicId); // Restore a soft-deleted skill subtopic
    }
}
