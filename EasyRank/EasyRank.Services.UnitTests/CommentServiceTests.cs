using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class CommentServiceTests : UnitTestBase
    {
        private ICommentService commentService;

        [SetUp]
        public void SetUp()
        {
            this.commentService = new CommentService(this.repo, this.mapper);
        }

        [Test]
        public void Test_GetCommentById_InvalidId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidCommentId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.commentService.GetCommentByIdAsync(invalidCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetCommentById_DeletedComment_ThrowsNotFoundException()
        {
            // Arrange: get deleted comment id from test db
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async () => await this.commentService.GetCommentByIdAsync(deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetCommentById_ValidId_ReturnsCorrectComment()
        {
            // Arrange: get 'GuestComment' from test db
            Comment guestComment = this.testDb.GuestComment;

            // Act: call service method with the 'GuestComment' id
            CommentServiceModel serviceModel = await this.commentService.GetCommentByIdAsync(guestComment.Id);

            // Assert: both ids must be equal
            Assert.That(serviceModel.Id, Is.EqualTo(guestComment.Id));
        }

        [Test]
        public void Test_IsCurrentUserCommentOwner_InvalidCommentId_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, initialise invalid id
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid invalidPageId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.commentService.IsCurrentUserCommentOwner(guestUserId, invalidPageId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserCommentOwner_DeletedComment_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, get deleted comment id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async() => await this.commentService.IsCurrentUserCommentOwner(guestUserId, deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserCommentOwner_NotCorrectOwnerId_ThrowsUnauthorizedUserException()
        {
            // Arrange: get denis user id, get guest comment id from test db
            Guid denisUserId = this.testDb.DenisUser.Id;
            Guid guestCommentId = this.testDb.GuestComment.Id;

            // Act:

            // Assert: UnauthorizedUserException is thrown with denis user id
            Assert.That(
                async() => await this.commentService.IsCurrentUserCommentOwner(denisUserId, guestCommentId),
                Throws.Exception.TypeOf<UnauthorizedUserException>());
        }

        [Test]
        public void Test_IsCurrentUserCommentOwner_ValidCommentId_DoesNotThrow()
        {
            // Arrange: get guest user id, get guest comment id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid guestCommentId = this.testDb.GuestComment.Id;

            // Act:

            // Assert: no exceptions are thrown
            Assert.That(
                async() => await this.commentService.IsCurrentUserCommentOwner(guestUserId, guestCommentId),
                 Throws.Nothing);
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_InvalidCommentId_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, initialise invalid id
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid invalidCommentId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.commentService.IsCurrentUserPageOwner(guestUserId, invalidCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_DeletedComment_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, get deleted comment id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async () => await this.commentService.IsCurrentUserCommentOwner(guestUserId, deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_DeletedPage_ThrowsNotFoundException()
        {
            // Arrange: get guest user id, get deleted comment id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async () => await this.commentService.IsCurrentUserCommentOwner(guestUserId, deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_NotCorrectOwnerId_ThrowsUnauthorizedUserException()
        {
            // Arrange: get denis user id, get guest comment id from test db
            Guid denisUserId = this.testDb.DenisUser.Id;
            Guid guestCommentId = this.testDb.GuestComment.Id;

            // Act:

            // Assert: UnauthorizedUserException is thrown with denis user id
            Assert.That(
                async () => await this.commentService.IsCurrentUserPageOwner(denisUserId, guestCommentId),
                Throws.Exception.TypeOf<UnauthorizedUserException>());
        }

        [Test]
        public void Test_IsCurrentUserPageOwner_ValidCommentId_DoesNotThrow()
        {
            // Arrange: get guest user id, get guest comment id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid guestCommentId = this.testDb.GuestComment.Id;

            // Act:

            // Assert: no exceptions are thrown
            Assert.That(
                async () => await this.commentService.IsCurrentUserPageOwner(guestUserId, guestCommentId),
                 Throws.Nothing);
        }

        [Test]
        public void Test_GetCommentPageId_InvalidCommentId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidCommentId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.commentService.GetCommentPageId(invalidCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetCommentPageId_DeletedComment_ThrowsNotFoundException()
        {
            // Arrange: get deleted comment id from test db
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async () => await this.commentService.GetCommentPageId(deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetCommentPageId_DeletedPage_ThrowsNotFoundException()
        {
            // Arrange: get deleted comment id from test db
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with deleted comment id
            Assert.That(
                async () => await this.commentService.GetCommentPageId(deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetCommentPageId_ValidCommentId_ReturnsCorrectPageId()
        {
            // Arrange: get guest comment id, get guest rank page id from test db
            Guid guestCommentId = this.testDb.GuestComment.Id;
            Guid guestRankPageId = this.testDb.GuestPage.Id;

            // Act: call service method to get rank page id from comment id
            Guid rankPageId = await this.commentService.GetCommentPageId(guestCommentId);

            // Assert: correct page id is returned
            Assert.That(rankPageId, Is.EqualTo(guestRankPageId));
        }
    }
}
