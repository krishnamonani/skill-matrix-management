using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SkillMatrixManagement.DTOs.PasswordReset;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Services;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SkillMatrixManagement.Application.Services
{
    public class PasswordResetService : ApplicationService, IPasswordResetService
    {
        private readonly IdentityUserManager _userManager;
        private readonly ILogger<PasswordResetService> _logger;

        // Error Codes
        private const string ERROR_CODE_USER_NOT_FOUND = "USER_NOT_FOUND";
        private const string ERROR_CODE_INVALID_PASSWORD = "INVALID_PASSWORD";
        private const string ERROR_CODE_PASSWORD_CHANGE_FAILED = "PASSWORD_CHANGE_FAILED";
        private const string ERROR_CODE_VALIDATION_ERROR = "VALIDATION_ERROR";

        public PasswordResetService(
            IdentityUserManager userManager,
            ILogger<PasswordResetService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ServiceResponse> ResetPasswordAsync(ResetPasswordDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse.Failure(
                        "Reset password request cannot be null", 
                        ERROR_CODE_VALIDATION_ERROR, 
                        (int)HttpStatusCode.BadRequest);
                }

                if (string.IsNullOrWhiteSpace(input.EmailOrUsername))
                {
                    return ServiceResponse.Failure(
                        "Username or email address is required", 
                        ERROR_CODE_VALIDATION_ERROR, 
                        (int)HttpStatusCode.BadRequest);
                }

                if (string.IsNullOrWhiteSpace(input.CurrentPassword))
                {
                    return ServiceResponse.Failure(
                        "Current password is required", 
                        ERROR_CODE_VALIDATION_ERROR, 
                        (int)HttpStatusCode.BadRequest);
                }

                if (string.IsNullOrWhiteSpace(input.NewPassword))
                {
                    return ServiceResponse.Failure(
                        "New password is required", 
                        ERROR_CODE_VALIDATION_ERROR, 
                        (int)HttpStatusCode.BadRequest);
                }

                if (input.NewPassword != input.ConfirmPassword)
                {
                    return ServiceResponse.Failure(
                        "New password and confirm password do not match", 
                        ERROR_CODE_VALIDATION_ERROR, 
                        (int)HttpStatusCode.BadRequest);
                }

                // Find the user
                var user = await FindUserByEmailOrUsernameAsync(input.EmailOrUsername);
                if (user == null)
                {
                    _logger.LogWarning("Password reset attempt failed: User not found for {EmailOrUsername}", input.EmailOrUsername);
                    return ServiceResponse.Failure(
                        "User not found", 
                        ERROR_CODE_USER_NOT_FOUND, 
                        (int)HttpStatusCode.NotFound);
                }

                // Verify current password
                var passwordValid = await _userManager.CheckPasswordAsync(user, input.CurrentPassword);
                if (!passwordValid)
                {
                    _logger.LogWarning("Password reset attempt failed: Invalid current password for user {UserName}", user.UserName);
                    return ServiceResponse.Failure(
                        "Current password is incorrect", 
                        ERROR_CODE_INVALID_PASSWORD, 
                        (int)HttpStatusCode.BadRequest);
                }

                // Change the password
                var changePasswordResult = await _userManager.ChangePasswordAsync(
                    user, 
                    input.CurrentPassword, 
                    input.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    var errors = string.Join(", ", changePasswordResult.Errors);
                    _logger.LogError("Password change failed for user {UserName}: {Errors}", user.UserName, errors);
                    
                    return ServiceResponse.Failure(
                        $"Failed to change password: {errors}", 
                        ERROR_CODE_PASSWORD_CHANGE_FAILED, 
                        (int)HttpStatusCode.BadRequest);
                }

                _logger.LogInformation("Password successfully reset for user {UserName}", user.UserName);
                return ServiceResponse.SuccessResult(
                    (int)HttpStatusCode.OK, 
                    "Password successfully reset");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during password reset: {Message}", ex.Message);
                return ServiceResponse.Failure(
                    "An error occurred while processing your request", 
                    "INTERNAL_SERVER_ERROR", 
                    (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ServiceResponse<bool>> ValidateCurrentPasswordAsync(string emailOrUsername, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailOrUsername) || string.IsNullOrWhiteSpace(password))
                {
                    return ServiceResponse<bool>.Failure(
                        "Email/username or password cannot be empty", 
                        ERROR_CODE_VALIDATION_ERROR, 
                        (int)HttpStatusCode.BadRequest);
                }

                // Find the user
                var user = await FindUserByEmailOrUsernameAsync(emailOrUsername);
                if (user == null)
                {
                    return ServiceResponse<bool>.Failure(
                        "User not found", 
                        ERROR_CODE_USER_NOT_FOUND, 
                        (int)HttpStatusCode.NotFound);
                }

                // Verify the password
                var passwordValid = await _userManager.CheckPasswordAsync(user, password);
                
                return ServiceResponse<bool>.SuccessResult(
                    passwordValid, 
                    (int)HttpStatusCode.OK, 
                    passwordValid ? "Password is valid" : "Password is invalid");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating password: {Message}", ex.Message);
                return ServiceResponse<bool>.Failure(
                    "An error occurred while validating the password", 
                    "INTERNAL_SERVER_ERROR", 
                    (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task<IdentityUser> FindUserByEmailOrUsernameAsync(string emailOrUsername)
        {
            _logger.LogInformation("Attempting to find user by identifier: {EmailOrUsername}", emailOrUsername);
            
            // Try finding by email first
            var user = await _userManager.FindByEmailAsync(emailOrUsername);
            
            // If not found by email, try by username
            if (user == null)
            {
                _logger.LogInformation("User not found by email, trying username");
                user = await _userManager.FindByNameAsync(emailOrUsername);
            }

            if (user != null)
            {
                _logger.LogInformation("User found: {UserName}, {Email}", user.UserName, user.Email);
            }
            else
            {
                _logger.LogWarning("No user found with identifier: {EmailOrUsername}", emailOrUsername);
            }

            return user;
        }
    }
}
