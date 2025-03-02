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
        public int QueryOptionsType { get; set; }
    }
}
