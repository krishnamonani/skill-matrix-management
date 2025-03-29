using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface ISkillRecommendationByManagerRepository : IBasicRepository<SkillRecommendationByManager, Guid>
    {
        // CRUD Methods
        Task<SkillRecommendationByManager> CreateAsync(SkillRecommendationByManager skillRecommendationByManager);
        Task<SkillRecommendationByManager> GetByIdAsync(Guid id);
        Task<List<SkillRecommendationByManager>> GetAllAsync();
        Task UpdateAsync(SkillRecommendationByManager skillRecommendationByManager);
        Task DeleteAsync(Guid skillRecommendationByManagerId); // Soft delete
        Task PermanentDeleteAsync(Guid skillRecommendationByManagerId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid skillRecommendationByManagerId); // Soft delete a skill recommendation by manager
        Task RestoreSkillRecommendationAsync(Guid skillRecommendationByManagerId); // Restore a soft-deleted skill recommendation by manager
    }
}
