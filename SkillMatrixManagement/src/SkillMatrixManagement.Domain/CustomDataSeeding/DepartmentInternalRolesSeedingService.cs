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

namespace SkillMatrixManagement.CustomDataSeeding
{
    class DepartmentInternalRolesSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<DepartmentInternalRole, Guid> _departmentInternalRoleRepository;

        public DepartmentInternalRolesSeedingService(IRepository<DepartmentInternalRole, Guid> departmentInternalRoleRepository)
        {
            _departmentInternalRoleRepository = departmentInternalRoleRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _departmentInternalRoleRepository.GetCountAsync() > 0) return;

            var softwareEngineerTrainee = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_ENGINEER_TRAINEE,
                RoleDescription = "Entry-level software engineer undergoing training.",
                Position = RolePositionEnum.TRAINEE
            };

            var softwareEngineerI = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_ENGINEER_I,
                RoleDescription = "Junior-level software engineer with foundational coding skills.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var softwareEngineerII = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_ENGINEER_II,
                RoleDescription = "Mid-level software engineer with strong development experience.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var softwareEngineerIII = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_ENGINEER_III,
                RoleDescription = "Senior software engineer responsible for technical solutions.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var techLead = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.TECH_LEAD,
                RoleDescription = "Technical lead guiding development teams.",
                Position = RolePositionEnum.LEAD
            };

            var solutionArchitect = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOLUTION_ARCHITECT,
                RoleDescription = "Designs comprehensive software solutions.",
                Position = RolePositionEnum.MANAGER
            };

            var vpEngineering = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.VP_OF_ENGINEERING,
                RoleDescription = "Leads engineering teams and drives technology vision.",
                Position = RolePositionEnum.MANAGER
            };

            var managingDirector = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.MANAGING_DIRECTOR,
                RoleDescription = "Oversees company operations and strategies.",
                Position = RolePositionEnum.HOD
            };

            var softwareEngineerIAIML = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_ENGINEER_I_AI_ML,
                RoleDescription = "Junior AI/ML engineer with entry-level experience.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var softwareEngineerIIAIML = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_ENGINEER_II_AI_ML,
                RoleDescription = "Mid-level AI/ML engineer specializing in advanced models.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var cfo = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CFO,
                RoleDescription = "Chief Financial Officer managing financial operations.",
                Position = RolePositionEnum.HOD
            };

            var businessAnalyst = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.BUSINESS_ANALYST,
                RoleDescription = "Analyzes business requirements and trends.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var seniorBusinessAnalyst = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_BUSINESS_ANALYST,
                RoleDescription = "Leads business analysis processes and improvements.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var businessDevelopmentExecutive = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.BUSINESS_DEVELOPMENT_EXECUTIVE,
                RoleDescription = "Identifies and develops business growth opportunities.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var seniorBusinessDevelopmentExecutive = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_BUSINESS_DEVELOPMENT_EXECUTIVE,
                RoleDescription = "Manages business growth strategies and partnerships.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var associateManagerBusinessDevelopment = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.ASSOCIATE_MANAGER_BUSINESS_DEVELOPMENT,
                RoleDescription = "Manages entry-level business development teams.",
                Position = RolePositionEnum.LEAD
            };

            var associateManagerCustomerSuccess = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.ASSOCIATE_MANAGER_CUSTOMER_SUCCESS,
                RoleDescription = "Leads customer success strategies for enhanced satisfaction.",
                Position = RolePositionEnum.LEAD
            };

            var businessDevelopmentManager = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.BUSINESS_DEVELOPMENT_MANAGER,
                RoleDescription = "Drives business expansion and key client relationships.",
                Position = RolePositionEnum.MANAGER
            };

            var customerSuccessManager = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CUSTOMER_SUCCESS_MANAGER,
                RoleDescription = "Ensures customer retention and satisfaction.",
                Position = RolePositionEnum.MANAGER
            };

            var avpSales = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.AVP_SALES,
                RoleDescription = "Assistant Vice President of Sales overseeing sales goals.",
                Position = RolePositionEnum.MANAGER
            };

            var vpSales = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.VP_SALES,
                RoleDescription = "Vice President of Sales ensuring revenue targets.",
                Position = RolePositionEnum.MANAGER
            };

            var cso = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CSO,
                RoleDescription = "Chief Security Officer responsible for security policies.",
                Position = RolePositionEnum.HOD
            };

            var contentTrainee = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CONTENT_TRAINEE,
                RoleDescription = "Entry-level content trainee responsible for assisting content creation.",
                Position = RolePositionEnum.TRAINEE
            };

            var contentWriter = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CONTENT_WRITER,
                RoleDescription = "Writes content for blogs, websites, and marketing materials.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var seniorContentWriter = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_CONTENT_WRITER,
                RoleDescription = "Leads content creation and ensures quality standards.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var contentLead = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CONTENT_LEAD,
                RoleDescription = "Oversees content strategy and manages content teams.",
                Position = RolePositionEnum.LEAD
            };

            var cmo = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CMO,
                RoleDescription = "Chief Marketing Officer responsible for marketing strategies.",
                Position = RolePositionEnum.HOD
            };

            var uxDesignerTrainee = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.UX_DESIGNER_TRAINEE,
                RoleDescription = "Entry-level UX designer learning design principles.",
                Position = RolePositionEnum.TRAINEE
            };

            var uxDesigner = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.UX_DESIGNER,
                RoleDescription = "Designs user interfaces with a focus on user experience.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var seniorUxDesigner = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_UX_DESIGNER,
                RoleDescription = "Leads UX design projects and mentors junior designers.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var uxDesignLead = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.UX_DESIGN_LEAD,
                RoleDescription = "Manages UX design teams and sets design direction.",
                Position = RolePositionEnum.LEAD
            };

            var brandDesigner = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.BRAND_DESIGNER,
                RoleDescription = "Designs brand identity materials and marketing visuals.",
                Position = RolePositionEnum.LEAD
            };

            var productDesigner = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.PRODUCT_DESIGNER,
                RoleDescription = "Designs product interfaces and ensures usability.",
                Position = RolePositionEnum.LEAD
            };

            var creativeHead = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CREATIVE_HEAD,
                RoleDescription = "Leads creative projects and ensures visual consistency.",
                Position = RolePositionEnum.MANAGER
            };

            var devopsEngineerI = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.DEVOPS_ENGINEER_I,
                RoleDescription = "Entry-level DevOps engineer managing CI/CD pipelines.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var devopsEngineerII = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.DEVOPS_ENGINEER_II,
                RoleDescription = "Experienced DevOps engineer handling infrastructure automation.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var cpo = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CPO,
                RoleDescription = "Chief Product Officer managing product strategies.",
                Position = RolePositionEnum.HOD
            };

            var hrTrainee = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.HR_TRAINEE,
                RoleDescription = "Entry-level HR professional learning HR processes.",
                Position = RolePositionEnum.TRAINEE
            };

            var adminAssistant = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.ADMIN_ASSISTANT,
                RoleDescription = "Assists with administrative tasks and operations.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var adminExecutive = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.ADMIN_EXECUTIVE,
                RoleDescription = "Oversees administrative functions and support.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var ceo = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CEO,
                RoleDescription = "Chief Executive Officer guiding company vision.",
                Position = RolePositionEnum.HOD
            };

            var projectManager = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.PROJECT_MANAGER,
                RoleDescription = "Manages project timelines, resources, and deliverables.",
                Position = RolePositionEnum.MANAGER
            };

            var seniorProjectManager = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_PROJECT_MANAGER,
                RoleDescription = "Oversees complex projects and manages project teams.",
                Position = RolePositionEnum.MANAGER
            };

            var vpOperationsAndDelivery = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.VP_OF_OPERATIONS_AND_DELIVERY,
                RoleDescription = "Ensures successful project delivery and operational excellence.",
                Position = RolePositionEnum.MANAGER
            };

            var coo = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.COO,
                RoleDescription = "Chief Operating Officer managing daily operations.",
                Position = RolePositionEnum.HOD
            };

            var softwareTestEngineerFunctional = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_TEST_ENGINEER_FUNCTIONAL,
                RoleDescription = "Tests software functionality to ensure quality.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var softwareTestEngineerAutomation = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SOFTWARE_TEST_ENGINEER_AUTOMATION,
                RoleDescription = "Automates testing processes for efficient quality assurance.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var seniorTestEngineer = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_TEST_ENGINEER,
                RoleDescription = "Leads testing initiatives and mentors junior testers.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var marketingTrainee = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.MARKETING_TRAINEE,
                RoleDescription = "Entry-level marketer assisting with campaigns.",
                Position = RolePositionEnum.TRAINEE
            };

            var marketingExecutive = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.MARKETING_EXECUTIVE,
                RoleDescription = "Executes marketing strategies and campaigns.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var seniorMarketingExecutive = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.SENIOR_MARKETING_EXECUTIVE,
                RoleDescription = "Leads marketing campaigns and mentors junior marketers.",
                Position = RolePositionEnum.ASSOCIATE
            };

            var marketingLead = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.MARKETING_LEAD,
                RoleDescription = "Manages marketing strategies and campaigns.",
                Position = RolePositionEnum.LEAD
            };

            var marketingManager = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.MARKETING_MANAGER,
                RoleDescription = "Oversees the entire marketing team and strategies.",
                Position = RolePositionEnum.MANAGER
            };

            var cto = new DepartmentInternalRole
            {
                RoleName = DepartmentRoleEnum.CTO,
                RoleDescription = "Chief Technology Officer driving technical innovation.",
                Position = RolePositionEnum.HOD
            };

            // Add all roles to a list
            await _departmentInternalRoleRepository.InsertManyAsync(new List<DepartmentInternalRole>() {
            softwareEngineerTrainee,
            softwareEngineerI,
            softwareEngineerII,
            softwareEngineerIII,
            techLead,
            solutionArchitect,
            vpEngineering,
            managingDirector,
            softwareEngineerIAIML,
            softwareEngineerIIAIML,
            cfo,
            businessAnalyst,
            seniorBusinessAnalyst,
            businessDevelopmentExecutive,
            seniorBusinessDevelopmentExecutive,
            associateManagerBusinessDevelopment,
            associateManagerCustomerSuccess,
            businessDevelopmentManager,
            customerSuccessManager,
            avpSales,
            vpSales,
            cso,
            contentTrainee,
            contentWriter,
            seniorContentWriter,
            contentLead,
            cmo,
            uxDesignerTrainee,
            uxDesigner,
            seniorUxDesigner,
            uxDesignLead,
            brandDesigner,
            productDesigner,
            creativeHead,
            devopsEngineerI,
            devopsEngineerII,
            cpo,
            hrTrainee,
            adminAssistant,
            adminExecutive,
            ceo,
            projectManager,
            seniorProjectManager,
            vpOperationsAndDelivery,
            coo,
            softwareTestEngineerFunctional,
            softwareTestEngineerAutomation,
            seniorTestEngineer,
            marketingTrainee,
            marketingExecutive,
            seniorMarketingExecutive,
            marketingLead,
            marketingManager,
            cto
                });
        }
    }
}
