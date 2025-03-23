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
        Task<ServiceResponse<List<CategoryDto>>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false);
        Task<ServiceResponse<object>> UpdateAsync(Guid id, UpdateCategoryDto input);
        Task<ServiceResponse<object>> DeleteAsync(Guid id);
        Task<ServiceResponse<object>> PermanentDeleteAsync(Guid id);
        Task<ServiceResponse<object>> RestoreCategoryAsync(Guid id);
        Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false);
    }
}
