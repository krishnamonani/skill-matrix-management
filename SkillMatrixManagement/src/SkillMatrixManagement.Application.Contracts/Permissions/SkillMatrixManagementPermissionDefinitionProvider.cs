using SkillMatrixManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SkillMatrixManagement.Permissions;

public class SkillMatrixManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var skillMatrixGroup = context.GetGroupOrNull(SkillMatrixManagementPermissions.GroupName)
                         ?? context.AddGroup(SkillMatrixManagementPermissions.GroupName, L("Permission:SkillMatrix"));


        var adminGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.Admin.Default, L("Permission:Admin"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.ManageSkills, L("Permission:ManageSkills"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.ManageProficiencyLevels, L("Permission:ManageProficiencyLevels"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.ManageUsers, L("Permission:ManageUsers"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.ManageDashboard, L("Permission:ManageDashboard"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.ConfigureSystem, L("Permission:ConfigureSystem"));

        var managerGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.Manager.Default, L("Permission:Manager"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.AssignSkills, L("Permission:AssignSkills"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.TrackProgress, L("Permission:TrackProgress"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.ValidateProficiency, L("Permission:ValidateProficiency"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.GenerateReports, L("Permission:GenerateReports"));

        var hrGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.HR.Default, L("Permission:HR"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.AnalyzeSkillTrends, L("Permission:AnalyzeSkillTrends"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.GenerateReports, L("Permission:GenerateReports"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.FacilitateTrainingPrograms, L("Permission:FacilitateTrainingPrograms"));

        var employeeGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.Developer.Default, L("Permission:Developer"));
        employeeGroup.AddChild(SkillMatrixManagementPermissions.Developer.ViewAssignedSkills, L("Permission:ViewAssignedSkills"));
        employeeGroup.AddChild(SkillMatrixManagementPermissions.Developer.UpdateSelfAssessment, L("Permission:UpdateSelfAssessment"));
        employeeGroup.AddChild(SkillMatrixManagementPermissions.Developer.AccessRecommendations, L("Permission:AccessRecommendations"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SkillMatrixManagementResource>(name);
    }
}
