// -----------------------------------------------------------------------
// <copyright file="RankServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class RankServiceTests : UnitTestBase
    {
        private IRankService rankService;

        [SetUp]
        public void SetUp()
        {
            this.rankService = new RankService(this.repo, this.mapper);
        }

        [Test]
        public async Task Test_GetAllRankings_ReturnsCorrectCount()
        {
            // Arrange: get 'RankPage' count from database (where pages are not deleted)
            int databaseCount = await this.repo.AllReadonly<RankPage>()
                .Where(rp => !rp.IsDeleted)
                .CountAsync();

            // Act: call service method and get ranks count
            ICollection<RankPageServiceModel> serviceModel = await this.rankService.GetAllRankingsAsync();
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }

        [Test]
        public void Test_GetRankPageByGuid_InvalidRankId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.GetRankPageByGuidAsync(invalidId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetRankPageByGuid_DeletedRankPage_ThrowsNotFoundException()
        {
            // Arrange: get deleted rank page from test db
            Guid deletedPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted id
            Assert.That(
                async() => await this.rankService.GetRankPageByGuidAsync(deletedPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetRankPageByGuid_ValidId_ReturnsCorrectPage()
        {
            // Arrange: get 'GuestPage' id from test db
            Guid guestRankPageId = this.testDb.GuestPage.Id;

            // Act: call service method with the 'GuestPage' id
            RankPageServiceModel serviceModel = await this.rankService.GetRankPageByGuidAsync(guestRankPageId);

            // Assert: both ids must be equal
            Assert.That(serviceModel.Id, Is.EqualTo(guestRankPageId));
        }

        [Test]
        public void Test_GetExtendedRankPageByGuid_InvalidRankId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.GetExtendedRankPageByGuidAsync(invalidId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetExtendedRankPageByGuid_DeletedRankPage_ThrowsNotFoundException()
        {
            // Arrange: get deleted rank page from test db
            Guid deletedPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted id
            Assert.That(
                async() => await this.rankService.GetExtendedRankPageByGuidAsync(deletedPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetExtendedRankPageByGuid_ValidId_ReturnsCorrectPage()
        {
            // Arrange: get 'GuestPage' id from test db
            Guid guestRankPageId = this.testDb.GuestPage.Id;

            // Act: call service method with the 'GuestPage' id
            RankPageServiceModel serviceModel = await this.rankService.GetExtendedRankPageByGuidAsync(guestRankPageId);

            // Assert: both ids must be equal
            Assert.That(serviceModel.Id, Is.EqualTo(guestRankPageId));
        }

        [Test]
        public async Task Test_GetAllRankingsByUser_ReturnsCorrectCount()
        {
            // Arrange: get 'RankPage' count (where pages are not deleted and filtered by user),
            // get 'GuestUser' id from database
            Guid guestUserId = this.testDb.GuestUser.Id;
            int databaseCount = await this.repo.AllReadonly<RankPage>()
                .Where(rp => !rp.IsDeleted && rp.CreatedByUserId == guestUserId)
                .CountAsync();

            // Act: call service method and get ranks count
            ICollection<RankPageServiceModel> serviceModel = 
                await this.rankService.GetAllRankingsByUserAsync(guestUserId);
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_InvalidRankPageId_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, initialise invalid id
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid invalidRankPageId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.IsCurrentUserPageOwner(guestUserId, invalidRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_DeletedPage_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, get deleted rank page id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid deletedRankPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async() => await this.rankService.IsCurrentUserPageOwner(guestUserId, deletedRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_NotCorrectOwnerId_ThrowsUnauthorizedUserException()
        {
            // Arrange: get denis user id, get guest rank page id from test db
            Guid denisUserId = this.testDb.DenisUser.Id;
            Guid guestRankPageId = this.testDb.GuestPage.Id;

            // Act:

            // Assert: UnauthorizedUserException is thrown with denis user id
            Assert.That(
                async() => await this.rankService.IsCurrentUserPageOwner(denisUserId, guestRankPageId),
                Throws.Exception.TypeOf<UnauthorizedUserException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_ValidRankPageId_DoesNotThrow()
        {
            // Arrange: get guest user id, get guest rank page id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid guestRankPageId = this.testDb.GuestPage.Id;

            // Act:

            // Assert: no exceptions are thrown
            Assert.That(
                async() => await this.rankService.IsCurrentUserPageOwner(guestUserId, guestRankPageId),
                 Throws.Nothing);
        }

        [Test]
        public async Task Test_CreateRank_AddsSuccessfully()
        {
            // Arrange: get the count of pages before adding from the database
            int rankPageCountBefore = await this.repo.AllReadonly<RankPage>()
                .CountAsync();

            // Arrange: create data for a new rank page to be added
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing creating page";
            string rankingTitle = "Top 10 Rank Page I Want to Create in the Future";
            Guid createdByUserId = this.testDb.GuestUser.Id;

            // Act: call the service method and pass the necessary data
            await this.rankService.CreateRankAsync(image, imageAlt, rankingTitle, createdByUserId);

            // Assert: the count of rank pages in teh database has increased by one
            int rankPagesCountAfter = await this.repo.AllReadonly<RankPage>()
                .CountAsync();
            Assert.That(rankPagesCountAfter, Is.EqualTo(rankPageCountBefore + 1));

            // Assert: the new comment has been added
            RankPage? newRankPageInDb = await this.repo.AllReadonly<RankPage>()
                .OrderByDescending(rp => rp.CreatedOn)
                .FirstOrDefaultAsync();
            Assert.That(newRankPageInDb, Is.Not.Null);
            Assert.That(newRankPageInDb!.ImageAlt, Is.EqualTo(imageAlt));
            Assert.That(newRankPageInDb.RankingTitle, Is.EqualTo(rankingTitle));
            Assert.That(newRankPageInDb.CreatedByUserId, Is.EqualTo(createdByUserId));
        }

        [Test]
        public void Test_EditRank_InvalidRankPageId_ThrowsNotFoundException()
        {
            // Arrange: initialise valid new data, initialise invalid id
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing edit page";
            string rankingTitle = "Top 10 Rank Page I Want to Edit in the Future";
            Guid invalidRankPageId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.EditRankAsync(invalidRankPageId, rankingTitle, imageAlt, image),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_EditRank_DeletedRankPage_ThrowsNotFoundException()
        {
            // Arrange: initialise valid new content, get deleted rank page id from test db
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing edit page";
            string rankingTitle = "Top 10 Rank Page I Want to Edit in the Future";
            Guid deletedRankPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.EditRankAsync(deletedRankPageId, rankingTitle, imageAlt, image),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_EditRank_ChangesSuccessfully()
        {
            // Arrange: create data for a new rank page to be added
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing edit page";
            string rankingTitle = "Top 10 Rank Page I Want to Edit in the Future"; 
            Guid createdByUserId = this.testDb.GuestUser.Id;

            // Arrange: call the add service method and pass the necessary data
            await this.rankService.CreateRankAsync(image, imageAlt, rankingTitle, createdByUserId);

            RankPage pageInDb = (await this.repo.AllReadonly<RankPage>()
                .OrderByDescending(rp => rp.CreatedOn)
                .FirstOrDefaultAsync())!;

            // Arrange: create new data to be changed
            string changedTitle = "Top (10) 5 Rank Page I Want to Edit in the Future";

            // Act: call the edit service method and pass the necessary data
            await this.rankService.EditRankAsync(pageInDb.Id, changedTitle, imageAlt, image);

            // Assert: the comment has been edited
            RankPage? newRankPageInDb = await this.repo.AllReadonly<RankPage>()
                .OrderByDescending(rp => rp.CreatedOn)
                .FirstOrDefaultAsync();
            Assert.That(newRankPageInDb, Is.Not.Null);
            Assert.That(newRankPageInDb!.RankingTitle, Is.EqualTo(changedTitle));
            Assert.That(newRankPageInDb.ImageAlt, Is.EqualTo(imageAlt));
            Assert.That(newRankPageInDb.CreatedByUserId, Is.EqualTo(createdByUserId));
        }

        [Test]
        public void Test_DeleteRank_InvalidRankPageId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidRankPageId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.DeleteRankAsync(invalidRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_DeleteRank_DeletedRankPage_ThrowsNotFoundException()
        {
            // Arrange: get deleted rank page id from test db
            Guid deletedRankPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.DeleteRankAsync(deletedRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteRank_RemovesSuccessfully()
        {
            // Arrange: create data for a new rank page to be added
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing delete page";
            string rankingTitle = "Top 10 Rank Page I Want to Delete in the Future";
            Guid createdByUserId = this.testDb.GuestUser.Id;

            // Arrange: call the add service method and pass the necessary data
            await this.rankService.CreateRankAsync(image, imageAlt, rankingTitle, createdByUserId);

            RankPage rankPageInDb = (await this.repo.AllReadonly<RankPage>()
                .OrderByDescending(rp => rp.CreatedOn)
                .FirstOrDefaultAsync())!;

            // Act: call the delete service method and pass the necessary data
            await this.rankService.DeleteRankAsync(rankPageInDb.Id);

            rankPageInDb = (await this.repo.AllReadonly<RankPage>()
                .OrderByDescending(rp => rp.CreatedOn)
                .FirstOrDefaultAsync())!;

            // Assert: the comment has been deleted;
            Assert.That(rankPageInDb.IsDeleted, Is.True);
        }

        [Test]
        public void Test_LikeComment_InvalidRankPageId_ThrowsNotFoundException()
        {
            // Arrange: get guest user id from test db, initialise invalid id
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid invalidRankPageId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.rankService.LikeCommentAsync(guestUserId, invalidRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_LikeComment_DeletedRankPage_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, get deleted rank page from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid deletedRankPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.rankService.LikeCommentAsync(guestUserId, deletedRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_LikeComment_UserNeverLikedPage_AddsAndLikesCorrectly()
        {
            // Arrange: get guest user id, get guest user rank page id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid guestUserPageId = this.testDb.GuestPage.Id;

            // Act: call the service method and pass the necessary data
            await this.rankService.LikeCommentAsync(guestUserId, guestUserPageId);

            // Assert: mapped entry has been created, page has been liked
            EasyRankUserRankPage? mappedEntry = await this.repo.AllReadonly<EasyRankUserRankPage>(
                    erup => erup.RankPageId == guestUserPageId
                            && erup.EasyRankUserId == guestUserId)
                .FirstOrDefaultAsync();
            Assert.That(mappedEntry, Is.Not.Null);
            Assert.That(mappedEntry!.IsLiked, Is.True);
        }

        [Test]
        public async Task Test_LikeComment_UserDislikes_ShouldDislikeComment()
        {
            // Arrange: get liked user id, get liked rank page id, get liked map from test db
            Guid likedUserId = this.testDb.LikedUser.Id;
            Guid likedPageId = this.testDb.LikedPage.Id;
            EasyRankUserRankPage likedMap = this.testDb.LikedMap;

            // Arrange: assert comment is liked beforehand
            Assert.That(likedMap.IsLiked, Is.True);

            // Act: call the service method and pass the necessary data
            await this.rankService.LikeCommentAsync(likedUserId, likedPageId);

            // Assert: rank page has been disliked
            Assert.That(likedMap.IsLiked, Is.False);
        }

        [Test]
        public async Task Test_LikeComment_UserLike_ShouldLikeComment()
        {
            // Arrange: get disliked user id, get disliked rank page id, get disliked map from test db
            Guid dislikedUserId = this.testDb.DislikedUser.Id;
            Guid dislikedPageId = this.testDb.DislikedPage.Id;
            EasyRankUserRankPage dislikedMap = this.testDb.DislikedMap;

            // Arrange: assert comment is liked beforehand
            Assert.That(dislikedMap.IsLiked, Is.False);

            // Act: call the service method and pass the necessary data
            await this.rankService.LikeCommentAsync(dislikedUserId, dislikedPageId);

            // Assert: rank page has been disliked
            Assert.That(dislikedMap.IsLiked, Is.True);
        }

        [Test]
        public async Task Test_GetAllLikesByUser_ReturnsCorrectCount()
        {
            // Arrange: get liked user id, get 'RankPage' count from database
            // (where pages are not deleted && liked by the user)
            Guid likedUserId = this.testDb.LikedUser.Id;

            List<Guid> likedPageIds = await this.repo.AllReadonly<EasyRankUserRankPage>()
                .Where(erurp => erurp.EasyRankUserId == likedUserId 
                                && erurp.IsLiked)
                .Select(erurp => erurp.RankPageId)
                .ToListAsync();

            int databaseCount = await this.repo.AllReadonly<RankPage>(rp => likedPageIds.Contains(rp.Id))
                .Where(rp => !rp.IsDeleted)
                .CountAsync();

            // Act: call service method and get liked ranks count
            ICollection<RankPageServiceModel> serviceModel = await this.rankService.GetAllLikesByUserAsync(likedUserId);
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }
    }
}
