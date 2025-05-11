// <copyright file="SearchQueryDto.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.ApplicationCore.DTOs
{
    /// <summary>
    /// Represents a search query.
    /// </summary>
    public class SearchQueryDto
    {
        /// <summary>
        /// Gets or sets the marketplace type id.
        /// </summary>
        [Required]
        public int? MarketplaceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the category type id.
        /// </summary>
        [Required]
        public int? CategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the location type id.
        /// </summary>
        [Required]
        public int? LocationTypeId { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [Required]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the distance is in miles or kilometers.
        /// </summary>
        public bool IsMiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include sold items only in the search results.
        /// </summary>
        [Required]
        public bool SoldItemsOnly { get; set; }

        /// <summary>
        /// Gets or sets the maximum page number.
        /// </summary>
        public int? MaxPageNumber { get; set; }
    }
}
