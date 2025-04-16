using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class ProjectEmployee : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("ProjectId")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        //[ForeignKey("UserId")]
        //public Guid CreatedBy { get; set; }   
        public virtual User Creator { get; set; }
    }

}
