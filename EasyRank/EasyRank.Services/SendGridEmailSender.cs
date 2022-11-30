// -----------------------------------------------------------------------
// <copyright file="SendGridEmailSender.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EasyRank.Services.Contracts;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace EasyRank.Services
{
    /// <summary>
    /// The SendGridEmailSender class responsible for dealing with email verifications, password resets etc.
    /// </summary>
    /// <remarks>Implementation of <see cref="IEmailSender"/>.</remarks>
    public class SendGridEmailSender : IEmailSender
    {
        private readonly SendGridClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendGridEmailSender"/> class.
        /// </summary>
        /// <param name="apiKey">The SendGrid API key to be used.</param>
        public SendGridEmailSender(string apiKey)
        {
            this.client = new SendGridClient(apiKey);
        }

        /// <inheritdoc />
        public async Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            ICollection<EmailAttachment>? attachments = null)
        {
            //if (string.IsNullOrWhiteSpace(subject) && string.IsNullOrWhiteSpace(htmlContent))
            //{
            //    throw new ArgumentException("Subject and message should be provided.");
            //}

            EmailAddress fromAddress = new EmailAddress(from, fromName);
            EmailAddress toAddress = new EmailAddress(to);
            SendGridMessage message = MailHelper.CreateSingleEmail(
                fromAddress,
                toAddress,
                subject,
                null,
                htmlContent);
            if (attachments?.Any() == true)
            {
                foreach (EmailAttachment attachment in attachments)
                {
                    message.AddAttachment(
                        attachment.FileName,
                        Convert.ToBase64String(attachment.Content),
                        attachment.MimeType);
                }
            }

            await this.client.SendEmailAsync(message);
        }
    }
}
