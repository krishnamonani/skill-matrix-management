using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.DTOs.ProjectEmployeeDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class ProjectEmployeeRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, ProjectEmployee, Guid>, IProjectEmployeeRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;
        private readonly IUserRepository _userRepository;

        public ProjectEmployeeRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider, IUserRepository userRepository)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
            _userRepository = userRepository;
        }

        // Create a new project employee assignment
        public async Task<ProjectEmployee> CreateAsync(ProjectEmployee projectEmployee)

        {
            Check.NotNull(projectEmployee, nameof(projectEmployee));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var exists = await dbContext.Set<ProjectEmployee>()
                .AnyAsync(pe => pe.ProjectId == projectEmployee.ProjectId && pe.UserId == projectEmployee.UserId && !pe.IsDeleted);

            if (exists)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.EMPLOYEE_ALREADY_ASSIGNED_TO_THIS_PROJECT, "Employee is already assigned to this project");

            var result = await dbContext.Set<ProjectEmployee>().AddAsync(projectEmployee);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Get project employee assignment by ID
        public async Task<ProjectEmployee> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Project Employee ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var projectEmployee = await dbContext.Set<ProjectEmployee>().FindAsync(id)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.PROJECT_EMPLOYEE_NOT_FOUND, "Project Employee not found");

            return projectEmployee;
        }

        // Get all project employee assignments
        public async Task<List<ProjectEmployee>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<ProjectEmployee>().Where(pe => !pe.IsDeleted).ToListAsync();
        }

        // Update project employee assignment
        public async Task UpdateAsync(ProjectEmployee projectEmployee)
        {
            Check.NotNull(projectEmployee, nameof(projectEmployee));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<ProjectEmployee>()
                .FirstOrDefaultAsync(pe => pe.Id == projectEmployee.Id && !pe.IsDeleted)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.PROJECT_EMPLOYEE_NOT_FOUND_FOR_UPDATE, "Project Employee not found for update");

            dbContext.Set<ProjectEmployee>().Update(projectEmployee);
            await dbContext.SaveChangesAsync();
        }

        // Soft Delete project employee assignment
        public async Task DeleteAsync(Guid projectEmployeeId)
        {
            await SoftDeleteAsync(projectEmployeeId);
        }

        // Soft Delete project employee assignment
        public async Task SoftDeleteAsync(Guid projectEmployeeId)
        {
            if (projectEmployeeId == Guid.Empty)
                throw new ArgumentException("Project Employee ID cannot be empty", nameof(projectEmployeeId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var projectEmployee = await dbContext.Set<ProjectEmployee>().FindAsync(projectEmployeeId)
                ?? throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.PROJECT_EMPLOYEE_NOT_FOUND, "Project Employee not found");

            if (projectEmployee.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.PROJECT_EMPLOYEE_NOT_FOUND_FOR_DELETION, "Project Employee is already deleted");

            projectEmployee.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        // Permanent Delete project employee assignment
        public async Task PermanentDeleteAsync(Guid projectEmployeeId)
        {
            if (projectEmployeeId == Guid.Empty)
                throw new ArgumentException("Project Employee ID cannot be empty", nameof(projectEmployeeId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var projectEmployee = await dbContext.Set<ProjectEmployee>().IgnoreQueryFilters()
                .FirstOrDefaultAsync(pe => pe.Id == projectEmployeeId);

            if (projectEmployee == null)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.PROJECT_EMPLOYEE_NOT_FOUND_FOR_DELETION, "Project Employee not found for deletion");

            dbContext.Set<ProjectEmployee>().Remove(projectEmployee);
            await dbContext.SaveChangesAsync();
        }

        // Restore a soft-deleted project employee assignment
        public async Task RestoreProjectEmployeeAsync(Guid projectEmployeeId)
        {
            if (projectEmployeeId == Guid.Empty)
                throw new ArgumentException("Project Employee ID cannot be empty", nameof(projectEmployeeId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var projectEmployee = await dbContext.Set<ProjectEmployee>().IgnoreQueryFilters()
                .FirstOrDefaultAsync(pe => pe.Id == projectEmployeeId);

            if (projectEmployee == null || !projectEmployee.IsDeleted)
                throw new BusinessException(SkillMatrixManagementDomainErrorCodes.ProjectEmployee.PROJECT_EMPLOYEE_NOT_FOUND_OR_NOT_DELETED, "Project Employee not found or not deleted");

            projectEmployee.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        // Get all employees assigned to a specific project
        public async Task<List<AssingedUserProjectDTO>> GetByProjectIdAsync(Guid projectId)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentException("Project ID cannot be empty", nameof(projectId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();

            // Fetch the project employee list
            var projectEmployeeList = await dbContext.Set<ProjectEmployee>()
                .Where(pe => pe.ProjectId == projectId && !pe.IsDeleted)
                .ToListAsync();

            var result = new List<AssingedUserProjectDTO>();

            foreach (var pr in projectEmployeeList)
            {
                // Fetch user details for each project employee
                var user = await dbContext.Set<User>()
                    .Include(u => u.Role) // Optionally include Role, Department, and Skill if needed
                    .Include(u => u.Department)
                    .Include(u => u.Skill)
                    .FirstOrDefaultAsync(u => u.Id == pr.UserId);

                if (user == null) continue;

                // Create User DTO
                var userDto = new CustomUserResponseDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Experience = user.Experience,
                    PhoneNumber = user.PhoneNumber,
                    RoleId = user.RoleId,
                    DepartmentId = user.DepartmentId,
                    DepartmentName = user.Department?.Name,  // Include Department Name
                    SkillId = user.SkillId,
                    SkillName = user.Skill?.Name,  // Include Skill Name
                    IsAvailable = user.IsAvailable,
                    ProfilePhoto = user.ProfilePhoto,
                    AssignibilityPerncentage = user.AssignibilityPercentage,
                    BillablePerncentage = user.BillablePercentage,
                    AvailabilityPerncentage = user.AvailabilityPercentage
                };

                // Create the assignment DTO
                var dto = new AssingedUserProjectDTO
                {
                    UserResponseData = userDto,  // Assign the user data
                    AssignabilityPercentage = pr.AssignibilityPercentage,
                    BillablePercentage = pr.BillablePercentage,
                    StartDate = pr.ProjectStartDate,
                    EndDate = pr.ProjectEndDate
                };

                // Add to the result list
                result.Add(dto);
            }

            return result;
        }


        // Get all projects assigned to a specific user
        public async Task<List<ProjectEmployee>> GetByUserIdAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<ProjectEmployee>()
                .Where(pe => pe.UserId == userId && !pe.IsDeleted)
                .ToListAsync();
        }


        public async Task<List<ProjectEmployee>> GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted = false)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await (includeDeleted ? dbContext.Set<ProjectEmployee>().IgnoreQueryFilters() : dbContext.Set<ProjectEmployee>())
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        Task<ProjectEmployee> IProjectEmployeeRepository.GetPagedListAsync(int skipCount, int maxResultCount, bool includeDeleted)
        {
            throw new NotImplementedException();
        }


        public async Task<Boolean> IsExistTheUserIdProjectIdAsync(Guid userId, Guid projectId)
        {
            if (userId == Guid.Empty || projectId==Guid.Empty)
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return  await dbContext.Set<ProjectEmployee>()
            .AnyAsync(pe => pe.ProjectId == projectId && pe.UserId == userId && !pe.IsDeleted);

        }
    }
}
