// <copyright file="EbayScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ScraperApp.ApplicationCore.Constants;
using ScraperApp.ApplicationCore.Enums;
using ScraperApp.ApplicationCore.Extensions;
using ScraperApp.ApplicationCore.Interfaces;
using ScraperApp.ApplicationCore.Models;

namespace ScraperApp.ApplicationCore.Services
{
    /// <summary>
    /// Represents the eBay scraper service.
    /// </summary>
    public class EbayScraperService : IScraperService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EbayScraperService"/> class.
        /// </summary>
        public EbayScraperService()
        {
        }

        /// <inheritdoc />
        public string ItemsListNodePath => NodePathConstants.Ebay.ItemsList;

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

        /// <inheritdoc />
        public string GetUrl(ScraperRequest request)
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

        /// <inheritdoc/>
        public string GetItemsListNodePath(int queryOptionsTypeId)
        {
            return NodePathConstants.Ebay.ItemsList;
        }

        /// <inheritdoc/>
        public List<ItemModel> GetItems(ScraperRequest request, List<HtmlNode> nodes)
        {
            var items = new List<ItemModel>();

            foreach (var node in nodes)
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

                // items will map to a list of entities
                var item = new ItemModel()
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

            return items;
        }
    }
}
