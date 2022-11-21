// -----------------------------------------------------------------------
// <copyright file="Comment.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.EntityFrameworkCore;

using static EasyRank.Infrastructure.Models.DataConstraints.Comment;

namespace EasyRank.Infrastructure.Models
{
    /// <summary>
    /// The database model for user created comments.
    /// </summary>
    [Comment("The 'Comment' model for the database.")]
    public class Comment
    {
        /// <summary>
        /// Gets or sets the unique GUID identifier for a comment.
        /// </summary>
        [Key]
        [Comment("Gets or sets the unique GUID identifier for a comment.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        [Required]
        [Comment("Gets or sets the content of the comment.")]
        [MaxLength(MaxCommentLength)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date & time a comment has been created on.
        /// </summary>
        [Required]
        [Comment("Gets or sets the date & time a comment has been created on.")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a comment has been deleted.
        /// </summary>
        [Required]
        [Comment("Gets or sets a value indicating whether a comment has been deleted.")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Gets or sets the guid of the user who created the comment.
        /// </summary>
        /// <remarks>Foreign key to the 'EasyRankUser' table.</remarks>
        [Required]
        [ForeignKey(nameof(CreatedByUser))]
        [Comment("Gets or sets the guid of the user who created the comment.")]
        public Guid CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the user who created the comment.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual EasyRankUser CreatedByUser { get; set; } = null!;

        /// <summary>
        /// Gets or sets the guid of the ranking page where the comment was sent.
        /// </summary>
        /// <remarks>Foreign key to the 'RankPage' table.</remarks>
        [Required]
        [ForeignKey(nameof(RankPage))]
        [Comment("Gets or sets the guid of the ranking page where the comment was sent.")]
        public Guid RankPageId { get; set; }

        /// <summary>
        /// Gets or sets the ranking page where the comment was sent.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual RankPage RankPage { get; set; } = null!;
    }
}
