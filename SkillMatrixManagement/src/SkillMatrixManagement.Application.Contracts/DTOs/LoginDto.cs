using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Validation;

namespace SkillMatrixManagement.DTOs
{
    [Serializable]
    public class LoginDto // Removed IDisableAuditing as it is not recognized
    {
        [Required]
        [Display(Name = "UserNameOrEmailAddress")] // Used for display purposes, e.g., in MVC views if applicable
        [StringLength(256)] // Reference constants for max length
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)] // Hint for UI rendering
        [DynamicStringLength(typeof(Volo.Abp.Identity.IdentityUserConsts), nameof(Volo.Abp.Identity.IdentityUserConsts.MaxPasswordLength))] // Dynamic length validation
        [DisableAuditing] // Ensure password is not logged
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        // Older versions might have separate UserName and EmailAddress fields,
        // but UserNameOrEmailAddress is common in recent versions.
    }
}
