using SkillMatrixManagement.Samples;
using Xunit;

namespace SkillMatrixManagement.EntityFrameworkCore.Domains;

[Collection(SkillMatrixManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SkillMatrixManagementEntityFrameworkCoreTestModule>
{

}
