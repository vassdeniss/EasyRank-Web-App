// -----------------------------------------------------------------------
// <copyright file="RankEntryViewModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

using EasyRank.Web.Models.Rank;

namespace EasyRank.Web.Areas.Admin.Models.Entry
{
    /// <summary>
    /// Extended model of the rank entry holding more needed properties.
    /// </summary>
    public class RankEntryViewModelExtended : RankEntryViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the rank page.
        /// </summary>
        public Guid RankPageId { get; set; }

        /// <summary>
        /// Gets or sets the username of the creator of the entry.
        /// </summary>
        public string Username { get; set; } = null!;
    }
}
