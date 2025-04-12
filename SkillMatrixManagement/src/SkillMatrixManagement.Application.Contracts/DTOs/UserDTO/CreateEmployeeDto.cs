using System;
using System.ComponentModel.DataAnnotations;

namespace SkillMatrixManagement.DTOs.UserDTO
{
    public class CreateEmployeeDto
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public Guid? DepartmentId { get; set; }
        
        public Guid? InternalRoleId { get; set; }
        
        [Required]
        public Guid RoleId { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}
