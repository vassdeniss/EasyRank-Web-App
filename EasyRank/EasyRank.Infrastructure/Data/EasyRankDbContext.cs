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

namespace EasyRank.Infrastructure.Data
{
    /// <summary>
    /// The database context for the app.
    /// </summary>
    public class EasyRankDbContext : IdentityDbContext<EasyRankUser, EasyRankRole, Guid>
    {
        private readonly bool isSeed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EasyRankDbContext"/> class.
        /// Constructor for the EasyRank database context.
        /// </summary>
        /// <param name="options">Options for the database.</param>
        /// <param name="isSeed">Should the database be seeded.</param>
        public EasyRankDbContext(DbContextOptions<EasyRankDbContext> options, bool isSeed = true)
            : base(options)
        {
            this.isSeed = isSeed;
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

        /// <summary>
        /// Gets or sets the 'EasyRankUserRankPage' table from the database.
        /// </summary>
        public DbSet<EasyRankUserRankPage> EasyRankUsersRankPages { get; set; }

        private EasyRankUser GuestUser { get; set; }

        private EasyRankUser GuestUserTwo { get; set; }

        private EasyRankUser AdminUser { get; set; }

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

            // Apply the 'EasyRankUserRankPage' entity model configuration.
            builder.ApplyConfigurationsFromAssembly(typeof(EasyRankUserRankPageEntityTypeConfiguration).Assembly);

            PasswordHasher<EasyRankUser> hasher = new PasswordHasher<EasyRankUser>();

            this.AdminUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = "vassdeniss",
                NormalizedUserName = "VASSDENISS",
                Email = "vassdeniss@gmail.com",
                NormalizedEmail = "VASSDENISS@GMAIL.COM",
                FirstName = "Denis",
                LastName = "Vasilev",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            this.AdminUser.PasswordHash = hasher.HashPassword(this.AdminUser, "admin-pass");

            builder.Entity<EasyRankUser>()
                .HasData(this.AdminUser);

            // Database seed
            if (!this.isSeed)
            {
                return;
            }


            //this.GuestUser = new EasyRankUser
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = "guest",
            //    NormalizedUserName = "GUEST",
            //    Email = "guest@mail.com",
            //    NormalizedEmail = "GUEST@MAIL.COM",
            //    FirstName = "Guest",
            //    LastName = "User",
            //    EmailConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),
            //};

            //this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guestPassword");

            //this.GuestUserTwo = new EasyRankUser
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = "guestTwo",
            //    NormalizedUserName = "GUESTTWO",
            //    Email = "guestTwo@mail.com",
            //    NormalizedEmail = "GUESTTWO@MAIL.COM",
            //    FirstName = "GuestTwo",
            //    LastName = "UserTwo",
            //    EmailConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),
            //};

            //this.GuestUserTwo.PasswordHash = hasher.HashPassword(this.GuestUserTwo, "guestPasswordTwo");

            //builder.Entity<EasyRankUser>()
            //    .HasData(this.GuestUser, this.GuestUserTwo, this.AdminUser);

            //this.RankPage = new RankPage
            //{
            //    Id = Guid.NewGuid(),
            //    Image = null,
            //    ImageAlt = "Yoda",
            //    RankingTitle = "Top 10 Best Movies of 2022",
            //    CreatedOn = DateTime.Today,
            //    CreatedByUserId = this.GuestUser.Id,
            //    IsDeleted = false,
            //};

            //builder.Entity<RankEntry>()
            //    .HasData(
            //        new RankEntry
            //        {
            //            Id = Guid.NewGuid(),
            //            Placement = 10,
            //            Title = "Star Wars",
            //            ImageAlt = "Picture of star wars",
            //            Description = "Good stuff",
            //            RankPageId = this.RankPage.Id,
            //        },
            //        new RankEntry
            //        {
            //            Id = Guid.NewGuid(),
            //            Placement = 9,
            //            Title = "Star Wars2",
            //            //Image = null,
            //            ImageAlt = "Picture of star wars2",
            //            Description =
            //                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.",
            //            RankPageId = this.RankPage.Id,
            //        });

            //builder.Entity<RankPage>()
            //    .HasData(
            //        this.RankPage,
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUser.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUser.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUser.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        },
            //        new RankPage
            //        {
            //            Id = Guid.NewGuid(),
            //            Image = null,
            //            ImageAlt = "Yoda",
            //            RankingTitle = "Top 5 Favorite Characters",
            //            CreatedOn = DateTime.Today,
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            IsDeleted = false,
            //        });

            //builder.Entity<Comment>()
            //    .HasData(
            //        new Comment
            //        {
            //            Id = Guid.NewGuid(),
            //            Content =
            //                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //            CreatedOn = DateTime.Now.AddDays(-3),
            //            CreatedByUserId = this.GuestUser.Id,
            //            RankPageId = this.RankPage.Id,
            //            IsDeleted = false,
            //        },
            //        new Comment
            //        {
            //            Id = Guid.NewGuid(),
            //            Content =
            //                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //            CreatedOn = DateTime.Now.AddDays(2),
            //            CreatedByUserId = this.GuestUser.Id,
            //            RankPageId = this.RankPage.Id,
            //            IsDeleted = false,
            //        },
            //        new Comment
            //        {
            //            Id = Guid.NewGuid(),
            //            Content =
            //                "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //            CreatedOn = DateTime.Now.AddDays(-10),
            //            CreatedByUserId = this.GuestUserTwo.Id,
            //            RankPageId = this.RankPage.Id,
            //            IsDeleted = false,
            //        });
        }
    }
}
