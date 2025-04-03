using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace SkillMatrixManagement.CustomDataSeeding
{
    public class AbpRoleSeedingService :IDataSeedContributor, ITransientDependency
    {
        private readonly IIdentityRoleRepository _roleRepository;
        private readonly IdentityRoleManager _roleManager;

        public AbpRoleSeedingService(IIdentityRoleRepository roleRepository, IdentityRoleManager roleManager)
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            await AddRoleIfNotExistsAsync("manager");
            await AddRoleIfNotExistsAsync("hr");
            await AddRoleIfNotExistsAsync("employee");
        }

        private async Task AddRoleIfNotExistsAsync(string roleName)
        {
            var existingRole = await _roleRepository.FindByNormalizedNameAsync(roleName.ToUpper());
            if (existingRole == null)
            {
                var newRole = new IdentityRole(Guid.NewGuid(), roleName);
                await _roleManager.CreateAsync(newRole);
            }
        }
    }
}
