using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface ISkillRecommendationRepository : IBasicRepository<SkillRecommendation, Guid>
    {
        // CRUD Methods
        Task<SkillRecommendation> CreateAsync(SkillRecommendation skillRecommendation);
        Task<SkillRecommendation> GetByIdAsync(Guid id);
        Task<List<SkillRecommendation>> GetAllAsync();
        Task UpdateAsync(SkillRecommendation skillRecommendation);
        Task DeleteAsync(Guid skillRecommendationId); // Soft delete
        Task PermanentDeleteAsync(Guid skillRecommendationId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid skillRecommendationId); // Soft delete a skill recommendation
        Task RestoreSkillRecommendationAsync(Guid skillRecommendationId); // Restore a soft-deleted skill recommendation
    }
}
