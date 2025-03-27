using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.UserDTO;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppUserService : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AppUserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _userRepository.WithDetailsAsync();
                if (!includeDeleted)
                {
                    query = query.Where(u => !u.IsDeleted);
                }
                var count = await query.CountAsync();
                return ServiceResponse<int>.SuccessResult(count, 200, "Count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve count: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<UserDto>> CreateAsync(CreateUserDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(input.FirstName))
                {
                    throw new UserFriendlyException("First name cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(input.LastName))
                {
                    throw new UserFriendlyException("Last name cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(input.Email))
                {
                    throw new UserFriendlyException("Email cannot be empty.");
                }
                if (input.RoleId == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                var query = await _userRepository.WithDetailsAsync();
                if (await query.AnyAsync(u => u.Email == input.Email && !u.IsDeleted))
                {
                    throw new UserFriendlyException($"A user with email '{input.Email}' already exists.");
                }

                var user = _mapper.Map<User>(input);
                var createdUser = await _userRepository.CreateAsync(user);
                var userDto = _mapper.Map<UserDto>(createdUser);
                return ServiceResponse<UserDto>.SuccessResult(userDto, 201, "User created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserDto>.Failure($"Failed to create user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("User ID cannot be empty.");
                }

                await _userRepository.SoftDeleteAsync(id); 
                return ServiceResponse.SuccessResult(200, "User deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to delete user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _userRepository.WithDetailsAsync();
                List<User> users;

                if (includeDeleted)
                {
                    users = await query.IgnoreQueryFilters().ToListAsync();
                }
                else
                {
                    users = await _userRepository.GetAllAsync(); // Repository doesn’t filter by default, so filter here
                    users = users.Where(u => !u.IsDeleted).ToList();
                }

                var userDtos = _mapper.Map<List<UserDto>>(users);
                return ServiceResponse<List<UserDto>>.SuccessResult(userDtos, 200, "Users retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<UserDto>>.Failure($"Failed to retrieve users: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<UserDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("User ID cannot be empty.");
                }

                var user = await _userRepository.GetByIdAsync(id);
                if (user.IsDeleted)
                {
                    throw new UserFriendlyException("User is deleted.");
                }

                var userDto = _mapper.Map<UserDto>(user);
                return ServiceResponse<UserDto>.SuccessResult(userDto, 200, "User retrieved successfully.");
            }
            catch (Exception ex)    
            {
                return ServiceResponse<UserDto>.Failure($"Failed to retrieve user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<UserLookupDto>>> GetLookupAsync()
        {
            try
            {
                var query = await _userRepository.WithDetailsAsync();
                var users = await query.Where(u => !u.IsDeleted).ToListAsync();
                var lookupDtos = _mapper.Map<List<UserLookupDto>>(users);
                return ServiceResponse<List<UserLookupDto>>.SuccessResult(lookupDtos, 200, "User lookup retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<UserLookupDto>>.Failure($"Failed to retrieve user lookup: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<UserPagedResultDto>> GetPagedListAsync(UserFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Filter input cannot be null.");
                }

                var query = await _userRepository.WithDetailsAsync();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(input.FirstName))
                {
                    query = query.Where(u => u.FirstName.Contains(input.FirstName));
                }
                if (!string.IsNullOrWhiteSpace(input.LastName))
                {
                    query = query.Where(u => u.LastName.Contains(input.LastName));
                }
                if (!string.IsNullOrWhiteSpace(input.Email))
                {
                    query = query.Where(u => u.Email.Contains(input.Email));
                }
                if (!string.IsNullOrWhiteSpace(input.PhoneNumber))
                {
                    query = query.Where(u => u.PhoneNumber.Contains(input.PhoneNumber));
                }
                if (input.RoleId.HasValue)
                {
                    query = query.Where(u => u.RoleId == input.RoleId.Value);
                }
                if (input.DepartmentId.HasValue)
                {
                    query = query.Where(u => u.DepartmentId == input.DepartmentId.Value);
                }
                if (input.InternalRoleId.HasValue)
                {
                    query = query.Where(u => u.InternalRoleId == input.InternalRoleId.Value);
                }
                if (input.IsAvailable.HasValue)
                {
                    query = query.Where(u => u.IsAvailable == input.IsAvailable.Value);
                }
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(u => u.IsDeleted == input.IsDeleted.Value);
                }
                else
                {
                    query = query.Where(u => !u.IsDeleted);
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(u => u.CreationTime >= input.CreationTimeStart.Value);
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(u => u.CreationTime <= input.CreationTimeEnd.Value);
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(u => u.LastModificationTime >= input.LastModificationTimeStart.Value);
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(u => u.LastModificationTime <= input.LastModificationTimeEnd.Value);
                }

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(input.Sorting))
                {
                    var sortParts = input.Sorting.Trim().Split(' ');
                    var propertyName = sortParts[0];
                    var isDescending = sortParts.Length > 1 && sortParts[1].ToUpper() == "DESC";

                    switch (propertyName.ToLower())
                    {
                        case "firstname":
                            query = isDescending ? query.OrderByDescending(u => u.FirstName) : query.OrderBy(u => u.FirstName);
                            break;
                        case "lastname":
                            query = isDescending ? query.OrderByDescending(u => u.LastName) : query.OrderBy(u => u.LastName);
                            break;
                        case "email":
                            query = isDescending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email);
                            break;
                        case "phonenumber":
                            query = isDescending ? query.OrderByDescending(u => u.PhoneNumber) : query.OrderBy(u => u.PhoneNumber);
                            break;
                        case "creationtime":
                            query = isDescending ? query.OrderByDescending(u => u.CreationTime) : query.OrderBy(u => u.CreationTime);
                            break;
                        case "lastmodificationtime":
                            query = isDescending ? query.OrderByDescending(u => u.LastModificationTime) : query.OrderBy(u => u.LastModificationTime);
                            break;
                        default:
                            query = query.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
                            break;
                    }
                }
                else
                {
                    query = query.OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
                }

                // Apply pagination
                var totalCount = await query.LongCountAsync();
                var items = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
                var itemDtos = _mapper.Map<List<UserDto>>(items);

                var result = new UserPagedResultDto(totalCount, itemDtos);
                return ServiceResponse<UserPagedResultDto>.SuccessResult(result, 200, "Paged users retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserPagedResultDto>.Failure($"Failed to retrieve paged users: {ex.Message}", 200);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("User ID cannot be empty.");
                }

                await _userRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "User permanently deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> RestoreUserAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("User ID cannot be empty.");
                }

                await _userRepository.RestoreUserAsync(id);
                return ServiceResponse.SuccessResult(200, "User restored successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateUserDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Input cannot be null.");
                }
                if (id == Guid.Empty)
                {
                    throw new UserFriendlyException("User ID cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(input.FirstName))
                {
                    throw new UserFriendlyException("First name cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(input.LastName))
                {
                    throw new UserFriendlyException("Last name cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(input.Email))
                {
                    throw new UserFriendlyException("Email cannot be empty.");
                }
                if (input.RoleId == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                var user = await _userRepository.GetByIdAsync(id);
                if (user.IsDeleted)
                {
                    throw new UserFriendlyException("Cannot update a deleted user.");
                }

                var query = await _userRepository.WithDetailsAsync();
                if (await query.AnyAsync(u => u.Email == input.Email && u.Id != id && !u.IsDeleted))
                {
                    throw new UserFriendlyException($"A user with email '{input.Email}' already exists.");
                }

                _mapper.Map(input, user);
                await _userRepository.UpdateAsync(user);
                return ServiceResponse.SuccessResult(200, "User updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to update user: {ex.Message}", 500);
            }
        }
    }
}