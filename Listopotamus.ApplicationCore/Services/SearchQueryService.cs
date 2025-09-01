// <copyright file="SearchQueryService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Entities.Jobs;
using Listopotamus.ApplicationCore.Entities.Search;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Shared.Extensions;
using Microsoft.AspNetCore.Http;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the search query service.
    /// </summary>
    public class SearchQueryService(
        IHttpContextAccessor httpContext,
        ISearchQueryRepository searchQueryRepository,
        IUserSearchRepository userSearchRepository,
        IScrapeJobRepository scrapeJobRepository,
        ITaskQueueService taskQueueService) : ISearchQueryService
    {
        /// <summary>
        /// Gets or sets the maximum page number to scrape.
        /// </summary>
        private int MaxPageNumber { get; set; } = 200;

        /// <summary>
        /// Gets the HTTP context accessor.
        /// </summary>
        private IHttpContextAccessor Accessor { get; } = httpContext;

        /// <summary>
        /// Gets the search query repository.
        /// </summary>
        private ISearchQueryRepository SearchQueryRepository { get; } = searchQueryRepository;

        /// <summary>
        /// Gets the user search repository.
        /// </summary>
        private IUserSearchRepository UserSearchRepository { get; } = userSearchRepository;

        /// <summary>
        /// Gets the scrape job repository.
        /// </summary>
        private IScrapeJobRepository ScrapeJobRepository { get; } = scrapeJobRepository;

        /// <summary>
        /// Gets the task queue service.
        /// </summary>
        private ITaskQueueService TaskQueueService { get; } = taskQueueService;

        /// <summary>
        /// Gets an existing search query.
        /// </summary>
        /// <param name="searchCriteria">The search query criteria.</param>
        /// <returns>The existing search query.</returns>
        public async Task<List<SearchQuery>> GetExistingAsync(SearchCriteriaModel searchCriteria)
        {
            return await this.SearchQueryRepository.GetAsync(
                x => x.CategoryTypeId == searchCriteria.Query.CategoryTypeId &&
                x.MarketplaceTypeId == searchCriteria.Query.MarketplaceTypeId &&
                x.PageNumber == searchCriteria.Query.PageNumber &&
                x.MaxPageNumber == searchCriteria.Query.MaxPageNumber &&
                x.ShowSoldOnly == searchCriteria.Query.SoldItemsOnly &&
                x.SearchTerm.Equals(searchCriteria.Query.SearchTerm, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Creates a search query.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The search query.</returns>
        public async Task CreateAsync(SearchCriteriaModel searchCriteria)
        {
            var existingSearchQueries = await this.GetExistingAsync(searchCriteria);
            var existingSearchQuery = existingSearchQueries.FirstOrDefault();

            var searchQuery = new SearchQuery();
            if (existingSearchQuery is not null)
            {
                searchQuery = existingSearchQuery;
            }
            else
            {
                searchQuery = new SearchQuery
                {
                    MarketplaceTypeId = searchCriteria.Query.MarketplaceTypeId!.Value,
                    CategoryTypeId = searchCriteria.Query.CategoryTypeId!.Value,
                    SearchTerm = searchCriteria.Query.SearchTerm?.Trim() ?? string.Empty,
                    PageNumber = searchCriteria.Query.PageNumber ?? 1,
                    ZipCode = string.IsNullOrWhiteSpace(searchCriteria.Query.ZipCode) ? string.Empty : searchCriteria.Query.ZipCode,
                    Distance = searchCriteria.Query.Distance,
                    IsMiles = searchCriteria.Query.IsMiles,
                    ShowSoldOnly = searchCriteria.Query.SoldItemsOnly,
                    MaxPageNumber = searchCriteria.Query.MaxPageNumber ?? this.MaxPageNumber,
                    ExternalId = Guid.NewGuid(),
                };
                searchQuery = await this.SearchQueryRepository.InsertAsync(searchQuery);

                var userSearch = new UserSearch
                {
                    SearchQueryId = searchQuery.Id,
                    UserId = this.Accessor.HttpContext.User.GetUserId(),
                    ExternalId = Guid.NewGuid(),
                    SearchDate = DateTime.UtcNow,
                };
                await this.UserSearchRepository.InsertAsync(userSearch);
            }

            var existingJobs = await this.ScrapeJobRepository.GetAsync(x => x.SearchQueryId == searchQuery.Id);
            var existingScrapeJob = existingJobs.FirstOrDefault();

            var scrapeJob = new ScrapeJob();
            if (existingScrapeJob is not null)
            {
                scrapeJob = existingScrapeJob;
            }
            else
            {
                scrapeJob = new ScrapeJob()
                {
                    SearchQueryId = searchQuery.Id,
                    Status = (int)JobStatusEnum.Queued,
                    ExternalId = Guid.NewGuid(),
                };
                scrapeJob = await this.ScrapeJobRepository.InsertAsync(scrapeJob);
            }

            if (!scrapeJob.Id.HasValue)
            {
                return; // return an error
            }

            await this.TaskQueueService.QueueAsync(scrapeJob.Id.Value);
        }
    }
}
