// <copyright file="QueryOptions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.ApplicationCore.Models
{
    /// <summary>
    /// Represents the query string options.
    /// </summary>
    public class QueryOptions
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [Required]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the marketplace type.
        /// </summary>
        public int? MarketplaceType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include sold items only in the search results.
        /// </summary>
        public bool SoldItemsOnly { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        [Required]
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        /// Gets or sets the category type id.
        /// </summary>
        public int? CategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the maximum page number.
        /// </summary>
        public int? MaxPageNumber { get; set; }
    }
}
