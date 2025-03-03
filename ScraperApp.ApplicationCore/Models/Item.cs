// <copyright file="Item.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Models
{
    /// <summary>
    /// Represents the data of an item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        required public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        // required public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        required public string Price { get; set; }
    }
}
