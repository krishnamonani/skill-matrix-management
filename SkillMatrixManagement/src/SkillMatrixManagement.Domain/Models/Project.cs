using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Models
{
    public class Project : FullAuditedAggregateRoot<Guid>, ISoftDelete
    {
        [StringLength(256)]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }

        public string Status {  get; set; }

        public bool IsDelayed { get; set; } = false;
        public bool IsOngoing { get; set; } = true;
    }

}
