using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using SkillMatrixManagement.Application.Contracts.Admin;
using SkillMatrixManagement.Domain;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp;
using SkillMatrixManagement.Repositories;

namespace SkillMatrixManagement.Application.Admin
{
    public class AppAdminAssignRoleService : ApplicationService, IAdminUserAppService
    {
        private readonly ICustomUserRepository _customUserRepository;
        private readonly IdentityUserManager _userManager;
        private readonly IIdentityRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public AppAdminAssignRoleService(
            ICustomUserRepository customUserRepository,
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository,IUserRepository userRepository)
        {
            _customUserRepository = customUserRepository;
            _userManager = userManager;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task<List<CustomUserDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _customUserRepository.GetListAsync();
                var userDtos = new List<CustomUserDto>();

                foreach (var user in users)
                {
                    var identityUser = await _userManager.FindByIdAsync(user.IdentityUserId.ToString());
                    string roleName = null;

                    if (identityUser != null)
                    {
                        var roles = await _userManager.GetRolesAsync(identityUser);
                        roleName = roles.FirstOrDefault();
                    }

                    userDtos.Add(new CustomUserDto
                    {
                        IdentityUserId = user.IdentityUserId,
                        UserName = user.UserName,
                        Email = user.Email,
                        IsActive = user.IsActive,
                        RoleName = roleName
                    });
                }

                return userDtos;
            }
            catch (Exception ex)
            {
                throw new BusinessException(
                    "INTERNAL_SERVER_ERROR",
                    "An error occurred while retrieving users: " + ex.Message);
            }
        }

        public async Task<ServiceResponse> AssignRoleAndActivateAsync(Guid identityUserId, string roleName)
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(roleName))
                {
                    return ServiceResponse.Failure(
                        "Role name cannot be empty.",
                        "INVALID_ROLE_NAME",
                        400);
                }

                // Find the user in CustomUsers
                var customUser = await _customUserRepository.FindByIdentityUserIdAsync(identityUserId);
                if (customUser == null)
                {
                    return ServiceResponse.Failure(
                        $"User with IdentityUserId {identityUserId} not found in CustomUsers.",
                        SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND,
                        404);
                }

                // Find the role in AbpRoles
                var role = await _roleRepository.FindByNormalizedNameAsync(roleName.ToUpper());
                if (role == null)
                {
                    return ServiceResponse.Failure(
                        $"Role {roleName} not found.",
                        "ROLE_NOT_FOUND",
                        404);
                }

                // Check if user exists in AbpUsers
                var identityUser = await _userManager.FindByIdAsync(identityUserId.ToString());
                if (identityUser == null)
                {
                    return ServiceResponse.Failure(
                        $"User with ID {identityUserId} not found in AbpUsers.",
                        SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND,
                        404);
                }

                // Remove existing roles
                var currentRoles = await _userManager.GetRolesAsync(identityUser);
                if (currentRoles.Any())
                {
                    var removeResult = await _userManager.RemoveFromRolesAsync(identityUser, currentRoles);
                    if (!removeResult.Succeeded)
                    {
                        var errors = removeResult.Errors.Select(e => e.Description).ToList();
                        return ServiceResponse.Failure(
                            $"Failed to remove existing roles.",
                            errors,
                            400);
                    }
                }

                // Assign the new role
                var addResult = await _userManager.AddToRoleAsync(identityUser, roleName);
                if (!addResult.Succeeded)
                {
                    var errors = addResult.Errors.Select(e => e.Description).ToList();
                    return ServiceResponse.Failure(
                        $"Failed to assign role {roleName}.",
                        errors,
                        400);
                }

                // Activate the user in CustomUsers
                if (!customUser.IsActive)
                {
                    customUser.IsActive = true;
                    await _customUserRepository.UpdateAsync(customUser);
                }

                return ServiceResponse.SuccessResult(
                    200,
                    $"Role {roleName} assigned and user activated successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(
                    "An error occurred while assigning role and activating user.",
                    "INTERNAL_SERVER_ERROR",
                    500);
            }
        }

        public async Task<ServiceResponse> SoftDeleteUserAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return ServiceResponse.Failure(
                        "Email cannot be empty.",
                        "INVALID_EMAIL",
                        400);
                }

                // Find AbpUser by Email
                var abpUser = await _userManager.FindByEmailAsync(email);
                if (abpUser == null)
                {
                    return ServiceResponse.Failure(
                        $"User with email {email} not found in AbpUsers.",
                        SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND,
                        404);
                }

                // Find CustomUser by Email
                var customUser = await _customUserRepository.FindByEmailAsync(email);
                if (customUser == null)
                {
                    return ServiceResponse.Failure(
                        $"User with email {email} not found in CustomUsers.",
                        SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND,
                        404);
                }

                // Check AppUser existence by Email
                var appUsers = await _userRepository.GetListAsync();
                var appUser = appUsers.FirstOrDefault(u => u.Email == email);

                if (appUser != null)
                {
                    // Soft delete AppUser
                    await _userRepository.SoftDeleteAsync(appUser.Id);
                }
                else
                {
                    // Clear roles from AbpUserRoles
                    var currentRoles = await _userManager.GetRolesAsync(abpUser);
                    if (currentRoles.Any())
                    {
                        var removeResult = await _userManager.RemoveFromRolesAsync(abpUser, currentRoles);
                        if (!removeResult.Succeeded)
                        {
                            var errors = removeResult.Errors.Select(e => e.Description).ToList();
                            return ServiceResponse.Failure(
                                $"Failed to remove roles from AbpUserRoles: {string.Join(", ", errors)}",
                                "ROLE_REMOVAL_FAILED",
                                400);
                        }
                    }
                }

                // Soft delete CustomUser
                await _customUserRepository.SoftDeleteAsync(customUser.Id);

                // Soft delete AbpUser
                abpUser.IsDeleted = true;
                var updateResult = await _userManager.UpdateAsync(abpUser);
                if (!updateResult.Succeeded)
                {
                    var errors = updateResult.Errors.Select(e => e.Description).ToList();
                    return ServiceResponse.Failure(
                        $"Failed to soft delete user in AbpUsers: {string.Join(", ", errors)}",
                        "USER_DELETION_FAILED",
                        400);
                }

                return ServiceResponse.SuccessResult(
                    200,
                    "User soft deleted successfully from all relevant tables.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(
                    $"Failed to soft delete user: {ex.Message}",
                    "INTERNAL_SERVER_ERROR",
                    500);
            }
        }

        public async Task<ServiceResponse> ChangeUserStatusAsync(Guid identityUserId, bool isActive)
        {
            try
            {
                // Find CustomUser
                var customUser = await _customUserRepository.FindByIdentityUserIdAsync(identityUserId);
                if (customUser == null)
                {
                    return ServiceResponse.Failure(
                        $"User with IdentityUserId {identityUserId} not found in CustomUsers.",
                        SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND,
                        404);
                }

                // Update status if different
                if (customUser.IsActive != isActive)
                {
                    customUser.IsActive = isActive;
                    await _customUserRepository.UpdateAsync(customUser);
                }

                return ServiceResponse.SuccessResult(
                    200,
                    $"User status updated to {(isActive ? "active" : "inactive")} successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(
                    "An error occurred while updating user status.",
                    "INTERNAL_SERVER_ERROR",
                    500);
            }
        }
    }
}