using SkillMatrixManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SkillMatrixManagement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SkillMatrixManagementController : AbpControllerBase
{
    protected SkillMatrixManagementController()
    {
        LocalizationResource = typeof(SkillMatrixManagementResource);
    }
}
