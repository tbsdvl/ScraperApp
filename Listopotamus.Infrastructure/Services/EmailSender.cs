// <copyright file="EmailSender.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using FluentEmail.Core;
using FluentEmail.Core.Interfaces;
using FluentEmail.Mailgun;
using Listopotamus.Core.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Listopotamus.Infrastructure.Services
{
    /// <summary>
    /// Represents the email sender.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="EmailSender"/> class.
    /// </remarks>
    /// <param name="optionsAccessor">The options accessor.</param>
    /// <param name="logger">The logger.</param>
    public class EmailSender(
        IOptions<AuthMessageSenderOptions> optionsAccessor,
        ILogger<EmailSender> logger) : IEmailSender
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

        /// <summary>
        /// Gets the logger.
        /// </summary>
        private ILogger Logger { get; } = logger;

        /// <summary>
        /// Gets the Mailgun sender.
        /// </summary>
        private ISender MailgunSender { get; } = CreateMailgunSender(optionsAccessor.Value, logger);

        /// <summary>
        /// Gets the configured sender email address.
        /// </summary>
        private string SenderEmail { get; } = ResolveSenderEmail(optionsAccessor.Value);

        /// <summary>
        /// Gets the configured sender name.
        /// </summary>
        private string SenderName { get; } = ResolveSenderName(optionsAccessor.Value);

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="toEmail">The recepient's email.</param>
        /// <param name="subject">The email's subject.</param>
        /// <param name="message">The email's message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var email = new Email()
                .SetFrom(this.SenderEmail, this.SenderName)
                .To(toEmail)
                .Subject(subject)
                .Body(message, isHtml: true);

            var response = await this.MailgunSender.SendAsync(email);

            if (!response.Successful)
            {
                var errorMessage = response.ErrorMessages.Count > 0
                    ? string.Join(", ", response.ErrorMessages)
                    : "Unknown error";

                this.Logger.LogError("Failed to send email to {Recipient}: {ErrorMessage}", toEmail, errorMessage);
                throw new InvalidOperationException($"Failed to send email via Mailgun: {errorMessage}");
            }

            this.Logger.LogInformation("Email to {Recipient} sent via Mailgun.", toEmail);
        }

        private static ISender CreateMailgunSender(AuthMessageSenderOptions options, ILogger logger)
        {
            ArgumentNullException.ThrowIfNull(options);

            if (string.IsNullOrWhiteSpace(options.MailgunDomain))
            {
                throw new InvalidOperationException("Mailgun domain must be configured before sending email.");
            }

            if (string.IsNullOrWhiteSpace(options.MailgunApiKey))
            {
                throw new InvalidOperationException("Mailgun API key must be configured before sending email.");
            }

            var region = MailGunRegion.USA;
            if (!string.IsNullOrWhiteSpace(options.MailgunRegion))
            {
                if (Enum.TryParse(options.MailgunRegion, out MailGunRegion parsedRegion))
                {
                    region = parsedRegion;
                }
                else
                {
                    logger.LogWarning("Invalid Mailgun region '{Region}' configured. Falling back to US region.", options.MailgunRegion);
                }
            }

            return new MailgunSender(options.MailgunDomain, options.MailgunApiKey, region);
        }

        private static string ResolveSenderEmail(AuthMessageSenderOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            return string.IsNullOrWhiteSpace(options.SenderEmail)
                ? "no-reply@localhost"
                : options.SenderEmail;
        }

        private static string ResolveSenderName(AuthMessageSenderOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            return string.IsNullOrWhiteSpace(options.SenderName)
                ? "Listopotamus"
                : options.SenderName;
        }
    }
}
