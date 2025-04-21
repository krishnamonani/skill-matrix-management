using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.CustomDataSeeding
{
    class DepartmentSkillSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Department, Guid> _departmentRepository;
        private readonly IRepository<Skill, Guid> _skillRepositry;
        private readonly IRepository<DepartmentSkill, Guid> _departmentSkillRepositry;

        public DepartmentSkillSeedingService(IRepository<Department, Guid> departmentRepository, IRepository<Skill, Guid> skillRepositry, IRepository<DepartmentSkill, Guid> departmentSkillRepositry)
        {
            _departmentRepository = departmentRepository;
            _skillRepositry = skillRepositry;
            _departmentSkillRepositry = departmentSkillRepositry;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _departmentSkillRepositry.GetCountAsync() > 0) return;

            var SKILL = await _skillRepositry.GetListAsync();

            var DEPT = await _departmentRepository.GetListAsync();

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


            var SKILL_BRAND_DESIGNER = SKILL.FirstOrDefault(skill => skill.Name == "BRAND_DESIGNER");
            var SKILL_BUSINESS_ANALYST = SKILL.FirstOrDefault(skill => skill.Name == "BUSINESS_ANALYST");
            var SKILL_CONTENT_LEAD = SKILL.FirstOrDefault(skill => skill.Name == "CONTENT_LEAD");
            var SKILL_CONTENT_TRAINEE = SKILL.FirstOrDefault(skill => skill.Name == "CONTENT_TRAINEE");
            var SKILL_CREATIVE_HEAD = SKILL.FirstOrDefault(skill => skill.Name == "CREATIVE_HEAD");
            var SKILL_DEVOPS_ENGINEER_I = SKILL.FirstOrDefault(skill => skill.Name == "DEVOPS_ENGINEER_I");
            var SKILL_DEVOPS_ENGINEER_II = SKILL.FirstOrDefault(skill => skill.Name == "DEVOPS_ENGINEER_II");
            var SKILL_MARKETING_EXECUTIVE = SKILL.FirstOrDefault(skill => skill.Name == "MARKETING_EXECUTIVE");
            var SKILL_MARKETING_LEAD = SKILL.FirstOrDefault(skill => skill.Name == "MARKETING_LEAD");
            var SKILL_MARKETING_MANAGER = SKILL.FirstOrDefault(skill => skill.Name == "MARKETING_MANAGER");
            var SKILL_MARKETING_TRAINEE = SKILL.FirstOrDefault(skill => skill.Name == "MARKETING_TRAINEE");
            var SKILL_PRODUCT_DESIGNER = SKILL.FirstOrDefault(skill => skill.Name == "PRODUCT_DESIGNER");
            var SKILL_PROJECT_MANAGER = SKILL.FirstOrDefault(skill => skill.Name == "PROJECT_MANAGER");
            var SKILL_SENIOR_BUSINESS_ANALYST = SKILL.FirstOrDefault(skill => skill.Name == "SENIOR_BUSINESS_ANALYST");
            var SKILL_SENIOR_MARKETING_EXECUTIVE = SKILL.FirstOrDefault(skill => skill.Name == "SENIOR_MARKETING_EXECUTIVE");
            var SKILL_SENIOR_PROJECT_MANAGER = SKILL.FirstOrDefault(skill => skill.Name == "SENIOR_PROJECT_MANAGER");
            var SKILL_SENIOR_UX_DESIGNER = SKILL.FirstOrDefault(skill => skill.Name == "SENIOR_UX_DESIGNER");
            var SKILL_SOFTWARE_ENGINEER_I_AI_ML = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_AI_ML");
            var SKILL_SOFTWARE_ENGINEER_II_AI_ML = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_AI_ML");
            var SKILL_SOFTWARE_ENGINEER_III_WEB = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_III_WEB");
            var SKILL_SOFTWARE_ENGINEER_III_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_III_COMMON");
            var SKILL_SOFTWARE_ENGINEER_II_BACKEND_DOTNET = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_BACKEND_DOTNET");
            var SKILL_SOFTWARE_ENGINEER_II_BACKEND_NODE = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_BACKEND_NODE");
            var SKILL_SOFTWARE_ENGINEER_II_BACKEND_JAVA = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_BACKEND_JAVA");
            var SKILL_SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR");
            var SKILL_SOFTWARE_ENGINEER_II_FRONTEND_REACT = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_FRONTEND_REACT");
            var SKILL_SOFTWARE_ENGINEER_II_MOBILE_ANDROID = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_MOBILE_ANDROID");
            var SKILL_SOFTWARE_ENGINEER_II_MOBILE_IOS = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_MOBILE_IOS");
            var SKILL_SOFTWARE_ENGINEER_II_MOBILE_FLUTTER = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_MOBILE_FLUTTER");
            var SKILL_SOFTWARE_ENGINEER_II_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_II_COMMON");
            var SKILL_SOFTWARE_ENGINEER_I_BACKEND_DOTNET = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_BACKEND_DOTNET");
            var SKILL_SOFTWARE_ENGINEER_I_BACKEND_NODE = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_BACKEND_NODE");
            var SKILL_SOFTWARE_ENGINEER_I_BACKEND_JAVA = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_BACKEND_JAVA");
            var SKILL_SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR");
            var SKILL_SOFTWARE_ENGINEER_I_FRONTEND_REACT = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_FRONTEND_REACT");
            var SKILL_SOFTWARE_ENGINEER_I_MOBILE_ANDROID = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_MOBILE_ANDROID");
            var SKILL_SOFTWARE_ENGINEER_I_MOBILE_IOS = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_MOBILE_IOS");
            var SKILL_SOFTWARE_ENGINEER_I_MOBILE_FLUTTER = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_MOBILE_FLUTTER");
            var SKILL_SOFTWARE_ENGINEER_I_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_I_COMMON");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER");
            var SKILL_SOFTWARE_ENGINEER_TRAINEE_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_ENGINEER_TRAINEE_COMMON");
            var SKILL_SOFTWARE_TEST_ENGINEER_AUTOMATION = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_TEST_ENGINEER_AUTOMATION");
            var SKILL_SOFTWARE_TEST_ENGINEER_FUNCTIONAL = SKILL.FirstOrDefault(skill => skill.Name == "SOFTWARE_TEST_ENGINEER_FUNCTIONAL");
            var SKILL_SOLUTION_ARCHITECT_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "SOLUTION_ARCHITECT_COMMON");
            var SKILL_TECH_LEAD = SKILL.FirstOrDefault(skill => skill.Name == "TECH_LEAD");
            var SKILL_TECH_LEAD_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "TECH_LEAD_COMMON");
            var SKILL_UX_DESIGNER = SKILL.FirstOrDefault(skill => skill.Name == "UX_DESIGNER");
            var SKILL_UX_DESIGNER_TRAINEE = SKILL.FirstOrDefault(skill => skill.Name == "UX_DESIGNER_TRAINEE");
            var SKILL_UX_DESIGN_LEAD = SKILL.FirstOrDefault(skill => skill.Name == "UX_DESIGN_LEAD");
            var SKILL_VP_OF_ENGINEERING_COMMON = SKILL.FirstOrDefault(skill => skill.Name == "VP_OF_ENGINEERING_COMMON");
            var SKILL_HR = SKILL.FirstOrDefault(skill => skill.Name == "HUMAN_RESOURSE");


            var DEPT_HR_HUMAN_RESOURSES = new DepartmentSkill
            {
                departmentId = DEPT_HUMAN_RESOURCES.Id,
                DepartmentName = DEPT_HUMAN_RESOURCES.Name,
                SkillId = SKILL_HR.Id,
                SkillName = SKILL_HR.Name,
            };
            var DEPT_AIML_SOFTWARE_ENGINEER_I_AI_ML = new DepartmentSkill
            {
                departmentId = DEPT_AIML.Id,
                DepartmentName = DEPT_AIML.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_AI_ML.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_AI_ML.Name,
            };

            var DEPT_AIML_SOFTWARE_ENGINEER_II_AI_ML = new DepartmentSkill
            {
                departmentId = DEPT_AIML.Id,
                DepartmentName = DEPT_AIML.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_AI_ML.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_AI_ML.Name,
            };

            var DEPT_BUSINESS_ANALYST_BUSINESS_ANALYST = new DepartmentSkill
            {
                departmentId = DEPT_BUSINESS_ANALYST.Id,
                DepartmentName = DEPT_BUSINESS_ANALYST.Name,
                SkillId = SKILL_BUSINESS_ANALYST.Id,
                SkillName = SKILL_BUSINESS_ANALYST.Name,
            };

            var DEPT_BUSINESS_ANALYST_SENIOR_BUSINESS_ANALYST = new DepartmentSkill
            {
                departmentId = DEPT_BUSINESS_ANALYST.Id,
                DepartmentName = DEPT_BUSINESS_ANALYST.Name,
                SkillId = SKILL_SENIOR_BUSINESS_ANALYST.Id,
                SkillName = SKILL_SENIOR_BUSINESS_ANALYST.Name,
            };

            var DEPT_BUSINESS_DEVELOPMENT_BRAND_DESIGNER = new DepartmentSkill
            {
                departmentId = DEPT_BUSINESS_DEVELOPMENT.Id,
                DepartmentName = DEPT_BUSINESS_DEVELOPMENT.Name,
                SkillId = SKILL_BRAND_DESIGNER.Id,
                SkillName = SKILL_BRAND_DESIGNER.Name,
            };

            var DEPT_CONTENT_CONTENT_LEAD = new DepartmentSkill
            {
                departmentId = DEPT_CONTENT.Id,
                DepartmentName = DEPT_CONTENT.Name,
                SkillId = SKILL_CONTENT_LEAD.Id,
                SkillName = SKILL_CONTENT_LEAD.Name,
            };

            var DEPT_CONTENT_CONTENT_TRAINEE = new DepartmentSkill
            {
                departmentId = DEPT_CONTENT.Id,
                DepartmentName = DEPT_CONTENT.Name,
                SkillId = SKILL_CONTENT_TRAINEE.Id,
                SkillName = SKILL_CONTENT_TRAINEE.Name,
            };

            var DEPT_DESIGN_CREATIVE_HEAD = new DepartmentSkill
            {
                departmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name,
                SkillId = SKILL_CREATIVE_HEAD.Id,
                SkillName = SKILL_CREATIVE_HEAD.Name,
            };

            var DEPT_DESIGN_PRODUCT_DESIGNER = new DepartmentSkill
            {
                departmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name,
                SkillId = SKILL_PRODUCT_DESIGNER.Id,
                SkillName = SKILL_PRODUCT_DESIGNER.Name,
            };

            var DEPT_DESIGN_SENIOR_UX_DESIGNER = new DepartmentSkill
            {
                departmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name,
                SkillId = SKILL_SENIOR_UX_DESIGNER.Id,
                SkillName = SKILL_SENIOR_UX_DESIGNER.Name,
            };

            var DEPT_DESIGN_UX_DESIGNER = new DepartmentSkill
            {
                departmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name,
                SkillId = SKILL_UX_DESIGNER.Id,
                SkillName = SKILL_UX_DESIGNER.Name,
            };

            var DEPT_DESIGN_UX_DESIGNER_TRAINEE = new DepartmentSkill
            {
                departmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name,
                SkillId = SKILL_UX_DESIGNER_TRAINEE.Id,
                SkillName = SKILL_UX_DESIGNER_TRAINEE.Name,
            };

            var DEPT_DESIGN_UX_DESIGN_LEAD = new DepartmentSkill
            {
                departmentId = DEPT_DESIGN.Id,
                DepartmentName = DEPT_DESIGN.Name,
                SkillId = SKILL_UX_DESIGN_LEAD.Id,
                SkillName = SKILL_UX_DESIGN_LEAD.Name,
            };

            var DEPT_DEVOPS_DEVOPS_ENGINEER_I = new DepartmentSkill
            {
                departmentId = DEPT_DEVOPS.Id,
                DepartmentName = DEPT_DEVOPS.Name,
                SkillId = SKILL_DEVOPS_ENGINEER_I.Id,
                SkillName = SKILL_DEVOPS_ENGINEER_I.Name,
            };

            var DEPT_DEVOPS_DEVOPS_ENGINEER_II = new DepartmentSkill
            {
                departmentId = DEPT_DEVOPS.Id,
                DepartmentName = DEPT_DEVOPS.Name,
                SkillId = SKILL_DEVOPS_ENGINEER_II.Id,
                SkillName = SKILL_DEVOPS_ENGINEER_II.Name,
            };

            var DEPT_PROJECT_MANAGEMENT_PROJECT_MANAGER = new DepartmentSkill
            {
                departmentId = DEPT_PROJECT_MANAGEMENT.Id,
                DepartmentName = DEPT_PROJECT_MANAGEMENT.Name,
                SkillId = SKILL_PROJECT_MANAGER.Id,
                SkillName = SKILL_PROJECT_MANAGER.Name,
            };

            var DEPT_PROJECT_MANAGEMENT_SENIOR_PROJECT_MANAGER = new DepartmentSkill
            {
                departmentId = DEPT_PROJECT_MANAGEMENT.Id,
                DepartmentName = DEPT_PROJECT_MANAGEMENT.Name,
                SkillId = SKILL_SENIOR_PROJECT_MANAGER.Id,
                SkillName = SKILL_SENIOR_PROJECT_MANAGER.Name,
            };

            var DEPT_QUALITY_SOFTWARE_TEST_ENGINEER_AUTOMATION = new DepartmentSkill
            {
                departmentId = DEPT_QUALITY.Id,
                DepartmentName = DEPT_QUALITY.Name,
                SkillId = SKILL_SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
                SkillName = SKILL_SOFTWARE_TEST_ENGINEER_AUTOMATION.Name,
            };

            var DEPT_QUALITY_SOFTWARE_TEST_ENGINEER_FUNCTIONAL = new DepartmentSkill
            {
                departmentId = DEPT_QUALITY.Id,
                DepartmentName = DEPT_QUALITY.Name,
                SkillId = SKILL_SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
                SkillName = SKILL_SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Name,
            };

            var DEPT_MARKETING_MARKETING_EXECUTIVE = new DepartmentSkill
            {
                departmentId = DEPT_MARKETING.Id,
                DepartmentName = DEPT_MARKETING.Name,
                SkillId = SKILL_MARKETING_EXECUTIVE.Id,
                SkillName = SKILL_MARKETING_EXECUTIVE.Name,
            };

            var DEPT_MARKETING_MARKETING_LEAD = new DepartmentSkill
            {
                departmentId = DEPT_MARKETING.Id,
                DepartmentName = DEPT_MARKETING.Name,
                SkillId = SKILL_MARKETING_LEAD.Id,
                SkillName = SKILL_MARKETING_LEAD.Name,
            };

            var DEPT_MARKETING_MARKETING_MANAGER = new DepartmentSkill
            {
                departmentId = DEPT_MARKETING.Id,
                DepartmentName = DEPT_MARKETING.Name,
                SkillId = SKILL_MARKETING_MANAGER.Id,
                SkillName = SKILL_MARKETING_MANAGER.Name,
            };

            var DEPT_MARKETING_MARKETING_TRAINEE = new DepartmentSkill
            {
                departmentId = DEPT_MARKETING.Id,
                DepartmentName = DEPT_MARKETING.Name,
                SkillId = SKILL_MARKETING_TRAINEE.Id,
                SkillName = SKILL_MARKETING_TRAINEE.Name,
            };

            var DEPT_MARKETING_SENIOR_MARKETING_EXECUTIVE = new DepartmentSkill
            {
                departmentId = DEPT_MARKETING.Id,
                DepartmentName = DEPT_MARKETING.Name,
                SkillId = SKILL_SENIOR_MARKETING_EXECUTIVE.Id,
                SkillName = SKILL_SENIOR_MARKETING_EXECUTIVE.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_III_WEB = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_III_WEB.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_III_WEB.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_III_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_III_COMMON.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_III_COMMON.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_BACKEND_DOTNET = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_BACKEND_NODE = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_BACKEND_NODE.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_BACKEND_JAVA = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_BACKEND_JAVA.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_FRONTEND_REACT = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_FRONTEND_REACT.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_MOBILE_ANDROID = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_MOBILE_IOS = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_MOBILE_IOS.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_MOBILE_IOS.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_MOBILE_FLUTTER = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_II_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_II_COMMON.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_II_COMMON.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_BACKEND_DOTNET = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_BACKEND_NODE = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_BACKEND_NODE.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_BACKEND_JAVA = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_BACKEND_JAVA.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_FRONTEND_REACT = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_FRONTEND_REACT.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_MOBILE_ANDROID = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_MOBILE_IOS = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_MOBILE_IOS.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_MOBILE_FLUTTER = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_I_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_I_COMMON.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_I_COMMON.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Name,
            };

            var DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOFTWARE_ENGINEER_TRAINEE_COMMON.Id,
                SkillName = SKILL_SOFTWARE_ENGINEER_TRAINEE_COMMON.Name,
            };

            var DEPT_TECH_SOLUTION_ARCHITECT_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_SOLUTION_ARCHITECT_COMMON.Id,
                SkillName = SKILL_SOLUTION_ARCHITECT_COMMON.Name,
            };

            var DEPT_TECH_TECH_LEAD = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_TECH_LEAD.Id,
                SkillName = SKILL_TECH_LEAD.Name,
            };

            var DEPT_TECH_TECH_LEAD_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_TECH_LEAD_COMMON.Id,
                SkillName = SKILL_TECH_LEAD_COMMON.Name,
            };

            var DEPT_TECH_VP_OF_ENGINEERING_COMMON = new DepartmentSkill
            {
                departmentId = DEPT_TECH.Id,
                DepartmentName = DEPT_TECH.Name,
                SkillId = SKILL_VP_OF_ENGINEERING_COMMON.Id,
                SkillName = SKILL_VP_OF_ENGINEERING_COMMON.Name,
            };

            var departmentSkills = new List<DepartmentSkill>
            {
                DEPT_AIML_SOFTWARE_ENGINEER_I_AI_ML,
                DEPT_AIML_SOFTWARE_ENGINEER_II_AI_ML,
                DEPT_BUSINESS_ANALYST_BUSINESS_ANALYST,
                DEPT_BUSINESS_ANALYST_SENIOR_BUSINESS_ANALYST,
                DEPT_BUSINESS_DEVELOPMENT_BRAND_DESIGNER,
                DEPT_CONTENT_CONTENT_LEAD,
                DEPT_CONTENT_CONTENT_TRAINEE,
                DEPT_DESIGN_CREATIVE_HEAD,
                DEPT_DESIGN_PRODUCT_DESIGNER,
                DEPT_DESIGN_SENIOR_UX_DESIGNER,
                DEPT_DESIGN_UX_DESIGNER,
                DEPT_DESIGN_UX_DESIGNER_TRAINEE,
                DEPT_DESIGN_UX_DESIGN_LEAD,
                DEPT_DEVOPS_DEVOPS_ENGINEER_I,
                DEPT_DEVOPS_DEVOPS_ENGINEER_II,
                DEPT_PROJECT_MANAGEMENT_PROJECT_MANAGER,
                DEPT_PROJECT_MANAGEMENT_SENIOR_PROJECT_MANAGER,
                DEPT_QUALITY_SOFTWARE_TEST_ENGINEER_AUTOMATION,
                DEPT_QUALITY_SOFTWARE_TEST_ENGINEER_FUNCTIONAL,
                DEPT_MARKETING_MARKETING_EXECUTIVE,
                DEPT_MARKETING_MARKETING_LEAD,
                DEPT_MARKETING_MARKETING_MANAGER,
                DEPT_MARKETING_MARKETING_TRAINEE,
                DEPT_MARKETING_SENIOR_MARKETING_EXECUTIVE,
                DEPT_TECH_SOFTWARE_ENGINEER_III_WEB,
                DEPT_TECH_SOFTWARE_ENGINEER_III_COMMON,
                DEPT_TECH_SOFTWARE_ENGINEER_II_BACKEND_DOTNET,
                DEPT_TECH_SOFTWARE_ENGINEER_II_BACKEND_NODE,
                DEPT_TECH_SOFTWARE_ENGINEER_II_BACKEND_JAVA,
                DEPT_TECH_SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR,
                DEPT_TECH_SOFTWARE_ENGINEER_II_FRONTEND_REACT,
                DEPT_TECH_SOFTWARE_ENGINEER_II_MOBILE_ANDROID,
                DEPT_TECH_SOFTWARE_ENGINEER_II_MOBILE_IOS,
                DEPT_TECH_SOFTWARE_ENGINEER_II_MOBILE_FLUTTER,
                DEPT_TECH_SOFTWARE_ENGINEER_II_COMMON,
                DEPT_TECH_SOFTWARE_ENGINEER_I_BACKEND_DOTNET,
                DEPT_TECH_SOFTWARE_ENGINEER_I_BACKEND_NODE,
                DEPT_TECH_SOFTWARE_ENGINEER_I_BACKEND_JAVA,
                DEPT_TECH_SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR,
                DEPT_TECH_SOFTWARE_ENGINEER_I_FRONTEND_REACT,
                DEPT_TECH_SOFTWARE_ENGINEER_I_MOBILE_ANDROID,
                DEPT_TECH_SOFTWARE_ENGINEER_I_MOBILE_IOS,
                DEPT_TECH_SOFTWARE_ENGINEER_I_MOBILE_FLUTTER,
                DEPT_TECH_SOFTWARE_ENGINEER_I_COMMON,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER,
                DEPT_TECH_SOFTWARE_ENGINEER_TRAINEE_COMMON,
                DEPT_TECH_SOLUTION_ARCHITECT_COMMON,
                DEPT_TECH_TECH_LEAD,
                DEPT_TECH_TECH_LEAD_COMMON,
                DEPT_TECH_VP_OF_ENGINEERING_COMMON,
                DEPT_HR_HUMAN_RESOURSES
            };

            await _departmentSkillRepositry.InsertManyAsync(departmentSkills);
        }
    }
}