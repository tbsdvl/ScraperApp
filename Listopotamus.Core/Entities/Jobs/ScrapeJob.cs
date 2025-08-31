// <copyright file="ScrapeJob.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Listopotamus.Core.Entities.Jobs
{
    /// <summary>
    /// Represents a scrape job.
    /// </summary>
    public class ScrapeJob : BaseExternalEntity<long?>
    {
        /// <summary>
        /// Gets or sets the search query id.
        /// </summary>
        [Required]
        public long? SearchQueryId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [Required]
        public int? Status { get; set; }

        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        public int? Progress { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
