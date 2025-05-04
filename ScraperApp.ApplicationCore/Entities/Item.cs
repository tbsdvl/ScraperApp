// <copyright file="Item.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Entities
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        required public long Id { get; set; }

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
    }
}
