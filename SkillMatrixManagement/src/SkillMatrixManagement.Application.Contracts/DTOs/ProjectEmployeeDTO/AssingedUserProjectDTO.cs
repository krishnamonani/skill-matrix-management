using SkillMatrixManagement.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkillMatrixManagement.DTOs.ProjectEmployeeDTO
{
    public class AssingedUserProjectDTO
    {
        public CustomUserResponseDTO UserResponseData{ get; set; }  // Entire user object
        public int AssignabilityPercentage { get; set; }
        public int BillablePercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AvailabilityPerncentage { get; set; }
    }
}
