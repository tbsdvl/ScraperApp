// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities.Items;
using Listopotamus.Resource;
using Microsoft.Extensions.DependencyInjection;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Provides services related to retrieving and processing HTML data.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ScraperService"/> class.
    /// </remarks>
    /// <param name="mapper">The mapper.</param>
    /// <param name="serviceScopeFactory">The service scope factory.</param>
    public class ScraperService(IMapper mapper, IServiceScopeFactory serviceScopeFactory) : IBaseScraperService
    {
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        private IMapper Mapper { get; } = mapper;

        /// <summary>
        /// Gets the service scope factory.
        /// </summary>
        private IServiceScopeFactory ServiceScopeFactory { get; } = serviceScopeFactory;

        /// <summary>
        /// Gets or sets the maximum page number to scrape.
        /// </summary>
        private int MaxPageNumber { get; set; } = 200;

        /// <summary>
        /// Gets a page's HTML.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <param name="service">The scraper service.</param>
        /// <returns>The page's HTML.</returns>
        private static async Task<HtmlDocument> GetPageHtmlAsync(SearchCriteriaModel request, IScraperService service)
        {
            request.Url = service.GetUrl(request);

            var webUtility = new HtmlWeb();
            var doc = await webUtility.LoadFromWebAsync(request.Url);
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

            var nodes = await this.GetItemNodesAsync(searchCriteria, service);
            if (nodes is null || nodes.Count == 0)
            {
                return new ScraperResult()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.NoItemsFound,
                };
            }

            items = service.GetItems(searchCriteria, nodes);

            if (items.Count == 0)
            {
                return new ScraperResult()
                {
                    Items = items,
                    TotalResults = items.Count,
                    ErrorMessage = ErrorMessages.NoItemsFound,
                };
            }

            var itemEntities = this.Mapper.Map<List<Item>>(items);

            // save the items to the database.
            // then return the response.
            return new ScraperResult()
            {
                Items = items,
                TotalResults = items.Count,
                Succeeded = true,
            };
        }
    }
}
