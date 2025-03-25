namespace SkillMatrixManagement
{
    public static class SkillMatrixManagementDomainErrorCodes
    {
        // Department error codes
        public const string INVALID_DEPARTMENT_ID = "DEPARTMENT-001";
        public const string DEPARTMENT_NOT_FOUND = "DEPARTMENT-002";
        public const string DEPARTMENT_ALREADY_EXISTS = "DEPARTMENT-003";
        public const string DEPARTMENT_ALREADY_DELETED = "DEPARTMENT-004";
        public const string DEPARTMENT_NOT_DELETED = "DEPARTMENT-005";

        // DepartmentRole Errors
        public const string DEPARTMENT_ROLE_ALREADY_EXISTS = "DEPARTMENT_ROLE-001";
        public const string DEPARTMENT_ROLE_NOT_FOUND = "DEPARTMENT_ROLE-002";
        public const string INVALID_DEPARTMENT_ROLE_ID = "DEPARTMENT_ROLE-003";
        public const string DEPARTMENT_ROLE_ALREADY_DELETED = "DEPARTMENT_ROLE-004";
        public const string DEPARTMENT_ROLE_NOT_DELETED = "DEPARTMENT_ROLE-005";

        // EmployeeSkill Errors
        public const string EMPLOYEE_SKILL_ALREADY_EXISTS = "EMPLOYEE_SKILL-001";
        public const string EMPLOYEE_SKILL_NOT_FOUND = "EMPLOYEE_SKILL-002";
        public const string INVALID_EMPLOYEE_SKILL_ID = "EMPLOYEE_SKILL-003";
        public const string EMPLOYEE_SKILL_ALREADY_DELETED = "EMPLOYEE_SKILL-004";
        public const string EMPLOYEE_SKILL_NOT_DELETED = "EMPLOYEE_SKILL-005";
    }
}
