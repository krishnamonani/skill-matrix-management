using Volo.Abp.Modularity;

namespace SkillMatrixManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class SkillMatrixManagementDomainTestBase<TStartupModule> : SkillMatrixManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
