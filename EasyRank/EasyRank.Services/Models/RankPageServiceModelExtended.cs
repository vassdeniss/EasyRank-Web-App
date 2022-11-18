﻿// -----------------------------------------------------------------------
// <copyright file="RankPageServiceModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

using EasyRank.Infrastructure.Models.Accounts;

namespace EasyRank.Services.Models
{
    /// <summary>
    /// Extended model of the service rank page holding more needed properties.
    /// </summary>
    public class RankPageServiceModelExtended : RankPageServiceModel
    {
        /// <summary>
        /// Gets or sets every entry on the given rank page.
        /// </summary>
        public ICollection<RankEntryServiceModel> Entries { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of users who liked the rank page.
        /// </summary>
        public ICollection<EasyRankUser> LikedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of comment view models on the rank page.
        /// </summary>
        public ICollection<CommentServiceModel> Comments { get; set; } = null!;
    }
}
