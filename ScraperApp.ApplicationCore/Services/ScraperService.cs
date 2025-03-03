// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using ScraperApp.ApplicationCore.Constants;
using ScraperApp.ApplicationCore.Enums;
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
        public async Task<ScraperResponse> GetItems(ScraperRequest request)
        {
            var items = new List<Item>();
            if (request.Options.QueryOptionsType == (int)QueryOptionsTypeEnum.Ebay)
            {
                var page = await this.GetPageHtml(request);
                var nodes = page.DocumentNode.SelectNodes("//ul[contains(@class, 'srp-results srp-list clearfix')]/li[contains(@class, 's-item')]");

                foreach (var node in nodes)
                {
                    var id = node.Id;
                    if (id == null)
                    {
                        continue;
                    }

                    var name = node.SelectSingleNode(".//a[contains(@class, 's-item__link')]");
                    if (name == null)
                    {
                        continue;
                    }

                    var price = node.SelectSingleNode(".//span[contains(@class, 's-item__price')]");
                    if (price == null)
                    {
                        continue;
                    }

                    items.Add(new Item()
                    {
                        Id = id,
                        Name = name.InnerText,
                        Price = price.InnerText,
                    });
                }
            }

            return new ScraperResponse()
            {
                Items = items,
            };
        }
    }
}
