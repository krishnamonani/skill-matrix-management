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
    public class SkillSubtopicSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Skill, Guid> _skillRepository;

        private readonly IRepository<SkillSubtopic, Guid> _skillSubtopicRepository;

        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<DepartmentInternalRole, Guid> _internalRoleRepository;



        public SkillSubtopicSeedingService(IRepository<Skill, Guid> skillRepository, IRepository<SkillSubtopic, Guid> skillSubtopic, IRepository<Category, Guid> categoryRepository, IRepository<DepartmentInternalRole, Guid> internalRoleRepository)
        {
            _skillRepository = skillRepository;

            _skillSubtopicRepository = skillSubtopic;

            _categoryRepository = categoryRepository;
            _internalRoleRepository = internalRoleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _skillSubtopicRepository.GetCountAsync() > 0) return;

            await new SkillSeedingService(_skillRepository, _categoryRepository, _internalRoleRepository).SeedAsync(context);

            var SkillsTableData = await _skillRepository.GetListAsync();


            //Skill By Name
            var MARKETING_EXECUTIVE = SkillsTableData.FirstOrDefault(s => s.Name == "MARKETING_EXECUTIVE");
            var SOFTWARE_ENGINEER_I_FRONTEND_REACT = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_FRONTEND_REACT");
            var SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR");
            var SOFTWARE_ENGINEER_II_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_COMMON");
            var UX_DESIGN_LEAD = SkillsTableData.FirstOrDefault(s => s.Name == "UX_DESIGN_LEAD");
            var SOFTWARE_ENGINEER_I_BACKEND_DOTNET = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_BACKEND_DOTNET");
            var SOFTWARE_ENGINEER_I_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_COMMON");
            var SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET");
            var SOFTWARE_ENGINEER_I_MOBILE_IOS = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_MOBILE_IOS");
            var SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA");
            var SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS");
            var SOFTWARE_ENGINEER_II_BACKEND_DOTNET = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_BACKEND_DOTNET");
            var SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE");
            var SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID");
            var SOFTWARE_TEST_ENGINEER_FUNCTIONAL = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_TEST_ENGINEER_FUNCTIONAL");
            var SOFTWARE_ENGINEER_I_BACKEND_JAVA = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_BACKEND_JAVA");
            var SOFTWARE_ENGINEER_I_BACKEND_NODE = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_BACKEND_NODE");
            var VP_OF_ENGINEERING_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "VP_OF_ENGINEERING_COMMON");
            var SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR");
            var TECH_LEAD = SkillsTableData.FirstOrDefault(s => s.Name == "TECH_LEAD");
            var SOFTWARE_ENGINEER_II_MOBILE_FLUTTER = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_MOBILE_FLUTTER");
            var UX_DESIGNER_TRAINEE = SkillsTableData.FirstOrDefault(s => s.Name == "UX_DESIGNER_TRAINEE");
            var SOLUTION_ARCHITECT_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "SOLUTION_ARCHITECT_COMMON");
            var UX_DESIGNER = SkillsTableData.FirstOrDefault(s => s.Name == "UX_DESIGNER");
            var SOFTWARE_ENGINEER_I_MOBILE_ANDROID = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_MOBILE_ANDROID");
            var SOFTWARE_ENGINEER_II_MOBILE_ANDROID = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_MOBILE_ANDROID");
            var SOFTWARE_ENGINEER_II_BACKEND_NODE = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_BACKEND_NODE");
            var SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT");
            var SOFTWARE_ENGINEER_I_MOBILE_FLUTTER = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_MOBILE_FLUTTER");
            var SOFTWARE_ENGINEER_TRAINEE_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_COMMON");
            var SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR");
            var SOFTWARE_ENGINEER_II_BACKEND_JAVA = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_BACKEND_JAVA");
            var SOFTWARE_TEST_ENGINEER_AUTOMATION = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_TEST_ENGINEER_AUTOMATION");
            var CONTENT_LEAD = SkillsTableData.FirstOrDefault(s => s.Name == "CONTENT_LEAD");
            var SOFTWARE_ENGINEER_III_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_III_COMMON");
            var CONTENT_TRAINEE = SkillsTableData.FirstOrDefault(s => s.Name == "CONTENT_TRAINEE");
            var SOFTWARE_ENGINEER_I_AI_ML = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_I_AI_ML");
            var SOFTWARE_ENGINEER_III_WEB = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_III_WEB");
            var MARKETING_MANAGER = SkillsTableData.FirstOrDefault(s => s.Name == "MARKETING_MANAGER");
            var PRODUCT_DESIGNER = SkillsTableData.FirstOrDefault(s => s.Name == "PRODUCT_DESIGNER");
            var SOFTWARE_ENGINEER_II_AI_ML = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_AI_ML");
            var SENIOR_MARKETING_EXECUTIVE = SkillsTableData.FirstOrDefault(s => s.Name == "SENIOR_MARKETING_EXECUTIVE");
            var SOFTWARE_ENGINEER_II_FRONTEND_REACT = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_II_FRONTEND_REACT");
            var TECH_LEAD_COMMON = SkillsTableData.FirstOrDefault(s => s.Name == "TECH_LEAD_COMMON");
            var SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER = SkillsTableData.FirstOrDefault(s => s.Name == "SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER");
            var DEVOPS_ENGINEER_II = SkillsTableData.FirstOrDefault(s => s.Name == "DEVOPS_ENGINEER_II");
            var MARKETING_TRAINEE = SkillsTableData.FirstOrDefault(s => s.Name == "MARKETING_TRAINEE");
            var PROJECT_MANAGER = SkillsTableData.FirstOrDefault(s => s.Name == "PROJECT_MANAGER");
            var SENIOR_UX_DESIGNER = SkillsTableData.FirstOrDefault(s => s.Name == "SENIOR_UX_DESIGNER");
            var MARKETING_LEAD = SkillsTableData.FirstOrDefault(s => s.Name == "MARKETING_LEAD");
            var SENIOR_BUSINESS_ANALYST = SkillsTableData.FirstOrDefault(s => s.Name == "SENIOR_BUSINESS_ANALYST");
            var CREATIVE_HEAD = SkillsTableData.FirstOrDefault(s => s.Name == "CREATIVE_HEAD");
            var DEVOPS_ENGINEER_I = SkillsTableData.FirstOrDefault(s => s.Name == "DEVOPS_ENGINEER_I");
            var BRAND_DESIGNER = SkillsTableData.FirstOrDefault(s => s.Name == "BRAND_DESIGNER");
            var SENIOR_PROJECT_MANAGER = SkillsTableData.FirstOrDefault(s => s.Name == "SENIOR_PROJECT_MANAGER");
            var BUSINESS_ANALYST = SkillsTableData.FirstOrDefault(s => s.Name == "BUSINESS_ANALYST");



            var MARKETING_EXECUTIVE_SUBSKILLS = new List<SkillSubtopic>
            {
                new SkillSubtopic
                {
                    Name = "Digital Marketing",
                    SkillId = MARKETING_EXECUTIVE.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "SEO", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "SEM (Search Engine Marketing)", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Social Media Management", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Content Marketing", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Email Marketing", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Google Analytics", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Analytics & Data",
                    SkillId = MARKETING_EXECUTIVE.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "CRM Systems", ProficiencyEnum.BEGINNER.ToString() },
                        { "Conversion Rate Optimization (CRO)", ProficiencyEnum.BEGINNER.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Brand & Creative Strategy",
                    SkillId = MARKETING_EXECUTIVE.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Brand Management", ProficiencyEnum.BEGINNER.ToString() },
                        { "Copywriting", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Graphic Design", "Intermediate (Advanced tools)" }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Campaign Management",
                    SkillId = MARKETING_EXECUTIVE.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Project Management", ProficiencyEnum.BEGINNER.ToString() },
                        { "Budget Management", ProficiencyEnum.BEGINNER.ToString() },
                        { "Stakeholder Management", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Public Relations & Outreach",
                    SkillId = MARKETING_EXECUTIVE.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Media Relations", ProficiencyEnum.BEGINNER.ToString() },
                        { "Influencer Marketing", ProficiencyEnum.BEGINNER.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Customer Engagement",
                    SkillId = MARKETING_EXECUTIVE.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Customer Segmentation", ProficiencyEnum.BEGINNER.ToString() },
                        { "Lead Nurturing", ProficiencyEnum.BEGINNER.ToString() }
                    }
                }
            };

            var SOFTWARE_ENGINEER_I_FRONTEND_REACT_SUBSKILL = new List<SkillSubtopic>
            {
                new SkillSubtopic
                {
                    Name = "Programming Languages",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Typescript", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Javascript", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Frontend Frameworks",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "React", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "NextJS", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Frontend",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "HTML", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "CSS", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Application Programming Interface (API)",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "REST / HTTP", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Version Control System",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Git", "Intermediate (Any 1)" },
                        { "TFVC", "Intermediate (Any 1)" }
                    }
                },

                new SkillSubtopic
                {
                    Name = "IDE",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Testing Framework",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Jest", "Intermediate (Any 1)" },
                        { "Mocha", "Intermediate (Any 1)" },
                        { "Jasmine / Karma", "Intermediate (Any 1)" }
                    }
                },

                new SkillSubtopic
                {
                    Name = "CI/CD Tools",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_REACT.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Jenkins", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                }
            };


            var SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR_SUBSKILLS = new List<SkillSubtopic>
            {
                new SkillSubtopic
                {
                    Name = "Programming Languages",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Typescript", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Javascript", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Frontend Frameworks",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Angular", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Frontend",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "HTML", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "CSS", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Application Programming Interface (API)",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "REST / HTTP", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Version Control System",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Git", "Intermediate (Any 1)" },
                        { "TFVC", "Intermediate (Any 1)" }
                    }
                },

                new SkillSubtopic
                {
                    Name = "IDE",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Visual Studio", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Testing Framework",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Jasmine / Karma", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "CI/CD Tools",
                    SkillId = SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Jenkins", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                }
            };
            var SOFTWARE_ENGINEER_II_COMMON_SUBSKILLS = new List<SkillSubtopic>
            {
                new SkillSubtopic
                {
                    Name = "SDLC Concepts",
                    SkillId = SOFTWARE_ENGINEER_II_COMMON.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Agile Concepts",
                    SkillId = SOFTWARE_ENGINEER_II_COMMON.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Scrum", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Kanban", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Redmine", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                },

                new SkillSubtopic
                {
                    Name = "Project Management Tools",
                    SkillId = SOFTWARE_ENGINEER_II_COMMON.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "JIRA", ProficiencyEnum.INTERMEDIATE.ToString() },
                        { "Asana", ProficiencyEnum.INTERMEDIATE.ToString() }
                    }
                }
            };

            var UX_DESIGN_LEAD_SUBSKILLS = new List<SkillSubtopic>
            {
                new SkillSubtopic
                {
                    Name = "Adobe XD",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Adobe Photoshop",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Adobe Illustrator",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Wireframing",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Figma", ProficiencyEnum.EXPERT.ToString() },
                        { "Sketch", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "UI Design",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Figma", ProficiencyEnum.EXPERT.ToString() },
                        { "Sketch", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Communication",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Time Management",
                    SkillId = UX_DESIGN_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
                    }
                },

            };

            var SOFTWARE_ENGINEER_I_BACKEND_DOTNET_SUBSKILLS = new List<SkillSubtopic>
    {
        new SkillSubtopic
        {
            Name = "Programming Languages",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "C#", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Backend Frameworks",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "ASP.NET", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Relational Database Fundamentals",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Normalization", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Indexing", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Performance", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Relational Database",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "SQL Queries", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "PostgreSQL", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "MySQL", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Microsoft SQL Server", ProficiencyEnum.BEGINNER.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "NoSQL Database",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "DynamoDB", ProficiencyEnum.BEGINNER.ToString() },
                { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "ORM",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Entity Framework", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Dapper", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Version Control System",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Git", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "TFVC", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "IDE",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Visual Studio", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Testing Frameworks",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "NUnit/XUnit", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Jenkins", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "CI/CD Tools",
            SkillId = SOFTWARE_ENGINEER_I_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        }
    };

            var SOFTWARE_ENGINEER_I_COMMON_SUBSKILSS = new List<SkillSubtopic>
        {
            new SkillSubtopic
            {
                Name = "SDLC Concepts",
                SkillId = SOFTWARE_ENGINEER_I_COMMON.Id,
                Description = new Dictionary<string, string>
                {
                    { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() }
                }
            },
            new SkillSubtopic
            {
                Name = "Agile Concepts",
                SkillId = SOFTWARE_ENGINEER_I_COMMON.Id,
                Description = new Dictionary<string, string>
                {
                    { "Scrum", ProficiencyEnum.INTERMEDIATE.ToString() },
                    { "Kanban", ProficiencyEnum.INTERMEDIATE.ToString() },
                    { "Redmine", ProficiencyEnum.INTERMEDIATE.ToString() },
                    { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() }
                }
            },
            new SkillSubtopic
            {
                Name = "Project Management Tools",
                SkillId = SOFTWARE_ENGINEER_I_COMMON.Id,
                Description = new Dictionary<string, string>
                {
                    { "JIRA", ProficiencyEnum.INTERMEDIATE.ToString() },
                    { "Asana", ProficiencyEnum.INTERMEDIATE.ToString() }
                }
            }
        };
            var SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "C#", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "ASP.NET", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.BEGINNER.ToString() },
            { "Indexing", ProficiencyEnum.BEGINNER.ToString() },
            { "Performance", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.BEGINNER.ToString() },
            { "PostgreSQL", ProficiencyEnum.BEGINNER.ToString() },
            { "MySQL", ProficiencyEnum.BEGINNER.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "Entity Framework", ProficiencyEnum.BEGINNER.ToString() },
            { "Dapper", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() },
            { "TFVC", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() },
            { "Visual Studio", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "NUnit/XUnit/MSTest", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() },
            { "Jenkins", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_I_MOBILE_IOS_SUBSKILLS = new List<SkillSubtopic>
    {
        new SkillSubtopic
        {
            Name = "Programming Languages",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "Objective C", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Swift", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Mobile Frameworks",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "iOS SDK", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Cocoa Touch", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "REST API Integration (NSURL, Alamofire, AFNetworking)", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "AutoLayout", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "SwiftUI", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "UIKit", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "RxSwift",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "Cordova", ProficiencyEnum.BEGINNER.ToString() },
                { "Capacitor", ProficiencyEnum.BEGINNER.ToString() },
                { "Multi Threading", ProficiencyEnum.BEGINNER.ToString() },
                { "Lazy Loading", ProficiencyEnum.BEGINNER.ToString() },
                { "Concurrency", ProficiencyEnum.BEGINNER.ToString() },
                { "Bridging", ProficiencyEnum.BEGINNER.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Database",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Core Data", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Realm", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Version Control System",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "Git", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "IDE",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "XCode", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Testing Frameworks",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "XCUITest", ProficiencyEnum.BEGINNER.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Architecture",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "MVC/MVVM", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Misc",
            SkillId = SOFTWARE_ENGINEER_I_MOBILE_IOS.Id,
            Description = new Dictionary<string, string>
            {
                { "Push Notifications", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Dependency Manager", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Pod", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Instruments", ProficiencyEnum.BEGINNER.ToString() },
                { "CICD", ProficiencyEnum.BEGINNER.ToString() },
                { "Fastlane", ProficiencyEnum.BEGINNER.ToString() },
                { "Bitrise", ProficiencyEnum.BEGINNER.ToString() },
                { "TestFlight", ProficiencyEnum.BEGINNER.ToString() },
                { "Firebase", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "App Store Deployment", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        }
    };
            var SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Java", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Spring", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.BEGINNER.ToString() },
            { "Indexing", ProficiencyEnum.BEGINNER.ToString() },
            { "Performance", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.BEGINNER.ToString() },
            { "PostgreSQL", ProficiencyEnum.BEGINNER.ToString() },
            { "MySQL", ProficiencyEnum.BEGINNER.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Spring Data", ProficiencyEnum.BEGINNER.ToString() },
            { "Hibernate", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() },
            { "TFVC", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() },
            { "IntelliJ", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "JUnit", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() },
            { "Jenkins", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};

            var SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS_SUBSKILS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "Objective C", ProficiencyEnum.BEGINNER.ToString() },
            { "Swift", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "iOS SDK", ProficiencyEnum.BEGINNER.ToString() },
            { "Cocoa Touch", ProficiencyEnum.BEGINNER.ToString() },
            { "REST API Integration (NSURL, Alamofire, AFNetworking)", ProficiencyEnum.BEGINNER.ToString() },
            { "AutoLayout", ProficiencyEnum.BEGINNER.ToString() },
            { "SwiftUI",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "UIKit",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "RxSwift",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "Cordova",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Capacitor",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Multi Threading",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Lazy Loading",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Concurrency",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Bridging",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.BEGINNER.ToString() },
            { "Core Data", ProficiencyEnum.BEGINNER.ToString() },
            { "Realm", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "XCode", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "XCUITest",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Architecture",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "MVC/MVVM",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.BEGINNER.ToString() },
            { "Dependency Manager",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Pod",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CI/CD",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Fastlane",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Bitrise",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "TestFlight",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "App Store Deployment", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_II_BACKEND_DOTNET_SUBSKILL = new List<SkillSubtopic>
    {
        new SkillSubtopic
        {
            Name = "Programming Languages",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "C#", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Backend Frameworks",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "ASP.NET", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Relational Database Fundamentals",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Normalization", ProficiencyEnum.EXPERT.ToString() },
                { "Indexing", ProficiencyEnum.EXPERT.ToString() },
                { "Performance", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Relational Database",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "SQL Queries", ProficiencyEnum.EXPERT.ToString() },
                { "PostgreSQL", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "MySQL", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "Microsoft SQL Server", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "NoSQL Database",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "DynamoDB", ProficiencyEnum.INTERMEDIATE.ToString() },
                { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "ORM",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Entity Framework", ProficiencyEnum.EXPERT.ToString() },
                { "Dapper", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Version Control System",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Git", ProficiencyEnum.EXPERT.ToString() },
                { "TFVC", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "IDE",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() },
                { "Visual Studio", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "Testing Frameworks",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "NUnit/XUnit/MSTest", ProficiencyEnum.EXPERT.ToString() },
                { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() },
                { "Jenkins", ProficiencyEnum.EXPERT.ToString() }
            }
        },
        new SkillSubtopic
        {
            Name = "CI/CD Tools",
            SkillId = SOFTWARE_ENGINEER_II_BACKEND_DOTNET.Id,
            Description = new Dictionary<string, string>
            {
                { "Github Actions", ProficiencyEnum.BEGINNER.ToString() },
                { "AWS Codebuild/CodePipeline", ProficiencyEnum.BEGINNER.ToString() },
                { "CircleCI/Travis CI", ProficiencyEnum.BEGINNER.ToString() }
            }
        }
    };

            var SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "JavaScript", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Express JS", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Typescript",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Nest JS", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.BEGINNER.ToString() },
            { "Indexing", ProficiencyEnum.BEGINNER.ToString() },
            { "Performance", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.BEGINNER.ToString() },
            { "PostgreSQL", ProficiencyEnum.BEGINNER.ToString() },
            { "MySQL", ProficiencyEnum.BEGINNER.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MongoDB",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Sequelize", ProficiencyEnum.BEGINNER.ToString() },
            { "TypeORM", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() },
            { "TFVC", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() },
            { "Jest", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Jest", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() },
            { "Jenkins", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Java", ProficiencyEnum.BEGINNER.ToString() },
            { "Kotlin", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Android SDK", ProficiencyEnum.BEGINNER.ToString() },
            { "REST API Integration (Volley/Retrofit)", ProficiencyEnum.BEGINNER.ToString() },
            { "Android Layouts, Custom Views", ProficiencyEnum.BEGINNER.ToString() },
            { "LiveData", ProficiencyEnum.BEGINNER.ToString() },
            { "RxJava",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NDK",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Cordova",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Capacitor",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Services", ProficiencyEnum.BEGINNER.ToString() },
            { "WorkerThread", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.BEGINNER.ToString() },
            { "SQLite", ProficiencyEnum.BEGINNER.ToString() },
            { "Room", ProficiencyEnum.BEGINNER.ToString() },
            { "Realm", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Android Studio", ProficiencyEnum.BEGINNER.ToString() },
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Robolectric",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase Analytics",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.BEGINNER.ToString() },
            { "Gradle", ProficiencyEnum.BEGINNER.ToString() },
            { "Google APIs", ProficiencyEnum.BEGINNER.ToString() },
            { "Android Profiler",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CI/CD",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Bitrise",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Testify",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Play Store Deployment", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_TEST_ENGINEER_FUNCTIONAL_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "STLC",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Understanding of SDLC and Agile concepts",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Design Test",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Test Planning", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Design Test Case", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Preparation of Test Data", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Severity and Priority Identification", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Defect Management",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Defect Reporting", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Defect Reproduction", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Operation - Automation Basic",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Knowledge of automation testing tools", ProficiencyEnum.BEGINNER.ToString() },
            { "Understanding manual vs. automated testing", ProficiencyEnum.BEGINNER.ToString() },
            { "Basic scripting knowledge", ProficiencyEnum.BEGINNER.ToString() },
            { "Selenium",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "OOP",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - Web Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "CI/CD",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "WebDriver IO",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Cypress",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - API Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Postman",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "RestAssured",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Karate",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - Mobile Application Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "Appium",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Performance Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_FUNCTIONAL.Id,
        Description = new Dictionary<string, string>
        {
            { "JMeter", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_I_BACKEND_JAVA_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Java", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Spring", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Indexing", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Performance", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "PostgreSQL", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MySQL", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.BEGINNER.ToString() },
            { "MongoDB", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Spring Data", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Hibernate", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "TFVC", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "IntelliJ", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "JUnit", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Jenkins", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};

            var SOFTWARE_ENGINEER_I_BACKEND_NODE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "JavaScript", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "TypeScript", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Express JS", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Nest JS", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Indexing", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Performance", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "PostgreSQL", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MySQL", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.BEGINNER.ToString() },
            { "MongoDB", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Sequelize", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "TypeORM", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "TFVC", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Jest", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Jenkins", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_I_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var VP_OF_ENGINEERING_COMMON_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SDLC Concepts",
        SkillId = VP_OF_ENGINEERING_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Agile Concepts",
        SkillId = VP_OF_ENGINEERING_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Scrum", ProficiencyEnum.EXPERT.ToString() },
            { "Kanban", ProficiencyEnum.EXPERT.ToString() },
            { "Redmine", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Tools",
        SkillId = VP_OF_ENGINEERING_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "JIRA", ProficiencyEnum.EXPERT.ToString() },
            { "Asana", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};

            var SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "TypeScript", ProficiencyEnum.EXPERT.ToString() },
            { "JavaScript", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Frontend Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Angular", ProficiencyEnum.EXPERT.ToString() },
            { "HTML", ProficiencyEnum.EXPERT.ToString() },
            { "CSS", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Application Programming Interface (API)",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "REST/HTTP", ProficiencyEnum.EXPERT.ToString() },
            { "GRC", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Jasmine/Karma", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Jenkins", ProficiencyEnum.BEGINNER.ToString() },
            { "Github Actions", ProficiencyEnum.BEGINNER.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.BEGINNER.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};

            var TECH_LEAD_SUBSKILLS = new List<SkillSubtopic>
{
    // Inherited Common Skills from Page 3
    new SkillSubtopic
    {
        Name = "SDLC Concepts",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Agile Concepts",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Scrum", ProficiencyEnum.EXPERT.ToString() },
            { "Kanban", ProficiencyEnum.EXPERT.ToString() },
            { "Redmine", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Tools",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "JIRA", ProficiencyEnum.EXPERT.ToString() },
            { "Asana", ProficiencyEnum.EXPERT.ToString() }
        }
    },

                // Tech Lead-specific Skills from Page 1
                new SkillSubtopic
                {
                    Name = "Programming Languages",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "TypeScript", ProficiencyEnum.EXPERT.ToString() },
                        { "C#", ProficiencyEnum.EXPERT.ToString() },
                        { "Java", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Backend Frameworks",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "ASP.NET", ProficiencyEnum.EXPERT.ToString() },
                        { "ExpressJS + Nest JS", ProficiencyEnum.EXPERT.ToString() },
                        { "Spring Boot", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Beyonded Frameworks", // Note: Likely a typo in the document, assuming "Frontend Frameworks"
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Angular", ProficiencyEnum.EXPERT.ToString() },
                        { "ReactJS + Next JS", ProficiencyEnum.EXPERT.ToString() },
                        { "HTML", ProficiencyEnum.EXPERT.ToString() },
                        { "CSS", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Relational Database Fundamentals",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Normalization", ProficiencyEnum.EXPERT.ToString() },
                        { "Indexing", ProficiencyEnum.EXPERT.ToString() },
                        { "Performance", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Relational Database",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "SQL Queries", ProficiencyEnum.EXPERT.ToString() },
                        { "PostgreSQL", ProficiencyEnum.EXPERT.ToString() },
                        { "MySQL", ProficiencyEnum.EXPERT.ToString() },
                        { "Microsoft SQL Server", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "NoSQL Database",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "DynamoDB", ProficiencyEnum.EXPERT.ToString() },
                        { "MongoDB", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "ORM",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Entity Framework", ProficiencyEnum.EXPERT.ToString() },
                        { "Sequelize", ProficiencyEnum.EXPERT.ToString() },
                        { "Hibernate/JPA", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Version Control System",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Git", ProficiencyEnum.EXPERT.ToString() },
                        { "TFVC", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "IDE",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "Visual Studio", ProficiencyEnum.EXPERT.ToString() },
                        { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() },
                        { "Eclipse", ProficiencyEnum.EXPERT.ToString() },
                        { "IntelliJ IDEA", ProficiencyEnum.EXPERT.ToString() }
                    }
                },
                new SkillSubtopic
                {
                    Name = "Testing Frameworks (Backend)",
                    SkillId = TECH_LEAD.Id,
                    Description = new Dictionary<string, string>
                    {
                        { "NUnit/XUnit/MSTest", ProficiencyEnum.EXPERT.ToString() }
                    }
                },

    // Tech Lead-specific Skills from Page 2
    new SkillSubtopic
    {
        Name = "Testing Frameworks (Frontend)", // Corrected "fibrillation" to "Frontend"
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Jest", ProficiencyEnum.EXPERT.ToString() },
            { "Jasmine/Karma", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() } // "Intermediate (All)" as per the table
        }
    },
    new SkillSubtopic
    {
        Name = "Cloud Platforms",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() } // "Intermediate (All)" as per the table
        }
    },
    new SkillSubtopic
    {
        Name = "DevOps",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() } // "Intermediate" as per the table
        }
    },
    new SkillSubtopic
    {
        Name = "Networking",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() } // "Intermediate" as per the table
        }
    },
    new SkillSubtopic
    {
        Name = "Microservices",
        SkillId = TECH_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() } // "Intermediate" as per the table
        }
    }
};
            var SOFTWARE_ENGINEER_II_MOBILE_FLUTTER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Dart", ProficiencyEnum.EXPERT.ToString() },
            { "Java", ProficiencyEnum.EXPERT.ToString() },
            { "Kotlin", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Flutter", ProficiencyEnum.EXPERT.ToString() },
            { "Android SDK", ProficiencyEnum.EXPERT.ToString() },
            { "REST API Integration (Volley/Retrofit/Http)", ProficiencyEnum.EXPERT.ToString() },
            { "Android Flutter Layouts, Custom Views", ProficiencyEnum.EXPERT.ToString() },
            { "LiveData/RxJava/RxDart", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NDK", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Cordova", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Capacitor", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Services", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "WorkerThread", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.EXPERT.ToString() },
            { "SQLite", ProficiencyEnum.EXPERT.ToString() },
            { "Room", ProficiencyEnum.EXPERT.ToString() },
            { "Realm", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Android Studio", ProficiencyEnum.EXPERT.ToString() },
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Flutter Test", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase Analytics", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.EXPERT.ToString() },
            { "Gradle", ProficiencyEnum.EXPERT.ToString() },
            { "Google APIs", ProficiencyEnum.EXPERT.ToString() },
            { "Android Profiler", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CI/CD", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Bitrise", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Testify", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Play Store Deployment", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var UX_DESIGNER_TRAINEE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Wireframing",
        SkillId = UX_DESIGNER_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.BEGINNER.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.BEGINNER.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.BEGINNER.ToString() },
            { "Figma", ProficiencyEnum.BEGINNER.ToString() },
            { "Sketch", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "UI Design",
        SkillId = UX_DESIGNER_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.BEGINNER.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.BEGINNER.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.BEGINNER.ToString() },
            { "Figma", ProficiencyEnum.BEGINNER.ToString() },
            { "Sketch", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication",
        SkillId = UX_DESIGNER_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = UX_DESIGNER_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOLUTION_ARCHITECT_COMMON_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SDLC Concepts",
        SkillId = SOLUTION_ARCHITECT_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Agile Concepts",
        SkillId = SOLUTION_ARCHITECT_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Scrum", ProficiencyEnum.EXPERT.ToString() },
            { "Kanban", ProficiencyEnum.EXPERT.ToString() },
            { "Redmine", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Tools",
        SkillId = SOLUTION_ARCHITECT_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "JIRA", ProficiencyEnum.EXPERT.ToString() },
            { "Asana", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var UX_DESIGNER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Wireframing",
        SkillId = UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Figma", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Sketch", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "UI Design",
        SkillId = UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Figma", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Sketch", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication",
        SkillId = UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_I_MOBILE_ANDROID_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Java", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Kotlin", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Android SDK", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "REST API Integration (Volley/Retrofit)", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Android Layouts, Custom Views", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "LiveData", ProficiencyEnum.BEGINNER.ToString() },
            { "RxJava", ProficiencyEnum.BEGINNER.ToString() },
            { "NDK", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Cordova", ProficiencyEnum.BEGINNER.ToString() },
            { "Capacitor", ProficiencyEnum.BEGINNER.ToString() },
            { "Services", ProficiencyEnum.BEGINNER.ToString() },
            { "WorkerThread", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "SQLite", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Room", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Realm", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Android Studio", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Robolectric", ProficiencyEnum.BEGINNER.ToString() },
            { "Firebase Analytics", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Gradle", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Google APIs", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Android Profiler", ProficiencyEnum.BEGINNER.ToString() },
            { "CI/CD", ProficiencyEnum.BEGINNER.ToString() },
            { "Bitrise", ProficiencyEnum.BEGINNER.ToString() },
            { "Testify", ProficiencyEnum.BEGINNER.ToString() },
            { "Firebase", ProficiencyEnum.BEGINNER.ToString() },
            { "Play Store Deployment", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_II_MOBILE_ANDROID_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Java", ProficiencyEnum.EXPERT.ToString() },
            { "Kotlin", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Android SDK", ProficiencyEnum.EXPERT.ToString() },
            { "REST API Integration (Volley/Retrofit)", ProficiencyEnum.EXPERT.ToString() },
            { "Android Layouts, Custom Views", ProficiencyEnum.EXPERT.ToString() },
            { "LiveData", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "RxJava", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NDK", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Cordova", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Capacitor", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Services", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "WorkerThread", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.EXPERT.ToString() },
            { "SQLite", ProficiencyEnum.EXPERT.ToString() },
            { "Room", ProficiencyEnum.EXPERT.ToString() },
            { "Realm", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Android Studio", ProficiencyEnum.EXPERT.ToString() },
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Robolectric", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase Analytics", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_II_MOBILE_ANDROID.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.EXPERT.ToString() },
            { "Gradle", ProficiencyEnum.EXPERT.ToString() },
            { "Google APIs", ProficiencyEnum.EXPERT.ToString() },
            { "Android Profiler", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CI/CD", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Bitrise", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Testify", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Play Store Deployment", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_II_BACKEND_NODE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "JavaScript", ProficiencyEnum.EXPERT.ToString() },
            { "TypeScript", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Express JS", ProficiencyEnum.EXPERT.ToString() },
            { "Nest JS", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.EXPERT.ToString() },
            { "Indexing", ProficiencyEnum.EXPERT.ToString() },
            { "Performance", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.EXPERT.ToString() },
            { "PostgreSQL", ProficiencyEnum.EXPERT.ToString() },
            { "MySQL", ProficiencyEnum.EXPERT.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Sequelize", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "TypeORM", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() },
            { "TFVC", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Jest", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() },
            { "Jenkins", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_NODE.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions", ProficiencyEnum.BEGINNER.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.BEGINNER.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "TypeScript", ProficiencyEnum.BEGINNER.ToString() },
            { "JavaScript", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Frontend Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "React", ProficiencyEnum.BEGINNER.ToString() },
            { "NextJS", ProficiencyEnum.BEGINNER.ToString() },
            { "HTML", ProficiencyEnum.BEGINNER.ToString() },
            { "CSS", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Application Programming Interface (API)",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "REST/HTTP", ProficiencyEnum.BEGINNER.ToString() },
            { "Git", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() },
            { "TFVC", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Jest", ProficiencyEnum.BEGINNER.ToString() },
            { "Mocha", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() },
            { "Jenkins", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_I_MOBILE_FLUTTER_SUBSKILL = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Dart", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Java", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Kotlin", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Flutter", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Android SDK", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "REST API Integration (Volley/Retrofit/Http)", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Android Flutter Layouts, Custom Views", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "LiveData/RxJava/RxDart", ProficiencyEnum.BEGINNER.ToString() },
            { "NDK", ProficiencyEnum.BEGINNER.ToString() },
            { "Cordova", ProficiencyEnum.BEGINNER.ToString() },
            { "Capacitor", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Services", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "WorkerThread", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "SQLite", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Room", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Realm", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Android Studio", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Visual Studio Code", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Flutter Test", ProficiencyEnum.BEGINNER.ToString() },
            { "Firebase Analytics", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_I_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Gradle", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Google APIs", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Android Profiler", ProficiencyEnum.BEGINNER.ToString() },
            { "CI/CD", ProficiencyEnum.BEGINNER.ToString() },
            { "Bitrise", ProficiencyEnum.BEGINNER.ToString() },
            { "Testify", ProficiencyEnum.BEGINNER.ToString() },
            { "Firebase", ProficiencyEnum.BEGINNER.ToString() },
            { "Play Store Deployment", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};

            var SOFTWARE_ENGINEER_TRAINEE_COMMON_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SDLC Concepts",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Agile Concepts",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Scrum", ProficiencyEnum.BEGINNER.ToString() },
            { "Kanban", ProficiencyEnum.BEGINNER.ToString() },
            { "Redmine", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Tools",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "JIRA", ProficiencyEnum.BEGINNER.ToString() },
            { "Asana", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR_SUBSKILL = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "TypeScript", ProficiencyEnum.BEGINNER.ToString() },
            { "JavaScript", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Frontend Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Angular", ProficiencyEnum.BEGINNER.ToString() },
            { "HTML", ProficiencyEnum.BEGINNER.ToString() },
            { "CSS", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Application Programming Interface (API)",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "REST/HTTP", ProficiencyEnum.BEGINNER.ToString() },
            { "Git", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() },
            { "TFVC", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Jasmine/Karma", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() },
            { "Jenkins", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_II_BACKEND_JAVA_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Java", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Spring", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.EXPERT.ToString() },
            { "Indexing", ProficiencyEnum.EXPERT.ToString() },
            { "Performance", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.EXPERT.ToString() },
            { "PostgreSQL", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MySQL", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Spring Data", ProficiencyEnum.EXPERT.ToString() },
            { "Hibernate", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() },
            { "TFVC", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() },
            { "JUnit", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() },
            { "Jenkins", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_II_BACKEND_JAVA.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions", ProficiencyEnum.BEGINNER.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.BEGINNER.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_TEST_ENGINEER_AUTOMATION_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "STLC",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "Understanding of SDLC and Agile concepts", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Design Test",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "Test Planning", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Design Test Case", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Preparation of Test Data", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Severity and Priority identification", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Defect Management",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "Defect Reporting", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Defect Reproduction", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Knowledge of automation testing tools", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Operation - Automation Basic",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "Understanding manual vs. automated testing", ProficiencyEnum.BEGINNER.ToString() },
            { "Basic scripting knowledge", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - OOP",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "OOP", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - Web Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "CI/CD", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "WebDriver IO", ProficiencyEnum.BEGINNER.ToString() },
            { "Cypress", ProficiencyEnum.BEGINNER.ToString() },
            { "Postman", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - API Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "RestAssured", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Automation - Mobile Application Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "Karate", ProficiencyEnum.BEGINNER.ToString() },
            { "Appium", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Performance Testing",
        SkillId = SOFTWARE_TEST_ENGINEER_AUTOMATION.Id,
        Description = new Dictionary<string, string>
        {
            { "JMeter", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var CONTENT_LEAD_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Requirement Gathering",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Understand the client's need", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Research",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Research more information", ProficiencyEnum.EXPERT.ToString() },
            { "Originality of thought & Content Ideation", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Adaptability in content",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Adapt new writing styles", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "SEO",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Technical knowledge", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Time Management/Timely delivery",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Management skill/multitasking", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Social Media",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Strategy & ideas", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Quality Orientation",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Maintain quality", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytical & Comprehension Skills",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Understand new ideas & topics", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Learning Orientation",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Update knowledge", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Result Orientation",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Meet deadlines & delivery goals", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Creative thinking",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "New ideas", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Team Management",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Team work", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication Skills",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Written", ProficiencyEnum.EXPERT.ToString() },
            { "Verbal", ProficiencyEnum.EXPERT.ToString() },
            { "Reading", ProficiencyEnum.EXPERT.ToString() },
            { "Listening", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Interpersonal skills",
        SkillId = CONTENT_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Coaching & Mentoring", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_III_COMMON_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SDLC Concepts",
        SkillId = SOFTWARE_ENGINEER_III_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Agile Concepts",
        SkillId = SOFTWARE_ENGINEER_III_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Scrum", ProficiencyEnum.EXPERT.ToString() },
            { "Kanban", ProficiencyEnum.EXPERT.ToString() },
            { "Redmine", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Tools",
        SkillId = SOFTWARE_ENGINEER_III_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "JIRA", ProficiencyEnum.EXPERT.ToString() },
            { "Asana", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var CONTENT_TRAINEE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Requirement Gathering",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Understand the client's need", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Research",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Research more information", ProficiencyEnum.BEGINNER.ToString() },
            { "Originality of thought & Content Ideation", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Adaptability in content",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Adapt new writing styles", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "SEO",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Technical knowledge", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Time Management/Timely delivery",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Management skill/multitasking", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Social Media",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Strategy & ideas", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Quality Orientation",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Maintain quality", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytical & Comprehension Skills",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Understand new ideas & topics", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Learning Orientation",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Update knowledge", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Result Orientation",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Meet deadlines & delivery goals", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Creative thinking",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "New ideas", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Team Management",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Team work", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication Skills",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Written", ProficiencyEnum.EXPERT.ToString() },
            { "Verbal", ProficiencyEnum.EXPERT.ToString() },
            { "Reading", ProficiencyEnum.EXPERT.ToString() },
            { "Listening", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Interpersonal skills",
        SkillId = CONTENT_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Coaching & Mentoring",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_I_AI_ML_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Python", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Machine Learning",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Supervised, Unsupervised, Reinforcement Learning, Regression and Classification Algorithms", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Deep Learning",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "TensorFlow", ProficiencyEnum.BEGINNER.ToString() },
            { "PyTorch", ProficiencyEnum.BEGINNER.ToString() },
            { "Keras", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Data Processing",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Pandas", ProficiencyEnum.BEGINNER.ToString() },
            { "NumPy", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Model Deployment",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Flask", ProficiencyEnum.BEGINNER.ToString() },
            { "FastAPI", ProficiencyEnum.BEGINNER.ToString() },
            { "Docker", ProficiencyEnum.BEGINNER.ToString() },
            { "Kubernetes", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Cloud Platforms",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "AWS", ProficiencyEnum.BEGINNER.ToString() },
            { "Azure", ProficiencyEnum.BEGINNER.ToString() },
            { "GCP", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "MLOps",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "MLflow", ProficiencyEnum.BEGINNER.ToString() },
            { "Kubeflow", ProficiencyEnum.BEGINNER.ToString() },
            { "CI/CD for Model Deployment, Testing and Iteration", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NLP",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Spacy", ProficiencyEnum.BEGINNER.ToString() },
            { "NLTK", ProficiencyEnum.BEGINNER.ToString() },
            { "BERT", ProficiencyEnum.BEGINNER.ToString() },
            { "GPT", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Computer Vision",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "CNN", ProficiencyEnum.BEGINNER.ToString() },
            { "OpenCV", ProficiencyEnum.BEGINNER.ToString() },
            { "YOLO", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Generative AI & LLM",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "GPT", ProficiencyEnum.BEGINNER.ToString() },
            { "BERT", ProficiencyEnum.BEGINNER.ToString() },
            { "Fine-tuning LLMs", ProficiencyEnum.BEGINNER.ToString() },
            { "Transformers", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "RAG",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Parsing, chunking, clustering, ranking, retrieval, integration with LLMs for question-answering", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Generative AI Models",
        SkillId = SOFTWARE_ENGINEER_I_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "GANs", ProficiencyEnum.BEGINNER.ToString() },
            { "VAEs (Generative Adversarial Networks, Variational Autoencoders)", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_III_WEB_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "JavaScript", ProficiencyEnum.EXPERT.ToString() },
            { "TypeScript", ProficiencyEnum.EXPERT.ToString() },
            { "Java", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Backend Frameworks",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Express JS", ProficiencyEnum.EXPERT.ToString() },
            { "Nest JS", ProficiencyEnum.EXPERT.ToString() },
            { "Spring Boot", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Frontend Frameworks",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "React", ProficiencyEnum.EXPERT.ToString() },
            { "NextJS", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database Fundamentals",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Normalization", ProficiencyEnum.EXPERT.ToString() },
            { "Indexing", ProficiencyEnum.EXPERT.ToString() },
            { "Performance", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Relational Database",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "SQL Queries", ProficiencyEnum.EXPERT.ToString() },
            { "PostgreSQL", ProficiencyEnum.EXPERT.ToString() },
            { "MySQL", ProficiencyEnum.EXPERT.ToString() },
            { "Microsoft SQL Server", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NoSQL Database",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "DynamoDB", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "MongoDB", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "ORM",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Entity Framework", ProficiencyEnum.EXPERT.ToString() },
            { "Hibernate", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() },
            { "TFVC", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "NUnit/JUnit/NUnit Test", ProficiencyEnum.EXPERT.ToString() },
            { "Jest", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Github Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Cloud",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "AWS", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "GCP", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Azure", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Containerization",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "Docker", ProficiencyEnum.BEGINNER.ToString() },
            { "Kubernetes", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Web scripting",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "HTML", ProficiencyEnum.BEGINNER.ToString() },
            { "CSS", ProficiencyEnum.BEGINNER.ToString() },
            { "TCP/IP", ProficiencyEnum.BEGINNER.ToString() },
            { "UDP", ProficiencyEnum.BEGINNER.ToString() },
            { "HTTP", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Networking",
        SkillId = SOFTWARE_ENGINEER_III_WEB.Id,
        Description = new Dictionary<string, string>
        {
            { "TCP/IP", ProficiencyEnum.BEGINNER.ToString() },
            { "UDP", ProficiencyEnum.BEGINNER.ToString() },
            { "HTTP", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var MARKETING_MANAGER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SEO",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "SEM (Search Engine Marketing)", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Digital Marketing",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Social Media Management", ProficiencyEnum.EXPERT.ToString() },
            { "Content Marketing", ProficiencyEnum.EXPERT.ToString() },
            { "Email Marketing", ProficiencyEnum.EXPERT.ToString() },
            { "Google Analytics", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytics & Data",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "CRM Systems", ProficiencyEnum.EXPERT.ToString() },
            { "Conversion Rate Optimization (CRO)", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Brand & Creative Strategy",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Brand Management", ProficiencyEnum.EXPERT.ToString() },
            { "Copywriting", ProficiencyEnum.EXPERT.ToString() },
            { "Graphic Design", ProficiencyEnum.EXPERT.ToString() },
            { "Project Management", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Campaign Management",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Budget Management", ProficiencyEnum.EXPERT.ToString() },
            { "Stakeholder Management", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Public Relations & Outreach",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Media Relations", ProficiencyEnum.EXPERT.ToString() },
            { "Influencer Marketing", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Customer Engagement",
        SkillId = MARKETING_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Customer Segmentation", ProficiencyEnum.EXPERT.ToString() },
            { "Lead Nurturing", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var PRODUCT_DESIGNER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Wireframing",
        SkillId = PRODUCT_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.EXPERT.ToString() },
            { "Figma", ProficiencyEnum.EXPERT.ToString() },
            { "Sketch", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "UI Design",
        SkillId = PRODUCT_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.EXPERT.ToString() },
            { "Figma", ProficiencyEnum.EXPERT.ToString() },
            { "Sketch", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication",
        SkillId = PRODUCT_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = PRODUCT_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_II_AI_ML_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Python", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Machine Learning",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Supervised, Unsupervised, Reinforcement Learning, Regression and Classification Algorithms", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Deep Learning",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "TensorFlow", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "PyTorch", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Keras", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Data Processing",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Pandas", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NumPy", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Model Deployment",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Flask", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "FastAPI", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Docker", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Kubernetes", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Cloud Platforms",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "AWS", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Azure", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "GCP", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "MLOps",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "MLflow", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Kubeflow", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CI/CD for Model Deployment, Testing and Iteration", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "NLP",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Spacy", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NLTK", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "BERT", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "GPT", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Computer Vision",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "CNN", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "OpenCV", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "YOLO", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Generative AI & LLM",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "GPT", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "BERT", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Fine-tuning LLMs", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Transformers", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "RAG",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "Parsing, chunking, clustering, ranking, retrieval, integration with LLMs for question-answering", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Generative AI Models",
        SkillId = SOFTWARE_ENGINEER_II_AI_ML.Id,
        Description = new Dictionary<string, string>
        {
            { "GANs", ProficiencyEnum.BEGINNER.ToString() },
            { "VAEs (Generative Adversarial Networks, Variational Autoencoders)", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var SENIOR_MARKETING_EXECUTIVE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SEO",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "SEM (Search Engine Marketing)", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Digital Marketing",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "Social Media Management", ProficiencyEnum.EXPERT.ToString() },
            { "Content Marketing", ProficiencyEnum.EXPERT.ToString() },
            { "Email Marketing", ProficiencyEnum.EXPERT.ToString() },
            { "Google Analytics", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytics & Data",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "CRM Systems", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Conversion Rate Optimization (CRO)", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Brand & Creative Strategy",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "Brand Management", ProficiencyEnum.EXPERT.ToString() },
            { "Copywriting", ProficiencyEnum.EXPERT.ToString() },
            { "Graphic Design", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Project Management", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Campaign Management",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "Budget Management", ProficiencyEnum.EXPERT.ToString() },
            { "Stakeholder Management", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Public Relations & Outreach",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "Media Relations", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Influencer Marketing", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Customer Engagement",
        SkillId = SENIOR_MARKETING_EXECUTIVE.Id,
        Description = new Dictionary<string, string>
        {
            { "Customer Segmentation", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Lead Nurturing", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_II_FRONTEND_REACT_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "TypeScript", ProficiencyEnum.EXPERT.ToString() },
            { "JavaScript", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Frontend Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "React", ProficiencyEnum.EXPERT.ToString() },
            { "NextJS", ProficiencyEnum.EXPERT.ToString() },
            { "HTML", ProficiencyEnum.EXPERT.ToString() },
            { "CSS", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Application Programming Interface (API)",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "REST/HTTP", ProficiencyEnum.EXPERT.ToString() },
            { "Git", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() },
            { "TFVC", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Visual Studio Code", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Jest", ProficiencyEnum.EXPERT.ToString() },
            { "Mocha", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() },
            { "Jenkins", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = SOFTWARE_ENGINEER_II_FRONTEND_REACT.Id,
        Description = new Dictionary<string, string>
        {
            { "Github Actions", ProficiencyEnum.BEGINNER.ToString() },
            { "AWS Codebuild/CodePipeline", ProficiencyEnum.BEGINNER.ToString() },
            { "CircleCI/Travis CI", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var TECH_LEAD_COMMON_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SDLC Concepts",
        SkillId = TECH_LEAD_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Agile Concepts",
        SkillId = TECH_LEAD_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "Scrum", ProficiencyEnum.EXPERT.ToString() },
            { "Kanban", ProficiencyEnum.EXPERT.ToString() },
            { "Redmine", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Tools",
        SkillId = TECH_LEAD_COMMON.Id,
        Description = new Dictionary<string, string>
        {
            { "JIRA", ProficiencyEnum.EXPERT.ToString() },
            { "Asana", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Programming Languages",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Dart", ProficiencyEnum.BEGINNER.ToString() },
            { "Java", ProficiencyEnum.BEGINNER.ToString() },
            { "Kotlin", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Mobile Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Flutter", ProficiencyEnum.BEGINNER.ToString() },
            { "Android SDK", ProficiencyEnum.BEGINNER.ToString() },
            { "REST API Integration (Volley/Retrofit/Http)", ProficiencyEnum.BEGINNER.ToString() },
            { "Android Flutter Layouts, Custom Views",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "LiveData/RxJava/RxDart",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NDK",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Cordova",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Capacitor",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Multi Threading",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Services", ProficiencyEnum.BEGINNER.ToString() },
            { "WorkerThread", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Database",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Relational Database Fundamentals (Normalization, Indexing, Performance etc.)", ProficiencyEnum.BEGINNER.ToString() },
            { "SQLite", ProficiencyEnum.BEGINNER.ToString() },
            { "Room", ProficiencyEnum.BEGINNER.ToString() },
            { "Realm", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control System",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "IDE",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Android Studio", ProficiencyEnum.BEGINNER.ToString() },
            { "Visual Studio Code", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Testing Frameworks",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Flutter Test",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase Analytics",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Misc",
        SkillId = SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER.Id,
        Description = new Dictionary<string, string>
        {
            { "Push Notifications", ProficiencyEnum.BEGINNER.ToString() },
            { "Gradle", ProficiencyEnum.BEGINNER.ToString() },
            { "Google APIs", ProficiencyEnum.BEGINNER.ToString() },
            { "Android Profiler",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "CI/CD",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Bitrise",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Testify",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firebase", ProficiencyEnum.BEGINNER.ToString() },
            { "Play Store Deployment", ProficiencyEnum.BEGINNER.ToString() }
        }
    }
};
            var DEVOPS_ENGINEER_II_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Cloud Platforms",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "AWS", ProficiencyEnum.EXPERT.ToString() },
            { "Azure", ProficiencyEnum.BEGINNER.ToString() },
            { "GCP", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Infrastructure as Code",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Terraform", ProficiencyEnum.EXPERT.ToString() },
            { "Cloudformation", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "ARM/Biceps", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Configuration Management",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Ansible", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Chef", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Puppet", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Containerization",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Docker", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Orchestration",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Kubernetes", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "ECS", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "ACS", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "GitHub Actions", ProficiencyEnum.EXPERT.ToString() },
            { "Azure DevOps", ProficiencyEnum.BEGINNER.ToString() },
            { "Gitlab/Bitbucket pipelines", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Networking",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "VPC", ProficiencyEnum.EXPERT.ToString() },
            { "Subnets", ProficiencyEnum.EXPERT.ToString() },
            { "DNS", ProficiencyEnum.EXPERT.ToString() },
            { "Load Balancing", ProficiencyEnum.EXPERT.ToString() },
            { "Firewalls", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Operating Systems",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Linux", ProficiencyEnum.EXPERT.ToString() },
            { "Windows", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Scripting",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "Shell", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Python", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "PowerShell", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Monitoring & Logging",
        SkillId = DEVOPS_ENGINEER_II.Id,
        Description = new Dictionary<string, string>
        {
            { "ELK", ProficiencyEnum.EXPERT.ToString() },
            { "Prometheus/Grafana", ProficiencyEnum.EXPERT.ToString() },
            { "Cloudwatch", ProficiencyEnum.EXPERT.ToString() },
            { "Application Insights", ProficiencyEnum.EXPERT.ToString() },
            { "DataDog", ProficiencyEnum.EXPERT.ToString() },
            { "NewRelic", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var MARKETING_TRAINEE_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SEO",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "SEM (Search Engine Marketing)", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Digital Marketing",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Social Media Management", ProficiencyEnum.BEGINNER.ToString() },
            { "Content Marketing", ProficiencyEnum.BEGINNER.ToString() },
            { "Email Marketing", ProficiencyEnum.BEGINNER.ToString() },
            { "Google Analytics", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytics & Data",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "CRM Systems", ProficiencyEnum.BEGINNER.ToString() },
            { "Conversion Rate Optimization (CRO)",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Brand & Creative Strategy",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Brand Management",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Copywriting", ProficiencyEnum.BEGINNER.ToString() },
            { "Graphic Design", ProficiencyEnum.BEGINNER.ToString() },
            { "Project Management",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Campaign Management",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Budget Management",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Stakeholder Management", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Public Relations & Outreach",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Media Relations",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Influencer Marketing",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Customer Engagement",
        SkillId = MARKETING_TRAINEE.Id,
        Description = new Dictionary<string, string>
        {
            { "Customer Segmentation",  ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Lead Nurturing",  ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var PROJECT_MANAGER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Project Planning",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Develop schedules and timelines", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Sequence tasks efficiently", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Identify critical paths and dependencies", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Approach & Methodology",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Agile/Scrum/Waterfall", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Select appropriate methodology", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Implement effective frameworks", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Quality Management",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Define quality standards", ProficiencyEnum.EXPERT.ToString() },
            { "Implement corrective actions", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Risk Management",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Assess risk impact and likelihood", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Develop risk response strategies", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Management & Change Management",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Communicate changes", ProficiencyEnum.EXPERT.ToString() },
            { "Update documentation", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Budget Management",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Monitor project expenses", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Prepare budgets", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Stakeholder Management",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Build strong relationships with stakeholders", ProficiencyEnum.EXPERT.ToString() },
            { "Engage stakeholders throughout the project lifecycle", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Team Coordination",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Assign tasks and responsibilities", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Resolve conflicts and promote collaboration", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Create project plans, charters, reports with more standard documentation", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Conflict Resolution",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Ensure documentation compliance", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Soft Skills",
        SkillId = PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Problem Solving", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Communication", ProficiencyEnum.EXPERT.ToString() },
            { "Negotiation", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Attention to Detail", ProficiencyEnum.EXPERT.ToString() },
            { "Adaptability", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};
            var SENIOR_UX_DESIGNER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Wireframing",
        SkillId = SENIOR_UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.ADVANCED.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.ADVANCED.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.ADVANCED.ToString() },
            { "Figma", ProficiencyEnum.ADVANCED.ToString() },
            { "Sketch", ProficiencyEnum.ADVANCED.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "UI Design",
        SkillId = SENIOR_UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.ADVANCED.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.ADVANCED.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.ADVANCED.ToString() },
            { "Figma", ProficiencyEnum.ADVANCED.ToString() },
            { "Sketch", ProficiencyEnum.ADVANCED.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication",
        SkillId = SENIOR_UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = SENIOR_UX_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.ADVANCED.ToString() }
        }
    }
};

            var MARKETING_LEAD_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "SEO",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "SEM (Search Engine Marketing)", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Digital Marketing",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Social Media Management", ProficiencyEnum.EXPERT.ToString() },
            { "Content Marketing", ProficiencyEnum.EXPERT.ToString() },
            { "Email Marketing", ProficiencyEnum.EXPERT.ToString() },
            { "Google Analytics", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytics & Data",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "CRM Systems", ProficiencyEnum.EXPERT.ToString() },
            { "Conversion Rate Optimization (CRO)", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Brand & Creative Strategy",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Brand Management", ProficiencyEnum.EXPERT.ToString() },
            { "Copywriting", ProficiencyEnum.EXPERT.ToString() },
            { "Graphic Design", ProficiencyEnum.EXPERT.ToString() },
            { "Project Management", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Campaign Management",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Budget Management", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Stakeholder Management", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Public Relations & Outreach",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Media Relations", ProficiencyEnum.EXPERT.ToString() },
            { "Influencer Marketing", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Customer Engagement",
        SkillId = MARKETING_LEAD.Id,
        Description = new Dictionary<string, string>
        {
            { "Customer Segmentation", ProficiencyEnum.EXPERT.ToString() },
            { "Lead Nurturing", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var DEVOPS_ENGINEER_I_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Cloud Platforms",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "AWS", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Azure", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "GCP", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Infrastructure as Code",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Terraform", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Cloudformation", ProficiencyEnum.BEGINNER.ToString() },
            { "ARM/Biceps", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Configuration Management",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Ansible", ProficiencyEnum.BEGINNER.ToString() },
            { "Chef", ProficiencyEnum.BEGINNER.ToString() },
            { "Puppet", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Containerization",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Docker", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Orchestration",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Kubernetes", ProficiencyEnum.BEGINNER.ToString() },
            { "ECS", ProficiencyEnum.BEGINNER.ToString() },
            { "ACS", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "CI/CD Tools",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "GitHub Actions", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Azure DevOps", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Gitlab/Bitbucket pipelines", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Version Control",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Git", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Networking",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "VPC", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Subnets", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "DNS", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Load Balancing", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Firewalls", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Operating Systems",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Linux", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Windows", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Scripting",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "Shell", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Python", ProficiencyEnum.BEGINNER.ToString() },
            { "PowerShell", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Monitoring & Logging",
        SkillId = DEVOPS_ENGINEER_I.Id,
        Description = new Dictionary<string, string>
        {
            { "ELK", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Prometheus/Grafana", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Cloudwatch", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Application Insights", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "DataDog", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "NewRelic", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};

            var BRAND_DESIGNER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Wireframing",
        SkillId = BRAND_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.EXPERT.ToString() },
            { "Figma", ProficiencyEnum.EXPERT.ToString() },
            { "Sketch", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "UI Design",
        SkillId = BRAND_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Adobe XD", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Photoshop", ProficiencyEnum.EXPERT.ToString() },
            { "Adobe Illustrator", ProficiencyEnum.EXPERT.ToString() },
            { "Figma", ProficiencyEnum.EXPERT.ToString() },
            { "Sketch", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication",
        SkillId = BRAND_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = BRAND_DESIGNER.Id,
        Description = new Dictionary<string, string>
        {
            { "Proficiency", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var SENIOR_PROJECT_MANAGER_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Project Planning",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Develop schedules and timelines", ProficiencyEnum.EXPERT.ToString() },
            { "Sequence tasks efficiently", ProficiencyEnum.EXPERT.ToString() },
            { "Identify critical paths and dependencies", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Project Management Approach & Methodology",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Agile/Scrum/Waterfall", ProficiencyEnum.EXPERT.ToString() },
            { "Understand various methodologies", ProficiencyEnum.EXPERT.ToString() },
            { "Select appropriate methodologies", ProficiencyEnum.EXPERT.ToString() },
            { "Implement project management tools", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Quality Management",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Define quality standards", ProficiencyEnum.EXPERT.ToString() },
            { "Identify risk impact and likelihood", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Risk Management",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Assess risk impact and likelihood", ProficiencyEnum.EXPERT.ToString() },
            { "Develop risk response strategies", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Management & Change Management",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Communicate changes", ProficiencyEnum.EXPERT.ToString() },
            { "Update documentation", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Budget Management",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Monitor project expenses", ProficiencyEnum.EXPERT.ToString() },
            { "Prepare budgets", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Time Management",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Prioritize tasks", ProficiencyEnum.EXPERT.ToString() },
            { "Handle strict deadlines", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Stakeholder Management",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Build strong relationships with stakeholders", ProficiencyEnum.EXPERT.ToString() },
            { "Engage stakeholders throughout the project lifecycle", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Team Coordination",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Assign tasks and responsibilities", ProficiencyEnum.EXPERT.ToString() },
            { "Facilitate team meetings and discussions", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Documentation",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Create project plans, charters, reports with more standard documentation", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Conflict Resolution",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Ensure documentation compliance with organizational standards", ProficiencyEnum.EXPERT.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Soft Skills",
        SkillId = SENIOR_PROJECT_MANAGER.Id,
        Description = new Dictionary<string, string>
        {
            { "Problem Solving", ProficiencyEnum.EXPERT.ToString() },
            { "Decision Making", ProficiencyEnum.EXPERT.ToString() },
            { "Communication", ProficiencyEnum.EXPERT.ToString() },
            { "Negotiation", ProficiencyEnum.EXPERT.ToString() },
            { "Attention to Detail", ProficiencyEnum.EXPERT.ToString() },
            { "Adaptability", ProficiencyEnum.EXPERT.ToString() }
        }
    }
};
            var BUSINESS_ANALYST_SUBSKILLS = new List<SkillSubtopic>
{
    new SkillSubtopic
    {
        Name = "Data Analysis",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Problem Solving", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Analytical Skills",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "SWOT Analysis", ProficiencyEnum.BEGINNER.ToString() },
            { "MoSCoW Prioritization", ProficiencyEnum.BEGINNER.ToString() },
            { "Root Cause Analysis", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Communication Skills",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Written Communication", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Verbal Communication", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Presentation Skills", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Facilitation", ProficiencyEnum.BEGINNER.ToString() },
            { "Active Listening", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Research and Learning",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Market Research", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Continuous Learning", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Competitive Analysis", ProficiencyEnum.BEGINNER.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Technical Skills",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Technical Writing & Documentation", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Understanding of IT Systems", ProficiencyEnum.BEGINNER.ToString() },
            { "Data Visualization Tools (e.g., Tableau, Power BI)", ProficiencyEnum.BEGINNER.ToString() },
            { "Business Analysis Tools (e.g., JIRA, Confluence)", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Stakeholder Management",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Stakeholder Engagement", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Conflict Resolution", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Negotiation Skills", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Scope Management",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Relationship Building", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Requirements Gathering", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Scope Validation", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    },
    new SkillSubtopic
    {
        Name = "Change Management",
        SkillId = BUSINESS_ANALYST.Id,
        Description = new Dictionary<string, string>
        {
            { "Change Request Management", ProficiencyEnum.INTERMEDIATE.ToString() },
            { "Change Impact Analysis", ProficiencyEnum.INTERMEDIATE.ToString() }
        }
    }
};






            var listOfListSkillSubTopic = new List<List<SkillSubtopic>>()
{
    MARKETING_EXECUTIVE_SUBSKILLS,
    SOFTWARE_ENGINEER_I_FRONTEND_REACT_SUBSKILL,
    SOFTWARE_ENGINEER_I_FRONTEND_ANGULAR_SUBSKILLS,
    SOFTWARE_ENGINEER_II_COMMON_SUBSKILLS,
    UX_DESIGN_LEAD_SUBSKILLS,
    SOFTWARE_ENGINEER_I_BACKEND_DOTNET_SUBSKILLS,
    SOFTWARE_ENGINEER_I_COMMON_SUBSKILSS,
    SOFTWARE_ENGINEER_TRAINEE_BACKEND_DOTNET_SUBSKILLS,
    SOFTWARE_ENGINEER_I_MOBILE_IOS_SUBSKILLS,
    SOFTWARE_ENGINEER_TRAINEE_BACKEND_JAVA_SUBSKILLS,
    SOFTWARE_ENGINEER_TRAINEE_MOBILE_IOS_SUBSKILS,
    SOFTWARE_ENGINEER_II_BACKEND_DOTNET_SUBSKILL,
    SOFTWARE_ENGINEER_TRAINEE_BACKEND_NODE_SUBSKILLS,
    SOFTWARE_ENGINEER_TRAINEE_MOBILE_ANDROID_SUBSKILLS,
    SOFTWARE_TEST_ENGINEER_FUNCTIONAL_SUBSKILLS,
    SOFTWARE_ENGINEER_I_BACKEND_JAVA_SUBSKILLS,
    SOFTWARE_ENGINEER_I_BACKEND_NODE_SUBSKILLS,
    SOFTWARE_ENGINEER_III_WEB_SUBSKILLS,
    MARKETING_MANAGER_SUBSKILLS,
    PRODUCT_DESIGNER_SUBSKILLS,
    SOFTWARE_ENGINEER_II_AI_ML_SUBSKILLS,
    SENIOR_MARKETING_EXECUTIVE_SUBSKILLS,
    SOFTWARE_ENGINEER_II_FRONTEND_REACT_SUBSKILLS,
    TECH_LEAD_COMMON_SUBSKILLS,
    SOFTWARE_ENGINEER_TRAINEE_MOBILE_FLUTTER_SUBSKILLS,
    DEVOPS_ENGINEER_II_SUBSKILLS,
    MARKETING_TRAINEE_SUBSKILLS,
    PROJECT_MANAGER_SUBSKILLS,
    SENIOR_UX_DESIGNER_SUBSKILLS,
    MARKETING_LEAD_SUBSKILLS,
    DEVOPS_ENGINEER_I_SUBSKILLS,
    BRAND_DESIGNER_SUBSKILLS,
    SENIOR_PROJECT_MANAGER_SUBSKILLS,
    BUSINESS_ANALYST_SUBSKILLS,
    VP_OF_ENGINEERING_COMMON_SUBSKILLS,
    SOFTWARE_ENGINEER_II_FRONTEND_ANGULAR_SUBSKILLS,
    TECH_LEAD_SUBSKILLS,
    SOFTWARE_ENGINEER_II_MOBILE_FLUTTER_SUBSKILLS,
    UX_DESIGNER_TRAINEE_SUBSKILLS,
    SOLUTION_ARCHITECT_COMMON_SUBSKILLS,
    UX_DESIGNER_SUBSKILLS,
    SOFTWARE_ENGINEER_I_MOBILE_ANDROID_SUBSKILLS,
    SOFTWARE_ENGINEER_II_MOBILE_ANDROID_SUBSKILLS,
    SOFTWARE_ENGINEER_II_BACKEND_NODE_SUBSKILLS,
    SOFTWARE_ENGINEER_TRAINEE_FRONTEND_REACT_SUBSKILLS,
    SOFTWARE_ENGINEER_I_MOBILE_FLUTTER_SUBSKILL,
    SOFTWARE_ENGINEER_TRAINEE_COMMON_SUBSKILLS,
    SOFTWARE_ENGINEER_TRAINEE_FRONTEND_ANGULAR_SUBSKILL,
    SOFTWARE_ENGINEER_II_BACKEND_JAVA_SUBSKILLS,
    SOFTWARE_TEST_ENGINEER_AUTOMATION_SUBSKILLS,
    CONTENT_LEAD_SUBSKILLS,

    SOFTWARE_ENGINEER_III_COMMON_SUBSKILLS,
    CONTENT_TRAINEE_SUBSKILLS,
    SOFTWARE_ENGINEER_I_AI_ML_SUBSKILLS,



};

            foreach (var list in listOfListSkillSubTopic)
            {
                await _skillSubtopicRepository.InsertManyAsync(list);
            }
        }
    }
};