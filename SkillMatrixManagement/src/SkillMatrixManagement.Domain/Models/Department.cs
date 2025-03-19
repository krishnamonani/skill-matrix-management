using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;

namespace SkillMatrixManagement.Models
{
    public class Department : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

    }

}
