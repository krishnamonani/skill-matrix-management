using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity; // Required for IdentityResult and UserManager methods
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events; // Required for EntityCreatedEventData
using Volo.Abp.EventBus; // Required for ILocalEventHandler
using Volo.Abp.Identity; // Required for IdentityUser and IdentityUserManager
using Volo.Abp.Uow; // Required for IUnitOfWorkManager if needed explicitly, often handled automatically

namespace YourProjectName.Users // Adjust namespace accordingly
{
    // Define your role name as a constant
    public static class AppRoles
    {
        public const string Developer = "DEVELOPER";
    }

    public class AssignDeveloperRoleOnRegisterHandler
        : ILocalEventHandler<EntityCreatedEventData<IdentityUser>>, // Handle local creation event
          ITransientDependency // Register for Dependency Injection
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly ILogger<AssignDeveloperRoleOnRegisterHandler> _logger;

        public AssignDeveloperRoleOnRegisterHandler(
            IdentityUserManager identityUserManager,
            ILogger<AssignDeveloperRoleOnRegisterHandler> logger) // Inject UserManager and Logger
        {
            _identityUserManager = identityUserManager;
            _logger = logger ?? NullLogger<AssignDeveloperRoleOnRegisterHandler>.Instance;
        }

        // This method will be automatically called when a new IdentityUser is created
        [UnitOfWork] // Ensures the operation is part of the same transaction as user creation
        public virtual async Task HandleEventAsync(EntityCreatedEventData<IdentityUser> eventData)
        {
            var user = eventData.Entity; // Get the newly created user

            if (user == null)
            {
                _logger.LogWarning("Received EntityCreatedEventData<IdentityUser> with null Entity.");
                return;
            }

            try
            {
                // Check if the user is already in the role (shouldn't happen on create, but good practice)
                if (!await _identityUserManager.IsInRoleAsync(user, AppRoles.Developer))
                {
                    // Add the user to the "DEVELOPER" role
                    var result = await _identityUserManager.AddToRoleAsync(user, AppRoles.Developer);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"Successfully added user {user.UserName} (ID: {user.Id}) to role '{AppRoles.Developer}'.");
                    }
                    else
                    {
                        // Log errors if adding the role failed
                        _logger.LogError($"Failed to add user {user.UserName} (ID: {user.Id}) to role '{AppRoles.Developer}'. " +
                                         $"Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                        // Optional: You might want to throw an exception here depending on your requirements
                        // throw new AbpException($"Could not add user {user.Id} to role {AppRoles.Developer}.");
                    }
                }
                else
                {
                    _logger.LogDebug($"User {user.UserName} (ID: {user.Id}) is already in role '{AppRoles.Developer}'. No action taken.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while trying to add user {user.UserName} (ID: {user.Id}) to role '{AppRoles.Developer}'.");
                // Rethrow or handle as needed
                throw;
            }
        }
    }
}