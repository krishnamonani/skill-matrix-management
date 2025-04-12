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

namespace SkillMatrixManagement.Application.Admin
{
    public class AppAdminAssignRoleService : ApplicationService, IAdminUserAppService
    {
        private readonly ICustomUserRepository _customUserRepository;
        private readonly IIdentityRoleRepository _roleRepository;
        private readonly IdentityUserManager _userManager;

        public AppAdminAssignRoleService(
            ICustomUserRepository customUserRepository,
            IIdentityRoleRepository roleRepository,
            IdentityUserManager userManager)
        {
            _customUserRepository = customUserRepository;
            _roleRepository = roleRepository;
            _userManager = userManager;
        }

        public async Task<List<CustomUserDto>> GetAllUsersAsync()
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

        public async Task<ServiceResponse> AssignRoleAndActivateAsync(Guid identityUserId, string roleName)
        {
            // Validate input
            if (string.IsNullOrEmpty(roleName))
            {
                return ServiceResponse.Failure("Role name cannot be empty.", "INVALID_ROLE_NAME", 400);
            }

            // Find the user in CustomUsers
            var customUser = await _customUserRepository.FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
            if (customUser == null)
            {
                return ServiceResponse.Failure($"User with IdentityUserId {identityUserId} not found in CustomUsers.", "USER_NOT_FOUND", 404);
            }

            // Find the role in AbpRoles
            var role = await _roleRepository.FindByNormalizedNameAsync(roleName.ToUpper());
            if (role == null)
            {
                return ServiceResponse.Failure($"Role {roleName} not found.", "ROLE_NOT_FOUND", 404);
            }

            // Check if user exists in AbpUsers
            var identityUser = await _userManager.FindByIdAsync(identityUserId.ToString());
            if (identityUser == null)
            {
                return ServiceResponse.Failure($"User with ID {identityUserId} not found in AbpUsers.", "USER_NOT_FOUND", 404);
            }

            // Remove existing roles
            var currentRoles = await _userManager.GetRolesAsync(identityUser);
            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(identityUser, currentRoles);
                if (!removeResult.Succeeded)
                {
                    var errors = removeResult.Errors.Select(e => e.Description).ToList();
                    return ServiceResponse.Failure($"Failed to remove existing roles.", errors, 400);
                }
            }

            // Assign the new role
            var addResult = await _userManager.AddToRoleAsync(identityUser, roleName);
            if (!addResult.Succeeded)
            {
                var errors = addResult.Errors.Select(e => e.Description).ToList();
                return ServiceResponse.Failure($"Failed to assign role {roleName}.", errors, 400);
            }

            // Activate the user in CustomUsers
            if (!customUser.IsActive)
            {
                customUser.IsActive = true;
                await _customUserRepository.UpdateAsync(customUser);
            }

            return ServiceResponse.SuccessResult(200, $"Role {roleName} assigned and user activated successfully.");
        }
    }
}