using SkillMatrixManagement.Samples;
using Xunit;

namespace SkillMatrixManagement.EntityFrameworkCore.Applications;

[Collection(SkillMatrixManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SkillMatrixManagementEntityFrameworkCoreTestModule>
{

}
