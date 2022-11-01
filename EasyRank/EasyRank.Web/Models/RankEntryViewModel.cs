// -----------------------------------------------------------------------
// <copyright file="ErrorViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Web.Models
{
    /// <summary>
    /// The ui side model for the rank entry.
    /// </summary>
    public class RankEntryViewModel
    {
        /// <summary>
        /// Gets or sets the placement in the ranking of the ranking entry.
        /// </summary>
        public int Placement { get; set; }

        /// <summary>
        /// Gets or sets the title for a rank entry.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets the image link for a rank entry.
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the alternative text if the image is broken.
        /// </summary>
        public string ImageAlt { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description for a rank entry.
        /// </summary>
        public string Description { get; set; } = null!;
    }
}
