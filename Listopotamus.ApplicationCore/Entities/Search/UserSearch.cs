// <copyright file="UserSearch.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Listopotamus.ApplicationCore.Entities.Identity;

namespace Listopotamus.ApplicationCore.Entities.Search
{
    /// <summary>
    /// Represents a user search.
    /// </summary>
    public class UserSearch : BaseExternalEntity<long?>
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [ForeignKey(nameof(User))]
        [Required]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets the search query id.
        /// </summary>
        [ForeignKey(nameof(SearchQuery))]
        [Required]
        public long? SearchQueryId { get; set; }

        /// <summary>
        /// Gets or sets the SearchDate.
        /// </summary>
        [Required]
        public DateTime? SearchDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user got notified of the search.
        /// </summary>
        [Required]
        public bool IsNotified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the search is archived.
        /// </summary>
        [Required]
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public SearchQuery SearchQuery { get; set; }
    }
}
