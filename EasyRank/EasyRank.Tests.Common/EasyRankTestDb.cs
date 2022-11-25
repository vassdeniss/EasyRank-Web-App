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

        public RankPage GuestPage { get; set; }

        public RankPage DeletedPage { get; set; }

        public Comment GuestComment { get; set; }

        public Comment DeletedComment { get; set; }

        public Comment CommentWithDeletedPage { get; set; }

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
                EmailConfirmed = true,
            };

            userManager.CreateAsync(this.DenisUser, "myVeryCoolPassword")
                .Wait();

            this.GuestPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = null,
                ImageAlt = "Yoda",
                RankingTitle = "Top 5 Favorite Characters",
                CreatedOn = DateTime.Today,
                CreatedByUserId = this.GuestUser.Id,
                IsDeleted = false,
            };

            dbContext.Add<RankPage>(this.GuestPage);

            this.DeletedPage = new RankPage
            {
                Id = Guid.NewGuid(),
                Image = null,
                ImageAlt = "DeletedImg",
                RankingTitle = "DeletedPage",
                CreatedOn = DateTime.Today,
                CreatedByUserId = this.GuestUser.Id,
                IsDeleted = true,
            };

            dbContext.Add<RankPage>(this.DeletedPage);

            this.GuestComment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Comment made by the GuestUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(2),
                CreatedByUserId = this.GuestUser.Id,
                RankPageId = this.GuestPage.Id,
                IsDeleted = false,
            };

            dbContext.Add<Comment>(this.GuestComment);

            this.DeletedComment = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Deleted comment made by the GuestUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(2),
                CreatedByUserId = this.GuestUser.Id,
                RankPageId = this.DeletedPage.Id,
                IsDeleted = true,
            };

            dbContext.Add<Comment>(this.DeletedComment);

            this.CommentWithDeletedPage = new Comment
            {
                Id = Guid.NewGuid(),
                Content = "Existing comment with deleted page made by the GuestUser for testing purposes",
                CreatedOn = DateTime.Now.AddDays(2),
                CreatedByUserId = this.GuestUser.Id,
                RankPageId = this.DeletedPage.Id,
                IsDeleted = false,
            };

            dbContext.Add<Comment>(this.CommentWithDeletedPage);

            dbContext.SaveChanges();
        }
    }
}
