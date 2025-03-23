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
    public interface ICategoryRepository: IBasicRepository<Category, Guid>
    {
        // CRUD Methods
        Task<Category> CreateAsync(Category category);
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllAsync();
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid categoryId); // Soft delete
        Task PermanentDeleteAsync(Guid categoryId); // Hard delete

        // Soft Delete & Restore
        Task SoftDeleteAsync(Guid categoryId); // Soft delete a category
        Task RestoreCategoryAsync(Guid categoryId); // Restore a soft-deleted category

        // Custom Methods
        Task<Category> GetByCategoryNameAsync(CategoryEnum categoryName); // Get category by CategoryEnum name
        Task<List<Category>> GetAllCategoriesAsync(bool includeDeleted = false); // Get all categories, optionally including deleted ones

        // Pagination and Filtering
        Task<List<Category>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false);
        Task<int> CountAsync(bool includeDeleted = false); // Count all categories, optionally including deleted ones
    }
}
