using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.Domain;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.EntityFrameworkCore
{
    public class CustomUserRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, CustomUser, Guid>, ICustomUserRepository
    {
        public CustomUserRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<CustomUser>> GetUsersByStatusAsync(bool isActive)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.CustomUsers
                .Where(u => u.IsActive == isActive)
                .ToListAsync();
        }
    }
}