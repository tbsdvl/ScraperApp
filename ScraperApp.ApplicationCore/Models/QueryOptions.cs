// <copyright file="QueryOptions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Models
{
    /// <summary>
    /// Represents the query string options.
    /// </summary>
    public class QueryOptions
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the query options type.
        /// </summary>
        public int? QueryOptionsType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include sold items only in the search results.
        /// </summary>
        public bool SoldItemsOnly { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        required public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int? Distance { get; set; }
    }
}
