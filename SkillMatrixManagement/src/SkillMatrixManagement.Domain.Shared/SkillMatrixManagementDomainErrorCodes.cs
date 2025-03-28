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
}
