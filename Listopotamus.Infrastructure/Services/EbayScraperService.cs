// <copyright file="EbayScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Listopotamus.ApplicationCore;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Entities.Lookups;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Infrastructure.Constants;

namespace Listopotamus.Infrastructure.Services
{
    /// <summary>
    /// Represents the eBay scraper service.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="EbayScraperService"/> class.
    /// </remarks>
    /// <param name="itemService">The item service.</param>
    /// <param name="lookupService">The lookupService.</param>
    public class EbayScraperService(IItemService itemService, ILookupService lookupService) : IEbayScraperService
    {
        /// <summary>
        /// The Maximum number of results per page.
        /// </summary>
        private const string MAXRESULTSPERPAGE = "240";

        /// <inheritdoc />
        public string ItemsListNodePath => NodePathConstants.Ebay.ItemsList;

        /// <summary>
        /// Gets the item service.
        /// </summary>
        private IItemService ItemService { get; } = itemService;

        /// <summary>
        /// Gets the lookup service.
        /// </summary>
        private ILookupService LookupService { get; } = lookupService;

        /// <inheritdoc />
        public string GetUrl(SearchCriteriaModel searchCriteria)
        {
            var baseUrl = UrlConstants.EBAY;

            if (searchCriteria.Query.CategoryCode.HasValue)
            {
                baseUrl += searchCriteria.Query.CategoryCode + UrlConstants.EBAYINDEX;
            }

            baseUrl += UrlConstants.EBAYSEARCHQUERY;

            if (!string.IsNullOrWhiteSpace(searchCriteria.Query.SearchTerm))
            {
                baseUrl += searchCriteria.Query.SearchTerm;
            }

            if (searchCriteria.Query.CategoryCode.HasValue)
            {
                baseUrl += UrlConstants.EBAYCATEGORY + searchCriteria.Query.CategoryCode;
            }

            if (searchCriteria.Query.SoldItemsOnly)
            {
                baseUrl += UrlConstants.EBAYSOLDITEMS;
            }

            if (searchCriteria.Query.PageNumber > 0)
            {
                baseUrl += UrlConstants.EBAYPAGENUM + searchCriteria.Query.PageNumber;
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.Query.ZipCode))
            {
                baseUrl += UrlConstants.EBAYZIPCODE + searchCriteria.Query.ZipCode;
            }

            if (searchCriteria.Query.Distance.HasValue)
            {
                baseUrl += UrlConstants.EBAYDISTANCE + searchCriteria.Query.Distance;
            }

            if (searchCriteria.Query.LocationTypeId.HasValue)
            {
                baseUrl += UrlConstants.EBAYLOCATION + searchCriteria.Query.LocationTypeId;
            }

            baseUrl += UrlConstants.EBAYRESULTSPERPAGE + MAXRESULTSPERPAGE;

            return baseUrl;
        }

        /// <inheritdoc/>
        public async Task<List<ItemDto>> GetItemsAsync(
            long searchQueryId,
            SearchCriteriaModel searchCriteria,
            List<HtmlNode> nodes,
            List<ItemDto> items)
        {
            var filteredNodes = FilterNewNodes(nodes, items);
            if (filteredNodes.Count == 0)
            {
                return items;
            }

            var getCategoryTypesResult = await this.LookupService.GetCategoryTypesAsync();
            if (!getCategoryTypesResult.IsSuccess)
            {
                return items;
            }

            var categoryType = getCategoryTypesResult.Content.FirstOrDefault(x => x.LookupValue == searchCriteria.Query.CategoryCode.ToString());

            var newItems = ParseItems(filteredNodes, searchCriteria, categoryType);
            items.AddRange(newItems);
            await this.ItemService.CreateAsync(searchQueryId, newItems);

            return items;
        }

