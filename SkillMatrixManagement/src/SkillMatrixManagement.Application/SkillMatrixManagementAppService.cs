using SkillMatrixManagement.Localization;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement;

/* Inherit your application services from this class.
 */
public abstract class SkillMatrixManagementAppService : ApplicationService
{
    protected SkillMatrixManagementAppService()
    {
        LocalizationResource = typeof(SkillMatrixManagementResource);
    }
}
