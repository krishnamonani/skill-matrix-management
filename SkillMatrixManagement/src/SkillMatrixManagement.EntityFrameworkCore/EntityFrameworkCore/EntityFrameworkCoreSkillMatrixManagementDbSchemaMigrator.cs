using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillMatrixManagement.Data;
using Volo.Abp.DependencyInjection;

namespace SkillMatrixManagement.EntityFrameworkCore;

public class EntityFrameworkCoreSkillMatrixManagementDbSchemaMigrator
    : ISkillMatrixManagementDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSkillMatrixManagementDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SkillMatrixManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SkillMatrixManagementDbContext>()
            .Database
            .MigrateAsync();

        await _serviceProvider
            .GetRequiredService<SkillMatrixManagementApplicationDbContext>()
            .Database
            .MigrateAsync();
    }
}
