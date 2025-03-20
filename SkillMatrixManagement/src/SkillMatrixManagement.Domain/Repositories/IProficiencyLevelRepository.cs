using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IProficiencyLevelRepository : IBasicRepository<ProficiencyLevel, Guid>
    {
        // CRUD Methods
        Task<ProficiencyLevel> CreateAsync(ProficiencyLevel proficiencyLevel);
        Task<ProficiencyLevel> GetByIdAsync(Guid id);
        Task<List<ProficiencyLevel>> GetAllAsync();
        Task UpdateAsync(ProficiencyLevel proficiencyLevel);
        Task DeleteAsync(Guid proficiencyLevelId); // Soft delete
        Task PermanentDeleteAsync(Guid proficiencyLevelId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid proficiencyLevelId); // Soft delete a proficiency level
        Task RestoreProficiencyLevelAsync(Guid proficiencyLevelId); // Restore a soft-deleted proficiency level

        // Custom Methods
        Task<List<ProficiencyLevel>> GetProficiencyLevelsByLevelAsync(ProficiencyEnum level);
    }
}
