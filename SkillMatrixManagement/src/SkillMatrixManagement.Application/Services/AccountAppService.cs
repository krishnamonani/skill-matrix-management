using System;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using SkillMatrixManagement.Domain;
using Volo.Abp.Account.Emailing;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Volo.Abp;

namespace SkillMatrixManagement.Application
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAccountAppService), typeof(AccountAppService))]
    public class CustomAccountAppService : AccountAppService
    {
        private readonly IRepository<CustomUser, Guid> _customUserRepository;

        public CustomAccountAppService(
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository,
            IAccountEmailer accountEmailer,
            IdentitySecurityLogManager identitySecurityLogManager,
            IOptions<IdentityOptions> identityOptions,
            IRepository<CustomUser, Guid> customUserRepository)
            : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
            _customUserRepository = customUserRepository;
        }

        public override async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            try
            {

            var identityUserDto = await base.RegisterAsync(input);

            // Create entry in CustomUsers
            var customUser = new CustomUser(
         id: Guid.NewGuid(), // Generate a new ID for CustomUser
         identityUserId: identityUserDto.Id, // Link to the registered user
         userName: identityUserDto.UserName, // Use the username from the registered user
         email: identityUserDto.Email, // Use the email from the registered user
         isActive: false // Set the initial status to inactive
     );
            await _customUserRepository.InsertAsync(customUser);

            return identityUserDto;
        }
            catch(Exception ex)
            {
                throw new UserFriendlyException($"Registration failed: {ex.Message}");
            }
            }
        
            // Call base method to register user in AbpUsers
    }
}