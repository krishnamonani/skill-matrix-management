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
using Volo.Abp.Identity;

namespace SkillMatrixManagement.Services
{
    public class AppUserService : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentInternalRoleRepository _roleInternalRepository;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IMapper _mapper;

        public AppUserService(IUserRepository userRepository,
                              IDepartmentRepository departmentRepository, 
                              IRoleRepository roleRepository, 
                              IDepartmentInternalRoleRepository roleInternalRepository, 
                              IIdentityUserRepository identityUserRepository, 
                              IdentityUserManager identityUserManager, 
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _roleRepository = roleRepository;
            _roleInternalRepository = roleInternalRepository;
            _identityUserRepository = identityUserRepository;
            _identityUserManager = identityUserManager;
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
                if (string.IsNullOrEmpty(input.UserName))
                {
                    throw new UserFriendlyException("UserName does not exist");
                }
                if(input.Experience > 100 || input.Experience < 0)
                {
                    throw new UserFriendlyException("Experience should be greated than equals to 0 and less than 100 Years");
                }
                if(input.PhoneNumber.Contains(' '))
                {
                    throw new UserFriendlyException("Phone number should not contain any space.");
                }
                if(input.UserName.Contains(' '))
                {
                    throw new UserFriendlyException("User name should not contain any space.");
                }
                if(input.PhoneNumber.Length > 10 || input.PhoneNumber.Length < 0)
                {
                    throw new UserFriendlyException("Invalid Phone number");
                }

                var query = await _userRepository.WithDetailsAsync();
                if (await query.AnyAsync(u => u.Email.ToLower() == input.Email.ToLower() && !u.IsDeleted))
                {
                    throw new UserFriendlyException($"A user with email '{input.Email}' already exists.");
                }

                if(await query.AnyAsync(u => u.UserName == input.UserName && !u.IsDeleted))
                {
                    throw new UserFriendlyException($"A User with userNmae '{input.UserName}' already exists");
                }
                
                if(input.FirstName.Contains(' ') || input.LastName.Contains(' '))
                {
                    throw new UserFriendlyException("FirstName and Lastname should not contain any space!");
                }

                var abpUsers = await _identityUserRepository.GetListAsync();
                if(!(abpUsers.Any(user => user.UserName == input.UserName && user.Email.ToUpper() == input.Email.ToUpper())))
                {
                    throw new Exception($"{input.UserName} or {input.Email} is not registered!");
                }

                var user = new User()
                {
                    FirstName        = input.FirstName,
                    LastName         = input.LastName,
                    Email            = input.Email,
                    UserName         = input.UserName,
                    Experience       = input.Experience,
                    PhoneNumber      = input.PhoneNumber,
                    RoleId           = input.RoleId,
                    DepartmentId     = input.DepartmentId,
                    InternalRoleId   = input.InternalRoleId,
                    IsAvailable      = input.IsAvailable,
                    ProfilePhoto     = input.ProfilePhoto
                };

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

                var userEmail = (await _userRepository.GetByIdAsync(id)).Email;
                var abpUser   = await _identityUserManager.FindByEmailAsync(userEmail);

                if (abpUser == null) return ServiceResponse.Failure("User not found!", 400);
                await _identityUserRepository.DeleteAsync(abpUser.Id, autoSave: true);

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

                var departments = await _departmentRepository.GetAllAsync();
                var roles = await _roleRepository.GetAllAsync();
                var internalRoles = await _roleInternalRepository.GetAllRolesAsync();

                foreach (var user in users)
                {
                    var department = departments.Where(dept => dept.Id == user.DepartmentId).FirstOrDefault();
                    user.Department = department;

                    var role = roles.Where(role => role.Id == user.RoleId).FirstOrDefault();
                    user.Role = role ?? throw new Exception("User should have a role, Role not found!");

                    var internaleRole = internalRoles.Where(internalRole => internalRole.Id == user.InternalRoleId).FirstOrDefault();
                    user.InternalRole = internaleRole;
                }

                var userDtos = _mapper.Map<List<UserDto>>(users);
                return ServiceResponse<List<UserDto>>.SuccessResult(userDtos, 200, "Users retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<UserDto>>.Failure($"Failed to retrieve users: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<UserDto>> GetByUserNameOrEmailAsync(string userNameOrEmail)
        {
            if (string.IsNullOrEmpty(userNameOrEmail)) throw new Exception("Usernamae or Email is empty");


            // checking for user exist in the db or not
            var users = await _userRepository.GetAllAsync();
            var user  = users.Where(u => u.Email.ToUpper() == userNameOrEmail.ToUpper()).FirstOrDefault();

            if (user == null)
            {
                user = users.Where(u => u.UserName == userNameOrEmail).FirstOrDefault();
                if (user == null) return ServiceResponse<UserDto>.Failure("User does not exist", 400);
            }

            // performing lazy loading
            if(user.DepartmentId != null)
            {
                user.Department = await _departmentRepository.GetByIdAsync(user.DepartmentId ?? Guid.NewGuid());

            } 
            else
            {
                user.Department = null;
            }

            if(user.InternalRoleId != null)
            {
                user.InternalRole = await _roleInternalRepository.GetByIdAsync(user.InternalRoleId ?? Guid.NewGuid());
            }
            else
            {
                user.InternalRole = null;
            }

             user.Role = await _roleRepository.GetByIdAsync(user.RoleId);

            return ServiceResponse<UserDto>.SuccessResult(_mapper.Map<UserDto>(user), 200);
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

                var department = await _departmentRepository.GetByIdAsync(user.DepartmentId ?? Guid.NewGuid());
                user.Department = department;

                var role = await _roleRepository.GetByIdAsync(user.RoleId);
                user.Role = role;

                var internaleRole = await _roleInternalRepository.GetByIdAsync(user.InternalRoleId ?? Guid.NewGuid());
                user.InternalRole = internaleRole;
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
                        case "username":
                            query = isDescending ? query.OrderByDescending(u => u.UserName) : query.OrderBy(u => u.UserName);
                            break;
                        case "experience":
                            query = isDescending ? query.OrderByDescending(u => u.Experience) : query.OrderBy(u => u.Experience);
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

                if(input.UserName.Contains(' '))
                {
                    throw new UserFriendlyException("UserName does not contains any space");
                }

                if (input.FirstName.Contains(' ') || input.LastName.Contains(' '))
                {
                    throw new UserFriendlyException("FirstName and Lastname should not contain any space!");
                }

                var user = await _userRepository.GetByIdAsync(id);
                if (user.IsDeleted)
                {
                    throw new UserFriendlyException("Cannot update a deleted user.");
                }

                var query = await _userRepository.WithDetailsAsync();
                if (await query.AnyAsync(u => u.Email.ToLower() == input.Email.ToLower() && u.Id != id && !u.IsDeleted))
                {
                    throw new UserFriendlyException($"A user with email '{input.Email}' already exists.");
                }

                if (await query.AnyAsync(u => u.UserName == input.UserName && u.Id != id && !u.IsDeleted))
                {
                    throw new UserFriendlyException($"A user with UserName '{input.UserName}' already exists.");
                }


                user.FirstName   = input.FirstName;
                user.LastName    = input.LastName;
                user.Email       = input.Email; // for now it is not updateable by frontend
                user.UserName    = input.UserName; // for now it is not updateable by frontend
                user.PhoneNumber = input.PhoneNumber;
                user.Experience  = input.Experience;
                user.RoleId      = input.RoleId;

                // optional fields
                user.DepartmentId   = input.DepartmentId;
                user.InternalRoleId = input.InternalRoleId;
                user.ProfilePhoto   = input.ProfilePhoto;

                user.IsAvailable = input.IsAvailable; // default false

                await _userRepository.UpdateAsync(user);
                return ServiceResponse.SuccessResult(200, "User updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to update user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<string[]>> GetUserNameAndEmailByUserNameOrEmail(string userNameOrEmail)
        {
            var user = await _identityUserRepository.FindByNormalizedEmailAsync(userNameOrEmail.ToUpper());
            if(user == null)
            {   
                user = await _identityUserRepository.FindByNormalizedUserNameAsync(userNameOrEmail.ToUpper());
                if (user == null) return ServiceResponse<string[]>.Failure("User not found", 404);
            }
            return ServiceResponse<string[]>.SuccessResult(new string[] {user.UserName, user.Email}, 200);
        }

        public async Task<ServiceResponse<UserDto>> CreateOrUpdateUserAsync(CreateUserDto input)
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
                if (string.IsNullOrWhiteSpace(input.UserName))
                {
                    throw new UserFriendlyException("Username cannot be empty.");
                }
                if (input.RoleId == Guid.Empty)
                {
                    throw new UserFriendlyException("Role ID cannot be empty.");
                }

                if (input.FirstName.Contains(' ') || input.LastName.Contains(' ')) return ServiceResponse<UserDto>.Failure("Firstname or the lastname should not contain any space between", 400);
                if (input.UserName.Contains(' ')) return ServiceResponse<UserDto>.Failure("UserName should not contain any space.", 400);

                var abpUsers = await _identityUserRepository.GetListAsync();
                var abpUserByEmail = abpUsers.Where(u => u.Email.ToUpper() == input.Email.ToUpper()).FirstOrDefault() ?? throw new Exception($"Somthing went wrong! The {input.Email} is not registered.");
                var abpUserbyUserName = abpUsers.Where(u => u.UserName == input.UserName).FirstOrDefault() ?? throw new Exception($"Something went wrong! The {input.UserName} is not registered.");

                var query = await _userRepository.WithDetailsAsync();
                var existingUser = await query.FirstOrDefaultAsync(u => (u.Email.ToUpper() == input.Email.ToUpper() || u.UserName == input.UserName)  && !u.IsDeleted);


                if (existingUser != null)
                {
                    if (await query.AnyAsync(user => (user.UserName == input.UserName) && user.Id != existingUser.Id && !user.IsDeleted))
                    {
                        throw new Exception($"{input.UserName} already exist");
                    } 
                    
                    if (await query.AnyAsync(user => (user.Email.ToLower() == input.Email.ToLower()) && user.Id != existingUser.Id && !user.IsDeleted))
                    {
                        throw new Exception($"{input.Email} already exist");
                    }

                    var updateUserDtoObj = _mapper.Map<UpdateUserDto>(input);
                    var serviceResponse = await UpdateAsync(existingUser.Id, updateUserDtoObj);
                    if (!serviceResponse.Success)
                    {
                        return ServiceResponse<UserDto>.Failure(serviceResponse.ErrorMessage ?? "Something wrong happen while updating", serviceResponse.StatusCode);
                    }
                    var updatedUserDto = _mapper.Map<UserDto>(existingUser);
                    return ServiceResponse<UserDto>.SuccessResult(updatedUserDto, 200, "User updated successfully.");
                }

                var user = new User()
                {
                    FirstName        = input.FirstName,
                    LastName         = input.LastName,
                    Email            = input.Email,
                    UserName         = input.UserName,
                    Experience       = input.Experience,
                    PhoneNumber      = input.PhoneNumber,
                    RoleId           = input.RoleId,
                    DepartmentId     = input.DepartmentId,
                    InternalRoleId   = input.InternalRoleId,
                    IsAvailable      = input.IsAvailable,
                    ProfilePhoto     = input.ProfilePhoto
                };

                var createdUser = await _userRepository.CreateAsync(user);
                var userDto = _mapper.Map<UserDto>(createdUser);
                return ServiceResponse<UserDto>.SuccessResult(userDto, 201, "User created successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserDto>.Failure($"Failed to create or update user: {ex.Message}", 500);
            }
        }
 
    }
}