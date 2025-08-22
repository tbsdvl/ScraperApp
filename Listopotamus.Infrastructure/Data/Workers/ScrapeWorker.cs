// <copyright file="ScrapeWorker.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.ApplicationCore.Services;
using Listopotamus.Core.Entities.Jobs;
using Listopotamus.Core.Entities.Search;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Listopotamus.Infrastructure.Data.Workers
{
    /// <summary>
    /// Represents a scrape worker.
    /// </summary>
    public sealed class ScrapeWorker : BackgroundService
    {
        private readonly ILogger<ScrapeWorker> _logger;
        private readonly ITaskQueueService _queue;
        private readonly IServiceScopeFactory _scopeFactory;

        public ScrapeWorker(ILogger<ScrapeWorker> logger,
                            ITaskQueueService queue,
                            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _queue = queue;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ScrapeWorker started");
            while (!stoppingToken.IsCancellationRequested)
            {
                long jobId = await _queue.DequeueAsync(stoppingToken);
                _ = ProcessJobAsync(jobId, stoppingToken); // do not block loop
            }
        }

        private async Task ProcessJobAsync(long jobId, CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var scraper = scope.ServiceProvider.GetRequiredService<IBaseScraperService>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ScrapeWorker>>();

            var job = await db.Set<ScrapeJob>().FindAsync(jobId);
            if (job is null) return;

            try
            {
                job.Status = (int)JobStatusEnum.Running;
                job.CreatedDate = DateTime.UtcNow;
                await db.SaveChangesAsync(ct);

                var searchQuery = await db.Set<SearchQuery>()
                    .AsNoTracking()
                    .FirstAsync(x => x.Id == job.SearchQueryId, ct);

                var criteria = new SearchCriteriaModel
                {
                    Query = new SearchQueryModel
                    {
                        MarketplaceTypeId = searchQuery.MarketplaceTypeId,
                        CategoryTypeId = searchQuery.CategoryTypeId,
                        SearchTerm = searchQuery.SearchTerm,
                        PageNumber = searchQuery.PageNumber,
                        MaxPageNumber = searchQuery.MaxPageNumber,
                        SoldItemsOnly = searchQuery.ShowSoldOnly,
                        ZipCode = searchQuery.ZipCode,
                        Distance = searchQuery.Distance,
                        IsMiles = searchQuery.IsMiles,
                        LocationTypeId = (int)LocationTypeEnum.US,
                    },
                };

                var result = await scraper.GetItemsAsync(criteria);

                job.Status = result.Succeeded ? (int)JobStatusEnum.Succeeded : (int)JobStatusEnum.Failed;
                job.ErrorMessage = result.Succeeded ? null : result.ErrorMessage;
                job.Progress = 100;

                await db.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Scrape job {JobId} failed", jobId);
                job.Status = (int)JobStatusEnum.Failed;
                job.ErrorMessage = ex.Message;
                await db.SaveChangesAsync(ct);
            }
        }
    }

}
