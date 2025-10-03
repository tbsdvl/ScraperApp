// <copyright file="EmailSender.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Core.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

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
        /// Sends an email.
        /// </summary>
        /// <param name="toEmail">The recepient's email.</param>
        /// <param name="subject">The email's subject.</param>
        /// <param name="message">The email's message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(this.Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }

            await this.Execute(this.Options.SendGridKey, subject, message, toEmail);
        }

        /// <summary>
        /// Sends an email using the SendGrid service.
        /// </summary>
        /// <param name="apiKey">The API key used to authenticate with the SendGrid service. Cannot be null or empty.</param>
        /// <param name="subject">The subject line of the email. Cannot be null or empty.</param>
        /// <param name="message">The content of the email, provided as both plain text and HTML. Cannot be null or empty.</param>
        /// <param name="toEmail">The recipient's email address. Must be a valid email address and cannot be null or empty.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Joe@contoso.com", "Password Recovery"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message,
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            this.Logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
