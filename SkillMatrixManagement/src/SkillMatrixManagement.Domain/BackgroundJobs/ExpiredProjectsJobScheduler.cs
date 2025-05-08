using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace SkillMatrixManagement.BackgroundJobs
{
    public class ExpiredProjectsJobScheduler : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly ILogger<ExpiredProjectsJobScheduler> _logger;

        public ExpiredProjectsJobScheduler(
            AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            IBackgroundJobManager backgroundJobManager,
            ILogger<ExpiredProjectsJobScheduler> logger)
            : base(timer, serviceScopeFactory)
        {
            _backgroundJobManager = backgroundJobManager;
            _logger = logger;
            Timer.Period = 86400000; // 24 hours in milliseconds
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            _logger.LogInformation("Queuing ExpiredProjectsJob");
            await _backgroundJobManager.EnqueueAsync(new ExpiredProjectsJobArgs());
        }
    }
}
