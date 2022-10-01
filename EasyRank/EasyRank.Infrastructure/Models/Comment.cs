// -----------------------------------------------------------------------
// <copyright file="Comment.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Models
{
    /// <summary>
    /// The database model for user created comemnts.
    /// </summary>
    [Comment("The 'comment' model for the database.")]
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
        [MaxLength(1_000)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date & time a comment has been created on.
        /// </summary>
        [Required]
        [Comment("Gets or sets the date & time a comment has been created on.")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the guid of the user who created the comment.
        /// </summary>
        /// <remarks>Foreign key to the 'User' table.</remarks>
        [Required]
        [ForeignKey(nameof(CreatedByUser))]
        [Comment("Gets or sets the guid of the user who created the comment.")]
        public Guid CreatedByUserGuid { get; set; }

        /// <summary>
        /// Gets or sets the user who created the comment.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual User CreatedByUser { get; set; } = null!;

        // TODO: Comment location
    }
}
