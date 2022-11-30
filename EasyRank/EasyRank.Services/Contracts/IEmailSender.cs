// -----------------------------------------------------------------------
// <copyright file="IEmailSender.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyRank.Services.Contracts
{
    /// <summary>
    /// The interface for the EmailSender.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Used for sending emails to users of the app.
        /// </summary>
        /// <param name="from">The outbound email address.</param>
        /// <param name="fromName">The outbound mailer name.</param>
        /// <param name="to">The inbound email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="htmlContent">The contents of the email. (as HTML).</param>
        /// <param name="attachments">Optional attachments to the email.</param>
        /// <returns>Task (void).</returns>
        Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            ICollection<EmailAttachment>? attachments = null);
    }
}
