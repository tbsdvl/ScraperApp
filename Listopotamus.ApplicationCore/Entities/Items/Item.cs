// <copyright file="Item.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Listopotamus.ApplicationCore.Entities.Lookups;
using Listopotamus.ApplicationCore.Entities.Search;

namespace Listopotamus.ApplicationCore.Entities.Items
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public class Item : BaseExternalEntity<long?>
    {
        /// <summary>
        /// Gets or sets the category type id.
        /// </summary>
        [ForeignKey(nameof(CategoryType))]
        [Required]
        public int? CategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the marketplace type id.
        /// </summary>
        [ForeignKey(nameof(MarketplaceType))]
        [Required]
        public int? MarketplaceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the location type id.
        /// </summary>
        [ForeignKey(nameof(LocationType))]
        [Required]
        public int? LocationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the element id.
        /// </summary>
        required public string ElementId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item name contains all uppercase letters.
        /// </summary>
        required public bool HasUpperCaseName { get; set; }

        /// <summary>
        /// Gets or sets the min price.
        /// </summary>
        required public decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the max price.
        /// </summary>
        public decimal? MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        public DateTime? SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the number of watchers.
        /// </summary>
        public int? TotalWatchers { get; set; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Gets or sets the total bids.
        /// </summary>
        public int? TotalBids { get; set; }

        /// <summary>
        /// Gets or sets the buying format.
        /// </summary>
        public int? BuyingFormat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has free delivery.
        /// </summary>
        public bool HasFreeDelivery { get; set; }

        /// <summary>
        /// Gets or sets the quantity sold.
        /// </summary>
        public int? QuantitySold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has an offer such as a discount.
        /// </summary>
        public bool HasOffer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is sponsored.
        /// </summary>
        public bool IsSponsored { get; set; }

        /// <summary>
        /// Gets or sets the seller name.
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Gets or sets the total seller reviews.
        /// </summary>
        public int? TotalSellerReviews { get; set; }

        /// <summary>
        /// Gets or sets the seller rating.
        /// </summary>
        public decimal? SellerRating { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the marketplace type.
        /// </summary>
        public MarketplaceType MarketplaceType { get; set; }

        /// <summary>
        /// Gets or sets the category type.
        /// </summary>
        public CategoryType CategoryType { get; set; }

        /// <summary>
        /// Gets or sets the location type.
        /// </summary>
        public LocationType LocationType { get; set; }

        /// <summary>
        /// Gets or sets the search result items.
        /// </summary>
        public List<SearchResultItem> SearchResultItems { get; set; }
    }
}
