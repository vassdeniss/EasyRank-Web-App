using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    public class CommentServiceTests : UnitTestBase
    {
        private ICommentService commentService;

        [SetUp]
        public void SetUp()
        {
            this.commentService = new CommentService(this.repo, this.mapper);
        }

        [Test]
        public async Task Test_GetCommentById_ReturnsCorrectId()
        {
            // Arrange: get 'GuestComment' from test db
            Comment guestComment = this.testDb.GuestComment;

            // Act: get comment from service with the test comment id
            CommentServiceModel serviceModel = await this.commentService.GetCommentByIdAsync(guestComment.Id);

            // Assert: both ids must be equal
            Assert.That(serviceModel.Id, Is.EqualTo(guestComment.Id));
        }
    }
}
