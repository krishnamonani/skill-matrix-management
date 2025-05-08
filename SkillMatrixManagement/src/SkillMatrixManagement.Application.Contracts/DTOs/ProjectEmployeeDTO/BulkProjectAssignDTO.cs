using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.ProjectEmployeeDTO
{
    public class BulkProjectAssignDTO
    {
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public int AssignabilityPercentage { get; set; }
        public int BillablePercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
