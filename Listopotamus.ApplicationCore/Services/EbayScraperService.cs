// <copyright file="EbayScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using System.Transactions;
using AutoMapper;
using HtmlAgilityPack;
using Listopotamus.ApplicationCore.Constants;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Extensions;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities.Items;
using Listopotamus.Core.Entities.Search;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the eBay scraper service.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="EbayScraperService"/> class.
    /// </remarks>
    /// <param name="mapper">The mapper.</param>
    /// <param name="itemRepository">The item repository.</param>
    /// <param name="searchResultItemRepository">The search result item repository.</param>
    public class EbayScraperService(IMapper mapper, IItemRepository itemRepository, ISearchResultItemRepository searchResultItemRepository) : IEbayScraperService
    {
        /// <summary>
        /// The Maximum number of results per page.
        /// </summary>
        private const string MAXRESULTSPERPAGE = "240";

        /// <inheritdoc />
        public string ItemsListNodePath => NodePathConstants.Ebay.ItemsList;

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        private IMapper Mapper { get; } = mapper;

        /// <summary>
        /// Gets the item repository.
        /// </summary>
        private IItemRepository ItemRepository { get; } = itemRepository;

        /// <summary>
        /// Gets the search result item repository.
        /// </summary>
        private ISearchResultItemRepository SearchResultItemRepository { get; } = searchResultItemRepository;

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

            // Match everything up to the first occurrence of a percentage (rating) with optional decimal, followed by "positive"
            var match = Regex.Match(sellerInfoText, @"^(.*?)\s+\d+(\.\d+)?% positive", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            // Fallback: take everything before the first parenthesis or just the first word
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

        /// <inheritdoc />
        public string GetUrl(SearchCriteriaModel searchCriteria)
        {
            var baseUrl = UrlConstants.EBAY;

            if (searchCriteria.Query.CategoryTypeId.HasValue)
            {
                baseUrl += searchCriteria.Query.CategoryTypeId + UrlConstants.EBAYINDEX;
            }

            baseUrl += UrlConstants.EBAYSEARCHQUERY;

            if (!string.IsNullOrWhiteSpace(searchCriteria.Query.SearchTerm))
            {
                baseUrl += searchCriteria.Query.SearchTerm;
            }

            if (searchCriteria.Query.CategoryTypeId.HasValue)
            {
                baseUrl += UrlConstants.EBAYCATEGORY + searchCriteria.Query.CategoryTypeId;
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
        public async Task<List<ItemDto>> GetItemsAsync(long? searchQueryId, SearchCriteriaModel searchCriteria, List<HtmlNode> nodes)
        {
            var items = new List<ItemDto>();

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
                var location = node.SelectSingleNode(NodePathConstants.Ebay.Location);

                var quantitySoldMatch = Regex.Match(node.InnerText, @"(\d{1,3}(?:,\d{3})*)\s*sold");
                var quantitySold = 0;
                if (quantitySoldMatch.Success)
                {
                    var soldText = quantitySoldMatch.Groups[1].Value;
                    quantitySold = int.Parse(soldText.Replace(",", string.Empty));
                }

                var item = new ItemDto()
                {
                    ExternalId = Guid.NewGuid(),
                    ElementId = id,
                    MarketplaceTypeId = (int)MarketplaceTypeEnum.Ebay,
                    CategoryTypeId = searchCriteria.Query.CategoryTypeId ?? (int)CategoryTypeEnum.AllCategories,
                    LocationTypeId = searchCriteria.Query.LocationTypeId,
                    Name = name.InnerText.Replace(EbayConstants.NewListingText.ToUpper(), string.Empty).Trim(),
                    HasUpperCaseName = name.InnerText.All(c => char.IsUpper(c)),
                    MinPrice = priceRange.Count > 0 ? priceRange.First() : priceText.ToDecimalPrice(),
                    MaxPrice = priceRange.LastOrDefault(),
                    SaleDate = saleDate,
                    Condition = condition is not null ? condition.InnerText.Trim() : string.Empty,
                    TotalBids = GetNumberOfBids(node.InnerText),
                    BuyingFormat = (int)GetBuyingFormat(node.InnerText),
                    HasFreeDelivery = node.InnerText.Contains(EbayConstants.FreeDeliveryText, StringComparison.OrdinalIgnoreCase),
                    TotalWatchers = totalWatchers is not null ? int.Parse(totalWatchers.InnerText.Trim().Split(' ')[0]) : 0,
                    HasOffer = offer is not null,
                    SellerName = sellerInfo is not null ? GetSellerName(sellerInfo.InnerText) : string.Empty,
                    TotalSellerReviews = sellerInfo is not null ? GetTotalSellerReviews(sellerInfo.InnerText) : null,
                    SellerRating = sellerInfo is not null ? GetSellerRating(sellerInfo.InnerText) : null,
                    QuantitySold = quantitySold,
                    Location = location is not null ? location.InnerText.Replace("from ", string.Empty).Replace("Located in", string.Empty).Trim() : string.Empty,
                };

                items.Add(item);
            }

            var itemEntities = this.Mapper.Map<List<Item>>(items);

            // use transaction scope because we have to relate the user search to the search result items.
            var options = new TransactionOptions()
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
            };

            using var scope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
            var savedItems = await this.ItemRepository.InsertAsync(itemEntities);

            var searchResultItems = new List<SearchResultItem>();
            foreach (var savedItem in savedItems)
            {
                var searchResultItem = new SearchResultItem
                {
                    SearchQueryId = searchQueryId,
                    ItemId = savedItem.Id,
                    ExternalId = Guid.NewGuid(),
                };
            }

            await this.SearchResultItemRepository.InsertAsync(searchResultItems);

            scope.Complete();

            return items;
        }
    }
}
