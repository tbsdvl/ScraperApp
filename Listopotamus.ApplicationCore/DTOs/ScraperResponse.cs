// <copyright file="ScraperResponse.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.DTOs
{
    /// <summary>
    /// Represents a scraper response.
    /// </summary>
    public class ScraperResponse
    {
        /// <summary>
        /// Gets or sets the list of items.
        /// </summary>
        required public List<ItemDto> Items { get; set; }

        /// <summary>
        /// Gets or sets an error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the response succeeded.
        /// </summary>
        public bool Succeeded { get; set; } = false;
    }
}
