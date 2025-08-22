// <copyright file="SearchQueryService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities.Jobs;
using Listopotamus.Core.Entities.Search;
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
        /// Creates a search query.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The search query.</returns>
        public async Task CreateAsync(SearchCriteriaModel searchCriteria)
        {
            var existingSearchQueries = await this.SearchQueryRepository.GetAsync(
                x => x.CategoryTypeId == searchCriteria.Query.CategoryTypeId &&
                x.MarketplaceTypeId == searchCriteria.Query.MarketplaceTypeId &&
                x.PageNumber == searchCriteria.Query.PageNumber &&
                x.MaxPageNumber == searchCriteria.Query.MaxPageNumber &&
                x.ShowSoldOnly == searchCriteria.Query.SoldItemsOnly &&
                x.SearchTerm.ToLower() == searchCriteria.Query.SearchTerm.ToLower());

            SearchQuery searchQuery = new ();
            if (existingSearchQueries.FirstOrDefault() is not null)
            {
                searchQuery = existingSearchQueries.FirstOrDefault();
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
                    SearchDate = DateTime.Now,
                };
                await this.UserSearchRepository.InsertAsync(userSearch);
            }

            ScrapeJob scrapeJob = new ();
            if (searchQuery is null)
            {
                scrapeJob = new ScrapeJob()
                {
                    SearchQueryId = searchQuery.Id,
                    Status = (int)JobStatusEnum.Queued,
                    ExternalId = Guid.NewGuid(),
                };
                scrapeJob = await this.ScrapeJobRepository.InsertAsync(scrapeJob);
            }
            else
            {
                var existingJobs = await this.ScrapeJobRepository.GetAsync(x => x.SearchQueryId == searchQuery.Id);
                scrapeJob = existingJobs.FirstOrDefault();
            }

            if (!scrapeJob.Id.HasValue)
            {
                return;
            }

            await this.TaskQueueService.QueueAsync(scrapeJob.Id.Value);
        }
    }
}
