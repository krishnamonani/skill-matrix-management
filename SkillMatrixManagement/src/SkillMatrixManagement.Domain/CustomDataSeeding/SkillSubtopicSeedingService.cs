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
        
        private readonly IRepository<SkillSubtopic, Guid> _skillSubtopic;

        public SkillSubtopicSeedingService(IRepository<Skill, Guid> skillRepository, IRepository<SkillSubtopic, Guid> skillSubtopic)
        {
            _skillRepository = skillRepository;
         
            _skillSubtopic = skillSubtopic;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
          if (await _skillSubtopic.GetCountAsync() > 0) return;
            var SkillsTableData = await _skillRepository.GetListAsync();
      

            //Skill By Name
            var MARKETING_EXECUTIVE = SkillsTableData.FirstOrDefault(s => s.Name == "MARKETING_EXECUTIVE");




            //var MARKETING_EXECUTIVE_SUBTOPICS = new SkillSubtopic()
            //{
            //    Name = " Digital Marketing",
            //    SkillId = MARKETING_EXECUTIVE.Id,
                
            //};




        }

         

    }
}
