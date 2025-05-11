// <copyright file="User.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EGov.ApplicationCore.Entities.Identity
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User : IdentityUser<long>
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user account is active.
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// Gets or sets the reports to user Id.
        /// </summary>
        public int? ReportsToUserId { get; set; }

        /// <summary>
        /// Gets or sets the user object id. This is the unique identifier
        /// of the user's azure account.
        /// </summary>
        [MaxLength(256)]
        public string UserObjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the enable notifications flag.
        /// </summary>
        [Required]
        public bool NotificationsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the user that updated the user account.
        /// </summary>
        [Required]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date the user account was updated.
        /// </summary>
        [Required]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the exteral id.
        /// </summary>
        [Required]
        public Guid? ExternalId { get; set; }
    }
}
