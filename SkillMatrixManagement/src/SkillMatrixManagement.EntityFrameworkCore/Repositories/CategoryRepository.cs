using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class CategoryRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Category, Guid>, ICategoryRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public CategoryRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            Check.NotNull(category, nameof(category));
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var exists = await dbContext.Set<Category>().AnyAsync(c => c.CategoryName == category.CategoryName && !c.IsDeleted);
            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_ALREADY_EXIST, "Category already exists");

            var result = await dbContext.Set<Category>().AddAsync(category);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Category ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var category = await dbContext.Set<Category>().FindAsync(id)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_NOT_FOUND, "Category not found");
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Category>().Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            Check.NotNull(category, nameof(category));

            var existing = await dbContext.Set<Category>().FirstOrDefaultAsync(c => c.Id == category.Id && !c.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_NOT_FOUND_FOR_UPDATE, "Category not found for update");

            var duplicateExists = await dbContext.Set<Category>().AnyAsync(c => c.CategoryName == category.CategoryName && c.Id != category.Id && !c.IsDeleted);
            if (duplicateExists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_DUPLICATE_NAME, "Category with the same name already exists");

            dbContext.Set<Category>().Update(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            await SoftDeleteAsync(categoryId);
        }

        public async Task SoftDeleteAsync(Guid categoryId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var category = await dbContext.Set<Category>().FindAsync(categoryId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_NOT_FOUND_FOR_SOFT_DELETE, "Category not found");

            category.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task PermanentDeleteAsync(Guid categoryId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var category = await dbContext.Set<Category>().IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_NOT_FOUND_FOR_PERMANENT_DELETE, "Category not found for deletion");

            dbContext.Set<Category>().Remove(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreCategoryAsync(Guid categoryId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var category = await dbContext.Set<Category>().IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null || !category.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_NOT_FOUND_OR_DELETED, "Category not found or not deleted");

            category.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task<Category> GetByCategoryNameAsync(CategoryEnum categoryName)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Category>().FirstOrDefaultAsync(c => c.CategoryName == categoryName)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.Category.CATEGORY_NOT_FOUND_BY_NAME, "Category not found");
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<Category>().IgnoreQueryFilters().ToListAsync() : dbContext.Set<Category>().ToListAsync());
        }

        public async Task<List<Category>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<Category>().IgnoreQueryFilters() : dbContext.Set<Category>())
                .Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public async Task<int> CountAsync(bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<Category>().IgnoreQueryFilters().CountAsync() : dbContext.Set<Category>().CountAsync());
        }
    }
}
