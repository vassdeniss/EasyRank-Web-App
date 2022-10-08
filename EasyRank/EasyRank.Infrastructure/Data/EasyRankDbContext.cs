// -----------------------------------------------------------------------
// <copyright file="EasyRankDbContext.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Data
{
    /// <summary>
    /// The databse context for the app.
    /// </summary>
    public class EasyRankDbContext : IdentityDbContext<EasyRankUser, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyRankDbContext"/> class.
        /// </summary>
        /// <param name="options">Options for the database.</param>
        public EasyRankDbContext(DbContextOptions<EasyRankDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the 'Comments' table from the database.
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
