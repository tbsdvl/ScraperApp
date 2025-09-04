// <copyright file="LookupDto.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.DTOs
{
    /// <summary>
    /// Represents a lookup model.
    /// </summary>
    public class LookupDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        required public int Id { get; set; }

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
