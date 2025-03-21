using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Models;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.CustomDataSeeding
{
    public class RoleSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Role, Guid> _roleRepository;

        public RoleSeedingService(IRepository<Role, Guid> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _roleRepository.GetCountAsync() > 0) return;

            var hr = new Role()
            {
                Name = RoleEnum.ROLE_HR
            };

            var manager = new Role()
            {
                Name = RoleEnum.ROLE_MANAGER 
            };

            var developer = new Role()
            {
                Name = RoleEnum.ROLE_DEVELOPER
            };

            var admin = new Role()
            {
                Name = RoleEnum.ROLE_ADMIN
            };

            await _roleRepository.InsertManyAsync(new List<Role>()
            {
                    hr, manager, developer, admin
            });
        }
    }
}
