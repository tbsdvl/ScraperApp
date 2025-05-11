// <copyright file="EbaySearchQueryDto.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Enums;

namespace Listopotamus.ApplicationCore.DTOs
{
    /// <summary>
    /// Represents the query options for scraping eBay pages.
    /// </summary>
    public class EbaySearchQueryDto : SearchQueryDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EbaySearchQueryDto"/> class.
        /// </summary>
        public EbaySearchQueryDto()
        {
            this.MarketplaceTypeId = (int)MarketplaceTypeEnum.Ebay;
        }
    }
}
