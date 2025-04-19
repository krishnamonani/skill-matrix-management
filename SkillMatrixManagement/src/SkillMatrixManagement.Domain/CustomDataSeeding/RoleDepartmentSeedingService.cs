using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace SkillMatrixManagement.CustomDataSeeding
{
    class RoleDepartmentSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Role, Guid> _roleRepository;
        private readonly IRepository<Department, Guid> _departmentRepositry;
        private readonly IRepository<RoleDepartment, Guid> _roleDepartmentRepositry;

        public RoleDepartmentSeedingService(IRepository<Role, Guid> roleRepository, IRepository<Department, Guid> departmentRepositry, IRepository<RoleDepartment, Guid> roleDepartmentRepositry)
        {
            _roleRepository = roleRepository;
            _departmentRepositry = departmentRepositry;
            _roleDepartmentRepositry = roleDepartmentRepositry;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _roleDepartmentRepositry.GetCountAsync() > 0) return;

            var ROLE = await _roleRepository.GetListAsync();
            var DEPT = await _departmentRepositry.GetListAsync();

            //role
            var ROLE_HR = ROLE.FirstOrDefault(role => role.Name == RoleEnum.ROLE_HR);
            var ROLE_ADMIN = ROLE.FirstOrDefault(role => role.Name == RoleEnum.ROLE_ADMIN);
            var ROLE_DEVELOPER = ROLE.FirstOrDefault(role => role.Name == RoleEnum.ROLE_DEVELOPER);
            var ROLE_MANAGER = ROLE.FirstOrDefault(role => role.Name == RoleEnum.ROLE_MANAGER);

            //department
            var DEPT_TECH = DEPT.FirstOrDefault(dept => dept.Name == "Tech");
            var DEPT_AIML = DEPT.FirstOrDefault(dept => dept.Name == "AI/ML");
            var DEPT_BUSINESS_ANALYST = DEPT.FirstOrDefault(dept => dept.Name == "Business Analyst");
            var DEPT_BUSINESS_DEVELOPMENT = DEPT.FirstOrDefault(dept => dept.Name == "Business Development");
            var DEPT_CONTENT = DEPT.FirstOrDefault(dept => dept.Name == "Content");
            var DEPT_DESIGN = DEPT.FirstOrDefault(dept => dept.Name == "Design");
            var DEPT_DEVOPS = DEPT.FirstOrDefault(dept => dept.Name == "DevOps");
            var DEPT_HUMAN_RESOURCES = DEPT.FirstOrDefault(dept => dept.Name == "Human Resources");
            var DEPT_PROJECT_MANAGEMENT = DEPT.FirstOrDefault(dept => dept.Name == "Project Management");
            var DEPT_QUALITY = DEPT.FirstOrDefault(dept => dept.Name == "Quality");
            var DEPT_MARKETING = DEPT.FirstOrDefault(dept => dept.Name == "Marketing");

            var HR_HUMAN_RESOURCES = new RoleDepartment
            {
                RoleId = ROLE_HR.Id,
                RoleName = RoleEnum.ROLE_HR,
                DepartmentId = DEPT_HUMAN_RESOURCES.Id,
                DepartmentName = DEPT_HUMAN_RESOURCES.Name
            };

            var HR_BUSINESS_DEVELOPMENT = new RoleDepartment
            {
                RoleId = ROLE_HR.Id,
                RoleName = RoleEnum.ROLE_HR,
                DepartmentId = DEPT_BUSINESS_DEVELOPMENT.Id,
                DepartmentName = DEPT_BUSINESS_DEVELOPMENT.Name
            };

            var HR_CONTENT = new RoleDepartment
            {
                RoleId = ROLE_HR.Id,
                RoleName = RoleEnum.ROLE_HR,
                DepartmentId = DEPT_CONTENT.Id,
                DepartmentName = DEPT_CONTENT.Name
            };

            var ADMIN_MARKETING = new RoleDepartment
            {
                RoleId = ROLE_ADMIN.Id,
                RoleName = RoleEnum.ROLE_ADMIN,
                DepartmentId = DEPT_MARKETING.Id,
                DepartmentName = DEPT_MARKETING.Name
            };

            var DEVELOPER_TECH = new RoleDepartment
            {
                RoleId = ROLE_DEVELOPER.Id,
                RoleName = RoleEnum.ROLE_DEVELOPER,
                DepartmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name
            };

            var DEVELOPER_AIML = new RoleDepartment
            {
                RoleId = ROLE_DEVELOPER.Id,
                RoleName = RoleEnum.ROLE_DEVELOPER,
                DepartmentId = DEPT_AIML.Id,
                DepartmentName = DEPT_AIML.Name
            };

            var DEVELOPER_BUSINESS_ANALYST = new RoleDepartment
            {
                RoleId = ROLE_DEVELOPER.Id,
                RoleName = RoleEnum.ROLE_DEVELOPER,
                DepartmentId = DEPT_BUSINESS_ANALYST.Id,
                DepartmentName = DEPT_BUSINESS_ANALYST.Name
            };

            var DEVELOPER_DESIGN = new RoleDepartment
            {
                RoleId = ROLE_DEVELOPER.Id,
                RoleName = RoleEnum.ROLE_DEVELOPER,
                DepartmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name
            };

            var DEVELOPER_DEVOPS = new RoleDepartment
            {
                RoleId = ROLE_DEVELOPER.Id,
                RoleName = RoleEnum.ROLE_DEVELOPER,
                DepartmentId = DEPT_DEVOPS.Id,
                DepartmentName = DEPT_DEVOPS.Name
            };

            var DEVELOPER_QUALITY = new RoleDepartment
            {
                RoleId = ROLE_DEVELOPER.Id,
                RoleName = RoleEnum.ROLE_DEVELOPER,
                DepartmentId = DEPT_QUALITY.Id,
                DepartmentName = DEPT_QUALITY.Name
            };

            var MANAGER_PROJECT_MANAGEMENT = new RoleDepartment
            {
                RoleId = ROLE_MANAGER.Id,
                RoleName = RoleEnum.ROLE_MANAGER,
                DepartmentId = DEPT_PROJECT_MANAGEMENT.Id,
                DepartmentName = DEPT_PROJECT_MANAGEMENT.Name
            };

            var roleDepartments = new List<RoleDepartment>
    {
        HR_HUMAN_RESOURCES,
        HR_BUSINESS_DEVELOPMENT,
        HR_CONTENT,
        ADMIN_MARKETING,
        DEVELOPER_TECH,
        DEVELOPER_AIML,
        DEVELOPER_BUSINESS_ANALYST,
        DEVELOPER_DESIGN,
        DEVELOPER_DEVOPS,
        DEVELOPER_QUALITY,
        MANAGER_PROJECT_MANAGEMENT
    };

            await _roleDepartmentRepositry.InsertManyAsync(roleDepartments);
        }
    }
}
