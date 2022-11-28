// -----------------------------------------------------------------------
// <copyright file="CommentServiceModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Models
{
    /// <summary>
    /// The service side model for the user comment.
    /// </summary>
    public class CommentServiceModel
    {
        /// <summary>
        /// Gets or sets the comments GUID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the profile picture of the user.
        /// </summary>
        public byte[]? ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the time and date the comment has been posted.
        /// </summary>
        public string PostedOn { get; set; } = null!;

        /// <summary>
        /// Gets or sets the comment content.
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether a comment has been edited.
        /// </summary>
        public bool IsEdited { get; set; }
    }
}
