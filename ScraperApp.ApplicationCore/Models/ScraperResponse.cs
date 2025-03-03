// <copyright file="ScraperResponse.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Models
{
    /// <summary>
    /// Represents a scraper response.
    /// </summary>
    public class ScraperResponse
    {
        /// <summary>
        /// Gets or sets the list of items.
        /// </summary>
        required public List<Item> Items { get; set; }
    }
}
