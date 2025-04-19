using SkillMatrixManagement.Models;
using SkillMatrixManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.CustomDataSeeding
{
    public class SkillSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Skill, Guid> _skillRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<DepartmentInternalRole, Guid> _internalRoleRepository;

        public SkillSeedingService(
            IRepository<Skill, Guid> skillRepository,
            IRepository<Category, Guid> categoryRepository,
            IRepository<DepartmentInternalRole, Guid> internalRoleRepository)
        {
            _skillRepository = skillRepository;
            _categoryRepository = categoryRepository;
            _internalRoleRepository = internalRoleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _skillRepository.GetCountAsync() > 0) return;


            // Retrieve existing categories and roles
            var categories = await _categoryRepository.GetListAsync();
            var internalRoles = await _internalRoleRepository.GetListAsync();



            // Map specific IDs by role and category names
            var technicalSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.TECHNICAL_SKILL)?.Id ?? Guid.NewGuid();
            var transferableSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.TRANSFERABLE_SKILL)?.Id ?? Guid.NewGuid();
            var cognitiveSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.COGNITIVE_SKILL)?.Id ?? Guid.NewGuid();
            var interpersonalSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.INTERPERSONAL_SKILL)?.Id ?? Guid.NewGuid();
            var intrapersonalSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.INTRAPERSONAL_SKILL)?.Id ?? Guid.NewGuid();
            var leadershipSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.LEADERSHIP_SKILL)?.Id ?? Guid.NewGuid();
            var creativeSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.CREATIVE_SKILL)?.Id ?? Guid.NewGuid();
            var analyticalSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.ANALYTICAL_SKILL)?.Id ?? Guid.NewGuid();
            var organizationalSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.ORGANIZATIONAL_SKILL)?.Id ?? Guid.NewGuid();
            var digitalSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.DIGITAL_SKILL)?.Id ?? Guid.NewGuid();
            var managementSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.MANAGEMENT_SKILL)?.Id ?? Guid.NewGuid();
            var softSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.SOFT_SKILL)?.Id ?? Guid.NewGuid();
            var HrSkillId = categories.FirstOrDefault(c => c.CategoryName == CategoryEnum.LEADERSHIP_SKILL)?.Id ?? Guid.NewGuid();



            var HRId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.MARKETING_EXECUTIVE)?.Id ?? Guid.NewGuid();
            var softwareEngineerTraineeId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_ENGINEER_TRAINEE)?.Id ?? Guid.NewGuid();
            var softwareEngineerIId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_ENGINEER_I)?.Id ?? Guid.NewGuid();
            var softwareEngineerIIId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_ENGINEER_II)?.Id ?? Guid.NewGuid();
            var softwareEngineerIIIId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_ENGINEER_III)?.Id ?? Guid.NewGuid();
            var techLeadId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.TECH_LEAD)?.Id ?? Guid.NewGuid();
            var solutionArchitectId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOLUTION_ARCHITECT)?.Id ?? Guid.NewGuid();
            var vpOfEngineeringId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.VP_OF_ENGINEERING)?.Id ?? Guid.NewGuid();
            var managingDirectorId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.MANAGING_DIRECTOR)?.Id ?? Guid.NewGuid();
            var softwareEngineerIAIMLId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_ENGINEER_I_AI_ML)?.Id ?? Guid.NewGuid();
            var softwareEngineerIIAIMLId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_ENGINEER_II_AI_ML)?.Id ?? Guid.NewGuid();
            var cfoId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CFO)?.Id ?? Guid.NewGuid();
            var businessAnalystId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.BUSINESS_ANALYST)?.Id ?? Guid.NewGuid();
            var seniorBusinessAnalystId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_BUSINESS_ANALYST)?.Id ?? Guid.NewGuid();
            var businessDevelopmentExecutiveId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.BUSINESS_DEVELOPMENT_EXECUTIVE)?.Id ?? Guid.NewGuid();
            var seniorBusinessDevelopmentExecutiveId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_BUSINESS_DEVELOPMENT_EXECUTIVE)?.Id ?? Guid.NewGuid();
            var associateManagerBusinessDevelopmentId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.ASSOCIATE_MANAGER_BUSINESS_DEVELOPMENT)?.Id ?? Guid.NewGuid();
            var associateManagerCustomerSuccessId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.ASSOCIATE_MANAGER_CUSTOMER_SUCCESS)?.Id ?? Guid.NewGuid();
            var businessDevelopmentManagerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.BUSINESS_DEVELOPMENT_MANAGER)?.Id ?? Guid.NewGuid();
            var customerSuccessManagerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CUSTOMER_SUCCESS_MANAGER)?.Id ?? Guid.NewGuid();
            var avpSalesId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.AVP_SALES)?.Id ?? Guid.NewGuid();
            var vpSalesId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.VP_SALES)?.Id ?? Guid.NewGuid();
            var csoId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CSO)?.Id ?? Guid.NewGuid();
            var contentTraineeId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CONTENT_TRAINEE)?.Id ?? Guid.NewGuid();
            var contentWriterId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CONTENT_WRITER)?.Id ?? Guid.NewGuid();
            var seniorContentWriterId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_CONTENT_WRITER)?.Id ?? Guid.NewGuid();
            var contentLeadId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CONTENT_LEAD)?.Id ?? Guid.NewGuid();
            var cmoId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CMO)?.Id ?? Guid.NewGuid();
            var uxDesignerTraineeId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.UX_DESIGNER_TRAINEE)?.Id ?? Guid.NewGuid();
            var uxDesignerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.UX_DESIGNER)?.Id ?? Guid.NewGuid();
            var seniorUxDesignerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_UX_DESIGNER)?.Id ?? Guid.NewGuid();
            var uxDesignLeadId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.UX_DESIGN_LEAD)?.Id ?? Guid.NewGuid();
            var brandDesignerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.BRAND_DESIGNER)?.Id ?? Guid.NewGuid();
            var productDesignerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.PRODUCT_DESIGNER)?.Id ?? Guid.NewGuid();
            var creativeHeadId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CREATIVE_HEAD)?.Id ?? Guid.NewGuid();
            var devOpsEngineerIId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.DEVOPS_ENGINEER_I)?.Id ?? Guid.NewGuid();
            var devOpsEngineerIIId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.DEVOPS_ENGINEER_II)?.Id ?? Guid.NewGuid();
            var cpoId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CPO)?.Id ?? Guid.NewGuid();
            var hrTraineeId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.HR_TRAINEE)?.Id ?? Guid.NewGuid();
            var adminAssistantId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.ADMIN_ASSISTANT)?.Id ?? Guid.NewGuid();
            var adminExecutiveId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.ADMIN_EXECUTIVE)?.Id ?? Guid.NewGuid();
            var ceoId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CEO)?.Id ?? Guid.NewGuid();
            var projectManagerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.PROJECT_MANAGER)?.Id ?? Guid.NewGuid();
            var seniorProjectManagerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_PROJECT_MANAGER)?.Id ?? Guid.NewGuid();
            var vpOperationsAndDeliveryId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.VP_OF_OPERATIONS_AND_DELIVERY)?.Id ?? Guid.NewGuid();
            var cooId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.COO)?.Id ?? Guid.NewGuid();
            var softwareTestEngineerFunctionalId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_TEST_ENGINEER_FUNCTIONAL)?.Id ?? Guid.NewGuid();
            var softwareTestEngineerAutomationId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SOFTWARE_TEST_ENGINEER_AUTOMATION)?.Id ?? Guid.NewGuid();
            var seniorTestEngineerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_TEST_ENGINEER)?.Id ?? Guid.NewGuid();
            var marketingTraineeId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.MARKETING_TRAINEE)?.Id ?? Guid.NewGuid();
            var marketingExecutiveId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.MARKETING_EXECUTIVE)?.Id ?? Guid.NewGuid();
            var seniorMarketingExecutiveId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.SENIOR_MARKETING_EXECUTIVE)?.Id ?? Guid.NewGuid();
            var marketingLeadId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.MARKETING_LEAD)?.Id ?? Guid.NewGuid();
            var marketingManagerId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.MARKETING_MANAGER)?.Id ?? Guid.NewGuid();
            var ctoId = internalRoles.FirstOrDefault(r => r.RoleName == DepartmentRoleEnum.CTO)?.Id ?? Guid.NewGuid();


            var HR = new Skill
            {
                Name = "HUMAN_RESOURSE",
                Description = "Human Resources (HR) is a department or function within an organization responsible for managing the employee lifecycle and fostering a productive work environment",
                CategoryId = HrSkillId,
                InternalRoleId = HRId


            };
            var brandDesigner = new Skill
            {
                Name = "BRAND_DESIGNER",
                Description = "Creating visual elements that represent a brand's identity and values.",
                CategoryId = creativeSkillId,
                InternalRoleId = brandDesignerId
            };

            var businessAnalyst = new Skill
            {
                Name = "BUSINESS_ANALYST",
                Description = "Analyzing business needs and recommending effective solutions.",
                CategoryId = analyticalSkillId,
                InternalRoleId = businessAnalystId
            };

            var contentLead = new Skill
            {
                Name = "CONTENT_LEAD",
                Description = "Overseeing content strategy and managing content teams.",
                CategoryId = creativeSkillId,
                InternalRoleId = contentLeadId
            };

            var contentTrainee = new Skill
            {
                Name = "CONTENT_TRAINEE",
                Description = "Assisting in content creation and learning content strategies.",
                CategoryId = creativeSkillId,
                InternalRoleId = contentTraineeId
            };

            var creativeHead = new Skill
            {
                Name = "CREATIVE_HEAD",
                Description = "Leading creative projects and ensuring visual consistency.",
                CategoryId = creativeSkillId,
                InternalRoleId = creativeHeadId
            };

            var devOpsEngineerI = new Skill
            {
                Name = "DEVOPS_ENGINEER_I",
                Description = "Implementing and maintaining CI/CD pipelines and infrastructure.",
                CategoryId = technicalSkillId,
                InternalRoleId = devOpsEngineerIId
            };

            var devOpsEngineerII = new Skill
            {
                Name = "DEVOPS_ENGINEER_II",
                Description = "Optimizing and automating infrastructure and deployments.",
                CategoryId = technicalSkillId,
                InternalRoleId = devOpsEngineerIIId
            };

            var marketingExecutive = new Skill
            {
                Name = "MARKETING_EXECUTIVE",
                Description = "Executing and managing marketing campaigns.",
                CategoryId = managementSkillId,
                InternalRoleId = marketingExecutiveId
            };

            var marketingLead = new Skill
            {
                Name = "MARKETING_LEAD",
                Description = "Guiding and overseeing marketing strategies.",
                CategoryId = managementSkillId,
                InternalRoleId = marketingLeadId
            };

            var marketingManager = new Skill
            {
                Name = "MARKETING_MANAGER",
                Description = "Planning and supervising marketing strategies and operations.",
                CategoryId = managementSkillId,
                InternalRoleId = marketingManagerId
            };

            var marketingTrainee = new Skill
            {
                Name = "MARKETING_TRAINEE",
                Description = "Assisting in marketing activities and learning industry practices.",
                CategoryId = managementSkillId,
                InternalRoleId = marketingTraineeId
            };

            var productDesigner = new Skill
            {
                Name = "PRODUCT_DESIGNER",
                Description = "Designing user-centric product experiences.",
                CategoryId = creativeSkillId,
                InternalRoleId = productDesignerId
            };
            var projectManager = new Skill
            {
                Name = "PROJECT_MANAGER",
                Description = "Managing project timelines, resources, and deliverables.",
                CategoryId = managementSkillId,
                InternalRoleId = projectManagerId
            };

            var seniorBusinessAnalyst = new Skill
            {
                Name = "SENIOR_BUSINESS_ANALYST",
                Description = "Leading business analysis and providing strategic insights.",
                CategoryId = analyticalSkillId,
                InternalRoleId = seniorBusinessAnalystId
            };

            var seniorMarketingExecutive = new Skill
            {
                Name = "SENIOR_MARKETING_EXECUTIVE",
                Description = "Overseeing marketing campaigns and mentoring junior marketers.",
                CategoryId = managementSkillId,
                InternalRoleId = seniorMarketingExecutiveId
            };

            var seniorProjectManager = new Skill
            {
                Name = "SENIOR_PROJECT_MANAGER",
                Description = "Directing complex projects and managing large teams.",
                CategoryId = managementSkillId,
                InternalRoleId = seniorProjectManagerId
            };

            var seniorUxDesigner = new Skill
            {
                Name = "SENIOR_UX_DESIGNER",
                Description = "Designing and refining complex user experiences.",
                CategoryId = creativeSkillId,
                InternalRoleId = seniorUxDesignerId
            };

            var softwareEngineerIAIML = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_AI_ML",
                Description = "Developing entry-level AI and ML solutions.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIAIMLId
            };

            var softwareEngineerIIAIML = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_AI_ML",
                Description = "Building and optimizing advanced AI and ML applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIAIMLId
            };

            var softwareEngineerIIIWeb = new Skill
            {
                Name = "SOFTWARE_ENGINEER_III_WEB",
                Description = "Developing and maintaining web applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIIId
            };

            var softwareEngineerIIICommon = new Skill
            {
                Name = "SOFTWARE_ENGINEER_III_COMMON",
                Description = "Working on shared application frameworks and services.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIIId
            };

            var softwareEngineerIIBackendDotnet = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_BACKEND_DOTNET",
                Description = "Developing and maintaining .NET backend systems.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIBackendNode = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_BACKEND_NODE",
                Description = "Creating and managing Node.js backend services.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIBackendJava = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_BACKEND_JAVA",
                Description = "Developing Java-based backend systems.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIFrontendAngular = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR",
                Description = "Building Angular-based front-end applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIFrontendReact = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_FRONTEND_REACT",
                Description = "Developing React.js front-end applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIMobileAndroid = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_MOBILE_ANDROID",
                Description = "Creating Android mobile applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIMobileIOS = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_MOBILE_IOS",
                Description = "Developing iOS mobile applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIIMobileFlutter = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_MOBILE_FLUTTER",
                Description = "Building cross-platform apps using Flutter.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };

            var softwareEngineerIICommon = new Skill
            {
                Name = "SOFTWARE_ENGINEER_II_COMMON",
                Description = "Working on common software components and frameworks.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIIId
            };
            var softwareEngineerIBackendDotnet = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_BACKEND_DOTNET",
                Description = "Developing and maintaining entry-level .NET backend applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIBackendNode = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_BACKEND_NODE",
                Description = "Creating and managing Node.js backend services at entry-level.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIBackendJava = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_BACKEND_JAVA",
                Description = "Developing entry-level Java-based backend systems.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIFrontendAngular = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR",
                Description = "Building Angular-based front-end applications at entry-level.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIFrontendReact = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_FRONTEND_REACT",
                Description = "Developing entry-level React.js front-end applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIMobileAndroid = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_MOBILE_ANDROID",
                Description = "Creating Android mobile applications at entry-level.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIMobileIOS = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_MOBILE_IOS",
                Description = "Developing entry-level iOS mobile applications.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerIMobileFlutter = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_MOBILE_FLUTTER",
                Description = "Building cross-platform apps using Flutter at entry-level.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };

            var softwareEngineerICommon = new Skill
            {
                Name = "SOFTWARE_ENGINEER_I_COMMON",
                Description = "Working on common software components at entry-level.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerIId
            };
            var softwareEngineerTraineeBackendDotnet = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET",
                Description = "Learning and supporting .NET backend development.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeBackendNode = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE",
                Description = "Assisting in Node.js backend development.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeBackendJava = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA",
                Description = "Gaining experience in Java backend systems.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeFrontendAngular = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR",
                Description = "Training in Angular-based front-end development.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeFrontendReact = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT",
                Description = "Assisting in React.js front-end development.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeMobileAndroid = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID",
                Description = "Learning Android mobile application development.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeMobileIOS = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS",
                Description = "Gaining experience in iOS mobile development.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeMobileFlutter = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER",
                Description = "Training in cross-platform app development using Flutter.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareEngineerTraineeCommon = new Skill
            {
                Name = "SOFTWARE_ENGINEER_TRAINEE_COMMON",
                Description = "Learning common software components and frameworks.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareEngineerTraineeId
            };

            var softwareTestEngineerAutomation = new Skill
            {
                Name = "SOFTWARE_TEST_ENGINEER_AUTOMATION",
                Description = "Creating and executing automated test scripts.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareTestEngineerAutomationId
            };

            var softwareTestEngineerFunctional = new Skill
            {
                Name = "SOFTWARE_TEST_ENGINEER_FUNCTIONAL",
                Description = "Performing functional testing to ensure quality.",
                CategoryId = technicalSkillId,
                InternalRoleId = softwareTestEngineerFunctionalId
            };

            var solutionArchitectCommon = new Skill
            {
                Name = "SOLUTION_ARCHITECT_COMMON",
                Description = "Designing and overseeing comprehensive technical solutions.",
                CategoryId = technicalSkillId,
                InternalRoleId = solutionArchitectId
            };

            var techLead = new Skill
            {
                Name = "TECH_LEAD",
                Description = "Leading technical teams and managing project execution.",
                CategoryId = technicalSkillId,
                InternalRoleId = techLeadId
            };

            var techLeadCommon = new Skill
            {
                Name = "TECH_LEAD_COMMON",
                Description = "Providing technical leadership across teams.",
                CategoryId = technicalSkillId,
                InternalRoleId = techLeadId
            };

            var uxDesigner = new Skill
            {
                Name = "UX_DESIGNER",
                Description = "Designing user interfaces with a focus on usability.",
                CategoryId = creativeSkillId,
                InternalRoleId = uxDesignerId
            };

            var uxDesignerTrainee = new Skill
            {
                Name = "UX_DESIGNER_TRAINEE",
                Description = "Assisting in UX design and learning design principles.",
                CategoryId = creativeSkillId,
                InternalRoleId = uxDesignerTraineeId
            };

            var uxDesignLead = new Skill
            {
                Name = "UX_DESIGN_LEAD",
                Description = "Directing and managing UX design strategies.",
                CategoryId = creativeSkillId,
                InternalRoleId = uxDesignLeadId
            };

            var vpOfEngineeringCommon = new Skill
            {
                Name = "VP_OF_ENGINEERING_COMMON",
                Description = "Overseeing engineering teams and driving technical strategies.",
                CategoryId = managementSkillId,
                InternalRoleId = vpOfEngineeringId
            };


            await _skillRepository.InsertManyAsync(new List<Skill>()
            {
                brandDesigner,
                businessAnalyst,
                contentLead,
                contentTrainee,
                creativeHead,
                devOpsEngineerI,
                devOpsEngineerII,
                marketingExecutive,
                marketingLead,
                marketingManager,
                marketingTrainee,
                productDesigner,
                projectManager,
                seniorBusinessAnalyst,
                seniorMarketingExecutive,
                seniorProjectManager,
                seniorUxDesigner,
                softwareEngineerIAIML,
                softwareEngineerIIAIML,
                softwareEngineerIIIWeb,
                softwareEngineerIIICommon,
                softwareEngineerIIBackendDotnet,
                softwareEngineerIIBackendNode,
                softwareEngineerIIBackendJava,
                softwareEngineerIIFrontendAngular,
                softwareEngineerIIFrontendReact,
                softwareEngineerIIMobileAndroid,
                softwareEngineerIIMobileIOS,
                softwareEngineerIIMobileFlutter,
                softwareEngineerIICommon,
                softwareEngineerIBackendDotnet,
                softwareEngineerIBackendNode,
                softwareEngineerIBackendJava,
                softwareEngineerIFrontendAngular,
                softwareEngineerIFrontendReact,
                softwareEngineerIMobileAndroid,
                softwareEngineerIMobileIOS,
                softwareEngineerIMobileFlutter,
                softwareEngineerICommon,
                softwareEngineerTraineeBackendDotnet,
                softwareEngineerTraineeBackendNode,
                softwareEngineerTraineeBackendJava,
                softwareEngineerTraineeFrontendAngular,
                softwareEngineerTraineeFrontendReact,
                softwareEngineerTraineeMobileAndroid,
                softwareEngineerTraineeMobileIOS,
                softwareEngineerTraineeMobileFlutter,
                softwareEngineerTraineeCommon,
                softwareTestEngineerAutomation,
                softwareTestEngineerFunctional,
                solutionArchitectCommon,
                techLead,
                techLeadCommon,
                uxDesigner,
                uxDesignerTrainee,
                uxDesignLead,
                vpOfEngineeringCommon,
                HR

            });
        }
    }
}
