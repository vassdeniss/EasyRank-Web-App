﻿// -----------------------------------------------------------------------
// <copyright file="RankPageViewModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

namespace EasyRank.Web.Models
{
    /// <summary>
    /// Extended model of the rank page holding more needed properties.
    /// </summary>
    public class RankPageViewModelExtended : RankPageViewModel
    {
        /// <summary>
        /// Gets or sets the collection of users who liked the rank page.
        /// </summary>
        public ICollection<EasyRankUser> LikedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of users who commented on the rank page.
        /// </summary>
        public ICollection<Comment> Comments { get; set; } = null!;
    }
}