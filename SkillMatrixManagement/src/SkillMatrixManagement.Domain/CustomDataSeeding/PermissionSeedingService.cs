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
    public class PermissionSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Permission, Guid> _permissionRepository;

        public PermissionSeedingService(IRepository<Permission, Guid> permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _permissionRepository.GetCountAsync() > 0) return;

            var permissions = new List<Permission>
            {
                new Permission
                {
                    Name = PermissionEnum.DEVELOPER_READ,
                    Description = "Permission to fetch Developer details"
                },
                new Permission
                {
                    Name = PermissionEnum.DEVELOPER_WRITE,
                    Description = "Permission to create Developer details"
                },
                new Permission
                {
                    Name = PermissionEnum.DEVELOPER_EDIT,
                    Description = "Permission to update Developer details"
                },
                new Permission
                {
                    Name = PermissionEnum.DEVELOPER_DELETE,
                    Description = "Permission to delete Developer details"
                },
                new Permission
                {
                    Name = PermissionEnum.MANAGER_READ,
                    Description = "Permission to fetch Manager details"
                },
                new Permission
                {
                    Name = PermissionEnum.MANAGER_WRITE,
                    Description = "Permission to create Manager details"
                },
                new Permission
                {
                    Name = PermissionEnum.MANAGER_EDIT,
                    Description = "Permission to update Manager details"
                },
                new Permission
                {
                    Name = PermissionEnum.MANAGER_DELETE,
                    Description = "Permission to delete Manager details"
                },
                new Permission
                {
                    Name = PermissionEnum.HR_READ,
                    Description = "Permission to fetch HR details"
                },
                new Permission
                {
                    Name = PermissionEnum.HR_WRITE,
                    Description = "Permission to create HR details"
                },
                new Permission
                {
                    Name = PermissionEnum.HR_EDIT,
                    Description = "Permission to update HR details"
                },
                new Permission
                {
                    Name = PermissionEnum.HR_DELETE,
                    Description = "Permission to delete HR details"
                }
            };

            await _permissionRepository.InsertManyAsync(permissions, autoSave: true);
        }
    }
}
