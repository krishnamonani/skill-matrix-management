using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SkillMatrixManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SkillMatrixManagement.Services
{
    public class CustomAccountAppService : ApplicationService, ICustomAccountAppService 
    {
        protected IdentityUserManager UserManager { get; }
        protected SignInManager<IdentityUser> SignInManager { get; }
        protected IOptions<IdentityOptions> IdentityOptions { get; }


        public CustomAccountAppService(
            IdentityUserManager userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<IdentityOptions> identityOptions
            )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            IdentityOptions = identityOptions;

        }

        public virtual async Task<CustomLoginResultDto> CustomLoginAsync(LoginDTO login)
        {
            await IdentityOptions.SetAsync();

            var user = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress)
                    ?? await UserManager.FindByEmailAsync(login.UserNameOrEmailAddress);

            if (user == null)
            {
                return new CustomLoginResultDto { Result = LoginResultType.InvalidCredentials, Description = L["InvalidUserNameOrPassword"] };
            }

            // Use CheckPasswordSignInAsync first
            var result = await SignInManager.CheckPasswordSignInAsync(user, login.Password, true);

            // Handle failures (LockedOut, NotAllowed, RequiresTwoFactor, InvalidCredentials)
  
            if (result.IsLockedOut)
            {
                return new CustomLoginResultDto { Result = LoginResultType.IsLockedOut, Description = L["UserLockedOut"] };
            }
            if (result.IsNotAllowed)
            {
                return new CustomLoginResultDto { Result = LoginResultType.IsNotAllowed, Description = L["LoginIsNotAllowed"] };
            }
            if (result.RequiresTwoFactor)
            {
                return new CustomLoginResultDto { Result = LoginResultType.RequiresTwoFactor, Description = L["RequiresTwoFactor"] };
            }
            if (!result.Succeeded)
            {
                return new CustomLoginResultDto { Result = LoginResultType.InvalidCredentials, Description = L["InvalidUserNameOrPassword"] };
            }

            // *** Role Check ***
            var roles = await UserManager.GetRolesAsync(user);
            if (roles == null || !roles.Any())
            {
                return new CustomLoginResultDto
                {
                    Result = LoginResultType.NoRoleAssigned,
                    Description = L["UserRequiresRoleAssignment"]
                };
            }

            // *** Role Check Passed - Proceed with Actual Sign In ***
            await SignInManager.SignInAsync(user, login.RememberMe); // Sets the cookie

            // *** Return Success with Roles ***
            return new CustomLoginResultDto
            {
                Result = LoginResultType.Success,
                Roles = roles.ToList() // Return the list of roles
            };
        }

    }
}
