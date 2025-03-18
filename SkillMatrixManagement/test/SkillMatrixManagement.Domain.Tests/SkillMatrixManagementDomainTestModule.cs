using Volo.Abp.Modularity;

namespace SkillMatrixManagement;

[DependsOn(
    typeof(SkillMatrixManagementDomainModule),
    typeof(SkillMatrixManagementTestBaseModule)
)]
public class SkillMatrixManagementDomainTestModule : AbpModule
{

}
