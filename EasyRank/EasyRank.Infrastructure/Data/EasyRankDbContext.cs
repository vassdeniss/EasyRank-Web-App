// -----------------------------------------------------------------------
// <copyright file="EasyRankDbContext.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Data.Configurations;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Infrastructure.Data
{
    /// <summary>
    /// The database context for the app.
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

        /// <summary>
        /// Gets or sets the 'RankPages' table from the database.
        /// </summary>
        public DbSet<RankPage> RankPages { get; set; }

        /// <summary>
        /// Gets or sets the 'RankEntries' table from the database.
        /// </summary>
        public DbSet<RankEntry> RankEntries { get; set; }

        private EasyRankUser GuestUser { get; set; }

        private RankPage RankPage { get; set; }

        private RankEntry RankEntityStarWars { get; set; }

        private RankEntry RankEntityStarWarsTwo { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply the 'Comment' entity model configuration.
            builder.ApplyConfigurationsFromAssembly(typeof(CommentEntityTypeConfiguration).Assembly);

            // Apply the 'RankEntry' entity model configuration.
            builder.ApplyConfigurationsFromAssembly(typeof(RankEntryEntityTypeConfiguration).Assembly);

            // Apply the 'RankPage' entity model configuration.
            builder.ApplyConfigurationsFromAssembly(typeof(RankPageEntityTypeConfiguration).Assembly);

            // Database seed
            PasswordHasher<EasyRankUser> hasher = new PasswordHasher<EasyRankUser>();

            this.GuestUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guestPassword");

            builder.Entity<EasyRankUser>()
                .HasData(this.GuestUser);

            this.RankPage = new RankPage
            {
                Id = Guid.NewGuid(),
                RankingTitle = "Top 10 Best Movies of 2022",
                CreatedOn = DateTime.Today,
                CreatedByUserId = this.GuestUser.Id
            };

            this.RankEntityStarWars = new RankEntry
            {
                Id = Guid.NewGuid(),
                Placement = 10,
                Title = "Star Wars",
                Description = "Good stuff",
                RankPageId = this.RankPage.Id
            };

            this.RankEntityStarWarsTwo = new RankEntry
            {
                Id = Guid.NewGuid(),
                Placement = 9,
                Title = "Star Wars2",
                Description = "Good stuff again",
                RankPageId = this.RankPage.Id
            };

            builder.Entity<RankEntry>()
                .HasData(this.RankEntityStarWars);

            builder.Entity<RankEntry>()
                .HasData(this.RankEntityStarWarsTwo);

            builder.Entity<RankPage>()
                .HasData(this.RankPage);

            builder.Entity<RankPage>()
                .HasData(new RankPage
                {
                    Id = Guid.NewGuid(),
                    RankingTitle = "Top 5 Favorite Characters",
                    CreatedOn = DateTime.Today,
                    CreatedByUserId = this.GuestUser.Id
                });
        }
    }
}
