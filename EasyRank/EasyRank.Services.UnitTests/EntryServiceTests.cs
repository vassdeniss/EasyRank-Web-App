// -----------------------------------------------------------------------
// <copyright file="EntryServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;

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
                async() => await this.entryService.IsCurrentUserPageOwner(guestUserId, invalidRankPageId),
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
                async() => await this.entryService.IsCurrentUserPageOwner(guestUserId, deletedRankPageId),
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
                async() => await this.entryService.IsCurrentUserPageOwner(denisUserId, guestRankPageId),
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
                async() => await this.entryService.IsCurrentUserPageOwner(guestUserId, guestRankPageId),
                 Throws.Nothing);
        }
    }
}
