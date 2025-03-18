using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class ProjectEmployee : FullAuditedEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public Guid CreatedBy { get; set; }
        public virtual User Creator { get; set; }
    }

}
