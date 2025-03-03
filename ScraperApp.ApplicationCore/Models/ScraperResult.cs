// <copyright file="ScraperResult.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Models
{
    /// <summary>
    /// Represents the result of a scraping operation.
    /// </summary>
    public class ScraperResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether or not the result succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public object? Data { get; set; }
    }
}
