using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.CategoryDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    class CategoryService : ApplicationService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ServiceResponse<CategoryDto>> CreateAsync(CreateCategoryDto input)
        {
            var category = new Category
            {
                CategoryName = input.CategoryName,
                Description = input.Description
            };
            await _categoryRepository.CreateAsync(category);
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            return ServiceResponse<CategoryDto>.SuccessResult(categoryDto, 200);
        }

        public Task<ServiceResponse<CategoryDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<CategoryDto>> GetByCategoryNameAsync(CategoryEnum categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CategoryDto>>> GetAllAsync(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<CategoryPagedResultDto>> GetPagedListAsync(CategoryFilterDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(Guid id, UpdateCategoryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> RestoreCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<CategoryLookupDto>>> GetLookupAsync()
        {
            throw new NotImplementedException();
        }


    }
}
