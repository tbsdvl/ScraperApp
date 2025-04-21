// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
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
        /// Gets or sets the maximum page number to scrape.
        /// </summary>
        private int MaxPageNumber { get; set; } = 200;

        /// <summary>
        /// Gets the eBay URL.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <returns>The eBay URL.</returns>
        private static string GetEbayUrl(ScraperRequest request)
        {
            var baseUrl = UrlConstants.EBAY;

            if (request.Options.CategoryId.HasValue)
            {
                baseUrl += request.Options.CategoryId + UrlConstants.EBAYINDEX;
            }

            baseUrl += UrlConstants.EBAYSEARCHQUERY;

            if (!string.IsNullOrWhiteSpace(request.Options.SearchTerm))
            {
                baseUrl += request.Options.SearchTerm;
            }

            if (request.Options.SoldItemsOnly)
            {
                baseUrl += UrlConstants.EBAYSOLDITEMS;
            }

            if (request.Options.PageNumber > 0)
            {
                baseUrl += UrlConstants.EBAYPAGENUM + request.Options.PageNumber;
            }

            if (!string.IsNullOrWhiteSpace(request.Options.ZipCode))
            {
                baseUrl += UrlConstants.EBAYZIPCODE + request.Options.ZipCode;
            }

            if (request.Options.Distance.HasValue)
            {
                baseUrl += UrlConstants.EBAYDISTANCE + request.Options.Distance;
            }

            return baseUrl;
        }

        /// <summary>
        /// Builds the request URL with the query parameters.
        /// </summary>
        /// <param name="request">The request.</param>
        private static void BuildRequestUrl(ScraperRequest request)
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
            BuildRequestUrl(request);

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

            var match = Regex.Match(sellerInfoText, @"(\d+(\.\d+)?)%");
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
        /// Gets the sold date from the text.
        /// </summary>
        /// <param name="text">The text containing the sold date.</param>
        /// <returns>The sold date.</returns>
        private static DateTime? GetSoldDate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return DateTime.MinValue;
            }

            var match = Regex.Match(text, @"Sold\s+([A-Za-z]+\s+\d{1,2},\s+\d{4})");
            return match.Success ? DateTime.Parse(match.Groups[1].Value) : null;
        }

        /// <summary>
        /// Gets the number of bids from the text.
        /// </summary>
        /// <param name="text">The text containing the number of bids.</param>
        /// <returns>The number of bids.</returns>
        private static int GetNumberOfBids(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            var match = Regex.Match(text, @"(\d+)\s+bids");
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
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
                var itemNodes = new List<HtmlNode>();
                var previousItemId = string.Empty;

                if (request.Options.MaxPageNumber.HasValue)
                {
                    this.MaxPageNumber = request.Options.MaxPageNumber.Value;
                }

                for (int i = 1; i <= this.MaxPageNumber; i++)
                {
                    request.Options.PageNumber = i;
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

                foreach (var node in itemNodes)
                {
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

                    // can't use element at, it will get the data for the wrong node
                    // find another way to get data from the correct nodes.
                    var saleDate = GetSoldDate(node.InnerText);
                    var condition = node.SelectSingleNode(NodePathConstants.Ebay.Condition);
                    var buyingFormat = node.SelectSingleNode(NodePathConstants.Ebay.BuyingFormat);
                    var totalWatchers = node.SelectSingleNode(NodePathConstants.Ebay.TotalWatchers);
                    var offer = node.SelectSingleNode(NodePathConstants.Ebay.HasOffer);
                    var sellerInfo = node.SelectSingleNode(NodePathConstants.Ebay.SellerInfo);

                    var quantitySoldMatch = Regex.Match(node.InnerText, @"(\d{1,3}(?:,\d{3})*)\s*sold");
                    var quantitySold = 0;
                    if (quantitySoldMatch.Success)
                    {
                        var soldText = quantitySoldMatch.Groups[1].Value;
                        quantitySold = int.Parse(soldText.Replace(",", string.Empty));
                    }

                    // this will be an entity
                    var item = new Item()
                    {
                        ElementId = id,
                        Name = name.InnerText.Trim(),
                        HasUpperCaseName = name.InnerText.All(c => char.IsUpper(c)),
                        MinPrice = priceRange.Count > 0 ? priceRange.First() : priceText.ToDecimalPrice(),
                        MaxPrice = priceRange.LastOrDefault(),
                        SaleDate = saleDate,
                        Condition = condition is not null ? condition.InnerText.Trim() : string.Empty,
                        TotalBids = GetNumberOfBids(node.InnerText),
                        BuyingFormat = (int)GetBuyingFormat(node.InnerText),
                        HasFreeDelivery = node.InnerText.Contains(NodePathConstants.Ebay.FreeDeliveryText, StringComparison.OrdinalIgnoreCase),
                        TotalWatchers = totalWatchers is not null ? int.Parse(totalWatchers.InnerText.Trim().Split(' ')[0]) : 0,
                        HasOffer = offer is not null,
                        SellerName = sellerInfo is not null ? sellerInfo.InnerText.Split('(')[0].Trim() : string.Empty,
                        TotalSellerReviews = sellerInfo is not null ? GetTotalSellerReviews(sellerInfo.InnerText) : null,
                        SellerRating = sellerInfo is not null ? GetSellerRating(sellerInfo.InnerText) : null,
                        QuantitySold = quantitySold,
                        CategoryId = request.Options.CategoryId,
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
