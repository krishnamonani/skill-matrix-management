using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SkillMatrixManagement.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace SkillMatrixManagement.BackgroundJobs
{
    public class ExpiredProjectsJob : AsyncBackgroundJob<ExpiredProjectsJobArgs>, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ExpiredProjectsJob> _logger;

        public ExpiredProjectsJob(
            IServiceProvider serviceProvider,
            ILogger<ExpiredProjectsJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public override async Task ExecuteAsync(ExpiredProjectsJobArgs args)
        {
            try
            {
                _logger.LogInformation("Started checking for expired projects");

                using var scope = _serviceProvider.CreateScope();
                var projectStatusService = scope.ServiceProvider.GetRequiredService<ProjectStatusService>();

                await projectStatusService.CheckExpiredProjectsAsync();

                _logger.LogInformation("Finished checking for expired projects");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing expired projects job");
                throw;
            }
        }
    }

    public class ExpiredProjectsJobArgs
    {
        // Can be empty as we don't need any parameters
    }
}
