using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.Domain
{
    public interface ICustomUserRepository : IRepository<CustomUser, Guid>
    {
        Task<List<CustomUser>> GetUsersByStatusAsync(bool isActive);
    }
}