using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IEmployeeSkillRepository : IBasicRepository<EmployeeSkill, Guid>
    {
        // CRUD Methods
        Task<EmployeeSkill> CreateAsync(EmployeeSkill employeeSkill);
        Task<EmployeeSkill> GetByIdAsync(Guid id);
        Task<List<EmployeeSkill>> GetAllAsync();
        Task UpdateAsync(EmployeeSkill employeeSkill);
        Task DeleteAsync(Guid employeeSkillId); // Soft delete
        Task PermanentDeleteAsync(Guid employeeSkillId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid employeeSkillId); // Soft delete an employee skill
        Task RestoreEmployeeSkillAsync(Guid employeeSkillId); // Restore a soft-deleted employee skill

        // Custom Methods
        Task<List<EmployeeSkill>> GetSkillsByUserAsync(Guid userId);
        Task<List<EmployeeSkill>> GetSkillsBySkillAsync(string coreSkillName);
        Task<List<EmployeeSkill>> GetSkillsByEndorserAsync(Guid endorserId);
    }
}
