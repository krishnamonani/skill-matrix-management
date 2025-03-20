using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Models;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.CustomDataSeeding
{
    public class CategorySeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategorySeedingService(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.GetCountAsync() > 0) return;

            var technicalSkill = new Category()
            {
                CategoryName = CategoryEnum.TECHNICAL_SKILL,
                Description = "Specialized knowledge or expertise required for specific tasks (e.g., coding, engineering, data analysis)."
            };

            var transferableSkill = new Category()
            {
                CategoryName = CategoryEnum.TRANSFERABLE_SKILL,
                Description = "Skills that can be applied across different jobs or industries (e.g., problem-solving, leadership, communication)."
            };

            var cognitiveSkill = new Category()
            {
                CategoryName = CategoryEnum.COGNITIVE_SKILL,
                Description = "Mental abilities related to learning, reasoning, and problem-solving (e.g., critical thinking, decision-making, analytical skills)."
            };

            var interpersonalSkill = new Category()
            {
                CategoryName = CategoryEnum.INTERPERSONAL_SKILL,
                Description = "Abilities related to interacting with others effectively (e.g., teamwork, conflict resolution, negotiation)."
            };

            var intrapersonalSkill = new Category()
            {
                CategoryName = CategoryEnum.INTRAPERSONAL_SKILL,
                Description = "Skills required to guide, influence, and manage teams (e.g., delegation, motivation, strategic thinking)."
            };

            var creativeSkill = new Category()
            {
                CategoryName = CategoryEnum.CREATIVE_SKILL,
                Description = "Abilities related to thinking outside the box and innovation (e.g., artistic abilities, content creation, design thinking)."
            };

            var analyticalSkill = new Category()
            {
                CategoryName = CategoryEnum.ANALYTICAL_SKILL,
                Description = "The ability to analyze information and make data-driven decisions (e.g., research, data interpretation, logical reasoning)."
            };

            var organizationalSkill = new Category()
            {
                CategoryName = CategoryEnum.ORGANIZATIONAL_SKILL,
                Description = "Skills that help with planning, prioritization, and efficiency (e.g., time management, multitasking, goal setting)."
            };

            var digitalSkill = new Category()
            {
                CategoryName = CategoryEnum.DIGITAL_SKILL,
                Description = "Proficiency in using digital tools and technologies (e.g., social media management, cybersecurity, cloud computing).\r\n"
            };
            var managementSkill = new Category()
            {
                CategoryName = CategoryEnum.MANAGEMENT_SKILL,

                Description = "Expertise in leading and organizing teams or projects (e.g., project management, time management, risk management).\r\n"
            };
            var softSkill = new Category()
            {
                CategoryName = CategoryEnum.SOFT_SKILL,
                Description = "Personal traits that enhance workplace interactions (e.g., communication, teamwork, adaptability).\r\n"
            };
            await _categoryRepository.InsertManyAsync(new List<Category>() {
            technicalSkill,
            transferableSkill,
            cognitiveSkill,
            interpersonalSkill,
            intrapersonalSkill,
            analyticalSkill,
            organizationalSkill,
            digitalSkill,
            creativeSkill,
            managementSkill,
            softSkill
        });
        }
    }
}
