// <copyright file="AuthMessageSenderOptions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.Core.Models
{
    /// <summary>
    /// The auth message sender options.
    /// </summary>
    public class AuthMessageSenderOptions
    {
        /// <summary>
        /// Gets or sets the default email address used when sending messages.
        /// </summary>
        public string? SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the human friendly display name associated with the sender.
        /// </summary>
        public string? SenderName { get; set; }

        /// <summary>
        /// Gets or sets the Mailgun API key used when authenticating requests.
        /// </summary>
        public string? MailgunApiKey { get; set; }

        /// <summary>
        /// Gets or sets the Mailgun domain the application should send from.
        /// </summary>
        public string? MailgunDomain { get; set; }

        /// <summary>
        /// Gets or sets the Mailgun region (for example, "US" or "EU").
        /// </summary>
        public string? MailgunRegion { get; set; }
    }
}