        /// <summary>
        /// Extracts the seller name from a seller info.
        /// </summary>
        /// <param name="sellerInfoText">The seller info text.</param>
        /// <returns>The seller name, or an empty string if not found.</returns>
        private static string GetSellerName(string sellerInfoText)
        {
            if (string.IsNullOrWhiteSpace(sellerInfoText))
            {
                return string.Empty;
            }

            var match = Regex.Match(sellerInfoText, @"^(.*?)\s+\d+(\.\d+)?% positive", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            var fallback = sellerInfoText.Split('(')[0].Trim();
            return fallback;
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
        /// Filters out nodes that already exist in the items list based on their IDs.
        /// </summary>
        /// <param name="nodes">The list of nodes.</param>
        /// <param name="items">The list of items.</param>
        /// <returns>The list of filtered nodes.</returns>
        private static List<HtmlNode> FilterNewNodes(List<HtmlNode> nodes, List<ItemDto> items)
        {
            if (items.Count == 0)
            {
                return nodes;
            }

            return nodes
                .Where(x => !string.IsNullOrWhiteSpace(x.Id) && !items.Any(i => i.ElementId.Equals(x.Id, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        /// <summary>
        /// Parses the item nodes into a list of ItemDtos.
        /// </summary>
        /// <param name="nodes">The list of notes.</param>
        /// <param name="criteria">The search criteria.</param>
        /// <param name="categoryType">The categoryType.</param>
        /// <returns>The list of ItemDtos.</returns>
        private static List<ItemDto> ParseItems(IEnumerable<HtmlNode> nodes, SearchCriteriaModel criteria, CategoryType? categoryType)
        {
            var items = new List<ItemDto>();

            foreach (var node in nodes)
            {
                if (string.IsNullOrWhiteSpace(node.Id))
                {
                    continue;
                }

                var name = node.SelectSingleNode(NodePathConstants.Ebay.ItemName);
                var price = node.SelectSingleNode(NodePathConstants.Ebay.ItemPrice);
                if (name is null || price is null)
                {
                    continue;
                }

                var dto = GetItemDto(node, name, price, criteria);
                if (dto is not null)
                {
                    if (categoryType is null)
                    {
                        dto.CategoryTypeId = (int)CategoryTypeEnum.AllCategories;
                    }
                    else
                    {
                        dto.CategoryTypeId = categoryType.Id;
                    }

                    items.Add(dto);
                }
            }

            return items;
        }

        /// <summary>
        /// Gets an item dto from the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="nameNode">The node for the item name.</param>
        /// <param name="priceNode">The node for the item price.</param>
        /// <param name="criteria">The search criteria.</param>
        /// <returns>The item dto.</returns>
        private static ItemDto GetItemDto(HtmlNode node, HtmlNode nameNode, HtmlNode priceNode, SearchCriteriaModel criteria)
        {
            var priceText = priceNode.InnerText.Trim();
            var priceRange = priceText.Contains("to", StringComparison.OrdinalIgnoreCase)
                ? priceText.ToPriceRange()
                : new List<decimal>();

            var conditionNode = node.SelectSingleNode(NodePathConstants.Ebay.Condition);
            var buyingFormatNode = node.SelectSingleNode(NodePathConstants.Ebay.BuyingFormat);
            var totalWatchersNode = node.SelectSingleNode(NodePathConstants.Ebay.TotalWatchers);
            var offerNode = node.SelectSingleNode(NodePathConstants.Ebay.HasOffer);
            var sellerInfoNode = node.SelectSingleNode(NodePathConstants.Ebay.SellerInfo);
            var locationNode = node.SelectSingleNode(NodePathConstants.Ebay.Location);

            return new ItemDto
            {
                ExternalId = Guid.NewGuid(),
                ElementId = node.Id,
                MarketplaceTypeId = (int)MarketplaceTypeEnum.Ebay,
                LocationTypeId = criteria.Query.LocationTypeId,
                Name = nameNode.InnerText.Replace(EbayConstants.NewListingText.ToUpper(), string.Empty).Trim(),
                HasUpperCaseName = nameNode.InnerText.All(char.IsUpper),
                MinPrice = priceRange.Count > 0 ? priceRange.First() : priceText.ToDecimalPrice(),
                MaxPrice = priceRange.LastOrDefault(),
                SaleDate = GetSoldDate(node.InnerText),
                Condition = conditionNode?.InnerText.Trim() ?? string.Empty,
                TotalBids = GetNumberOfBids(node.InnerText),
                BuyingFormat = (int)GetBuyingFormat(node.InnerText),
                HasFreeDelivery = node.InnerText.Contains(EbayConstants.FreeDeliveryText, StringComparison.OrdinalIgnoreCase),
                TotalWatchers = totalWatchersNode is not null ? ParseWatchers(totalWatchersNode.InnerText) : 0,
                HasOffer = offerNode is not null,
                SellerName = sellerInfoNode is not null ? GetSellerName(sellerInfoNode.InnerText) : string.Empty,
                TotalSellerReviews = sellerInfoNode is not null ? GetTotalSellerReviews(sellerInfoNode.InnerText) : null,
                SellerRating = sellerInfoNode is not null ? GetSellerRating(sellerInfoNode.InnerText) : null,
                QuantitySold = ParseQuantitySold(node.InnerText),
                Location = locationNode is not null ? ParseLocation(locationNode.InnerText) : string.Empty,
            };
        }

        /// <summary>
        /// Parses the number of watchers from the inner text of a total watchers node.
        /// </summary>
        /// <param name="innerText">The inner text.</param>
        /// <returns>The number of an item's total watchers.</returns>
        private static int ParseWatchers(string innerText)
        {
            if (string.IsNullOrWhiteSpace(innerText))
            {
                return 0;
            }

            var first = innerText.Trim().Split(' ')[0];
            return int.TryParse(first, out var n) ? n : 0;
        }

        /// <summary>
        /// Parses the location from the inner text of a location node.
        /// </summary>
        /// <param name="innerText">The inner text.</param>
        /// <returns>The item's location.</returns>
        private static string ParseLocation(string innerText)
        {
            if (string.IsNullOrWhiteSpace(innerText))
            {
                return string.Empty;
            }

            return innerText
                .Replace("from ", string.Empty)
                .Replace("Located in", string.Empty)
                .Trim();
        }

        /// <summary>
        /// Parses the quantity sold from the specified text.
        /// </summary>
        /// <param name="innerText">The inner text.</param>
        /// <returns>The number for the quantity of sold items.</returns>
        private static int ParseQuantitySold(string innerText)
        {
            var m = Regex.Match(innerText, @"(\d{1,3}(?:,\d{3})*)\s*sold", RegexOptions.IgnoreCase);
            if (!m.Success)
            {
                return 0;
            }

            var s = m.Groups[1].Value.Replace(",", string.Empty);
            return int.TryParse(s, out var n) ? n : 0;
        }
    }
}
