// <copyright file="ScraperRequest.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.ApplicationCore.DTOs
{
    /// <summary>
    /// Represents the request data for a scraping operation.
    /// </summary>
    public class ScraperRequest
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the query options.
        /// </summary>
        [Required]
        public SearchQueryDto Query { get; set; }
    }
}
