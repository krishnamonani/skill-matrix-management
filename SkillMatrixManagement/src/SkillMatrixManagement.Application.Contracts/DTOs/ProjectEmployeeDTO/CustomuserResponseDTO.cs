using System;
using System.Collections.Generic;
using SkillMatrixManagement.Constants;

namespace SkillMatrixManagement.DTOs.ProjectEmployeeDTO
{
    public class CustomUserResponseDTO
    {
        // User Basic Info
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }

        // User Related Info
        public Guid RoleId { get; set; }
        public string? RoleName { get; set; }

        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public Guid? SkillId { get; set; }
        public string? SkillName { get; set; }

        public ProjectStatusEnum IsAvailable { get; set; }
        public string? ProfilePhoto { get; set; }

        public int AssignibilityPerncentage { get; set; }
        public int BillablePerncentage { get; set; }
        public int AvailabilityPerncentage { get; set; }

        // Assignment (Recent) Info
        public int AssignedAssignibilityPercentage { get; set; }
        public int AssignedBillablePercentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
