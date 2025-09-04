// <copyright file="LocationType.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.ApplicationCore.Entities.Lookups
{
    /// <summary>
    /// Represents a location type.
    /// </summary>
    public class LocationType : BaseLookupEntity
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
