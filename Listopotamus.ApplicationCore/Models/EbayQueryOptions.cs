// <copyright file="EbayQueryOptions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Enums;

namespace Listopotamus.ApplicationCore.Models
{
    /// <summary>
    /// Represents the query options for scraping eBay pages.
    /// </summary>
    public class EbayQueryOptions : QueryOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EbayQueryOptions"/> class.
        /// </summary>
        public EbayQueryOptions()
        {
            this.MarketplaceType = (int)MarketplaceTypeEnum.Ebay;
        }
    }
}
