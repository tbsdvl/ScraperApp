// <copyright file="EbaySearchQueryModel.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Enums;

namespace Listopotamus.ApplicationCore.Models
{
    /// <summary>
    /// Represents the query options for scraping eBay pages.
    /// </summary>
    public class EbaySearchQueryModel : SearchQueryModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EbaySearchQueryModel"/> class.
        /// </summary>
        public EbaySearchQueryModel()
        {
            this.MarketplaceTypeId = (int)MarketplaceTypeEnum.Ebay;
        }
    }
}
