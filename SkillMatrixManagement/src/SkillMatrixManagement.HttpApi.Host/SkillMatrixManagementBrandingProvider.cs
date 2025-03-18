using Microsoft.Extensions.Localization;
using SkillMatrixManagement.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SkillMatrixManagement;

[Dependency(ReplaceServices = true)]
public class SkillMatrixManagementBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SkillMatrixManagementResource> _localizer;

    public SkillMatrixManagementBrandingProvider(IStringLocalizer<SkillMatrixManagementResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
