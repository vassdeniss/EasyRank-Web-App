// -----------------------------------------------------------------------
// <copyright file="EasyRankDbContext.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Data
{
    /// <summary>
    /// The databse context for the app.
    /// </summary>
    public class EasyRankDbContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyRankDbContext"/> class.
        /// </summary>

        #pragma warning disable CS8618

        // Non-nullable field must contain a non-null value when exiting constructor.
        // Consider declaring as nullable.
        public EasyRankDbContext()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EasyRankDbContext"/> class.
        /// </summary>
        /// <param name="options">Options for the database.</param>

        #pragma warning disable CS8618

        // Non-nullable field must contain a non-null value when exiting constructor.
        // Consider declaring as nullable.
        public EasyRankDbContext(DbContextOptions<EasyRankDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the 'users' table from the database.
        /// </summary>

        #pragma warning disable CS0114

        // Member hides inherited member;
        // missing override keyword
        public DbSet<User> Users { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
