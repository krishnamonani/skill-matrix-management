using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class Permission : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
