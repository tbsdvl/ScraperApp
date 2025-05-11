// <copyright file="CategoryType.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.Core.Entities.Lookups
{
    /// <summary>
    /// Represents a category type.
    /// </summary>
    public class CategoryType : BaseLookupEntity
    {
        /// <summary>
        /// Gets or sets the marketplace type id.
        /// </summary>
        [Required]
        public int MarketplaceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the marketplace type.
        /// </summary>
        public MarketplaceType MarketplaceType { get; set; }
    }
}
