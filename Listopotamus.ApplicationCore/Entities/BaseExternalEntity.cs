// <copyright file="BaseExternalEntity.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.ApplicationCore.Entities
{
    /// <summary>
    /// Represents a base external entity.
    /// </summary>
    /// <typeparam name="T"> The type of the entity's id.</typeparam>
    public class BaseExternalEntity<T> : BaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        [Required]
        public Guid? ExternalId { get; set; }
    }
}
