// -----------------------------------------------------------------------
// <copyright file="CommentControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Comment;
using EasyRank.Web.UnitTests.Mocks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    public class CommentControllerTests : UnitTestBase
    {
        private ICommentService commentService;
        private CommentController commentController;

        [OneTimeSetUp]
        public void SetUp()
        {
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            this.commentService = CommentServiceMock.MockCommentService().Object;
            this.commentController = new CommentController(this.commentService, this.mapper)
            {
                TempData = tempData,
            };
        }

        [Test]
        public async Task Test_Create_Post_InvalidModelState_RedirectsToViewRank()
        {
            // Arrange: add model error to the model state
            this.commentController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.commentController.CreateAsync(Guid.NewGuid(), new CommentFormModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Rank', action name is 'ViewRanking'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
            Assert.That(redirectResult.RouteValues, Is.Not.Null);
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_EmptySanitize_RedirectsToViewRank()
        {
            // Arrange: clear the model state
            this.commentController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.commentController.CreateAsync(Guid.NewGuid(), new CommentFormModel
            {
                Content = "<script></script>",
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Rank', action name is 'ViewRanking'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
            Assert.That(redirectResult.RouteValues, Is.Not.Null);
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_RedirectsToViewRank()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Arrange: clear the model state
            this.commentController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.commentController.CreateAsync(Guid.NewGuid(),
                new CommentFormModel
                {
                    Content = "No js",
                });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Rank', action name is 'ViewRanking'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
            Assert.That(redirectResult.RouteValues, Is.Not.Null);
        }

        [Test]
        public async Task Test_Edit_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = await this.commentController.EditAsync(Guid.NewGuid());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'CommentFormModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<CommentFormModelExtended>());
        }

        [Test]
        public async Task Test_Edit_Post_InvalidModelState_ReturnsToSameView()
        {
            // Arrange: add model error to the model state
            this.commentController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.commentController.EditAsync(new CommentFormModelExtended());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'CommentFormModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<CommentFormModelExtended>());
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_EmptySanitize_ReturnsToSameView_WithTempData()
        {
            // Arrange: clear the model state
            this.commentController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.commentController.EditAsync(new CommentFormModelExtended
            {
                Content = "<script></script>",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'CommentFormModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<CommentFormModelExtended>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_Admin_RedirectsToAllComments()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(
                user,
                shouldBeAdmin: true);

            // Arrange: clear the model state
            this.commentController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.commentController.EditAsync(
                new CommentFormModelExtended
                {
                    Content = "No js",
                });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Comment', action name is 'All', area is 'Admin'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Comment"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.RouteValues!.ContainsKey("area"), Is.True);
            Assert.That(redirectResult.RouteValues["area"], Is.EqualTo("Admin"));
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_RedirectsToViewRank()
        {
            // Arrange: get guest user, guest page from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Arrange: clear the model state
            this.commentController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.commentController.EditAsync(new 
                CommentFormModelExtended
                {
                    Content = "No js",
                });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Rank', action name is 'ViewRanking'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
            Assert.That(redirectResult.RouteValues, Is.Not.Null);
            Assert.That(redirectResult.RouteValues!.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task Test_Delete_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = await this.commentController.DeleteAsync(Guid.NewGuid());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'CommentFormModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<CommentFormModelExtended>());
        }

        [Test]
        public async Task Test_Delete_Post_Admin_RedirectsToAllComments()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(
                user,
                shouldBeAdmin: true);

            // Act: invoke the controller method
            IActionResult result = await this.commentController.DeleteAsync(
                new CommentFormModelExtended());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Comment', action name is 'All'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Comment"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.RouteValues!.ContainsKey("area"), Is.True);
            Assert.That(redirectResult.RouteValues["area"], Is.EqualTo("Admin"));
        }

        [Test]
        public async Task Test_Delete_Post_RedirectsToViewRank()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.commentController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = await this.commentController.DeleteAsync(
                new CommentFormModelExtended());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Rank', action name is 'ViewRanking'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
            Assert.That(redirectResult.RouteValues, Is.Not.Null);
            Assert.That(redirectResult.RouteValues!.Count, Is.GreaterThan(0));
        }
    }
}
