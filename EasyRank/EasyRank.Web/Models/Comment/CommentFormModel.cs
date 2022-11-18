// -----------------------------------------------------------------------
// <copyright file="CommentFormModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using static EasyRank.Web.Models.ViewModelConstraints.CommentConstraints;

namespace EasyRank.Web.Models.Comment
{
    /// <summary>
    /// The UI side form model for the user comment.
    /// </summary>
    public class CommentFormModel
    {
        /// <summary>
        /// Gets or sets the comment content.
        /// </summary>
        [Required(ErrorMessage = CommentEmptyErrorMessage)]
        [StringLength(MaxCommentLength, MinimumLength = MinCommentLength, ErrorMessage = CommentLengthErrorMessage)]
        public string Content { get; set; } = null!;
    }
}
