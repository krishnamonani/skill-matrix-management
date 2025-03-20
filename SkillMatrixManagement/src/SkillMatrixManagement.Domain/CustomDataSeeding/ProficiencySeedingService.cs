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
    public class ProficiencySeedingService : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<ProficiencyLevel> _proficiencyRepository;

        public ProficiencySeedingService(IRepository<ProficiencyLevel> proficiencyRepository)
        {
            _proficiencyRepository = proficiencyRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _proficiencyRepository.GetCountAsync() > 0) return;

            var beginner = new ProficiencyLevel()
            {
                Level = ProficiencyEnum.BEGINNER,
                Description = "The \"Beginner\" level represents an individual who has just started learning or working" +
                " with a particular skill. They may have basic knowledge or a limited understanding of the skill and " +
                "need significant guidance and practice to improve."
            };

            var intermediate = new ProficiencyLevel()
            {
                Level = ProficiencyEnum.INTERMEDIATE,
                Description = "The \"Intermediate\" level indicates that the individual has a decent understanding of" +
                " the skill and can use it competently with some guidance. They are able to perform tasks independently," +
                " but may still require occasional support for more complex scenarios."
            };

            var advanced = new ProficiencyLevel()
            {
                Level = ProficiencyEnum.ADVANCED,
                Description = "The \"Advanced\" level signifies a high degree of proficiency with the skill." +
                " Individuals at this level can apply the skill to solve complex problems with minimal assistance and can " +
                "contribute to higher-level tasks and projects."
            };

            var expert = new ProficiencyLevel()
            {
                Level = ProficiencyEnum.EXPERT,
                Description = "The \"Expert\" level represents mastery of the skill. Experts have an in-depth" +
                " understanding and are highly capable of applying their knowledge in any scenario. They can innovate, " +
                "make strategic decisions, and lead projects related to the skill."
            };

            await _proficiencyRepository.InsertManyAsync(new List<ProficiencyLevel>()
            {
                 beginner, intermediate, advanced, expert
            });
        }
    }
}
