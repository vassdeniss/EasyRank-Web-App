// -----------------------------------------------------------------------
// <copyright file="EntryServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class EntryServiceTests : UnitTestBase
    {
        private IEntryService entryService;

        [SetUp]
        public void SetUp()
        {
            this.entryService = new EntryService(this.repo);
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
                async() => await this.entryService.IsCurrentUserPageOwnerAsync(guestUserId, invalidRankPageId),
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
                async() => await this.entryService.IsCurrentUserPageOwnerAsync(guestUserId, deletedRankPageId),
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
                async() => await this.entryService.IsCurrentUserPageOwnerAsync(denisUserId, guestRankPageId),
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
                async() => await this.entryService.IsCurrentUserPageOwnerAsync(guestUserId, guestRankPageId),
                 Throws.Nothing);
        }

        [Test]
        public async Task Test_CreateEntry_AddsSuccessfully()
        {
            // Arrange: get the guest user page from test db
            RankPage guestRankPage = this.testDb.GuestPage;

            // Arrange: get the count of entries before adding from the database
            int rankEntryCountBefore = await this.repo.AllReadonly<RankEntry>()
                .CountAsync();

            // Arrange: create data for a new rank entry to be added
            int placement = 5;
            string entryTitle = "Insert some random creation entry text here";
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing creating entry";
            string description = "Lorem ipsum alabala description uuu yay";
            Guid rankPageId = guestRankPage.Id;

            // Act: call the service method and pass the necessary data
            await this.entryService.CreateEntryAsync(placement, entryTitle, image, imageAlt, description, rankPageId);

            // Assert: the count of rank entries in the database has increased by one
            int rankEntriesCountAfter = await this.repo.AllReadonly<RankEntry>()
                .CountAsync();
            Assert.That(rankEntriesCountAfter, Is.EqualTo(rankEntryCountBefore + 1));

            // Assert: the new entry has been added
            RankEntry? newRankPageInDb = await this.repo.AllReadonly<RankEntry>(
                    re => re.RankPageId == guestRankPage.Id)
                .OrderByDescending(re => re.Placement)
                .LastOrDefaultAsync();
            Assert.That(newRankPageInDb, Is.Not.Null);
            Assert.That(newRankPageInDb!.Placement, Is.EqualTo(placement));
            Assert.That(newRankPageInDb.Title, Is.EqualTo(entryTitle));
            Assert.That(newRankPageInDb.ImageAlt, Is.EqualTo(imageAlt));
            Assert.That(newRankPageInDb.RankPageId, Is.EqualTo(rankPageId));
        }

        [Test]
        public void Test_GetAvailablePlacements_InvalidRankPageId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidRankPageId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.entryService.GetAvailablePlacementsAsync(invalidRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetAvailablePlacements_DeletedPage_ThrowsNotFoundException()
        {
            // Arrange: get deleted rank page id from test db
            Guid deletedRankPageId = this.testDb.DeletedPage.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async () => await this.entryService.GetAvailablePlacementsAsync(deletedRankPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetAvailablePlacements_ValidRankPageId_DoesNotThrow()
        {
            // Arrange: get guest rank page from test db
            RankPage guestRankPage = this.testDb.GuestPage;

            // Act: call service method and get available placements
            ICollection<int> availablePlacements = await this.entryService.GetAvailablePlacementsAsync(guestRankPage.Id);

            int maxPlacements = 10;
            int actualAvailablePlacements = maxPlacements - guestRankPage.Entries.Count;

            // Assert: returned count matches expected
            Assert.That(availablePlacements.Count, Is.EqualTo(actualAvailablePlacements));
        }
    }
}
