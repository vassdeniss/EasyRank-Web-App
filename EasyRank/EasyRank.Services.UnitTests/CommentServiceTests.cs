// -----------------------------------------------------------------------
// <copyright file="CommentServiceTests.cs" company="Denis Vasilev">
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
                async() => await this.commentService.GetCommentByIdAsync(invalidCommentId),
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
                async() => await this.commentService.GetCommentByIdAsync(deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetCommentById_ValidId_ReturnsCorrectComment()
        {
            // Arrange: get 'GuestComment' id from test db
            Guid guestCommentId = this.testDb.GuestComment.Id;

            // Act: call service method with the 'GuestComment' id
            CommentServiceModel serviceModel = await this.commentService.GetCommentByIdAsync(guestCommentId);

            // Assert: both ids must be equal
            Assert.That(serviceModel.Id, Is.EqualTo(guestCommentId));
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
                async() => await this.commentService.IsCurrentUserCommentOwnerAsync(guestUserId, invalidPageId),
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
                async() => await this.commentService.IsCurrentUserCommentOwnerAsync(guestUserId, deletedCommentId),
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
                async() => await this.commentService.IsCurrentUserCommentOwnerAsync(denisUserId, guestCommentId),
                Throws.Exception.TypeOf<UnauthorizedUserException>());
        }

        [Test]
        public void Test_IsCurrentUserCommentOwner_OwnerOfPage_DoesNotThrow()
        {
            // Arrange: get guest user id, get denis comment id from test db
            Guid guestUserId = this.testDb.GuestUser.Id;
            Guid denisCommentId = this.testDb.DenisComment.Id;

            // Act:

            // Assert: no exceptions are thrown
            Assert.That(
                async() => await this.commentService.IsCurrentUserCommentOwnerAsync(guestUserId, denisCommentId),
                Throws.Nothing);
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
                async() => await this.commentService.IsCurrentUserCommentOwnerAsync(guestUserId, guestCommentId),
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
                async() => await this.commentService.GetCommentPageIdAsync(invalidCommentId),
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
                async() => await this.commentService.GetCommentPageIdAsync(deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetCommentPageId_ValidCommentId_ReturnsCorrectPageId()
        {
            // Arrange: get guest comment id, get guest rank page id from test db
            Guid guestCommentId = this.testDb.GuestComment.Id;
            Guid guestRankPageId = this.testDb.GuestPage.Id;

            // Act: call service method to get rank page id from comment id
            Guid rankPageId = await this.commentService.GetCommentPageIdAsync(guestCommentId);

            // Assert: correct page id is returned
            Assert.That(rankPageId, Is.EqualTo(guestRankPageId));
        }

        [Test]
        public async Task Test_CreateComment_AddsSuccessfully()
        {
            // Arrange: get the count of comments before adding from the database
            int commentCountBefore = await this.repo.AllReadonly<Comment>()
                    .CountAsync();

            // Arrange: create data for a new comment to be added
            string content = "I think I really enjoyed your ranking and I would like to see more.";
            Guid createdByUserId = this.testDb.GuestUser.Id;
            Guid rankPageId = this.testDb.GuestPage.Id;

            // Act: call the service method and pass the necessary data
            await this.commentService.CreateCommentAsync(content, createdByUserId, rankPageId);

            // Assert: the count of comments in the database has increased by one
            int commentCountAfter = await this.repo.AllReadonly<Comment>()
                .CountAsync();
            Assert.That(commentCountAfter, Is.EqualTo(commentCountBefore + 1));

            // Assert: the new comment has been added
            Comment? newCommentInDb = await this.repo.AllReadonly<Comment>()
                .OrderByDescending(c => c.CreatedOn)
                .FirstOrDefaultAsync();
            Assert.That(newCommentInDb, Is.Not.Null);
            Assert.That(newCommentInDb!.Content, Is.EqualTo(content));
            Assert.That(newCommentInDb.CreatedByUserId, Is.EqualTo(createdByUserId));
            Assert.That(newCommentInDb.RankPageId, Is.EqualTo(rankPageId));
        }

        [Test]
        public void Test_EditComment_InvalidCommentId_ThrowsNotFoundException()
        {
            // Arrange: initialise valid new content, initialise invalid id
            string newContent = "Test new comment content to save to the database";
            Guid invalidCommentId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.commentService.EditCommentAsync(invalidCommentId, newContent),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_EditComment_DeletedComment_ThrowsNotFoundException()
        {
            // Arrange: initialise valid new content, get deleted comment id from test db
            string newContent = "Test new comment content to save to the database";
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.commentService.EditCommentAsync(deletedCommentId, newContent),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_EditComment_ChangesSuccessfully()
        {
            // Arrange: create data for a new comment to be added
            Guid commentId = Guid.NewGuid();
            string content = "I think I really enjoyed your ranking and I would like to see more.";
            Guid createdByUserId = this.testDb.GuestUser.Id;
            Guid rankPageId = this.testDb.GuestPage.Id;

            Comment newComment = new Comment
            {
                Id = commentId,
                Content = content,
                CreatedByUserId = createdByUserId,
                RankPageId = rankPageId,
            };

            // Arrange: add the comment to the db
            await this.repo.AddAsync<Comment>(newComment);
            await this.repo.SaveChangesAsync();

            // Arrange: create new content to be changed
            string changedContent = "I think I didn't enjoy your ranking and I don't want to see more. (Edit)";

            // Act: call the edit service method and pass the necessary data
            await this.commentService.EditCommentAsync(newComment.Id, changedContent);

            Comment newCommentInDb = await this.repo.GetByIdAsync<Comment>(newComment.Id);

            // Assert: the comment has been edited
            Assert.That(newCommentInDb, Is.Not.Null);
            Assert.That(newCommentInDb.IsEdited, Is.True);
            Assert.That(newCommentInDb.Content, Is.EqualTo(changedContent));
            Assert.That(newCommentInDb.CreatedByUserId, Is.EqualTo(createdByUserId));
            Assert.That(newCommentInDb.RankPageId, Is.EqualTo(rankPageId));
        }

        [Test]
        public void Test_DeleteComment_InvalidCommentId_ThrowsNotFoundException()
        {
            // Arrange: initialise invalid id
            Guid invalidCommentId = Guid.NewGuid();

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.commentService.DeleteCommentAsync(invalidCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_DeleteComment_DeletedComment_ThrowsNotFoundException()
        {
            // Arrange: get deleted comment id from test db
            Guid deletedCommentId = this.testDb.DeletedComment.Id;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.commentService.DeleteCommentAsync(deletedCommentId),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteComment_RemovesSuccessfully()
        {
            // Arrange: create data for a new comment to be added
            Guid commentId = Guid.NewGuid();
            string content = "I think I wanna delete this page cause I am an admin lol";
            Guid createdByUserId = this.testDb.GuestUser.Id;
            Guid rankPageId = this.testDb.GuestPage.Id;

            Comment newComment = new Comment
            {
                Id = commentId,
                Content = content,
                CreatedByUserId = createdByUserId,
                RankPageId = rankPageId,
            };

            // Arrange: add the comment to the db
            await this.repo.AddAsync<Comment>(newComment);
            await this.repo.SaveChangesAsync();

            // Act: call the delete service method and pass the necessary data
            await this.commentService.DeleteCommentAsync(newComment.Id);

            Comment newCommentInDb = await this.repo.GetByIdAsync<Comment>(newComment.Id);

            // Assert: the comment has been deleted;
            Assert.That(newCommentInDb.IsDeleted, Is.True);
        }
    }
}
