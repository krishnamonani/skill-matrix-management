namespace SkillMatrixManagement;

public static class SkillMatrixManagementDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public static class Category
    {
        public const string CategoryAlreadyExists = "CATEGORY-001";
        public const string CategoryNotFound = "CATEGORY-002";
        public const string CategoryNotFoundForUpdate = "CATEGORY-003";
        public const string CategoryDuplicateName = "CATEGORY-004";
        public const string CategoryNotFoundForSoftDelete = "CATEGORY-005";
        public const string CategoryNotFoundForPermanentDelete = "CATEGORY-006";
        public const string CategoryNotFoundOrNotDeleted = "CATEGORY-007";
        public const string CategoryNotFoundByName = "CATEGORY-008";
    }

    public static class DepartmentInternalRole
    {
        public const string InvalidRoleName = "DEP_ROLE-001";
        public const string RoleAlreadyExists = "DEP_ROLE-002";
        public const string RoleNotFound = "DEP_ROLE-003";
        public const string InvalidRoleNameForUpdate = "DEP_ROLE-004";
        public const string RoleNotFoundForUpdate = "DEP_ROLE-005";
        public const string DuplicateRoleName = "DEP_ROLE-006";
        public const string RoleNotFoundOrNotDeleted = "DEP_ROLE-007"; // Unique code assigned
        public const string RoleAlreadyDeleted = "DEP_ROLE-008"; 
    }

    public static class DepartmentManager
    {
        public const string DepartmentManagerNotFound = "DM-001";
        public const string DepartmentManagerNotFoundForUpdate = "DM-002";
        public const string DepartmentManagerNotFoundForSoftDelete = "DM-003";
        public const string DepartmentManagerNotFoundForPermanentDelete = "DM-004";
        public const string DepartmentManagerNotFoundForRestoration = "DM-005";
        public const string DepartmentManagerNotDeleted = "DM-006";
    }

    public static class Role
    {
        public const string InvalidRoleName = "ROLE-001";
        public const string RoleAlreadyExists = "ROLE-002";
        public const string RoleNotFound = "ROLE-004";
        public const string RoleNotFoundForPermanentDeletion = "ROLE-005";
        public const string RoleNotFoundForRestoration = "ROLE-006";
        public const string RoleNotDeleted = "ROLE-007";
        public const string DuplicateRoleNameOnRestore = "ROLE-008";
        public const string RoleNotFoundForSoftDeletion = "ROLE-009";
        public const string RoleAlreadyDeleted = "ROLE-010";
        public const string InvalidRoleNameForUpdate = "ROLE-011";
        public const string RoleNotFoundForUpdate = "ROLE-012";
        public const string DuplicateRoleName = "ROLE-013";
    }

    public static class SkillHistory
    {
        public const string UserIdCannotBeEmpty = "SKILLHISTORY-001";
        public const string SkillIdCannotBeEmpty = "SKILLHISTORY-002";
        public const string InvalidProficiencyLevel = "SKILLHISTORY-003";
        public const string SkillHistoryIdCannotBeEmptyForGet = "SKILLHISTORY-004";
        public const string SkillHistoryNotFound = "SKILLHISTORY-005";
        public const string SkillHistoryIdCannotBeEmptyForUpdate = "SKILLHISTORY-006";
        public const string UserIdCannotBeEmptyForUpdate = "SKILLHISTORY-007";
        public const string SkillIdCannotBeEmptyForUpdate = "SKILLHISTORY-008";
        public const string InvalidProficiencyLevelForUpdate = "SKILLHISTORY-009";
        public const string SkillHistoryNotFoundForUpdate = "SKILLHISTORY-010";
        public const string SkillHistoryIdCannotBeEmptyForSoftDelete = "SKILLHISTORY-011";
        public const string SkillHistoryNotFoundForSoftDeletion = "SKILLHISTORY-012";
        public const string SkillHistoryAlreadyDeleted = "SKILLHISTORY-013";
        public const string SkillHistoryIdCannotBeEmptyForPermanentDelete = "SKILLHISTORY-014";
        public const string SkillHistoryNotFoundForPermanentDeletion = "SKILLHISTORY-015";
        public const string SkillHistoryIdCannotBeEmptyForRestoration = "SKILLHISTORY-016";
        public const string SkillHistoryNotFoundForRestoration = "SKILLHISTORY-017";
        public const string SkillHistoryNotDeleted = "SKILLHISTORY-018";
    }

    public static class SkillMatrix
    {
        public const string DepartmentIdCannotBeEmpty = "SM-001";
        public const string SkillIdCannotBeEmpty = "SM-002";
        public const string SkillMatrixCombinationAlreadyExists = "SM-003";
        public const string SkillMatrixNotFound = "SM-005";
        public const string SkillMatrixNotFoundForPermanentDeletion = "SM-006";
        public const string SkillMatrixNotFoundForRestoration = "SM-007";
        public const string SkillMatrixNotDeleted = "SM-008";
        public const string SkillMatrixNotFoundForSoftDeletion = "SM-009";
        public const string SkillMatrixAlreadyDeleted = "SM-010";
        public const string DepartmentIdCannotBeEmptyForUpdate = "SM-011";
        public const string SkillIdCannotBeEmptyForUpdate = "SM-012";
        public const string SkillMatrixNotFoundForUpdate = "SM-013";
        public const string DuplicateSkillMatrixCombination = "SM-014";
        public const string DuplicateSkillMatrixCombinationOnRestore = "SM-015";
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
