using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs
{
    [Serializable]
    public class CustomLoginResultDto
    {
        public LoginResultType Result { get; set; }
        
        public List<string> Roles { get; set; } // Added: List of roles
        public string Description { get; set; }
    }

    // LoginResultType enum remains the same
    public enum LoginResultType
    {
        Success = 1,
        InvalidCredentials = 2,
        IsNotAllowed = 3,
        IsLockedOut = 4,
        RequiresTwoFactor = 5,
        NoRoleAssigned = 6
    }
}
