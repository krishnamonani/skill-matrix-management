using Volo.Abp.Modularity;

namespace SkillMatrixManagement;

[DependsOn(
    typeof(SkillMatrixManagementApplicationModule),
    typeof(SkillMatrixManagementDomainTestModule)
)]
public class SkillMatrixManagementApplicationTestModule : AbpModule
{

}
