// -----------------------------------------------------------------------
// <copyright file="RankEntryFormModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EasyRank.Web.Models.ViewModelConstraints.CommonConstraints;
using static EasyRank.Web.Models.ViewModelConstraints.RankEntryConstraints;

namespace EasyRank.Web.Models.Entry
{
    /// <summary>
    /// The UI side form model for the rank entry.
    /// </summary>
    public class RankEntryFormModel
    {
        /// <summary>
        /// Gets or sets the id of the rank entry.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the image for the rank entry.
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
        /// Gets or sets the position of the entry on the page.
        /// </summary>
        [Required]
        [Display(Name = "Placement of the entry")]
        [Range(MinPlacement, MaxPlacement)]
        public int Placement { get; set; }

        /// <summary>
        /// Gets or sets the name of the ranking entry.
        /// </summary>
        [Required]
        [Display(Name = "Entry Title")]
        [StringLength(MaxEntryTitleLength, MinimumLength = MinEntryTitleLength, ErrorMessage = EntryTitleErrorMessage)]
        public string EntryTitle { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description of the ranking entry.
        /// </summary>
        [Required]
        [Display(Name = "Entry Description")]
        [StringLength(
            MaxEntryDescriptionLength,
            MinimumLength = MinEntryDescriptionLength,
            ErrorMessage = EntryDescriptionErrorMessage)]
        public string EntryDescription { get; set; } = null!;

        public ICollection<int> AvailablePlacements { get; set; }
    }
}
