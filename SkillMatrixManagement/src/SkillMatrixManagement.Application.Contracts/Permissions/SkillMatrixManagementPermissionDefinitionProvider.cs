using SkillMatrixManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SkillMatrixManagement.Permissions;

public class SkillMatrixManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var skillMatrixGroup = context.GetGroupOrNull(SkillMatrixManagementPermissions.GroupName)
                         ?? context.AddGroup(SkillMatrixManagementPermissions.GroupName, L("Permission:SkillMatrix"));

        // Admin CRUD Permissions
        var adminGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.Admin.Default, L("Permission:Admin"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.Create, L("Permission:Admin.Create"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.Read, L("Permission:Admin.Read"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.Update, L("Permission:Admin.Update"));
        adminGroup.AddChild(SkillMatrixManagementPermissions.Admin.Delete, L("Permission:Admin.Delete"));

        // Manager CRUD Permissions
        var managerGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.Manager.Default, L("Permission:Manager"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.Create, L("Permission:Manager.Create"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.Read, L("Permission:Manager.Read"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.Update, L("Permission:Manager.Update"));
        managerGroup.AddChild(SkillMatrixManagementPermissions.Manager.Delete, L("Permission:Manager.Delete"));

        // HR CRUD Permissions
        var hrGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.HR.Default, L("Permission:HR"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.Create, L("Permission:HR.Create"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.Read, L("Permission:HR.Read"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.Update, L("Permission:HR.Update"));
        hrGroup.AddChild(SkillMatrixManagementPermissions.HR.Delete, L("Permission:HR.Delete"));

        // Developer CRUD Permissions
        var developerGroup = skillMatrixGroup.AddPermission(SkillMatrixManagementPermissions.Developer.Default, L("Permission:Developer"));
        developerGroup.AddChild(SkillMatrixManagementPermissions.Developer.Create, L("Permission:Developer.Create"));
        developerGroup.AddChild(SkillMatrixManagementPermissions.Developer.Read, L("Permission:Developer.Read"));
        developerGroup.AddChild(SkillMatrixManagementPermissions.Developer.Update, L("Permission:Developer.Update"));
        developerGroup.AddChild(SkillMatrixManagementPermissions.Developer.Delete, L("Permission:Developer.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SkillMatrixManagementResource>(name);
    }
}