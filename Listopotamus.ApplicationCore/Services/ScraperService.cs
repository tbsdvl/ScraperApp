// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using Listopotamus.ApplicationCore.Entities.Items;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.ApplicationCore.Models;
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
    public class ScraperService(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
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
        private static async Task<HtmlDocument> GetPageHtmlAsync(ScraperRequest request, IScraperService service)
        {
            request.Url = service.GetUrl(request);

            var webUtility = new HtmlWeb();
            var htmlDoc = await webUtility.LoadFromWebAsync(request.Url);

            return htmlDoc;
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
                (int)MarketplaceTypeEnum.Ebay => serviceScope.ServiceProvider.GetRequiredService<EbayScraperService>(),
                _ => null,
            };
        }

        /// <summary>
        /// Gets a list of item nodes from a page.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <param name="service">The scraper service.</param>
        /// <returns>A list of nodes.</returns>
        private async Task<List<HtmlNode>> GetItemNodesAsync(ScraperRequest request, IScraperService service)
        {
            var itemNodes = new List<HtmlNode>();
            var previousItemId = string.Empty;

            if (request.Options.MaxPageNumber.HasValue)
            {
                this.MaxPageNumber = request.Options.MaxPageNumber.Value;
            }

            for (int i = 1; i <= this.MaxPageNumber; i++)
            {
                request.Options.PageNumber = i;
                var page = await GetPageHtmlAsync(request, service);
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
        /// <param name="request">The request.</param>
        /// <returns>The scraper response including a list of items.</returns>
        public async Task<ScraperResponse> GetItemsAsync(ScraperRequest request)
        {
            var items = new List<ItemModel>();
            if (!request.Options.MarketplaceTypeId.HasValue)
            {
                return new ScraperResponse()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.MissingQueryOption,
                };
            }

            using var serviceScope = this.ServiceScopeFactory.CreateScope();
            var service = GetService(serviceScope, request.Options.MarketplaceTypeId.Value);
            if (service is null)
            {
                return new ScraperResponse()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.InvalidQueryOptionType,
                };
            }

            var nodes = await this.GetItemNodesAsync(request, service);
            if (nodes is null || nodes.Count == 0)
            {
                return new ScraperResponse()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.NoItemsFound,
                };
            }

            items = service.GetItems(request, nodes);

            if (items.Count == 0)
            {
                return new ScraperResponse()
                {
                    Items = items,
                    ErrorMessage = ErrorMessages.NoItemsFound,
                };
            }

            var itemEntities = this.Mapper.Map<List<Item>>(items);

            // save the items to the database.
            // then return the response.
            return new ScraperResponse()
            {
                Items = items,
                Succeeded = true,
            };
        }
    }
}
