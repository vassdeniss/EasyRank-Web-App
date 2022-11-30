// -----------------------------------------------------------------------
// <copyright file="EmailAttachment.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Services
{
    /// <summary>
    /// An email class for an attachment.
    /// </summary>
    public class EmailAttachment
    {
        /// <summary>
        /// Gets or sets the attachment itself.
        /// </summary>
        public byte[] Content { get; set; } = null!;

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the mime type.
        /// </summary>
        public string MimeType { get; set; } = null!;
    }
}
