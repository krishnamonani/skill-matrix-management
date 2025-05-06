using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.PasswordReset;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IPasswordResetService : IApplicationService
    {
        /// <summary>
        /// Resets a user's password after validating their identity with the current password
        /// </summary>
        /// <param name="input">Reset password request containing email/username, current password, and new password</param>
        /// <returns>Service response indicating success or failure</returns>
        Task<ServiceResponse> ResetPasswordAsync(ResetPasswordDto input);
        
        /// <summary>
        /// Validates if the provided current password is correct for the specified user
        /// </summary>
        /// <param name="emailOrUsername">User's email or username</param>
        /// <param name="password">Password to validate</param>
        /// <returns>Service response indicating if the password is valid</returns>
        Task<ServiceResponse<bool>> ValidateCurrentPasswordAsync(string emailOrUsername, string password);
    }
}
