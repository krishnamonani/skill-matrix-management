using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class ProjectRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, Project, Guid>, IProjectRepository
    {
        private readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public ProjectRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        // Create a new project
        public async Task<Project> CreateAsync(Project project)
        {
            Check.NotNull(project, nameof(project));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var exists = await dbContext.Set<Project>().AnyAsync(p => p.ProjectName == project.ProjectName && !p.IsDeleted);

            if (exists)
                throw new BusinessException("PRJ-001", "Project with the same name already exists");

            var result = await dbContext.Set<Project>().AddAsync(project);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // Get project by ID
        public async Task<Project> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Project ID cannot be empty", nameof(id));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var project = await dbContext.Set<Project>().FindAsync(id)
                ?? throw new BusinessException("PRJ-002", "Project not found");

            return project;
        }

        // Get all projects
        public async Task<List<Project>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Project>().Where(p => !p.IsDeleted).ToListAsync();
        }

        // Update project
        public async Task UpdateAsync(Project project)
        {
            Check.NotNull(project, nameof(project));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var existing = await dbContext.Set<Project>().FirstOrDefaultAsync(p => p.Id == project.Id && !p.IsDeleted)
                ?? throw new BusinessException("PRJ-003", "Project not found for update");

            dbContext.Set<Project>().Update(project);
            await dbContext.SaveChangesAsync();
        }

        // Soft Delete project
        public async Task DeleteAsync(Guid projectId)
        {
            await SoftDeleteAsync(projectId);
        }

        // Soft Delete project
        public async Task SoftDeleteAsync(Guid projectId)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentException("Project ID cannot be empty", nameof(projectId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var project = await dbContext.Set<Project>().FindAsync(projectId)
                ?? throw new BusinessException("PRJ-004", "Project not found");

            if (project.IsDeleted)
                throw new BusinessException("PRJ-005", "Project is already deleted");

            project.IsDeleted = true;
            await dbContext.SaveChangesAsync();
        }

        // Permanent Delete project
        public async Task PermanentDeleteAsync(Guid projectId)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentException("Project ID cannot be empty", nameof(projectId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var project = await dbContext.Set<Project>().IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
                throw new BusinessException("PRJ-006", "Project not found for deletion");

            dbContext.Set<Project>().Remove(project);
            await dbContext.SaveChangesAsync();
        }

        // Restore a soft-deleted project
        public async Task RestoreProjectAsync(Guid projectId)
        {
            if (projectId == Guid.Empty)
                throw new ArgumentException("Project ID cannot be empty", nameof(projectId));

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var project = await dbContext.Set<Project>().IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null || !project.IsDeleted)
                throw new BusinessException("PRJ-007", "Project not found or not deleted");

            project.IsDeleted = false;
            await dbContext.SaveChangesAsync();
        }

        // Get all delayed projects (projects where EndDate has passed)
        public async Task<List<Project>> GetDelayedProjectsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Project>()
                .Where(p => !p.IsDeleted && p.ExpectedEndDate < DateTime.UtcNow)
                .ToListAsync();
        }

        // Get all ongoing projects (projects where EndDate is in the future)
        public async Task<List<Project>> GetOngoingProjectsAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.Set<Project>()
                .Where(p => !p.IsDeleted && p.ExpectedEndDate >= DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
