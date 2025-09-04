// <copyright file="ItemDto.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.DTOs
{
    /// <summary>
    /// Represents the data of an item.
    /// </summary>
    public class ItemDto
    {
        /// <summary>
        /// Gets or sets the external identifier.
        /// </summary>
        public Guid ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the category type id.
        /// </summary>
        public int? CategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the marketplace type id.
        /// </summary>
        public int? MarketplaceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the location type id.
        /// </summary>
        public int? LocationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the element id.
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item name contains all uppercase letters.
        /// </summary>
        public bool HasUpperCaseName { get; set; }

        /// <summary>
        /// Gets or sets the min price.
        /// </summary>
        public decimal MinPrice { get; set; }

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
    }
}
