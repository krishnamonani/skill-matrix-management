using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.EntityFrameworkCore;
using SkillMatrixManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SkillMatrixManagement.Repositories
{
    public class ReportAnalyticsRepository : EfCoreRepository<SkillMatrixManagementApplicationDbContext, ReportAnalytics, Guid>, IReportAnalyticsRepository
    {
        readonly IDbContextProvider<SkillMatrixManagementApplicationDbContext> _dbContextProvider;

        public ReportAnalyticsRepository(IDbContextProvider<SkillMatrixManagementApplicationDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<ReportAnalytics> CreateAsync(ReportAnalytics reportAnalytics)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            await dbContext.ReportAnalyticss.AddAsync(reportAnalytics);
            await dbContext.SaveChangesAsync();
            return reportAnalytics;
        }

        public Task DeleteAsync(Guid reportAnalyticsId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReportAnalytics>> GetAllAsync()
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.ReportAnalyticss.ToListAsync();
        }

        public async Task<ReportAnalytics> GetByIdAsync(Guid id)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.ReportAnalyticss.FindAsync(id) ?? throw new Exception("ID not Found!!");
        }

        public async Task<List<ReportAnalytics>> GetReportsByGeneratedByAsync(Guid userId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.ReportAnalyticss.Where(r=>r.GeneratedBy==userId ).ToListAsync() ?? throw new  Exception($"Not any Report available which is created by the user {userId}!");
        }

        public async Task<List<ReportAnalytics>> GetReportsByTypeAsync(ReportTypeEnum reportType)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            return await dbContext.ReportAnalyticss.Where(r => r.ReportType == reportType && !r.IsDeleted).ToListAsync();

        }

        public async Task PermanentDeleteAsync(Guid reportAnalyticsId)
        {

            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var report = await dbContext.ReportAnalyticss.IgnoreQueryFilters().FirstOrDefaultAsync(r => r.Id == reportAnalyticsId);
            if (report != null)
            {
                dbContext.ReportAnalyticss.Remove(report);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RestoreReportAnalyticsAsync(Guid reportAnalyticsId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var report = await dbContext.ReportAnalyticss.IgnoreQueryFilters().FirstOrDefaultAsync(r => r.Id == reportAnalyticsId);
            if (report != null && report.IsDeleted)
            {
                report.IsDeleted = false;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task SoftDeleteAsync(Guid reportAnalyticsId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var report = await dbContext.ReportAnalyticss.FindAsync(reportAnalyticsId);
            if (report != null)
            {
                report.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(ReportAnalytics reportAnalytics)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var ExistingReport = dbContext.ReportAnalyticss.FirstOrDefaultAsync(r=>r.Id == reportAnalytics.Id);
            if (ExistingReport != null) { 
                dbContext.Entry(ExistingReport).CurrentValues.SetValues(reportAnalytics);
                await dbContext.SaveChangesAsync();
            }
            throw new NotImplementedException();


        }
    }
}
