// -----------------------------------------------------------------------
// <copyright file="EntryServiceTests.cs" company="Denis Vasilev">
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
    public class EntryServiceTests : UnitTestBase
    {
        private IEntryService entryService;

        [SetUp]
        public void SetUp()
        {
            this.entryService = new EntryService(this.repo, this.mapper);
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
                    re => re.ImageAlt == imageAlt)
                .FirstOrDefaultAsync();
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
                async() => await this.entryService.GetAvailablePlacementsAsync(invalidRankPageId),
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
                async() => await this.entryService.GetAvailablePlacementsAsync(deletedRankPageId),
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

        [Test]
        public void Test_EditEntry_InvalidRankEntryId_ThrowsNotFoundException()
        {
            // Arrange: initialise valid new data, initialise invalid id
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing edit entry";
            string entryTitle = "I want to edit this one 4 / 10";
            int entryPlacement = 4;
            string entryDescription = "I want to edit this one 4 / 10 really much cause i really like how it looks and blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah";
            Guid invalidRankEntryId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.entryService.EditEntryAsync(
                    invalidRankEntryId,
                    entryPlacement,
                    entryTitle,
                    image,
                    imageAlt,
                    entryDescription),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_EditEntry_DeletedRankEntry_ThrowsNotFoundException()
        {
            // Arrange: initialise valid new data, get deleted rank entry id from test db
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing edit entry";
            string entryTitle = "I want to edit this one 4 / 10";
            int entryPlacement = 4;
            string entryDescription = "I want to edit this one 4 / 10 really much cause i really like how it looks and blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah";
            Guid deletedRankEntryId = this.testDb.DeletedEntry.Id;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.entryService.EditEntryAsync(
                    deletedRankEntryId,
                    entryPlacement,
                    entryTitle,
                    image,
                    imageAlt,
                    entryDescription),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_EditEntry_ChangesSuccessfully()
        {
            // Arrange: create data for a new rank entry to be added
            Guid rankEntryId = Guid.NewGuid();
            byte[] image = Array.Empty<byte>();
            string imageAlt = "Alternative text for image for testing edit entry";
            string entryTitle = "I want to edit this one 4 / 10";
            int entryPlacement = 4;
            string entryDescription = "I want to edit this one 4 / 10 really much cause i really like how it looks and blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah";
            Guid rankPageId = this.testDb.GuestPage.Id;

            RankEntry newEntry = new RankEntry
            {
                Id = rankEntryId,
                Placement = entryPlacement,
                Title = entryTitle,
                Image = image,
                ImageAlt = imageAlt,
                Description = entryDescription,
                IsDeleted = false,
                RankPageId = rankPageId,
            };

            // Arrange: add the entry to the db
            await this.repo.AddAsync<RankEntry>(newEntry);
            await this.repo.SaveChangesAsync();

            // Arrange: create new data to be changed
            string changedTitle = "I want to edit this one 1 / 10";
            int changedPlacement = 1;

            // Act: call the edit service method and pass the necessary data
            await this.entryService.EditEntryAsync(
                rankEntryId,
                changedPlacement,
                changedTitle,
                image,
                imageAlt,
                entryDescription);

            // Assert: the entry has been edited
            RankEntry entryInDb = await this.repo.GetByIdAsync<RankEntry>(rankEntryId);

            Assert.That(entryInDb.Id, Is.EqualTo(rankEntryId));
            Assert.That(entryInDb.Placement, Is.EqualTo(changedPlacement));
            Assert.That(entryInDb.Title, Is.EqualTo(changedTitle));
            Assert.That(entryInDb.ImageAlt, Is.EqualTo(imageAlt));
            Assert.That(entryInDb.Description, Is.EqualTo(entryDescription));
        }

        [Test]
        public void Test_GetRankEntryByGuid_InvalidEntryId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.entryService.GetRankEntryByGuidAsync(invalidId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetRankEntryByGuid_DeletedRankEntry_ThrowsNotFoundException()
        {
            // Arrange: get deleted rank entry from test db
            Guid deletedEntryId = this.testDb.DeletedEntry.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted id
            Assert.That(
                async() => await this.entryService.GetRankEntryByGuidAsync(deletedEntryId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetRankEntryByGuid_ValidId_ReturnsCorrectEntry()
        {
            // Arrange: get 'GuestEntry' id from test db
            Guid guestRankEntryId = this.testDb.GuestEntry.Id;

            // Act: call service method with the 'GuestEntry' id
            RankEntryServiceModel serviceModel = await this.entryService.GetRankEntryByGuidAsync(guestRankEntryId);

            // Assert: both ids must be equal
            Assert.That(serviceModel.Id, Is.EqualTo(guestRankEntryId));
        }
    }
}
