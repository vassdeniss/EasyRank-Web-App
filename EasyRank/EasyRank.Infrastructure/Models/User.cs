// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Models
{
    /// <summary>
    /// The main user class used for accounts.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique GUID identifier for a user.
        /// </summary>
        [Key]
        [Comment("Gets or sets the unique GUID identifier for a user.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique username for a user.
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Comment("Gets or sets the unique username for a user.")]
        public string Username { get; set; } = null!;

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

        /// <summary>
        /// Gets or sets the unique email for a user.
        /// </summary>
        [Required]
        [MaxLength(320)]
        [Comment("Gets or sets the unique email for a user.")]
        public string Email { get; set; } = null!;

        // TODO: Avatar

        // TODO: Collections
    }
}
