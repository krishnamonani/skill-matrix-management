using SkillMatrixManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SkillMatrixManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SkillMatrixManagementEntityFrameworkCoreModule),
    typeof(SkillMatrixManagementApplicationContractsModule)
)]
public class SkillMatrixManagementDbMigratorModule : AbpModule
{
}
