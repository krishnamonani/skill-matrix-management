using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.RoleDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SkillMatrixManagement.Services
{
    public class AppRoleService : ApplicationService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private const string GENERAL_ROLE_EXCEPTION_CODE = "ROLE-EXCEPTION-000";

        public AppRoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _roleRepository.WithDetailsAsync();
                if (!includeDeleted)
                {
                    query = query.Where(r => !r.IsDeleted);
                }
                var count = query.Count();
                return ServiceResponse<int>.SuccessResult(count, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve count: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<RoleDto>> CreateAsync(CreateRoleDto input)
        {
            try
            {
                // Validate input
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                if (!Enum.IsDefined(typeof(RoleEnum), input.Name))
                {
                    throw new UserFriendlyException("Invalid role name specified.");
                }

                // creating new role object
                var role = new Role()
                {
                    Name = input.Name
                };

                // Use repository to create
                var createdRole = await _roleRepository.CreateAsync(role);

                // Map back to DTO
                var roleDto = _mapper.Map<RoleDto>(createdRole);
                return ServiceResponse<RoleDto>.SuccessResult(roleDto, 200, "Role Created Successfully");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<RoleDto>.Failure($"Failed to create role: {ex.Message}", 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RoleDto>.Failure($"Failed to create role: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                await _roleRepository.SoftDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Role soft-deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to delete role: {ex.Message}", ex.Code ?? AppRoleService.GENERAL_ROLE_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to delete role: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<RoleDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _roleRepository.WithDetailsAsync();
                var roles = includeDeleted
                    ? await query.IgnoreQueryFilters().ToListAsync()
                    : await _roleRepository.GetAllAsync(); // Repository already filters out deleted by default
                var roleDtos = _mapper.Map<List<RoleDto>>(roles);
                roleDtos = roleDtos.Where(role => role.Name != RoleEnum.ROLE_ADMIN).ToList(); // excluding the admin role
                return ServiceResponse<List<RoleDto>>.SuccessResult(roleDtos, 200, "Roles retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<RoleDto>>.Failure($"Failed to retrieve roles: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<RoleDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                var role = await _roleRepository.GetByIdAsync(id);
                var roleDto = _mapper.Map<RoleDto>(role);
                return ServiceResponse<RoleDto>.SuccessResult(roleDto, 200, "Role retrieved successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<RoleDto>.Failure($"Failed to retrieve role: {ex.Message}", ex.Code ?? AppRoleService.GENERAL_ROLE_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RoleDto>.Failure($"Failed to retrieve role: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<RoleLookupDto>>> GetLookupAsync()
        {
            try
            {
                var roles = await _roleRepository.GetAllAsync(); // Only active roles for lookup
                var lookupDtos = _mapper.Map<List<RoleLookupDto>>(roles);
                lookupDtos = lookupDtos.Where(role => role.Name != RoleEnum.ROLE_ADMIN).ToList(); // excluding the admin role
                return ServiceResponse<List<RoleLookupDto>>.SuccessResult(lookupDtos, 200, "Role lookup retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<RoleLookupDto>>.Failure($"Failed to retrieve role lookup: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<RolePagedResultDto>> GetPagedListAsync(RoleFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Filter input cannot be null.");
                }

                var query = await _roleRepository.WithDetailsAsync();

                // Apply filters
                if (input.Name.HasValue)
                {
                    query = query.Where(r => r.Name == input.Name.Value);
                }
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(r => r.IsDeleted == input.IsDeleted.Value);
                }
                else
                {
                    query = query.Where(r => !r.IsDeleted);
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(r => r.CreationTime >= input.CreationTimeStart.Value);
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(r => r.CreationTime <= input.CreationTimeEnd.Value);
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(r => r.LastModificationTime >= input.LastModificationTimeStart.Value);
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(r => r.LastModificationTime <= input.LastModificationTimeEnd.Value);
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
                            query = isDescending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name);
                            break;
                        case "creationtime":
                            query = isDescending ? query.OrderByDescending(r => r.CreationTime) : query.OrderBy(r => r.CreationTime);
                            break;
                        case "lastmodificationtime":
                            query = isDescending ? query.OrderByDescending(r => r.LastModificationTime) : query.OrderBy(r => r.LastModificationTime);
                            break;
                        default:
                            query = query.OrderBy(r => r.Name);
                            break;
                    }
                }
                else
                {
                    query = query.OrderBy(r => r.Name);
                }

                // Apply pagination
                var totalCount = await query.LongCountAsync();
                var items = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
                var itemDtos = _mapper.Map<List<RoleDto>>(items);

                var result = new RolePagedResultDto(totalCount, itemDtos);
                return ServiceResponse<RolePagedResultDto>.SuccessResult(result, 200, "Paged roles retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<RolePagedResultDto>.Failure($"Failed to retrieve paged roles: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                await _roleRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Role permanently deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete role: {ex.Message}", ex.Code ?? AppRoleService.GENERAL_ROLE_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete role: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> RestoreRoleAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                await _roleRepository.RestoreRoleAsync(id);
                return ServiceResponse.SuccessResult(200, "Role restored successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to restore role: {ex.Message}", ex.Code ?? AppRoleService.GENERAL_ROLE_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore role: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateRoleDto input)
        {
            try
            {
                // Validate input
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }
                if (!Enum.IsDefined(typeof(RoleEnum), input.Name))
                {
                    throw new UserFriendlyException("Invalid role name specified.");
                }

                // Get existing role
                var role = await _roleRepository.GetByIdAsync(id);

                role.Name = input.Name; // only the name can be updateable

                // Update via repository
                await _roleRepository.UpdateAsync(role);

                return ServiceResponse.SuccessResult(200, "Role updated successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure($"Failed to update role: {ex.Message}", ex.Code ?? AppRoleService.GENERAL_ROLE_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to update role: {ex.Message}", 500);
            }
        }
    }
}