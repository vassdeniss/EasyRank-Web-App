// -----------------------------------------------------------------------
// <copyright file="RankPageViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace EasyRank.Web.Models
{
    /// <summary>
    /// The ui side model for the rank page.
    /// </summary>
    public class RankPageViewModel
    {
        /// <summary>
        /// Gets or sets the unique GUID identifier for a ranking page.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the image link for a rank page.
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the alternative text if the image is broken.
        /// </summary>
        public string ImageAlt { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the ranking page.
        /// </summary>
        public string RankingTitle { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date & time a ranking page has been created on.
        /// </summary>
        public string CreatedOn { get; set; } = null!;

        // public ICollection<EasyRankUser> LikedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the like count of the ranking page.
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// Gets or sets the username for the author of the ranking page.
        /// </summary>
        public string CreatedByUserName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the comment count for the ranking page.
        /// </summary>
        public int CommentCount { get; set; }

        // public ICollection<Comment> Comments { get; set; } = null!;

        /// <summary>
        /// Gets or sets every entry on the given rank page.
        /// </summary>
        public ICollection<RankEntryViewModel> Entries { get; set; } = null!;
    }
}
