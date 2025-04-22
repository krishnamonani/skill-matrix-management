using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace SkillMatrixManagement.DTOs.PasswordReset
{
    [Serializable]
    public class ResetPasswordDto
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string EmailOrUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisableAuditing]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(128, MinimumLength = 6)]
        [DisableAuditing]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        [DisableAuditing]
        public string ConfirmPassword { get; set; }
    }
}
