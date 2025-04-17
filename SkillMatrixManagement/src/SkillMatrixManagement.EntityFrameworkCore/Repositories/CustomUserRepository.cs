using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.Domain;
using SkillMatrixManagement.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class CustomUserRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, CustomUser, Guid>, ICustomUserRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public CustomUserRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }
 public async Task<List<CustomUser>> GetUsersByStatusAsync(bool isActive)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.CustomUsers
                .Where(u => u.IsActive == isActive)
                .ToListAsync();
        }
        public async Task<CustomUser> CreateAsync(CustomUser user)
        {
            Check.NotNull(user, nameof(user));
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var exists = await dbContext.Set<CustomUser>()
                .AnyAsync(u => (u.UserName == user.UserName || u.Email == user.Email) && !u.IsDeleted);
            if (exists)
                throw new BusinessException(
                    SkillMatrixManagementDomainErrorCodes.CustomUser.USER_ALREADY_EXISTS,
                    "A user with the same username or email already exists");

            var result = await dbContext.Set<CustomUser>().AddAsync(user);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<CustomUser> FindByEmailAsync(string email)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<CustomUser>()
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<CustomUser> UpdateAsync(CustomUser user)
        {
            Check.NotNull(user, nameof(user));
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var existing = await dbContext.Set<CustomUser>()
                .FirstOrDefaultAsync(u => u.Id == user.Id && !u.IsDeleted)
                ?? throw new BusinessException(
                    SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND_FOR_UPDATE,
                    "User not found for update");

            var duplicateExists = await dbContext.Set<CustomUser>()
                .AnyAsync(u => (u.UserName == user.UserName || u.Email == user.Email) && u.Id != user.Id && !u.IsDeleted);
            if (duplicateExists)
                throw new BusinessException(
                    SkillMatrixManagementDomainErrorCodes.CustomUser.USER_DUPLICATE_NAME,
                    "A user with the same username or email already exists");

            dbContext.Set<CustomUser>().Update(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<CustomUser> FindByIdentityUserIdAsync(Guid identityUserId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<CustomUser>()
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId && !u.IsDeleted);
        }

        public async Task SoftDeleteAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var user = await dbContext.Set<CustomUser>()
                .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted)
                ?? throw new BusinessException(
                    SkillMatrixManagementDomainErrorCodes.CustomUser.USER_NOT_FOUND_FOR_SOFT_DELETE,
                    "User not found");

            user.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }
    }
}