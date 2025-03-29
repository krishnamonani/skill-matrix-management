using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface ISkillMatrixRepository : IBasicRepository<SkillMatrix, Guid>
    {
        // CRUD Methods
        Task<SkillMatrix> CreateAsync(SkillMatrix skillMatrix);
        Task<SkillMatrix> GetByIdAsync(Guid id);
        Task<List<SkillMatrix>> GetAllAsync();
        Task UpdateAsync(SkillMatrix skillMatrix);
        Task DeleteAsync(Guid skillMatrixId); // Soft delete
        Task PermanentDeleteAsync(Guid skillMatrixId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid skillMatrixId); // Soft delete a skill matrix
        Task RestoreSkillMatrixAsync(Guid skillMatrixId); // Restore a soft-deleted skill matrix
    }
}
