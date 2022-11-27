// -----------------------------------------------------------------------
// <copyright file="RankPageFormModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using static EasyRank.Web.Models.ViewModelConstraints.CommonConstraints;
using static EasyRank.Web.Models.ViewModelConstraints.RankPageConstraints;

namespace EasyRank.Web.Models.Rank
{
    /// <summary>
    /// The UI side form model for the rank page.
    /// </summary>
    public class RankPageFormModel
    {
        /// <summary>
        /// Gets or sets the id of the rank page.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the image for the rank page.
        /// </summary>
        [Display(Name = "Cover Image")]
        public byte[]? Image { get; set; }

        /// <summary>
        /// Gets or sets the alternative text if the image is broken.
        /// </summary>
        [Required]
        [Display(Name = "Alternative Text for Image")]
        [StringLength(MaxImageAltLength, MinimumLength = MinImageAltLength, ErrorMessage = ImageAltErrorMessage)]
        public string ImageAlt { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the ranking page.
        /// </summary>
        [Required]
        [Display(Name = "Rank Title")]
        [StringLength(MaxRankTitleLength, MinimumLength = MinRankTitleLength, ErrorMessage = RankTitleErrorMessage)]
        public string RankingTitle { get; set; } = null!;
    }
}
