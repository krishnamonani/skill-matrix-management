using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        public Guid? DepartmentId { get; set; }

        public Guid? InternalRoleId { get; set; }

        public bool IsAvailable { get; set; }

        [StringLength(500)]
        public string? ProfilePhoto { get; set; }
    }
}
