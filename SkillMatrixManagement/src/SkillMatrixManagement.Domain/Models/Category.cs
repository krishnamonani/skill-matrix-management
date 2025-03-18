using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public CategoryEnum CategoryName { get; set; }

        public string Description { get; set; }

        public bool IsUpdated { get; set; } = false;
    }

}
