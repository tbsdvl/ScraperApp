// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using ScraperApp.ApplicationCore.Constants;
using ScraperApp.ApplicationCore.Enums;
using ScraperApp.ApplicationCore.Extensions;
using ScraperApp.ApplicationCore.Models;
using System.Text.RegularExpressions;

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
        private static void SetRequestUrlWithQueryParams(ScraperRequest request)
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
        private static async Task<HtmlDocument> GetPageHtml(ScraperRequest request)
        {
            SetRequestUrlWithQueryParams(request);

            var webUtility = new HtmlWeb();
            var htmlDoc = await webUtility.LoadFromWebAsync(request.Url);

            return htmlDoc;
        }

        /// <summary>
        /// Gets the total seller's reviews.
        /// </summary>
        /// <param name="sellerInfoText">The seller info text.</param>
        /// <returns>The total seller's reviews.</returns>
        private static int GetTotalSellerReviews(string sellerInfoText)
        {
            if (string.IsNullOrWhiteSpace(sellerInfoText))
    {
                return 0;
            }

            var match = Regex.Match(sellerInfoText, @"\((\d+)\)");
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }

        /// <summary>
        /// Gets the seller's rating.
        /// </summary>
        /// <param name="sellerInfoText">The seller info text.</param>
        /// <returns>The seller's rating.</returns>
        private static decimal GetSellerRating(string sellerInfoText)
        {
            if (string.IsNullOrWhiteSpace(sellerInfoText))
            {
                return 0;
            }

            var match = Regex.Match(sellerInfoText, @"(\d+)%");
            return match.Success ? decimal.Parse(match.Groups[1].Value) : 0;
        }

        /// <summary>
        /// Gets the buying format.
        /// </summary>
        /// <param name="innerText">The inner text of the node.</param>
        /// <returns>The buying format.</returns>
        private static BuyingFormatEnum GetBuyingFormat(string innerText)
        {
            if (innerText.Contains("Buy It Now", StringComparison.OrdinalIgnoreCase))
            {
                return BuyingFormatEnum.BuyItNow;
            }

            if (innerText.Contains("Best Offer", StringComparison.OrdinalIgnoreCase))
            {
                return BuyingFormatEnum.BestOffer;
            }

            if (innerText.Contains("Bids", StringComparison.OrdinalIgnoreCase))
            {
                return BuyingFormatEnum.Bids;
            }

            return BuyingFormatEnum.None;
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
                var page = await GetPageHtml(request);
                var nodes = page.DocumentNode.SelectNodes(NodePathConstants.Ebay.ItemsList);

                if (nodes is null || nodes.Count == 0)
                {
                    return new ScraperResponse()
                    {
                        Items = items,
                        ErrorMessage = "No items found on the page. Please check the search term or the URL.",
                        Succeeded = false,
                    };
                }

                for (int i = 0; i < nodes.Count; i++)
                {
                    var node = nodes[i];
                    var id = node.Id;
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        continue;
                    }

                    var name = node.SelectSingleNode(NodePathConstants.Ebay.ItemName);
                    var price = node.SelectSingleNode(NodePathConstants.Ebay.ItemPrice);

                    if (name is null || price is null)
                    {
                        continue;
                    }

                    var priceText = price.InnerText.Trim();
                    var priceRange = new List<decimal>();
                    if (priceText.Contains("to", StringComparison.OrdinalIgnoreCase))
                    {
                        priceRange = priceText.ToPriceRange();
                    }

                    var saleDate = node.SelectNodes(NodePathConstants.Ebay.SaleDate)?.ElementAt(i);
                    var condition = node.SelectSingleNode(NodePathConstants.Ebay.Condition);
                    var totalBids = node.SelectNodes(NodePathConstants.Ebay.TotalBids)?.ElementAt(i);
                    var buyingFormat = node.SelectNodes(NodePathConstants.Ebay.BuyingFormat)?.ElementAt(i);
                    var totalWatchers = node.SelectNodes(NodePathConstants.Ebay.TotalWatchers)?.ElementAt(i);
                    var hasOffer = node.SelectNodes(NodePathConstants.Ebay.HasOffer)?.ElementAt(i);
                    var isSponsored = node.SelectNodes(NodePathConstants.Ebay.IsSponsored)?.ElementAt(i);
                    var sellerInfo = node.SelectNodes(NodePathConstants.Ebay.SellerInfo).ElementAt(i);

                    var quantitySoldMatch = Regex.Match(node.InnerText, @"(\d{1,3}(?:,\d{3})*)\s*sold");
                    var quantitySold = 0;
                    if (quantitySoldMatch.Success)
                    {
                        var soldText = quantitySoldMatch.Groups[1].Value;
                        quantitySold = int.Parse(soldText.Replace(",", string.Empty));
                    }

                    var item = new Item()
                    {
                        Id = id,
                        Name = name.InnerText.Trim(),
                        HasUpperCaseName = name.InnerText.All(c => char.IsUpper(c)),
                        MinPrice = priceRange.Count > 0 ? priceRange.First() : priceText.ToDecimalPrice(),
                        MaxPrice = priceRange.LastOrDefault(),
                        SaleDate = saleDate is not null ? DateTime.Parse(saleDate.InnerText.Trim()) : DateTime.MinValue,
                        Condition = condition is not null ? condition.InnerText.Trim() : string.Empty,
                        TotalBids = totalBids is not null ? int.Parse(totalBids.InnerText.Trim().Split(' ')[0]) : 0,
                        BuyingFormat = (int)GetBuyingFormat(node.InnerText),
                        HasFreeDelivery = node.InnerText.Contains("Free delivery", StringComparison.OrdinalIgnoreCase),
                        TotalWatchers = totalWatchers is not null ? int.Parse(totalWatchers.InnerText.Trim().Split(' ')[0]) : 0,
                        HasOffer = hasOffer is not null,
                        IsSponsored = isSponsored is not null,
                        SellerName = sellerInfo.InnerText.Split('(')[0].Trim(),
                        TotalSellerReviews = GetTotalSellerReviews(sellerInfo.InnerText),
                        SellerRating = GetSellerRating(sellerInfo.InnerText),
                        QuantitySold = quantitySold,
                    };

                    items.Add(item);
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
