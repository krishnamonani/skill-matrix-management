using Volo.Abp.Reflection;

namespace SkillMatrixManagement.Permissions;

public static class SkillMatrixManagementPermissions
{


    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public const string GroupName = "SkillMatrix";

    public static class Admin
    {
        public const string Default = GroupName + ".Admin";
        public const string ManageSkills = Default + ".ManageSkills";
        public const string ManageProficiencyLevels = Default + ".ManageProficiencyLevels";
        public const string ManageUsers = Default + ".ManageUsers";
        public const string ManageDashboard = Default + ".ManageDashboard";
        public const string ConfigureSystem = Default + ".ConfigureSystem";
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Admin));
        }
    }

    public static class Manager
    {
        public const string Default = GroupName + ".Manager";
        public const string AssignSkills = Default + ".AssignSkills";
        public const string TrackProgress = Default + ".TrackProgress";
        public const string ValidateProficiency = Default + ".ValidateProficiency";
        public const string GenerateReports = Default + ".GenerateReports";
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Manager));
        }
    }

    public static class HR
    {
        public const string Default = GroupName + ".HR";
        public const string AnalyzeSkillTrends = Default + ".AnalyzeSkillTrends";
        public const string GenerateReports = Default + ".GenerateReports";
        public const string FacilitateTrainingPrograms = Default + ".FacilitateTrainingPrograms";
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(HR));
        }
    }

    public static class Employee
    {
        public const string Default = GroupName + ".Employee";
        public const string ViewAssignedSkills = Default + ".ViewAssignedSkills";
        public const string UpdateSelfAssessment = Default + ".UpdateSelfAssessment";
        public const string AccessRecommendations = Default + ".AccessRecommendations";
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Employee));
        }
    }

}
