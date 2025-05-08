using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class UserProjectAssignibilityStatusDto
    {
        public Guid Id { get; set; }
        public int AssignibilityPercentage { get; set; } 
        public int BillablePercentage { get; set; } 
        public int AvailabilityPercentage { get; set; } 
    }
}
