// <copyright file="BaseEntity.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.Entities
{
    /// <summary>
    /// Represents the base entity.
    /// </summary>
    /// <typeparam name="T"> The type of the entity's id.</typeparam>
    public class BaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
