using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppDepartmentInternalRoleService : ApplicationService, IDepartmentInternalRoleService
    {
        private readonly IDepartmentInternalRoleRepository _departmentInternalRoleRepository;
        private readonly IMapper _mapper;

        public AppDepartmentInternalRoleService(IDepartmentInternalRoleRepository departmentInternalRoleRepository, IMapper mapper)
        {
            _departmentInternalRoleRepository = departmentInternalRoleRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _departmentInternalRoleRepository.GetAllAsync();
                if (!includeDeleted)
                {
                    query = query.Where(r => !r.IsDeleted).ToList();
                }
                return ServiceResponse<int>.SuccessResult(query.Count, 200, "Count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Error: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<DepartmentInternalRoleDto>> CreateAsync(CreateDepartmentInternalRoleDto input)
        {
            try
            {
                if (input == null)
                    throw new UserFriendlyException("Input cannot be null.");
                if (!Enum.IsDefined(typeof(DepartmentRoleEnum), input.RoleName))
                    throw new UserFriendlyException("Invalid Role Name.");

                var role = _mapper.Map<DepartmentInternalRole>(input);
                var createdRole = await _departmentInternalRoleRepository.CreateAsync(role);
                var roleDto = _mapper.Map<DepartmentInternalRoleDto>(createdRole);
                return ServiceResponse<DepartmentInternalRoleDto>.SuccessResult(roleDto, 200, "Role created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<DepartmentInternalRoleDto>.Failure($"Error: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Department internal role id cannot be empty.");

                await _departmentInternalRoleRepository.DeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Role deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<List<DepartmentInternalRoleDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _departmentInternalRoleRepository.GetAllAsync();
                if (!includeDeleted)
                {
                    query = query.Where(r => !r.IsDeleted).ToList();
                }

                var roles = _mapper.Map<List<DepartmentInternalRoleDto>>(query);
                return ServiceResponse<List<DepartmentInternalRoleDto>>.SuccessResult(roles, 200, "Roles retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<DepartmentInternalRoleDto>>.Failure($"Error: {ex.Message}", 400);
            }
        }


        public async Task<ServiceResponse<DepartmentInternalRoleDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Department internal role id cannot be empty.");

                var role = await _departmentInternalRoleRepository.GetByIdAsync(id);

                var roleDto = _mapper.Map<DepartmentInternalRoleDto>(role);
                return ServiceResponse<DepartmentInternalRoleDto>.SuccessResult(roleDto, 200, "Role retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<DepartmentInternalRoleDto>.Failure($"Error: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<List<DepartmentInternalRoleLookupDto>>> GetLookupAsync()
        {
            try
            {
                var roles = await _departmentInternalRoleRepository.GetAllAsync();
                var lookupDtos = _mapper.Map<List<DepartmentInternalRoleLookupDto>>(roles);
                return ServiceResponse<List<DepartmentInternalRoleLookupDto>>.SuccessResult(lookupDtos, 200, "Role lookup retrieved successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<List<DepartmentInternalRoleLookupDto>>.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<DepartmentInternalRoleLookupDto>>.Failure($"Failed to retrieve role lookup: {ex.Message}", 400);
            }
        }
        public async Task<ServiceResponse<DepartmentInternalRolePagedResultDto>> GetPagedListAsync(DepartmentInternalRoleFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                var query = await _departmentInternalRoleRepository.GetAllAsync();
                // Apply filters
                if (input.RoleName.HasValue && !string.IsNullOrWhiteSpace(input.RoleName.Value.ToString()))
                {
                    query = query.Where(r => r.RoleName == input.RoleName.Value).ToList();
                }
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(r => r.IsDeleted == input.IsDeleted.Value).ToList();
                }
                else
                {
                    query = query.Where(r => !r.IsDeleted).ToList();
                }

                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(r => r.CreationTime >= input.CreationTimeStart.Value).ToList();
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(r => r.CreationTime <= input.CreationTimeEnd.Value).ToList();
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(r => r.LastModificationTime >= input.LastModificationTimeStart.Value).ToList();
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(r => r.LastModificationTime <= input.LastModificationTimeEnd.Value).ToList();
                }
                // Sorting
                if (!string.IsNullOrWhiteSpace(input.Sorting))
                {
                    query = input.Sorting switch
                    {
                        "roleName" => query.OrderBy(r => r.RoleName).ToList(),
                        "roleName desc" => query.OrderByDescending(r => r.RoleName).ToList(),
                        "creationTime" => query.OrderBy(r => r.CreationTime).ToList(),
                        "creationTime desc" => query.OrderByDescending(r => r.CreationTime).ToList(),
                        "lastModificationTime" => query.OrderBy(r => r.LastModificationTime).ToList(),
                        "lastModificationTime desc" => query.OrderByDescending(r => r.LastModificationTime).ToList(),
                        _ => query.ToList()
                    };
                }
                else
                {
                    query = query.OrderByDescending(r => r.CreationTime).ToList();
                }

                var totalCount = query.Count();

                var items = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
                var roleDtos = _mapper.Map<List<DepartmentInternalRoleDto>>(items);

                var result = new DepartmentInternalRolePagedResultDto(totalCount, roleDtos);
                return ServiceResponse<DepartmentInternalRolePagedResultDto>.SuccessResult(result, 200, "Paged roles retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<DepartmentInternalRolePagedResultDto>.Failure($"Error: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Department internal role id cannot be empty.");
                await _departmentInternalRoleRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Role permanently deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failde to permanently delete role. {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> RestoreDepartmentInternalRoleAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new UserFriendlyException("Department internal role id cannot be empty.");
                await _departmentInternalRoleRepository.RestoreDepartmentInternalRoleAsync(id);
                return ServiceResponse.SuccessResult(200, "Role Restored successfully");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore role. {ex.Message}", 400);
            }
        }

        public Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentInternalRoleDto input)
        {
            throw new NotImplementedException();
        }

        // public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateDepartmentInternalRoleDto input)
        // {
        //     try
        //     {
        //         if (input == null)
        //             throw new UserFriendlyException("Invalid input");

        //         if (id == Guid.Empty)
        //             throw new UserFriendlyException("Role id cannot be empty");

        //         if (!Enum.IsDefined(typeof(DepartmentRoleEnum), input.RoleName))
        //             throw new UserFriendlyException("Invalid role name specified");

        //         var role = await _departmentInternalRoleRepository.GetByIdAsync(id);
        //         _mapper.Map(input, role);
        //         await _departmentInternalRoleRepository.UpdateAsync(role);
        //         var updatedRoleDto = _mapper.Map<DepartmentInternalRoleDto>(role);
        //         return ServiceResponse.SuccessResult(200, "Role updated successfully");

        //     }
        //     catch (Exception ex)
        //     {
        //         return ServiceResponse.Failure($"Failed to update role: {ex.Message}", 400);
        //     }
        // }
    }
}
