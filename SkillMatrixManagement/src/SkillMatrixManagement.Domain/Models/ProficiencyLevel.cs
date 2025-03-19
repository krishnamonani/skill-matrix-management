using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class ProficiencyLevel : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        public ProficiencyEnum Level { get; set; }
        public string Description { get; set; }

    }

}
