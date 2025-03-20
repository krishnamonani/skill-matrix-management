using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SkillMatrixManagement.CustomDataSeeding
{
    class ProjectSeedingService : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Project, Guid> _projectRepository;

        public ProjectSeedingService(IRepository<Project, Guid> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _projectRepository.GetCountAsync() > 0) return;

            var project1 = new Project()
            {
                ProjectName = "Project 1",
                Description = "Project 1 description",
                StartDate = DateTime.Now.AddMonths(-3),
                ExpectedEndDate = DateTime.Now.AddDays(-15),
                IsDelayed = false,
                IsOngoing = true

            };
            var project2 = new Project()
            {
                ProjectName = "Project 2",
                Description = "Project 2 description",
                StartDate = DateTime.Now.AddMonths(-3),
                ExpectedEndDate = DateTime.Now.AddDays(-10),
                IsDelayed = false,
                IsOngoing = false
            };
            var project3 = new Project()
            {
                ProjectName = "Project 3",
                Description = "Project 3 description",
                StartDate = DateTime.Now.AddMonths(-2),
                ExpectedEndDate = DateTime.Now.AddDays(-5),
                IsDelayed = false,
                IsOngoing = false
            };
            var project4 = new Project()
            {
                ProjectName = "Project 4",
                Description = "Project 4 description",
                StartDate = DateTime.Now.AddMonths(-2),
                ExpectedEndDate = DateTime.Now.AddDays(-5),
                IsDelayed = false,
                IsOngoing = false
            };
            var project5 = new Project()
            {
                ProjectName = "Project 5",
                Description = "Project 5 description",
                StartDate = DateTime.Now.AddMonths(-1),
                ExpectedEndDate = DateTime.Now.AddMonths(1),
                IsDelayed = false,
                IsOngoing = true
            };
            var project6 = new Project()
            {
                ProjectName = "Project 6",
                Description = "Project 6 description",
                StartDate = DateTime.Now.AddDays(-5),
                ExpectedEndDate = DateTime.Now.AddMonths(2),
                IsDelayed = false,
                IsOngoing = true
            };
            var project7 = new Project()
            {
                ProjectName = "Project 7",
                Description = "Project 7 description",
                StartDate = DateTime.Now.AddDays(-5),
                ExpectedEndDate = DateTime.Now.AddMonths(2),
                IsDelayed = true,
                IsOngoing = true
            };
            var project8 = new Project()
            {
                ProjectName = "Project 8",
                Description = "Project 8 description",
                StartDate = DateTime.Now.AddDays(-2),
                ExpectedEndDate = DateTime.Now.AddMonths(3),
                IsDelayed = false,
                IsOngoing = true
            };
            var project9 = new Project()
            {
                ProjectName = "Project 9",
                Description = "Project 9 description",
                StartDate = DateTime.Now,
                ExpectedEndDate = DateTime.Now.AddMonths(3),
                IsDelayed = true,
                IsOngoing = true
            };
            var project10 = new Project()
            {
                ProjectName = "Project 10",
                Description = "Project 10 description",
                StartDate = DateTime.Now,
                ExpectedEndDate = DateTime.Now.AddMonths(3),
                IsDelayed = false,
                IsOngoing = true
            };

            await _projectRepository.InsertManyAsync(new List<Project>() {
                project1,
                project2,
                project3,
                project4,
                project5,
                project6,
                project7,
                project8,
                project9,
                project10
         });
        }
    }
}
