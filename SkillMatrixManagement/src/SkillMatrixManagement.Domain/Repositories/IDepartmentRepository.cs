using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Repositories
{
    public interface IDepartmentRepository: IBasicRepository<Department,Guid>
    {
        // CRUD Methods
        Task<Department> CreateAsync(Department department);
        Task<Department> GetByIdAsync(Guid id);
        Task<List<Department>> GetAllAsync();
        Task UpdateAsync(Department department);
        Task DeleteAsync(Guid departmentId); // Soft delete
        Task PermanentDeleteAsync(Guid departmentId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid departmentId); // Soft delete a department
        Task RestoreDepartmentAsync(Guid departmentId); // Restore a soft-deleted department

        // Custom Methods
        Task<List<Department>> GetAllDepartmentsAsync(bool includeDeleted = false); // Get all departments, optionally including deleted ones

        // Pagination and Filtering
        Task<List<Department>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false);
        Task<int> CountAsync(bool includeDeleted = false); // Count all departments, optionally including deleted ones

        Task<IQueryable<Department>> WithDetailsAsync();
    }
}
