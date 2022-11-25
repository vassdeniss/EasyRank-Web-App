// -----------------------------------------------------------------------
// <copyright file="RankPageViewModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace EasyRank.Web.Models.Rank  
{
    /// <summary>
    /// Extended model of the rank page holding more needed properties.
    /// </summary>
    public class RankPageViewModelExtended : RankPageViewModel
    {
        /// <summary>
        /// Gets or sets every entry on the given rank page.
        /// </summary>
        public ICollection<RankEntryViewModel> Entries { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of users who liked the rank page.
        /// </summary>
        public ICollection<Guid> LikedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of comment view models on the rank page.
        /// </summary>
        public ICollection<CommentViewModel> Comments { get; set; } = null!;
    }
}
