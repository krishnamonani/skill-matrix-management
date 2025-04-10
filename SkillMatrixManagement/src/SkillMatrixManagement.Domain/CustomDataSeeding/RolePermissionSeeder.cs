using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace SkillMatrixManagement.CustomDataSeeding
{
   public class RolePermissionSeeder : IDataSeedContributor , ITransientDependency
    {
        private readonly IPermissionManager _permissionManager;
        private readonly IIdentityRoleRepository _roleRepository;

        public RolePermissionSeeder(IPermissionManager permissionManager, IIdentityRoleRepository roleRepository)
        {
            _permissionManager = permissionManager;
            _roleRepository = roleRepository;
            
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await GrantPermissionsToRoleAsync("Admin", SkillMatrixManagementPermissions.Admin.GetAll());
            await GrantPermissionsToRoleAsync("Manager", SkillMatrixManagementPermissions.Manager.GetAll());
            await GrantPermissionsToRoleAsync("HR", SkillMatrixManagementPermissions.HR.GetAll());
            await GrantPermissionsToRoleAsync("Developer", SkillMatrixManagementPermissions.Developer.GetAll());
        }

        private async Task GrantPermissionsToRoleAsync(string roleName, string[] permissions)
        {
            var role = await _roleRepository.FindByNormalizedNameAsync(roleName.ToUpper());
            if (role == null) return;

            foreach (var permission in permissions)
            {
                await _permissionManager.SetForRoleAsync(role.Name, permission, true);
            }
        }
    }
}