using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Application.Contracts.Admin
{
    public interface IAdminUserAppService : IApplicationService
    {
        Task<List<CustomUserDto>> GetAllUsersAsync();
        Task<ServiceResponse> AssignRoleAndActivateAsync(Guid identityUserId, string roleName);
    }

    public class CustomUserDto
    {
        public Guid IdentityUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
    }
}