using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SkillMatrixManagement.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
    * (like Add-Migration and Update-Database commands) */
    public class SkillMatrixManagementApplicationDbContextFactory
        : IDesignTimeDbContextFactory<SkillMatrixManagementApplicationDbContext>
    {
        public SkillMatrixManagementApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<SkillMatrixManagementApplicationDbContext>()
                .UseNpgsql(configuration.GetConnectionString("ApplicationDb"));
            return new SkillMatrixManagementApplicationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SkillMatrixManagement.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
