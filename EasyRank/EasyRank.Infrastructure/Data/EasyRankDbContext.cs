// -----------------------------------------------------------------------
// <copyright file="EasyRankDbContext.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

using EasyRank.Infrastructure.Data.Configurations;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static System.Net.Mime.MediaTypeNames;

namespace EasyRank.Infrastructure.Data
{
    /// <summary>
    /// The database context for the app.
    /// </summary>
    public class EasyRankDbContext : IdentityDbContext<EasyRankUser, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EasyRankDbContext"/> class.
        /// Constructor for the EasyRank database context.
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

        private EasyRankUser GuestUserTwo { get; set; }

        private RankPage RankPage { get; set; }

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
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guestPassword");

            this.GuestUserTwo = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = "guestTwo",
                NormalizedUserName = "GUESTTWO",
                Email = "guestTwo@mail.com",
                NormalizedEmail = "GUESTTWO@MAIL.COM",
                FirstName = "GuestTwo",
                LastName = "UserTwo",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            this.GuestUserTwo.PasswordHash = hasher.HashPassword(this.GuestUserTwo, "guestPasswordTwo");

            builder.Entity<EasyRankUser>()
                .HasData(this.GuestUser, this.GuestUserTwo);

            this.RankPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                ImageAlt = "Yoda",
                RankingTitle = "Top 10 Best Movies of 2022",
                CreatedOn = DateTime.Today,
                CreatedByUserId = this.GuestUser.Id,
            };

            builder.Entity<RankEntry>()
                .HasData(
                    new RankEntry
                    {
                        Id = Guid.NewGuid(),
                        Placement = 10,
                        Title = "Star Wars",
                        ImageAlt = "Picture of star wars",
                        Description = "Good stuff",
                        RankPageId = this.RankPage.Id,
                    },
                    new RankEntry
                    {
                        Id = Guid.NewGuid(),
                        Placement = 9,
                        Title = "Star Wars2",
                        Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                        ImageAlt = "Picture of star wars2",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.",
                        RankPageId = this.RankPage.Id,
                    });

            builder.Entity<RankPage>()
                .HasData(
                    this.RankPage,
                    new RankPage
                    {
                        Id = Guid.NewGuid(),
                        Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                        ImageAlt = "Yoda",
                        RankingTitle = "Top 5 Favorite Characters",
                        CreatedOn = DateTime.Today,
                        CreatedByUserId = this.GuestUser.Id,
                    },
                    new RankPage
                    {
                        Id = Guid.NewGuid(),
                        Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                        ImageAlt = "Yoda",
                        RankingTitle = "Top 5 Favorite Characters",
                        CreatedOn = DateTime.Today,
                        CreatedByUserId = this.GuestUser.Id,
                    },
                    new RankPage
                    {
                        Id = Guid.NewGuid(),
                        Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                        ImageAlt = "Yoda",
                        RankingTitle = "Top 5 Favorite Characters",
                        CreatedOn = DateTime.Today,
                        CreatedByUserId = this.GuestUser.Id,
                    },
                    new RankPage
                    {
                        Id = Guid.NewGuid(),
                        Image = "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534",
                        ImageAlt = "Yoda",
                        RankingTitle = "Top 5 Favorite Characters",
                        CreatedOn = DateTime.Today,
                        CreatedByUserId = this.GuestUserTwo.Id,
                    });

            builder.Entity<Comment>()
                .HasData(
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content =
                            "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CreatedOn = DateTime.Now.AddDays(-3),
                        CreatedByUserId = this.GuestUser.Id,
                        RankPageId = this.RankPage.Id,
                        IsDeleted = false,
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content =
                            "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CreatedOn = DateTime.Now.AddDays(2),
                        CreatedByUserId = this.GuestUser.Id,
                        RankPageId = this.RankPage.Id,
                        IsDeleted = false,
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content =
                            "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        CreatedOn = DateTime.Now.AddDays(-10),
                        CreatedByUserId = this.GuestUserTwo.Id,
                        RankPageId = this.RankPage.Id,
                        IsDeleted = false,
                    });
        }
    }
}
