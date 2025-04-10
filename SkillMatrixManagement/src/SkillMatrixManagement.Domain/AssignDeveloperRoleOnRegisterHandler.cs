using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Identity;

namespace SkillMatrixManagement
{
    public static class AppRoles
    {
        public const string Developer = "DEVELOPER";
    }

    public class AssignDeveloperRoleOnRegisterHandler
        : ILocalEventHandler<EntityCreatedEventData<IdentityUser>>,
          ITransientDependency
    {
        private readonly IdentityUserManager _identityUserManager;

        public AssignDeveloperRoleOnRegisterHandler(IdentityUserManager identityUserManager)
        {
            _identityUserManager = identityUserManager;
        }

        public virtual async Task HandleEventAsync(EntityCreatedEventData<IdentityUser> eventData)
        {
            var user = eventData.Entity;

            if (user != null)
            {
                // Skip if user is already in admin role
                if (await _identityUserManager.IsInRoleAsync(user, "admin"))
                {
                    return;
                }

                if (!await _identityUserManager.IsInRoleAsync(user, AppRoles.Developer))
                {
                    await _identityUserManager.AddToRoleAsync(user, AppRoles.Developer);
                }
            }
        }
    }
}