using Volo.Abp.Reflection;

namespace SkillMatrixManagement.Permissions;

public static class SkillMatrixManagementPermissions
{
    public const string GroupName = "SkillMatrix";

    public static class Admin
    {
        public const string Default = GroupName + ".Admin";
        public const string Create = Default + ".Create";
        public const string Read = Default + ".Read";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Admin));
        }
    }

    public static class Manager
    {
        public const string Default = GroupName + ".Manager";
        public const string Create = Default + ".Create";
        public const string Read = Default + ".Read";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Manager));
        }
    }

    public static class HR
    {
        public const string Default = GroupName + ".HR";
        public const string Create = Default + ".Create";
        public const string Read = Default + ".Read";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(HR));
        }
    }

    public static class Developer
    {
        public const string Default = GroupName + ".Developer";
        public const string Create = Default + ".Create";
        public const string Read = Default + ".Read";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(Developer));
        }
    }
}