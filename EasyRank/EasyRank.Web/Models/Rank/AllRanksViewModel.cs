// -----------------------------------------------------------------------
// <copyright file="AllRanksViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace EasyRank.Web.Models.Rank
{
    /// <summary>
    /// The UI side model for visualizing all ranks.
    /// </summary>
    public class AllRanksViewModel
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets all the ranks of the app.
        /// </summary>
        public ICollection<RankPageViewModel> Ranks { get; set; } = null!;

        /// <summary>
        /// Gets or sets the total amount of pages.
        /// </summary>
        public int TotalRankCount { get; set; }
    }
}
