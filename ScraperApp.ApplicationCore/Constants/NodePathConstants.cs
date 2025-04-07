// <copyright file="NodePathConstants.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>
namespace ScraperApp.ApplicationCore.Constants
{
    /// <summary>
    /// Represents the node constants.
    /// </summary>
    public class NodePathConstants
    {
        /// <summary>
        /// The eBay class.
        /// </summary>
        public class Ebay
        {
            /// <summary>
            /// Expression for selecting the list of eBay items from the search results.
            /// </summary>
            public const string ItemsList = "//ul[contains(@class, 'srp-results srp-list clearfix')]/li[contains(@class, 's-item')]";

            /// <summary>
            /// Expression for selecting the name of an individual eBay item node.
            /// </summary>
            public const string ItemName = ".//a[contains(@class, 's-item__link')]";

            /// <summary>
            /// Expression for selecting the price of an individual eBay item node.
            /// </summary>
            public const string ItemPrice = ".//span[contains(@class, 's-item__price')]";

            /// <summary>
            /// Expression for selecting the sale date of an individual eBay item node.
            /// </summary>
            public const string SaleDate = "//div[@class='s-card__caption']/span[@class='su-styled-text positive default']";

            /// <summary>
            /// Expression for selecting the condition of an individual eBay item node.
            /// </summary>
            public const string Condition = ".//span[@class='SECONDARY_INFO']";

            /// <summary>
            /// Expression for selecting the total number of bids on an individual eBay item node.
            /// </summary>
            public const string TotalBids = AttributeRow + "/span[contains(text(), 'bids')]";

            /// <summary>
            /// Expression for selecting the buying format of an individual eBay item node.
            /// </summary>
            public const string BuyingFormat = "//div[contains(@class, 'su-card-container__attributes')]//span[contains(@class, 'LABEL_CLASS_NAME')]";

            /// <summary>
            /// Expression for selecting whether the item has free delivery or not.
            /// </summary>
            public const string HasFreeDelivery = "//span[contains(@class, 's-item__logisticsCost') and contains(text(), 'Free')]";

            /// <summary>
            /// Expression for selecting the total number of watchers for an individual eBay item node.
            /// </summary>
            public const string TotalWatchers = "//span[contains(@class, 's-item__watchers')]";

            /// <summary>
            /// Expression for selecting whether the item has an offer such as a discount.
            /// </summary>
            public const string HasOffer = SecondaryAttributesContainer + "/div[@class='s-card__attribute-row']/span[contains(@class, 'negative bold large')]";

            /// <summary>
            /// Expression for checking if the item is sponsored or promoted in eBay search results.
            /// </summary>
            public const string IsSponsored = AttributeRow + "/span[contains(@class, 's-bsaq651_s-9hme301')]";

            /// <summary>
            /// Expression for selecting the seller info of an individual eBay item node.
            /// </summary>
            public const string SellerInfo = SecondaryAttributesContainer + SellerInfoSection + "/span[@class='s-item__seller-info-text']";

            /// <summary>
            /// Expression for selecting the quantity sold of an individual eBay item node.
            /// </summary>
            public const string QuantitySold = "//span[contains(text(), 'sold')]/text()";

            /// <summary>
            /// Expression for selecting the attribute row of an individual eBay item node.
            /// </summary>
            public const string AttributeRow = "//div[@class='s-item__detail s-item__detail--primary']";

            /// <summary>
            /// Expression for selecting the secondary attributes container of an individual eBay item node.
            /// </summary>
            public const string SecondaryAttributesContainer = "//div[@class='s-item__details-section--secondary']";

            /// <summary>
            /// Expression for selecting the seller info of an individual eBay item node.
            /// </summary>
            public const string SellerInfoSection = "/span[@class='s-item__detail s-item__detail--secondary']/span[@class='s-item__seller-info']";

            /// <summary>
            /// Constant for the free delivery text.
            /// </summary>
            public const string FreeDeliveryText = "Free delivery";
        }
    }
}