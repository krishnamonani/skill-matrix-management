using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class UserProjectAssignibilityRemoveDto
    {
        public Guid UserId { get; set; }
        [Range(0, 100)]
        public int AssignibilityPercentage { get; set; } 
        [Range(0, 100)] 
        public int BillablePercentage { get; set; }
    }
}
