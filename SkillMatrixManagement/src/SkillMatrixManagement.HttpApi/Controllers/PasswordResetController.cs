using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillMatrixManagement.DTOs.PasswordReset;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace SkillMatrixManagement.HttpApi.Controllers
{
    [Route("api/password")]
    public class PasswordResetController : AbpControllerBase
    {
        private readonly IPasswordResetService _passwordResetService;

        public PasswordResetController(IPasswordResetService passwordResetService)
        {
            _passwordResetService = passwordResetService;
        }

        [HttpPost("reset")]
        public async Task<ServiceResponse> ResetPasswordPost(ResetPasswordDto input)
        {
            return await _passwordResetService.ResetPasswordAsync(input);
        }

        [HttpGet("reset")]
        public async Task<ServiceResponse> ResetPasswordGet([FromQuery] ResetPasswordDto input)
        {
            return await _passwordResetService.ResetPasswordAsync(input);
        }

        [HttpPost("validate")]
        public async Task<ServiceResponse<bool>> ValidatePassword([FromBody] ValidatePasswordDto input)
        {
            return await _passwordResetService.ValidateCurrentPasswordAsync(input.EmailOrUsername, input.Password);
        }
    }

    public class ValidatePasswordDto
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}
