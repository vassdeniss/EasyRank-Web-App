// -----------------------------------------------------------------------
// <copyright file="AllRanksServiceModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace EasyRank.Services.Models.Rank
{
    /// <summary>
    /// The service side model for visualizing all ranks.
    /// </summary>
    public class AllRanksServiceModel
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets all the ranks of the app.
        /// </summary>
        public ICollection<RankPageServiceModel> Ranks { get; set; } = null!;

        /// <summary>
        /// Gets or sets the total amount of pages.
        /// </summary>
        public int TotalRankCount { get; set; }
    }
}
