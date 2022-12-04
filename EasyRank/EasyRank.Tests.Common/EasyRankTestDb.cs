// -----------------------------------------------------------------------
// <copyright file="EasyRankTestDb.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Data;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EasyRank.Tests.Common
{
    public class EasyRankTestDb
    {
        public EasyRankTestDb(EasyRankDbContext dbContext)
        {
            this.SeedDatabase(dbContext);
        }

        public EasyRankUser GuestUser { get; set; }

        public EasyRankUser DenisUser { get; set; }

        public EasyRankUser LikedUser { get; set; }

        public EasyRankUser DislikedUser { get; set; }

        public EasyRankUser UnconfirmedUser { get; set; }

        public RankPage GuestPage { get; set; }

        public RankPage DeletedPage { get; set; }

        public RankPage LikedPage { get; set; }

        public RankPage DislikedPage { get; set; }

        public RankEntry DeletedEntry { get; set; }

        public RankEntry GuestEntry { get; set; }

        public Comment GuestComment { get; set; }

        public Comment DeletedComment { get; set; }

        public Comment DenisComment { get; set; }

        public Comment CommentWithDeletedPage { get; set; }

        public EasyRankUserRankPage LikedMap { get; set; }

        public EasyRankUserRankPage DislikedMap { get; set; }

        private void SeedDatabase(EasyRankDbContext dbContext)
        {
            UserOnlyStore<EasyRankUser, EasyRankDbContext, Guid> userStore = 
                new UserOnlyStore<EasyRankUser, EasyRankDbContext, Guid>(dbContext);
            PasswordHasher<EasyRankUser> hasher = new PasswordHasher<EasyRankUser>();
            UpperInvariantLookupNormalizer normalizer = new UpperInvariantLookupNormalizer();
            UserManager<EasyRankUser> userManager = new UserManager<EasyRankUser>(
                userStore, 
                null, 
                hasher, 
                null, null, 
                normalizer, 
                null, null, null);

            this.GuestUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = $"guest{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"GUEST{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM", 
                FirstName = "Guest",
                LastName = "User",
                EmailConfirmed = true,
            };

            userManager.CreateAsync(this.GuestUser, "guestPass")
                .Wait();

            this.DenisUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = $"vass{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"VASS{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "vassdeniss@mail.com",
                NormalizedEmail = "VASSDENISS@MAIL.COM",
                FirstName = string.Empty,
                LastName = string.Empty,
                EmailConfirmed = false,
            };

            userManager.CreateAsync(this.DenisUser, "myVeryCoolPassword")
                .Wait();

            this.LikedUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = $"Liked{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"LIKED{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "liked@mail.com",
                NormalizedEmail = "LIKED@MAIL.COM",
                FirstName = string.Empty,
                LastName = string.Empty,
                EmailConfirmed = true,
            };

            userManager.CreateAsync(this.LikedUser, "iLikePagesYay")
                .Wait();

            this.DislikedUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = $"Disliked{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"DISLIKED{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "disliked@mail.com",
                NormalizedEmail = "DISLIKED@MAIL.COM",
                FirstName = string.Empty,
                LastName = string.Empty,
                EmailConfirmed = true,
            };

            userManager.CreateAsync(this.DislikedUser, "iDislikePagesYay")
                .Wait();

            this.UnconfirmedUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                UserName = $"Unconfirmed{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"UNCONFIRMED{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "unconfirmed@mail.com",
                NormalizedEmail = "UNCONFIRMED@MAIL.COM",
                FirstName = string.Empty,
                LastName = string.Empty,
                EmailConfirmed = false,
            };

            userManager.CreateAsync(this.UnconfirmedUser, "unconfirmed")
                .Wait();

            this.GuestPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = null,
                ImageAlt = "Yoda",
                RankingTitle = "Top 5 Favorite Characters",
                CreatedOn = DateTime.Now.AddHours(-2),
                CreatedByUserId = this.GuestUser.Id,
                IsDeleted = false,
            };

            dbContext.Add<RankPage>(this.GuestPage);

            this.LikedPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = null,
                ImageAlt = "Just image",
                RankingTitle = "Top 5 Liked Posts",
                CreatedOn = DateTime.Now.AddHours(-3),
                CreatedByUserId = this.LikedUser.Id,
                IsDeleted = false,
            };

            dbContext.Add<RankPage>(this.LikedPage);

            this.DislikedPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = null,
                ImageAlt = "Just stupid image",
                RankingTitle = "Top 5 Disliked Posts",
                CreatedOn = DateTime.Now.AddHours(-4),
                CreatedByUserId = this.DislikedUser.Id,
                IsDeleted = false,
            };

            dbContext.Add<RankPage>(this.DislikedPage);

            this.DeletedPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = null,
                ImageAlt = "DeletedImg",
                RankingTitle = "DeletedPage",
                CreatedOn = DateTime.Now.AddHours(-5),
                CreatedByUserId = this.GuestUser.Id,
                IsDeleted = true,
            };

            dbContext.Add<RankPage>(this.DeletedPage);

            this.DeletedEntry = new RankEntry
            {
                Id = Guid.NewGuid(),
                Placement = 3,
                Title = "DeletedEntry",
                Image = null,
                ImageAlt = "DeletedImg",
                Description = "DeletedDescription",
                IsDeleted = true,
                RankPageId = this.GuestPage.Id,
            };

            dbContext.Add<RankEntry>(this.DeletedEntry);

            this.GuestEntry = new RankEntry
            {
                Id = Guid.NewGuid(),
                Placement = 2,
                Title = "GuestEntry",
                Image = null,
                ImageAlt = "GuestImg",
                Description = "GuestDescription",
                IsDeleted = false,
                RankPageId = this.GuestPage.Id,
            };

            dbContext.Add<RankEntry>(this.GuestEntry);

            this.GuestComment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Comment made by the GuestUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(-10),
                CreatedByUserId = this.GuestUser.Id,
                RankPageId = this.GuestPage.Id,
                IsDeleted = false,
            };

            dbContext.Add<Comment>(this.GuestComment);

            this.DeletedComment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Deleted comment made by the GuestUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(-2),
                CreatedByUserId = this.GuestUser.Id,
                RankPageId = this.DeletedPage.Id,
                IsDeleted = true,
            };

            dbContext.Add<Comment>(this.DeletedComment);

            this.DenisComment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Deleted comment made by the DenisUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(-7),
                CreatedByUserId = this.DenisUser.Id,
                RankPageId = this.GuestPage.Id,
                IsDeleted = false,
            };

            dbContext.Add<Comment>(this.DenisComment);

            this.CommentWithDeletedPage = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Existing comment with deleted page made by the GuestUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(-5),
                CreatedByUserId = this.GuestUser.Id,
                RankPageId = this.DeletedPage.Id,
                IsDeleted = false,
            };

            dbContext.Add<Comment>(this.CommentWithDeletedPage);

            this.LikedMap = new EasyRankUserRankPage
            {
                EasyRankUserId = this.LikedUser.Id,
                RankPageId = this.LikedPage.Id,
                IsLiked = true,
            };

            dbContext.Add<EasyRankUserRankPage>(this.LikedMap);

            this.DislikedMap = new EasyRankUserRankPage
            {
                EasyRankUserId = this.DislikedUser.Id,
                RankPageId = this.DislikedPage.Id,
                IsLiked = false,
            };

            dbContext.Add<EasyRankUserRankPage>(this.DislikedMap);

            dbContext.SaveChanges();
        }
    }
}
