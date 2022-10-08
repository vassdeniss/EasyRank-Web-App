// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Models.Accounts
{
    /// <summary>
    /// The main user class used for accounts.
    /// </summary>
    [Comment("The 'easyRankUser' model for the database.")]
    public class EasyRankUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Gets or sets the first name for a user.
        /// </summary>
        [MaxLength(8)]
        [Comment("Gets or sets the first name for a user.")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name for a user.
        /// </summary>
        [MaxLength(10)]
        [Comment("Gets or sets the last name for a user.")]
        public string? LastName { get; set; }

        // TODO: Avatar

        // TODO: Collections
    }
}
