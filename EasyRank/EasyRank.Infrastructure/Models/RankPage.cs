// -----------------------------------------------------------------------
// <copyright file="RankPage.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Models
{
    /// <summary>
    /// The model for every different rank page in the database.
    /// </summary>
    [Comment("The 'RankPage' model for the database.")]
    public class RankPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RankPage"/> class.
        /// </summary>
        public RankPage()
        {
            this.LikedBy = new HashSet<EasyRankUser>();
            this.Comments = new HashSet<Comment>();
        }

        /// <summary>
        /// Gets or sets the unique GUID identifier for a ranking page.
        /// </summary>
        [Key]
        [Comment("Gets or sets the unique GUID identifier for a ranking page.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ranking page.
        /// </summary>
        [Required]
        [MaxLength(30)]
        [Comment("Gets or sets the name of the ranking page.")]
        public string RankingName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date & time a ranking page has been created on.
        /// </summary>
        [Required]
        [Comment("Gets or sets the date & time a ranking page has been created on.")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the collection of users who liked this ranking page.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual ICollection<EasyRankUser> LikedBy { get; set; }

        /// <summary>
        /// Gets or sets the guid of the user who created the ranking page.
        /// </summary>
        /// <remarks>Foreign key to the 'EasyRankUser' table.</remarks>
        [Required]
        [ForeignKey(nameof(CreatedByUser))]
        [Comment("Gets or sets the guid of the user who created the ranking page.")]
        public Guid CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the user who created the ranking page.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual EasyRankUser CreatedByUser { get; set; } = null!;

        /// <summary>
        /// Gets or sets every comment on the given rank page.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual ICollection<Comment> Comments { get; set; }

        // TODO: Collection of entries
    }
}
