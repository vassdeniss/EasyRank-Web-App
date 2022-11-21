// -----------------------------------------------------------------------
// <copyright file="EasyRankUser.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static EasyRank.Infrastructure.Models.DataConstraints.EasyRankUserConstraints;

namespace EasyRank.Infrastructure.Models.Accounts
{
    /// <summary>
    /// The main user class used for accounts.
    /// </summary>
    [Comment("The 'EasyRankUser' model for the database.")]
    public class EasyRankUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyRankUser"/> class.
        /// Constructor for the user class.
        /// </summary>
        public EasyRankUser()
        {
            this.UserComments = new HashSet<Comment>();
            this.UserRankings = new HashSet<RankPage>();
            this.LikedRankings = new HashSet<RankPage>();
        }

        /// <summary>
        /// Gets or sets the first name for a user.
        /// </summary>
        [MaxLength(MaxFirstNameLength)]
        [Comment("Gets or sets the first name for a user.")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name for a user.
        /// </summary>
        [MaxLength(MaxLastNameLength)]
        [Comment("Gets or sets the last name for a user.")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the profile picture of the user.
        /// </summary>
        [Comment("Gets or sets the profile picture of the user.")]
        public byte[]? ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets every comment which the user has made.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual ICollection<Comment> UserComments { get; set; }

        /// <summary>
        /// Gets or sets every different rank page which the user has made.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<RankPage> UserRankings { get; set; }

        /// <summary>
        /// Gets or sets every rank page which the user has liked.
        /// </summary>
        /// <remarks>Navigational property.</remarks>
        public virtual ICollection<RankPage> LikedRankings { get; set; }
    }
}
