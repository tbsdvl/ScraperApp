// <copyright file="ScraperRequest.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Models
{
    /// <summary>
    /// Represents the request data for a scraping operation.
    /// </summary>
    public class ScraperRequest
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        required public string Url { get; set; }

        /// <summary>
        /// Gets or sets the query options.
        /// </summary>
        required public QueryOptions Options { get; set; }
    }
}
