using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.CategoryDTO;
using SkillMatrixManagement.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface ICategoryService: IApplicationService
    {
        Task<ServiceResponse<CategoryDto>> CreateAsync(CreateCategoryDto input);
        Task<ServiceResponse<CategoryDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<CategoryDto>> GetByCategoryNameAsync(CategoryEnum categoryName);
        Task<ServiceResponse<List<CategoryDto>>> GetAllAsync(bool includeDeleted = false);
        Task<ServiceResponse<CategoryPagedResultDto>> GetPagedListAsync(CategoryFilterDto input);
        Task<ServiceResponse> UpdateAsync(Guid id, UpdateCategoryDto input);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse> RestoreCategoryAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
        Task<ServiceResponse<List<CategoryLookupDto>>> GetLookupAsync();
    }
}
