using Microsoft.AspNetCore.Identity;
using SkillMatrixManagement.Domain;
using SkillMatrixManagement.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SkillMatrixManagement.Services
{
    public class AppGoogleLogInService : ApplicationService, IGoogleLogIn
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly IdentityUserManager _identityUserManager;
        private readonly ICustomUserRepository _customUserRepository;

        public AppGoogleLogInService(SignInManager<IdentityUser> signinManager, IdentityUserManager identityUserManager, ICustomUserRepository customUserRepository)
        {
            _signinManager = signinManager;
            _identityUserManager = identityUserManager;
            _customUserRepository = customUserRepository;
        }

        public async Task<ServiceResponse> GetGoogleLogInAsync(string email)
        {
            try
            {

                var user = await _identityUserManager.FindByEmailAsync(email);
                var InActiveUSerList =await _customUserRepository.GetUsersByStatusAsync(false);
                if (user == null)
                {
                    return ServiceResponse.Failure("Oops! We couldn't find an account associated with this email address. Please check for any typos or try a different email.", 404);
                }
                var IsInActive = InActiveUSerList.FirstOrDefault(u => u.Email.ToLower()==user.Email.ToLower());
                if (IsInActive != null)
                {
                    return ServiceResponse.Failure("Your account is inactive and requires administrator activation or role assignment", 404);

                }
                var InActiveUser = await _customUserRepository.GetUsersByStatusAsync(false);
                var CustomUser =InActiveUser.FirstOrDefault(u => u.Id == user.Id);
                if (CustomUser!=null)
                {
                    return ServiceResponse.Failure("Your account is inactive and requires administrator activation or role assignment", 404);
                }

               

                await _signinManager.SignInAsync(user, isPersistent: true);

                return ServiceResponse.SuccessResult(successMessage: "Login successful. Welcome back!", statusCode: 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }
        }
    }
}
