using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Microsoft.Extensions.Logging;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs;
using SkillMatrixManagement.Domain;
using SkillMatrixManagement.Services;

public class UserStatusService : ApplicationService, IUserStatusService
{
    private readonly IdentityUserManager _userManager;
    private readonly IRepository<CustomUser, Guid> _customUserRepository;
    private readonly ILogger<UserStatusService> _logger;

    // Error Codes (Constants for consistency)
    private const string ERROR_CODE_INACTIVE = "USER_INACTIVE";
    private const string ERROR_CODE_PROFILE_INCOMPLETE = "USER_PROFILE_INCOMPLETE";
    private const string ERROR_CODE_NOT_FOUND = "USER_NOT_FOUND";
    private const string ERROR_CODE_INVALID_INPUT = "INVALID_INPUT";

    public UserStatusService(
        IdentityUserManager userManager,
        IRepository<CustomUser, Guid> customUserRepository,
        ILogger<UserStatusService> logger)
    {
        _userManager = userManager;
        _customUserRepository = customUserRepository;
        _logger = logger;
    }

    public async Task<ServiceResponse<UserRolesDto>> GetCurrentUserStatusAndRolesAsync(string userNameOrEmailAddress)
    {
        // 1. Validate input
        if (string.IsNullOrWhiteSpace(userNameOrEmailAddress))
        {
            _logger.LogWarning("GetCurrentUserStatusAndRolesAsync called with no userNameOrEmailAddress provided.");
            return ServiceResponse<UserRolesDto>.Failure(
                "Username or email address must be provided.",
                ERROR_CODE_INVALID_INPUT,
                (int)HttpStatusCode.BadRequest
            );
        }

        _logger.LogInformation($"Looking up user by userNameOrEmailAddress: {userNameOrEmailAddress}");

        // 2. Find the user by email or username
        IdentityUser abpUser = await _userManager.FindByEmailAsync(userNameOrEmailAddress);
        if (abpUser == null)
        {
            abpUser = await _userManager.FindByNameAsync(userNameOrEmailAddress);
        }

        if (abpUser == null)
        {
            _logger.LogError($"User not found for provided userNameOrEmailAddress: {userNameOrEmailAddress}");
            return ServiceResponse<UserRolesDto>.Failure(
                "User details could not be found.",
                ERROR_CODE_NOT_FOUND,
                (int)HttpStatusCode.NotFound
            );
        }

        var currentUserId = abpUser.Id;
        _logger.LogInformation($"Checking status for user: {abpUser.UserName} (ID: {currentUserId})");

        // 3. Check Custom User Status in ApplicationDb
        var customUser = await _customUserRepository.FirstOrDefaultAsync(cu => cu.IdentityUserId == currentUserId);
        if (customUser == null)
        {
            _logger.LogWarning($"User '{abpUser.UserName}' (ID: {currentUserId}) has no entry in CustomUser table.");
            return ServiceResponse<UserRolesDto>.Failure(
                "User profile setup is incomplete. Please contact administrator.",
                ERROR_CODE_PROFILE_INCOMPLETE,
                (int)HttpStatusCode.Forbidden
            );
        }

        // 4. Check if user is active
        if (!customUser.IsActive)
        {
            _logger.LogInformation($"User '{abpUser.UserName}' (ID: {currentUserId}) is inactive.");
            return ServiceResponse<UserRolesDto>.Failure(
                "Your account is inactive and requires administrator activation or role assignment.",
                ERROR_CODE_INACTIVE,
                (int)HttpStatusCode.Forbidden
            );
        }

        // 5. Get Roles
        var roles = await _userManager.GetRolesAsync(abpUser);
        _logger.LogInformation($"User '{abpUser.UserName}' (ID: {currentUserId}) is active with roles: {(roles != null ? string.Join(", ", roles) : "none")}");

        // 6. Prepare Response
        var userRolesDto = new UserRolesDto
        {
            Roles = roles?.ToList() ?? new List<string>()
        };

        return ServiceResponse<UserRolesDto>.SuccessResult(
            userRolesDto,
            (int)HttpStatusCode.OK,
            "User status and roles retrieved successfully."
        );
    }
}