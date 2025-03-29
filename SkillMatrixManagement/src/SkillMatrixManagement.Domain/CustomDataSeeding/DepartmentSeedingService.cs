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
    class DepartmentSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Department, Guid> _departmentRepository;

        public DepartmentSeedingService(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _departmentRepository.GetCountAsync() > 0) return;

            var techDepartment = new Department()
            {
                Name = "Tech",
                Description = "The core technology team responsible for software development, infrastructure, and IT solutions. This includes software engineers, architects, and system administrators."
            };
            var aiMLDepartment = new Department()
            {
                Name = "AI/ML",
                Description = "Focuses on artificial intelligence and machine learning, developing algorithms, predictive models, and automation to enhance software capabilities."
            };
            var businessAnalystDepartment = new Department()
            {
                Name = "Business Analyst",
                Description = "Bridges the gap between business needs and technical solutions, analyzing requirements, creating documentation, and ensuring projects align with business goals."
            };
            var businessDevelopmenDepartment = new Department()
            {
                Name = "Business Development",
                Description = "Identifies new opportunities, builds partnerships, and drives revenue growth by expanding the company’s market reach."
            };
            var contentDepartment = new Department()
            {
                Name = "Content",
                Description = "Manages and creates digital content, including blogs, documentation, marketing materials, and social media strategies to engage users and promote products."
            };

            var designDepartment = new Department()
            {
                Name = "Design",
                Description = "Encompasses UI/UX design, graphic design, and product design, ensuring applications are visually appealing, user-friendly, and functionally efficient."
            };

            var devOpsDepartment = new Department()
            {
                Name = "DevOps",
                Description = "Integrates development and IT operations to streamline software deployment, improve automation, and enhance system reliability."
            };

            var humanResourcesDepartment = new Department()
            {
                Name = "Human Resources",
                Description = "Handles recruitment, employee management, training, company culture, and compliance with labor laws."
            };

            var projectManagementDepartment = new Department()
            {
                Name = "Project Management",
                Description = "Oversees IT projects from planning to execution, ensuring timely delivery, scope management, and coordination among teams."
            };

            var qualityDepartment = new Department()
            {
                Name = "Quality",
                Description = "Ensures software products meet quality standards through testing, debugging, and performance evaluation before deployment."
            };
            var marketingDepartment = new Department()
            {
                Name = "Marketing",
                Description = "Promotes the company’s products or services through digital campaigns, branding, SEO, advertising, and customer engagement strategies."
            };

            await _departmentRepository.InsertManyAsync(new List<Department>() {
             techDepartment,
             aiMLDepartment,
             businessAnalystDepartment,
             businessDevelopmenDepartment,
             contentDepartment,
             designDepartment,
             devOpsDepartment,
             humanResourcesDepartment,
             projectManagementDepartment,
             qualityDepartment,
             marketingDepartment
         });
        }
    }
}
