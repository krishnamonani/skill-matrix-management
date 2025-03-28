using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrixManagement.Constants;
using Volo.Abp.Application.Dtos;

namespace SkillMatrixManagement.DTOs.EmployeeSkillDTO
{
    public class EmployeeSkillFilterDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
       

        public ProficiencyEnum? SelfAssessedProficiency { get; set; }
        public ProficiencyEnum? ManagerAssignedProficiency { get; set; }
        public Guid? EndorsedBy { get; set; }
        public DateTime? EndorsedAtStart { get; set; }
        public DateTime? EndorsedAtEnd { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreationTimeStart { get; set; }
        public DateTime? CreationTimeEnd { get; set; }
        public DateTime? LastModificationTimeStart { get; set; }
        public DateTime? LastModificationTimeEnd { get; set; }
    }
}
