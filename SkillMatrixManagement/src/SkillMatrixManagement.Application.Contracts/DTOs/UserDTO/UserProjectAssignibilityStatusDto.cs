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
        public int AssignibilityPerncentage { get; set; } 
        public int BillablePerncentage { get; set; } 
        public int AvailabilityPerncentage { get; set; } 
    }
}
