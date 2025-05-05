// <copyright file="BaseLookupEntity.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Entities
{
    /// <summary>
    /// Represents the base lookup entity.
    /// </summary>
    public class BaseLookupEntity : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}
