using System.Data;
using Volo.Abp.Validation.StringValues;

namespace SkillMatrixManagement;

public static class SkillMatrixManagementDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public static class Category
    {
        public const string CATEGORY_ALREADY_EXIST = "CATEGORY-001";
        public const string CATEGORY_NOT_FOUND = "CATEGORY-002";
        public const string CATEGORY_NOT_FOUND_FOR_UPDATE = "CATEGORY-003";
        public const string CATEGORY_DUPLICATE_NAME = "CATEGORY-004";
        public const string CATEGORY_NOT_FOUND_FOR_SOFT_DELETE = "CATEGORY-005";
        public const string CATEGORY_NOT_FOUND_FOR_PERMANENT_DELETE = "CATEGORY-006";
        public const string CATEGORY_NOT_FOUND_OR_DELETED = "CATEGORY-007";
        public const string CATEGORY_NOT_FOUND_BY_NAME = "CATEGORY-008";
    }

    public static class DepartmentInternalRole
    {
        public const string INVALID_ROLE_NAME = "DEP_ROLE-001";
        public const string ROLE_ALREADY_EXIST = "DEP_ROLE-002";
        public const string ROLE_NOT_FOUND = "DEP_ROLE-003";
        public const string INVALID_ROLE_NAME_FOR_UPDATE = "DEP_ROLE-004";
        public const string ROLE_NOT_FOUND_FOR_UPDATE = "DEP_ROLE-005";
        public const string DUPLICATE_ROLE_NAME = "DEP_ROLE-006";
        public const string ROLE_NOT_FOUND_OR_NOT_DELETED = "DEP_ROLE-007"; // Unique code assigned
        public const string ROLE_ALREADY_DELETED = "DEP_ROLE-008";
    }

    public static class DepartmentManager
    {
        public const string DEPARTMENT_MANAGER_NOT_FOUND = "DM-001";
        public const string DEPARTMENT_MANAGER_NOT_FOUND_UPDATE = "DM-002";
        public const string DEPARTMENT_MANAGER_NOT_FOUND_FOR_SOFT_DELETE = "DM-003";
        public const string DEPARTMENT_MANAGER_NOT_FOUND_FOR_PERMANENT_DELETE = "DM-004";
        public const string DEPARTMENT_MANAGER_NOT_FOUND_FOR_RESTORATION = "DM-005";
        public const string DEPARTMENT_MANAGER_NOT_DELETED = "DM-006";
    }

    public static class Role
    {
        public const string INVALID_ROLE_NAME = "ROLE-001";
        public const string ROLE_ALRADY_EXIST = "ROLE-002";
        public const string ROLE_NOT_FOUND = "ROLE-004";
        public const string ROLE_NOT_FOUND_FOR_PERMANENT_DELETE = "ROLE-005";
        public const string ROLE_NOT_FOUND_FOR_RESTORATION = "ROLE-006";
        public const string ROLE_NOT_DELETED = "ROLE-007";
        public const string DUPLICATE_ROLE_NAME_ON_RESTORE = "ROLE-008";
        public const string ROLE_NOT_FOUND_FOR_SOFT_DELETE = "ROLE-009";
        public const string ROLE_ALREADY_DELETED = "ROLE-010";
        public const string INVALID_ROLE_NAME_FOR_UPDATE = "ROLE-011";
        public const string ROLE_NAME_NOT_FOUND_FOR_UPDATE = "ROLE-012";
        public const string DUPLICATE_ROLE_NAME = "ROLE-013";
    }

    public static class SkillHistory
    {
        public const string USER_ID_CAN_NOT_BE_EMPTY = "SKILLHISTORY-001";
        public const string SKILL_ID_CAN_NOT_BE_EMPTY = "SKILLHISTORY-002";
        public const string INVALID_PROFICIENCY_LEVEL = "SKILLHISTORY-003";
        public const string SKILL_HISTORY_ID_CAN_NOT_BE_EMPTY_FOR_GET = "SKILLHISTORY-004";
        public const string SKILL_HISTORY_NOT_FOUND = "SKILLHISTORY-005";
        public const string SKILL_HISTORY_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE = "SKILLHISTORY-006";
        public const string USER_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE = "SKILLHISTORY-007";
        public const string SKILL_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE = "SKILLHISTORY-008";
        public const string INVALID_PROFICIENCY_LEVEL_FOR_UPDATE = "SKILLHISTORY-009";
        public const string SKILL_HISTORY_NOT_FOUND_FOR_UPDATE = "SKILLHISTORY-010";
        public const string SKILL_HISTORY_ID_CAN_NOT_BE_EMPTY_FOR_SOFT_DELETE = "SKILLHISTORY-011";
        public const string SKILL_HISTORY_NOT_FOUND_FOR_SOFT_DELETE = "SKILLHISTORY-012";
        public const string SKILL_HISTORY_ALREADY_DELETED = "SKILLHISTORY-013";
        public const string SKILL_HISTORY_ID_CAN_NOT_BE_EMPTY_FOR_PERMANENT_DELETE = "SKILLHISTORY-014";
        public const string SKILL_HISTORY_NOT_FOUND_FOR_PERMANENT_DELETION = "SKILLHISTORY-015";
        public const string SKILL_HISTORY_ID_CAN_NOT_BE_EMPTY_FOR_RESTORATION = "SKILLHISTORY-016";
        public const string SKILL_HISTORY_NOT_FOUND_FOR_RESTORATION = "SKILLHISTORY-017";
        public const string SKILL_HISTORY_NOT_DELETED = "SKILLHISTORY-018";
    }

    public static class SkillMatrix
    {
        public const string DEPARTMENT_ID_CAN_NOT_BE_EMPTY = "SM-001";
        public const string SKILL_ID_CAN_NOT_BE_EMPTY = "SM-002";
        public const string SKILL_MATRIX_COMBINATION_ALREADY_EXIST = "SM-003";
        public const string SKILL_MATRIX_NOT_FOUND = "SM-005";
        public const string SKILL_MATRIX_NOT_FOUND_FOR_PERMANENT_DELETION = "SM-006";
        public const string SKILL_MATRIX_NOT_FOUND_FOR_RESTORATION = "SM-007";
        public const string SKILL_MATRIX_NOT_DELETED = "SM-008";
        public const string SKILL_MATRIX_NOT_FOUND_FOR_SOFT_DELETION = "SM-009";
        public const string SKILL_MATRIX_ALREADY_DELETED = "SM-010";
        public const string DEPARTMENT_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE = "SM-011";
        public const string SKILL_ID_CAN_NOT_BE_EMPTY_FOR_UPDATE = "SM-012";
        public const string SKILL_MATRIX_NOT_FOUND_FOR_UPDATE = "SM-013";
        public const string DUPLICATE_SKILL_MATRIX_COMBINATION = "SM-014";
        public const string DUPLICATE_SKILL_MATRIX_COMBINATION_ON_RESTORE = "SM-015";
    }

    // Department error codes
    public static class Department
    {
        public const string INVALID_DEPARTMENT_ID = "DEPARTMENT-001";
        public const string DEPARTMENT_NOT_FOUND = "DEPARTMENT-002";
        public const string DEPARTMENT_ALREADY_EXISTS = "DEPARTMENT-003";
        public const string DEPARTMENT_ALREADY_DELETED = "DEPARTMENT-004";
        public const string DEPARTMENT_NOT_DELETED = "DEPARTMENT-005";
    }

    // DepartmentRole Errors
    public static class DepartmentRole
    {
        public const string DEPARTMENT_ROLE_ALREADY_EXISTS = "DEPARTMENT_ROLE-001";
        public const string DEPARTMENT_ROLE_NOT_FOUND = "DEPARTMENT_ROLE-002";
        public const string INVALID_DEPARTMENT_ROLE_ID = "DEPARTMENT_ROLE-003";
        public const string DEPARTMENT_ROLE_ALREADY_DELETED = "DEPARTMENT_ROLE-004";
        public const string DEPARTMENT_ROLE_NOT_DELETED = "DEPARTMENT_ROLE-005";
    }

    // EmployeeSkill Errors
    public static class EmployeeSkill
    {
        public const string EMPLOYEE_SKILL_ALREADY_EXISTS = "EMPLOYEE_SKILL-001";
        public const string EMPLOYEE_SKILL_NOT_FOUND = "EMPLOYEE_SKILL-002";
        public const string INVALID_EMPLOYEE_SKILL_ID = "EMPLOYEE_SKILL-003";
        public const string EMPLOYEE_SKILL_ALREADY_DELETED = "EMPLOYEE_SKILL-004";
        public const string EMPLOYEE_SKILL_NOT_DELETED = "EMPLOYEE_SKILL-005";
        public const string EMPLOYEE_SKILL_CAN_NOT_BE_NULL = "EMPLOYEE_SKILL-006";
        public const string EMPLOYEE_SKILL_NAME_CAN_NOT_BE_NUMBER = "EMPLOYEE_SKILL-007";

    }
    public static class SkillSubtopicErrorCodes
    {
        public const string SkillSubtopicInvalid = "SKILLSUBTOPIC-001"; // When input is null in CreateAsync
        public const string SkillSubtopicNotFound = "SKILLSUBTOPIC-002"; // When entity is not found in GetByIdAsync
        public const string SkillSubtopicAlreadyDeleted = "SKILLSUBTOPIC-003"; // When trying to restore an already active entity
        public const string SkillSubtopicNotFoundForUpdate = "SKILLSUBTOPIC-004"; // When trying to update a non-existent entity
        public const string SkillSubtopicNotFoundForDelete = "SKILLSUBTOPIC-005"; // When trying to delete a non-existent entity
        public const string SkillSubtopicNotFoundForPermanentDelete = "SKILLSUBTOPIC-006"; // When trying to permanently delete a non-existent entity
    }

    public static class Notification
    {
        public const string NOTIFICATION_NOT_FOUND = "NOTIF-001";
        public const string NOTIFICATION_NOT_FOUND_FOR_UPDATE = "NOTIF-002";
        public const string NOTIFICATION_NOT_FOUND_FOR_SOFT_DELETE = "NOTIF-003";
        public const string NOTIFICATION_ALREADY_DELETED = "NOTIF-004";
        public const string NOTIFICATION_NOT_FOUND_FOR_PERMANENT_DELETE = "NOTIF-005";
        public const string NOTIFICATION_NOT_FOUND_FOR_RESTORATION = "NOTIF-006";
        public const string NOTIFICATION_NOT_DELETED_CANNOT_RESTORE = "NOTIF-007";
    }

    public static class Permission
    {
        public const string PERMISSION_WITH_THIS_NAME_ALREADY_EXISTS = "PERM-001";
        public const string PERMISSION_NOT_FOUND = "PERM-002";
        public const string PERMISSION_NOT_FOUND_FOR_UPDATE = "PERM-003";
        public const string PERMISSION_NOT_FOUND_FOR_SOFT_DELETE = "PERM-004";
        public const string PERMISSION_ALREADY_DELETED = "PERM-005";
        public const string PERMISSION_NOT_FOUND_FOR_PERMANENT_DELETE = "PERM-006";
        public const string PERMISSION_NOT_FOUND_FOR_RESTORATION = "PERM-007";
        public const string PERMISSION_NOT_DELETED_CANNOT_RESTORE = "PERM-008";
    }

    public static class ProficiencyLevel
    {
        public const string PERMISSION_PROFICIENCY_LEVEL_WITH_THIS_NAME_ALREADY_EXISTS = "PROF-001";
        public const string PERMISSION_PROFICIENCY_LEVEL_NOT_FOUND = "PROF-002";
        public const string PERMISSION_PROFICIENCY_LEVEL_NOT_FOUND_FOR_UPDATE = "PROF-003";
        public const string PERMISSION_PROFICIENCY_LEVEL_NOT_FOUND_FOR_SOFT_DELETE = "PROF-004";
        public const string PERMISSION_PROFICIENCY_LEVEL_ALREADY_DELETED = "PROF-005";
        public const string PERMISSION_PROFICIENCY_LEVEL_NOT_FOUND_FOR_PERMANENT_DELETE = "PROF-006";
        public const string PERMISSION_PROFICIENCY_LEVEL_NOT_FOUND_FOR_RESTORATION = "PROF-007";
        public const string PERMISSION_PROFICIENCY_LEVEL_NOT_DELETED_CANNOT_RESTORE = "PROF-008";
    }
    public static class ProjectEmployee
    {
        public const string EMPLOYEE_ALREADY_ASSIGNED_TO_THIS_PROJECT = "PROJECT_EMPLOYEE-001";
        public const string PROJECT_EMPLOYEE_NOT_FOUND = "PROJECT_EMPLOYEE-002";
        public const string PROJECT_EMPLOYEE_NOT_FOUND_FOR_UPDATE = "PROJECT_EMPLOYEE-003";
        public const string PROJECT_EMPLOYEE_ALREADY_DELETED = "PROJECT_EMPLOYEE-004";
        public const string PROJECT_EMPLOYEE_NOT_FOUND_FOR_DELETION = "PROJECT_EMPLOYEE-005";
        public const string PROJECT_EMPLOYEE_NOT_FOUND_OR_NOT_DELETED = "PROJECT_EMPLOYEE-006";

    }

    public static class Project
    {
        public const string PROJECT_ALREADY_EXISTS_WITH_SAME_NAME = "PROJECT-001";
        public const string PROJECT_NOT_FOUND = "PROJECT-002";
        public const string PROJECT_NOT_FOUND_FOR_UPDATE = "PROJECT-003";
        public const string PROJECT_ALREADY_DELETED = "PROJECT-004";
        public const string PROJECT_NOT_FOUND_FOR_DELETION = "PROJECT-005";
        public const string PROJECT_NOT_FOUND_OR_NOT_DELETED = "PROJECT-006";
    }
    public static class RolePermission
    {
        public const string PERMISSION_ALREADY_ASSIGNED_TO_THIS_ROLE = "ROLE_PERMISSION-001";
        public const string ROLE_PERMISSION_NOT_FOUND = "ROLE_PERMISSION-002";

        public const string ROLE_PERMISSION_NOT_FOUND_FOR_UPDATE = "ROLE_PERMISSION-003";
        public const string ROLE_PERMISSION_ALREADY_DELETED = "ROLE_PERMISSION-004";
        public const string ROLE_PERMISSION_NOT_FOUND_FOR_DELETION = "ROLE_PERMISSION-005";
        public const string ROLE_PERMISSION_NOT_FOUND_OR_NOT_DELETED = "ROLE_PERMISSION-006";
    }
    public static class SkillRecommendation
    {
        public const string SKILL_RECOMMENDATION_ALREADY_EXISTS = "SKILL_RECOMMENDATION-001";
        public const string SKILL_RECOMMENDATION_NOT_FOUND = "SKILL_RECOMMENDATION-002";
        public const string SKILL_RECOMMENDATION_NOT_FOUND_FOR_UPDATE = "SKILL_RECOMMENDATION-003";
        public const string SKILL_RECOMMENDATION_ALREADY_DELETED = "SKILL_RECOMMENDATION-004";
        public const string SKILL_RECOMMENDATION_NOT_FOUND_FOR_DELETION = "SKILL_RECOMMENDATION-005";
        public const string SKILL_RECOMMENDATION_NOT_FOUND_OR_NOT_DELETED = "SKILL_RECOMMENDATION-006";
    }

    public static class SkillRecommendationByManager
    {
        public const string SKILL_RECOMMENDATION_NOT_FOUND = "SKILL_RECOMMENDATION_BY_MANAGER-001";

        public const string SKILL_RECOMMENDATION_NOT_FOUND_FOR_DELETION = "SKILL_RECOMMENDATION_BY_MANAGER-002";

        public const string SKILL_RECOMMENDATION_ALREADY_DELETED = "SKILL_RECOMMENDATION_BY_MANAGER-003";
        public const string SKILL_RECOMMENDATION_NOT_FOUND_OR_NOT_DELETED = "SKILL_RECOMMENDATION_BY_MANAGER-004";
        public const string SKILL_RECOMMENDATION_NOT_FOUND_FOR_UPDATE = "SKILL_RECOMMENDATION_BY_MANAGER-005";
    }
    public static class Skill
    {
        public const string SKILL_ALREADY_EXISTS_WITH_SAME_NAME = "SKILL-001";
        public const string SKILL_NOT_FOUND = "SKILL-002";
        public const string SKILL_NOT_FOUND_FOR_UPDATE = "SKILL-003";
        public const string SKILL_ALREADY_DELETED = "SKILL-004";
        public const string SKILL_NOT_FOUND_FOR_DELETION = "SKILL-005";
        public const string SKILL_NOT_FOUND_OR_NOT_DELETED = "SKILL-006";
        public const string SKILL_NOT_FOUND_FOR_RESTORED = "SKILL-007";
    }
    public static class CustomUser
        {
            public const string USER_ALREADY_EXISTS = "CustomUser:AlreadyExists";
            public const string USER_NOT_FOUND = "CustomUser:NotFound";
            public const string USER_NOT_FOUND_FOR_UPDATE = "CustomUser:NotFoundForUpdate";
            public const string USER_NOT_FOUND_FOR_SOFT_DELETE = "CustomUser:NotFoundForSoftDelete";
            public const string USER_NOT_FOUND_FOR_PERMANENT_DELETE = "CustomUser:NotFoundForPermanentDelete";
            public const string USER_NOT_FOUND_OR_DELETED = "CustomUser:NotFoundOrDeleted";
            public const string USER_DUPLICATE_NAME = "CustomUser:DuplicateName";
            public const string USER_DUPLICATE_EMAIL = "CustomUser:DuplicateEmail";
            public const string USER_NOT_FOUND_BY_NAME_OR_EMAIL = "CustomUser:NotFoundByNameOrEmail";
        }

}
