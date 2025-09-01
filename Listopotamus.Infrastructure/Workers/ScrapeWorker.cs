// <copyright file="ScrapeWorker.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Transactions;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Entities.Search;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Listopotamus.Infrastructure.Workers
{
    /// <summary>
    /// Represents a scrape worker.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ScrapeWorker"/> class.
    /// </remarks>
    /// <param name="logger">The logger.</param>
    /// <param name="queue">The queue.</param>
    /// <param name="scopeFactory">The scope factory.</param>
    /// <param name="scrapeJobRepository">The scrape job repository.</param>
    public sealed class ScrapeWorker(
        ILogger<ScrapeWorker> logger,
        ITaskQueueService queue,
        IServiceScopeFactory scopeFactory,
        IScrapeJobRepository scrapeJobRepository
            ) : BackgroundService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<ScrapeWorker> Logger = logger;

        /// <summary>
        /// The task queue service.
        /// </summary>
        private readonly ITaskQueueService Queue = queue;

        /// <summary>
        /// The scope factory.
        /// </summary>
        private readonly IServiceScopeFactory ScopeFactory = scopeFactory;

        /// <summary>
        /// Gets the scrape job repository.
        /// </summary>
        private IScrapeJobRepository ScrapeJobRepository { get; } = scrapeJobRepository;

        /// <summary>
        /// Executes the scrape worker.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the exection of the worker.</returns>
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            this.Logger.LogInformation("ScrapeWorker started");
            while (!cancellationToken.IsCancellationRequested)
            {
                long jobId = await this.Queue.DequeueAsync(cancellationToken);
                _ = this.ProcessJobAsync(jobId, cancellationToken); // do not block loop
            }
        }

        /// <summary>
        /// Processes a job.
        /// </summary>
        /// <param name="jobId">The job id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the processing of a job.</returns>
        private async Task ProcessJobAsync(long jobId, CancellationToken cancellationToken)
        {
            using var scopeFactory = this.ScopeFactory.CreateScope();

            var dbContext = scopeFactory.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var scraper = scopeFactory.ServiceProvider.GetRequiredService<IBaseScraperService>();
            var logger = scopeFactory.ServiceProvider.GetRequiredService<ILogger<ScrapeWorker>>();

            var job = await this.ScrapeJobRepository.GetByIDAsync(jobId);
            if (job is null)
            {
                return;
            }

            var options = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
            };
            using var scope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                job.Status = (int)JobStatusEnum.Running;
                job.CreatedDate = DateTime.UtcNow;
                await this.ScrapeJobRepository.UpdateAsync(job);

                var searchQuery = await dbContext.Set<SearchQuery>()
                    .AsNoTracking()
                    .FirstAsync(x => x.Id == job.SearchQueryId, cancellationToken);

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
                    },
                };

                var result = await scraper.GetItemsAsync(criteria);

                job.Status = result.IsSuccess ? (int)JobStatusEnum.Succeeded : (int)JobStatusEnum.Failed;
                job.ErrorMessage = result.IsSuccess ? null : result.ErrorMessage;
                job.Progress = 100;
                await this.ScrapeJobRepository.UpdateAsync(job);

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Scrape job {JobId} failed", jobId);
                job.Status = (int)JobStatusEnum.Failed;
                job.ErrorMessage = ex.Message;
                await this.ScrapeJobRepository.UpdateAsync(job);
            }

            scope.Complete();
        }
    }
}
