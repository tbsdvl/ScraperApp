// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using ScraperApp.ApplicationCore.Constants;
using ScraperApp.ApplicationCore.Enums;
using ScraperApp.ApplicationCore.Extensions;
using ScraperApp.ApplicationCore.Models;

namespace ScraperApp.ApplicationCore.Services
{
    /// <summary>
    /// Provides services related to retrieving and processing HTML data.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ScraperService"/> class.
    /// </remarks>
    /// <param name="mapper">The mapper.</param>
    public class ScraperService(IMapper mapper)
    {
        /// <summary>
        /// Gets or sets the mapper.
        /// </summary>
        private IMapper Mapper { get; set; } = mapper;

        /// <summary>
        /// Gets the eBay URL.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <returns>The eBay URL.</returns>
        private static string GetEbayUrl(ScraperRequest request)
        {
            var baseUrl = BaseUrlConstants.EBAY;
            if (!string.IsNullOrWhiteSpace(request.Options.SearchTerm))
            {
                baseUrl += request.Options.SearchTerm;
            }

            return baseUrl;
        }

        /// <summary>
        /// Gets the request URL with the query parameters.
        /// </summary>
        /// <param name="request">The request.</param>
        private void SetRequestUrlWithQueryParams(ScraperRequest request)
        {
            switch (request.Options.QueryOptionsType)
            {
                case (int)QueryOptionsTypeEnum.Ebay:
                    request.Url = GetEbayUrl(request);
                    break;
            }
        }

        /// <summary>
        /// Gets a page's HTML.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <returns>The page's HTML.</returns>
        private async Task<HtmlDocument> GetPageHtml(ScraperRequest request)
        {
            this.SetRequestUrlWithQueryParams(request);

            var webUtility = new HtmlWeb();
            var htmlDoc = await webUtility.LoadFromWebAsync(request.Url);

            return htmlDoc;
        }

        /// <summary>
        /// Gets a list of items from a page.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The scraper response including a list of items.</returns>
        public async Task<ScraperResponse> GetItemsAsync(ScraperRequest request)
        {
            var items = new List<Item>();

            // use plumbing to get a service for scraping HTML
            if (request.Options.QueryOptionsType == (int)QueryOptionsTypeEnum.Ebay)
            {
                var page = await this.GetPageHtml(request);
                var nodes = page.DocumentNode.SelectNodes(NodePathConstants.EbayItemsList);

                if (nodes is null || nodes.Count == 0)
                {
                    return new ScraperResponse()
                    {
                        Items = items,
                        ErrorMessage = "No items found on the page. Please check the search term or the URL.",
                        Succeeded = false,
                    };
                }

                foreach (var node in nodes)
                {
                    var id = node.Id;
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        continue;
                    }

                    var name = node.SelectSingleNode(NodePathConstants.EbayItemName);
                    if (name is null)
                    {
                        continue;
                    }

                    var price = node.SelectSingleNode(NodePathConstants.EbayItemPrice);
                    if (price is null)
                    {
                        continue;
                    }

                    var priceText = price.InnerText.Trim();
                    var priceRange = new List<decimal>();
                    if (priceText.Contains("to", StringComparison.OrdinalIgnoreCase))
                    {
                        priceRange = priceText.ToPriceRange();
                    }

                    items.Add(new Item()
                    {
                        Id = id,
                        Name = name.InnerText.Trim(),
                        MinPrice = priceRange.Count > 0 ? priceRange.First() : priceText.ToDecimalPrice(),
                        MaxPrice = priceRange.LastOrDefault(),
                    });
                }
            }

            return new ScraperResponse()
            {
                Items = items,
                Succeeded = true,
            };
        }
    }
}
