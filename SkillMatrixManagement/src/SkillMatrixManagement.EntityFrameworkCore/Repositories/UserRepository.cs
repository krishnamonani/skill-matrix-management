using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class UserRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, User, Guid>, IUserRepository
    {
        readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public UserRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<User> CreateAsync(User user)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(Guid userId) // Rename to SoftDeleteAsync for clarity
        {
            await SoftDeleteAsync(userId);
        }

        public async Task<List<User>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Users.Where(u => !u.IsDeleted).ToListAsync(); // Filter out deleted by default
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found or is deleted.");
            }
            return user;
        }

        public async Task PermanentDeleteAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var user = await dbContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task RestoreUserAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var user = await dbContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            if (!user.IsDeleted)
            {
                throw new Exception($"User with ID {userId} is already active.");
            }

            user.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var user = await dbContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            if (user.IsDeleted)
            {
                throw new Exception($"User with ID {userId} is already deleted.");
            }

            user.IsDeleted = true; // Fixed
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id && !u.IsDeleted);
            if (existingUser == null)
            {
                throw new Exception($"User with ID {user.Id} not found or is deleted.");
            }

            dbContext.Entry(existingUser).CurrentValues.SetValues(user);
            await dbContext.SaveChangesAsync();
        }

        public override async Task<IQueryable<User>> WithDetailsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return dbContext.Set<User>();
        }
    }
}