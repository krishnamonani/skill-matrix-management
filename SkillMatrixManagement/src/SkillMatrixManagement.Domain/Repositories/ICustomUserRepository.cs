using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Domain
{
   public interface ICustomUserRepository : IRepository<CustomUser, Guid>
    {
        Task<CustomUser> FindByIdentityUserIdAsync(Guid identityUserId);
        Task<CustomUser> FindByEmailAsync(string email);
        Task SoftDeleteAsync(Guid userId);
        Task<List<CustomUser>> GetUsersByStatusAsync(bool isActive);
        Task<CustomUser> CreateAsync(CustomUser user);
        Task<CustomUser> UpdateAsync(CustomUser user);
    }
}