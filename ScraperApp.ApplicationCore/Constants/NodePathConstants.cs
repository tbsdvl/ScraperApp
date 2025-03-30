// <copyright file="NodeConstants.cs" company="Psybersimian LLC">
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
        /// XPath expression for selecting the list of eBay items from the search results.
        /// </summary>
        public const string EbayItemsList = "//ul[contains(@class, 'srp-results srp-list clearfix')]/li[contains(@class, 's-item')]";

        /// <summary>
        /// XPath expression for selecting the name of an individual eBay item node.
        /// </summary>
        public const string EbayItemName = ".//a[contains(@class, 's-item__link')]";

        /// <summary>
        /// XPath expression for selecting the price of an individual eBay item node.
        /// </summary>
        public const string EbayItemPrice = ".//span[contains(@class, 's-item__price')]";
    }
}
