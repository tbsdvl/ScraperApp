// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Transactions;
using AutoMapper;
using HtmlAgilityPack;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities.Search;
using Listopotamus.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Provides services related to retrieving and processing HTML data.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ScraperService"/> class.
    /// </remarks>
    /// <param name="serviceScopeFactory">The service scope factory.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="httpContext">The http context.</param>
    /// <param name="searchQueryRepository">The search query repository.</param>
    /// <param name="searchResultItemRepository">The search result item repository.</param>
    public class ScraperService(
        IServiceScopeFactory serviceScopeFactory,
        IMapper mapper,
        ISearchQueryRepository searchQueryRepository,
        ISearchResultItemRepository searchResultItemRepository) : IBaseScraperService
    {
        /// <summary>
        /// Gets the service scope factory.
        /// </summary>
        private IServiceScopeFactory ServiceScopeFactory { get; } = serviceScopeFactory;

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        private IMapper Mapper { get; } = mapper;

        /// <summary>
        /// Gets the search query repository.
        /// </summary>
        private ISearchQueryRepository SearchQueryRepository { get; } = searchQueryRepository;

        /// <summary>
        /// Gets the search result item repository.
        /// </summary>
        private ISearchResultItemRepository SearchResultItemRepository { get; } = searchResultItemRepository;

        /// <summary>
        /// Gets or sets the maximum page number to scrape.
        /// </summary>
        private int MaxPageNumber { get; set; } = 200;

        /// <summary>
        /// Gets a page's HTML.
        /// </summary>
        /// <param name="searchCriteria">The scraper request.</param>
        /// <param name="service">The scraper service.</param>
        /// <returns>The page's HTML.</returns>
        private static async Task<HtmlDocument> GetPageHtmlAsync(SearchCriteriaModel searchCriteria, IScraperService service)
        {
            searchCriteria.Url = service.GetUrl(searchCriteria);

            var webUtility = new HtmlWeb();
            var doc = await webUtility.LoadFromWebAsync(searchCriteria.Url);
            return doc;
        }

        /// <summary>
        /// Gets the scraper service based on the service type id.
        /// </summary>
        /// <param name="serviceScope">The service scope.</param>
        /// <param name="serviceTypeId">The service type id.</param>
        /// <returns>The scraper service.</returns>
        private static IScraperService? GetService(IServiceScope serviceScope, int serviceTypeId)
        {
            return serviceTypeId switch
            {
                (int)MarketplaceTypeEnum.Ebay => serviceScope.ServiceProvider.GetRequiredService<IEbayScraperService>(),
                _ => null,
            };
        }

        /// <summary>
        /// Gets a list of item nodes from a page.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="service">The scraper service.</param>
        /// <returns>A list of nodes.</returns>
        private async Task<List<HtmlNode>> GetItemNodesAsync(SearchCriteriaModel searchCriteria, IScraperService service)
        {
            var itemNodes = new List<HtmlNode>();
            var previousItemId = string.Empty;

            if (searchCriteria.Query.MaxPageNumber.HasValue)
            {
                this.MaxPageNumber = searchCriteria.Query.MaxPageNumber.Value;
            }

            for (int i = 1; i <= this.MaxPageNumber; i++)
            {
                searchCriteria.Query.PageNumber = i;
                var page = await GetPageHtmlAsync(searchCriteria, service);
                var nodes = page.DocumentNode.SelectNodes(service.ItemsListNodePath);

                if (nodes is null || nodes.Count == 0)
                {
                    return itemNodes;
                }

                var firstNode = nodes.FirstOrDefault();

                if (string.IsNullOrWhiteSpace(firstNode?.Id))
                {
                    break;
                }

                if (!string.IsNullOrWhiteSpace(previousItemId) && previousItemId.Equals(firstNode.Id, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                previousItemId = firstNode.Id;

                itemNodes.AddRange(nodes);
            }

            return itemNodes;
        }

        /// <summary>
        /// Gets a search query.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <param name="items">The list of items.</param>
        /// <returns>The search query.</returns>
        private async Task<SearchQuery> GetSearchQueryAsync(SearchCriteriaModel searchCriteria, List<ItemDto> items)
        {
            var existingSearchQueryResults = await this.SearchQueryRepository.GetAsync(
                x => x.CategoryTypeId == searchCriteria.Query.CategoryTypeId &&
                x.MarketplaceTypeId == searchCriteria.Query.MarketplaceTypeId &&
                x.PageNumber == searchCriteria.Query.PageNumber &&
                x.MaxPageNumber == searchCriteria.Query.MaxPageNumber &&
                x.ShowSoldOnly == searchCriteria.Query.SoldItemsOnly &&
                x.SearchTerm.ToLower() == searchCriteria.Query.SearchTerm.ToLower());

            SearchQuery searchQuery = new ();
            if (existingSearchQueryResults.FirstOrDefault() is not null)
            {
                searchQuery = existingSearchQueryResults.First();
                var existingSearchResultItems = await this.SearchResultItemRepository.GetAsync(
                    x => x.SearchQueryId == searchQuery.Id,
                    include: q => q.Include(x => x.Item));

                if (existingSearchResultItems is not null && existingSearchResultItems.Count > 0)
                {
                    var existingItems = existingSearchResultItems.Select(x => x.Item).ToList();
                    items.AddRange(this.Mapper.Map<List<ItemDto>>(existingItems));
                }
            }

            return searchQuery;
        }

        /// <summary>
        /// Gets a list of items from a page.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The scraper response including a list of items.</returns>
        public async Task<ScraperResult> GetItemsAsync(SearchCriteriaModel searchCriteria)
        {
            var items = new List<ItemDto>();
            if (!searchCriteria.Query.MarketplaceTypeId.HasValue)
            {
                return new ScraperResult()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.MissingQueryOption,
                };
            }

            using var serviceScope = this.ServiceScopeFactory.CreateScope();
            var service = GetService(serviceScope, searchCriteria.Query.MarketplaceTypeId.Value);
            if (service is null)
            {
                return new ScraperResult()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.InvalidQueryOptionType,
                };
            }

            var options = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
            };

            using var scope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);

            var searchQuery = await this.GetSearchQueryAsync(searchCriteria, items);

            var nodes = await this.GetItemNodesAsync(searchCriteria, service);
            if (nodes is null || nodes.Count == 0)
            {
                return new ScraperResult()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.NoItemsFound,
                };
            }

            items = await service.GetItemsAsync(searchQuery.Id, searchCriteria, nodes, items);

            scope.Complete();

            if (items.Count == 0)
            {
                return new ScraperResult()
                {
                    Items = items,
                    TotalResults = items.Count,
                    ErrorMessage = ErrorMessages.NoItemsFound,
                };
            }

            return new ScraperResult()
            {
                Items = items,
                TotalResults = items.Count,
                Succeeded = true,
            };
        }
    }
}
