using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SkillMatrixManagement.Data;

/* This is used if database provider does't define
 * ISkillMatrixManagementDbSchemaMigrator implementation.
 */
public class NullSkillMatrixManagementDbSchemaMigrator : ISkillMatrixManagementDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
