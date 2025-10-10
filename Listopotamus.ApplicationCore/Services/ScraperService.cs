// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Entities.Search;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core;
using Listopotamus.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Transactions;

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
    /// <param name="searchQueryService">The search query service.</param>
    /// <param name="searchResultItemRepository">The search result item repository.</param>
    public class ScraperService(
        IServiceScopeFactory serviceScopeFactory,
        IMapper mapper,
        ISearchQueryService searchQueryService,
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
        /// Gets the search query service.
        /// </summary>
        private ISearchQueryService SearchQueryService { get; } = searchQueryService;

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

            var webUtility = new HtmlWeb
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36",
                UseCookies = true,
                Timeout = 30000, // 30 seconds
            };

            webUtility.PreRequest += request =>
            {
                request.AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Referer = "https://www.ebay.com/";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Headers[HttpRequestHeader.AcceptLanguage] = "en-US,en;q=0.9";
                request.Headers[HttpRequestHeader.CacheControl] = "no-cache";
                request.Headers[HttpRequestHeader.Pragma] = "no-cache";
                request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";
                return true;
            };

            var doc = await webUtility.LoadFromWebAsync(searchCriteria.Url);

            if (doc.DocumentNode.InnerText.Contains("Pardon Our Interruption", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("eBay blocked the scraping request. The response indicates bot protection was triggered.");
            }

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
            var getExistingSearchQueryResult = await this.SearchQueryService.GetExistingAsync(searchCriteria);
            var existingSearchQuery = getExistingSearchQueryResult.FirstOrDefault();

            var searchQuery = new SearchQuery();
            if (existingSearchQuery is not null)
            {
                searchQuery = getExistingSearchQueryResult.First();
                var existingSearchResultItems = await this.SearchResultItemRepository.GetAsync(
                    x => x.SearchQueryId == searchQuery.Id,
                    include: q => q.Include(x => x.Item));

                if (existingSearchResultItems is not null && existingSearchResultItems.Count > 0)
                {
                    var existingItems = existingSearchResultItems.Select(x => x.Item).ToList();
                    var itemDtos = this.Mapper.Map<List<ItemDto>>(existingItems);
                    items.AddRange(itemDtos);
                }
            }

            return searchQuery;
        }

        /// <summary>
        /// Gets a list of items from a page.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The scraper response including a list of items.</returns>
        public async Task<Result<List<ItemDto>>> GetItemsAsync(SearchCriteriaModel searchCriteria)
        {
            var items = new List<ItemDto>();
            if (!searchCriteria.Query.MarketplaceTypeId.HasValue)
            {
                return Result<List<ItemDto>>.Failure(ErrorMessages.MissingQueryOption);
            }

            using var serviceScope = this.ServiceScopeFactory.CreateScope();
            var service = GetService(serviceScope, searchCriteria.Query.MarketplaceTypeId.Value);
            if (service is null)
            {
                return Result<List<ItemDto>>.Failure(ErrorMessages.InvalidQueryOptionType);
            }

            var options = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
            };

            using var scope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);

            var searchQuery = await this.GetSearchQueryAsync(searchCriteria, items);
            if (!searchQuery.Id.HasValue)
            {
                return Result<List<ItemDto>>.Failure(ErrorMessages.InvalidQueryOptionType);
            }

            var nodes = await this.GetItemNodesAsync(searchCriteria, service);
            if (nodes is null || nodes.Count == 0)
            {
                return Result<List<ItemDto>>.Failure(ErrorMessages.NoItemsFound);
            }

            items = await service.GetItemsAsync(searchQuery.Id.Value, searchCriteria, nodes, items);

            scope.Complete();

            if (items.Count == 0)
            {
                return Result<List<ItemDto>>.Failure(ErrorMessages.NoItemsFound);
            }

            return Result<List<ItemDto>>.Success(items);
        }
    }
}
