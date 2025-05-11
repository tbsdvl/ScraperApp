// <copyright file="BaseLookupEntity.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.ApplicationCore.Entities
{
    /// <summary>
    /// Represents the base lookup entity.
    /// </summary>
    public class BaseLookupEntity : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the lookup value.
        /// </summary>
        [Required]
        public string LookupValue { get; set; }
    }
}
