using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppDepartmentService : ApplicationService, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private const string GENERAL_DEPARTMENT_EXCEPTION_CODE = "DEPARTMENT-000";

        public AppDepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var count = await _departmentRepository.CountAsync(includeDeleted);
                return ServiceResponse<int>.SuccessResult(count, 200, "Count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve count: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<DepartmentDto>> CreateAsync(CreateDepartmentDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(input.Name))
                {
                    throw new UserFriendlyException("Department name cannot be empty.");
                }

                var department = _mapper.Map<Department>(input);
                var createdDepartment = await _departmentRepository.CreateAsync(department);
                var departmentDto = _mapper.Map<DepartmentDto>(createdDepartment);
                return ServiceResponse<DepartmentDto>.SuccessResult(departmentDto, 201, "Department created successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<DepartmentDto>.Failure($"Failed to create department: {ex.Message}", ex.Code ?? AppDepartmentService.GENERAL_DEPARTMENT_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DepartmentDto>.Failure($"Failed to create department: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Department ID cannot be empty.");
                }

                await _departmentRepository.SoftDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Department soft-deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to delete department: {ex.Message}", ex.Code ?? AppDepartmentService.GENERAL_DEPARTMENT_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to delete department: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<DepartmentDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var departments = await _departmentRepository.GetAllDepartmentsAsync(includeDeleted);
                var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);
                return ServiceResponse<List<DepartmentDto>>.SuccessResult(departmentDtos, 200, "Departments retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<DepartmentDto>>.Failure($"Failed to retrieve departments: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<DepartmentDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Department ID cannot be empty.");
                }

                var department = await _departmentRepository.GetByIdAsync(id);
                var departmentDto = _mapper.Map<DepartmentDto>(department);
                return ServiceResponse<DepartmentDto>.SuccessResult(departmentDto, 200, "Department retrieved successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<DepartmentDto>.Failure($"Failed to retrieve department: {ex.Message}", ex.Code ?? AppDepartmentService.GENERAL_DEPARTMENT_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DepartmentDto>.Failure($"Failed to retrieve department: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<DepartmentLookupDto>>> GetLookupAsync()
        {
            try
            {
                var departments = await _departmentRepository.GetAllAsync(); // Only active departments
                var lookupDtos = _mapper.Map<List<DepartmentLookupDto>>(departments);
                return ServiceResponse<List<DepartmentLookupDto>>.SuccessResult(lookupDtos, 200, "Department lookup retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<DepartmentLookupDto>>.Failure($"Failed to retrieve department lookup: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<DepartmentPagedResultDto>> GetPagedListAsync(DepartmentFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Filter input cannot be null.");
                }

                var query = await _departmentRepository.WithDetailsAsync();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(input.Name))
                {
                    query = query.Where(d => d.Name.Contains(input.Name));
                }
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(d => d.IsDeleted == input.IsDeleted.Value);
                }
                else
                {
                    query = query.Where(d => !d.IsDeleted); // Default to active departments
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(d => d.CreationTime >= input.CreationTimeStart.Value);
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(d => d.CreationTime <= input.CreationTimeEnd.Value);
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(d => d.LastModificationTime >= input.LastModificationTimeStart.Value);
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(d => d.LastModificationTime <= input.LastModificationTimeEnd.Value);
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
                            query = isDescending ? query.OrderByDescending(d => d.Name) : query.OrderBy(d => d.Name);
                            break;
                        case "creationtime":
                            query = isDescending ? query.OrderByDescending(d => d.CreationTime) : query.OrderBy(d => d.CreationTime);
                            break;
                        case "lastmodificationtime":
                            query = isDescending ? query.OrderByDescending(d => d.LastModificationTime) : query.OrderBy(d => d.LastModificationTime);
                            break;
                        default:
                            query = query.OrderBy(d => d.Name); // Default sorting
                            break;
                    }
                }
                else
                {
                    query = query.OrderBy(d => d.Name); // Default sorting
                }

                // Apply pagination
                var totalCount = await query.LongCountAsync();
                var items = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
                var itemDtos = _mapper.Map<List<DepartmentDto>>(items);

                var result = new DepartmentPagedResultDto(totalCount, itemDtos);
                return ServiceResponse<DepartmentPagedResultDto>.SuccessResult(result, 200, "Paged departments retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<DepartmentPagedResultDto>.Failure($"Failed to retrieve paged departments: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Department ID cannot be empty.");
                }

                await _departmentRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Department permanently deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete department: {ex.Message}", ex.Code ?? AppDepartmentService.GENERAL_DEPARTMENT_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete department: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> RestoreDepartmentAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Department ID cannot be empty.");
                }

                await _departmentRepository.RestoreDepartmentAsync(id);
                return ServiceResponse.SuccessResult(200, "Department restored successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to restore department: {ex.Message}", ex.Code ?? AppDepartmentService.GENERAL_DEPARTMENT_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore department: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Department ID cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(input.Name))
                {
                    throw new UserFriendlyException("Department name cannot be empty.");
                }

                var department = await _departmentRepository.GetByIdAsync(id);
                _mapper.Map(input, department);
                await _departmentRepository.UpdateAsync(department);
                return ServiceResponse.SuccessResult(200, "Department updated successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to update department: {ex.Message}", ex.Code ?? AppDepartmentService.GENERAL_DEPARTMENT_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to update department: {ex.Message}", 500);
            }
        }
    }
}