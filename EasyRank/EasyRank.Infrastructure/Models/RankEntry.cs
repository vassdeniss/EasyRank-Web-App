// -----------------------------------------------------------------------
// <copyright file="RankEntry.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using static EasyRank.Infrastructure.Models.DataConstraints.RankEntryConstraints;

namespace EasyRank.Infrastructure.Models
{
    /// <summary>
    /// The database model for individual rank entries.
    /// </summary>
    [Comment("The 'RankEntry' model for the database.")]
    public class RankEntry
    {
        /// <summary>
        /// Gets or sets the unique GUID identifier for a rank entry.
        /// </summary>
        [Key]
        [Comment("Gets or sets the unique GUID identifier for a rank entry.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the placement in the ranking of the ranking entry.
        /// </summary>
        [Required]
        [Comment("Gets or sets the placement in the ranking of the ranking entry.")]
        public int Placement { get; set; }

        /// <summary>
        /// Gets or sets the title for a rank entry.
        /// </summary>
        [Required]
        [MaxLength(MaxEntryTitle)]
        [Comment("Gets or sets the title for a rank entry.")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets the image link for a rank entry.
        /// </summary>
        [MaxLength(MaxImageLinkLength)]
        [Unicode(false)]
        [Comment("Gets or sets the image link for a rank entry.")]
        public string? Image { get; set; }

        /// <summary>
        /// Gets or sets the description for a rank entry.
        /// </summary>
        [Required]
        [MaxLength(MaxEntryDescription)]
        [Comment("Gets or sets the description for a rank entry.")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Gets or sets the guid of the rank page which the entry belongs to.
        /// </summary>
        /// <remarks>Foreign key to the 'RankPage' table.</remarks>
        [Required]
        [Comment("Gets or sets the guid of the rank page which the entry belongs to.")]
        public Guid RankPageId { get; set; }

        /// <summary>
        /// Gets or sets the guid of the rank page which the entry belongs to.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual RankPage RankPage { get; set; } = null!;
    }
}
