using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.CategoryDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppCategoryService : ApplicationService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AppCategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> CreateAsync(CreateCategoryDto input)
        {
            try
            {
                if (input == null)
                    throw new UserFriendlyException("Input cannot be null.");

                if (!Enum.IsDefined(typeof(CategoryEnum), input.CategoryName))
                    throw new UserFriendlyException("Invalid category name specified.");

                var category = _mapper.Map<Category>(input);
                var createdCategory = await _categoryRepository.CreateAsync(category);
                var categoryDto = _mapper.Map<CategoryDto>(createdCategory);
                return ServiceResponse<CategoryDto>.SuccessResult(categoryDto, 200, "Category Created Successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.Failure($"Failed to create category: {ex.Message}", 400);
            }
        }
        public async Task<ServiceResponse<CategoryDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Category ID cannot be empty.");

                var category = await _categoryRepository.GetByIdAsync(id);

                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ServiceResponse<CategoryDto>.SuccessResult(categoryDto, 200, "Category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.Failure($"Failed to retrieve category: {ex.Message}", 400);
            }

        }

        public async Task<ServiceResponse<CategoryDto>> GetcategoryNameAsync(CategoryEnum categoryName)
        {
            try
            {
                if (!Enum.IsDefined(typeof(CategoryEnum), categoryName))
                    throw new UserFriendlyException("Invalid category name specified.");

                var category = await _categoryRepository.GetByCategoryNameAsync(categoryName);

                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ServiceResponse<CategoryDto>.SuccessResult(categoryDto, 200, "Category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.Failure($"Failed to retrieve category: {ex.Message}", 400);
            }
        }
        
        public async Task<ServiceResponse<CategoryPagedResultDto>> GetPagedListAsync(CategoryFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Filter input cannot be null.");
                }

                var query = await _categoryRepository.GetAllAsync();

                // Apply filters
                if (input.CategoryName.HasValue && !string.IsNullOrWhiteSpace(input.CategoryName.Value.ToString()))
                {
                    query = query.Where(c => c.CategoryName == input.CategoryName).ToList();
                }
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(c => c.IsDeleted == input.IsDeleted.Value).ToList();
                }
                else
                {
                    query = query.Where(c => !c.IsDeleted).ToList();
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(c => c.CreationTime >= input.CreationTimeStart.Value).ToList();
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(c => c.CreationTime <= input.CreationTimeEnd.Value).ToList();
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(c => c.LastModificationTime >= input.LastModificationTimeStart.Value).ToList();
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(c => c.LastModificationTime <= input.LastModificationTimeEnd.Value).ToList();
                }

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(input.Sorting))
                {
                    var sortParts = input.Sorting.Trim().Split(' ');
                    var propertyName = sortParts[0];
                    var isDescending = sortParts.Length > 1 && sortParts[1].ToUpper() == "DESC";

                    switch (propertyName.ToLower())
                    {
                        case "name":
                            query = isDescending ? query.OrderByDescending(c => c.CategoryName).ToList() : query.OrderBy(c => c.CategoryName).ToList();
                            break;
                        case "creationtime":
                            query = isDescending ? query.OrderByDescending(c => c.CreationTime).ToList() : query.OrderBy(c => c.CreationTime).ToList();
                            break;
                        case "lastmodificationtime":
                            query = isDescending ? query.OrderByDescending(c => c.LastModificationTime).ToList() : query.OrderBy(c => c.LastModificationTime).ToList();
                            break;
                        default:
                            query = query.OrderBy(c => c.CategoryName).ToList();
                            break;
                    }
                }
                else
                {
                    query = query.OrderBy(c => c.CategoryName).ToList();
                }

                // Apply pagination
                var totalCount = query.LongCount();
                var items = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
                var itemDtos = _mapper.Map<List<CategoryDto>>(items);

                var result = new CategoryPagedResultDto(totalCount, itemDtos);
                return ServiceResponse<CategoryPagedResultDto>.SuccessResult(result, 200, "Paged categories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryPagedResultDto>.Failure($"Failed to retrieve paged categories: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateCategoryDto input)
        {
            try
            {
                if (input == null)
                    throw new UserFriendlyException("Input cannot be null.");

                if (id == Guid.Empty)
                    throw new UserFriendlyException("Category ID cannot be empty.");
                if (!Enum.IsDefined(typeof(CategoryEnum), input.CategoryName))
                    throw new UserFriendlyException("Invalid category name specified.");
                    
                var category = await _categoryRepository.GetByIdAsync(id);
                _mapper.Map(input, category);
                await _categoryRepository.UpdateAsync(category);
                var updatedCategoryDto = _mapper.Map<CategoryDto>(category);
                return ServiceResponse.SuccessResult(200, "Category updated successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to update category: {ex.Message}", 400);
            }
        }
        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Category ID cannot be empty.");

                await _categoryRepository.SoftDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Category soft-deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to delete category: {ex.Message}", 500);
            }
        }
        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Category ID cannot be empty.");

                await _categoryRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Category permanently deleted successfully.");
            }
        catch (BusinessException ex){
            return ServiceResponse.Failure(ex.Message, 400);
        }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete category: {ex.Message}", 400);
            }
        }
        public async Task<ServiceResponse> RestoreCategoryAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Category ID cannot be empty.");

                await _categoryRepository.RestoreCategoryAsync(id);
                return ServiceResponse.SuccessResult(200, "Category restored successfully.");
            }
            catch(BusinessException ex){
                return ServiceResponse.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore category: {ex.Message}", 500);
            }
        }
        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _categoryRepository.GetAllAsync();

                if (!includeDeleted)
                {
                    query = query.Where(c => !c.IsDeleted).ToList();
                }

                int count = query.Count();
                return ServiceResponse<int>.SuccessResult(count, 200, "Category count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve category count: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<List<CategoryLookupDto>>> GetLookupAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                var lookupDtos = _mapper.Map<List<CategoryLookupDto>>(categories);
                return ServiceResponse<List<CategoryLookupDto>>.SuccessResult(lookupDtos, 200, "Category lookup retrieved successfully.");
            }
            catch(BusinessException ex){
                return ServiceResponse<List<CategoryLookupDto>>.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<CategoryLookupDto>>.Failure($"Failed to retrieve category lookup: {ex.Message}", 400);
            }
        }

        public Task<ServiceResponse<CategoryDto>> GetByCategoryNameAsync(CategoryEnum categoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<CategoryDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _categoryRepository.GetAllAsync();
                var categories = includeDeleted
                    ? query
                    : await _categoryRepository.GetAllAsync();

                var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
                return ServiceResponse<List<CategoryDto>>.SuccessResult(categoryDtos, 200, "Categories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<CategoryDto>>.Failure($"Failed to retrieve categories: {ex.Message}", 500);
            }
        }

        // Task<ServiceResponse> ICategoryService.UpdateAsync(Guid id, UpdateCategoryDto input)
        // {
        //     throw new NotImplementedException();
        // }
    }
}