// -----------------------------------------------------------------------
// <copyright file="ManageControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Manage;
using EasyRank.Web.Models.Rank;
using EasyRank.Web.UnitTests.Mocks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    public class ManageControllerTests : UnitTestBase
    {
        private ManageController manageController;

        [SetUp]
        public void SetUp()
        {
            this.manageController = new ManageController(
                Mock.Of<IEmailSender>(),
                this.mapper,
                Mock.Of<IRankService>(),
                ManageServiceMock.MockManageService(new List<EasyRankUser>
                {
                    this.testDb.GuestUser,
                }).Object,
                AccountServiceMock.MockAccountService(new List<EasyRankUser>
                {
                    this.testDb.GuestUser,
                    this.testDb.UnconfirmedUser,
                }).Object);

            this.manageController.AddTempData();
        }

        [Test]
        public async Task Test_Index_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ManageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ManageViewModel>());
        }

        [Test]
        public async Task Test_DeleteProfilePicture_Post_RedirectsToManageIndex_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.DeleteProfilePictureAsync();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));

            // Assert: temp data exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public void Test_DeleteAccount_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.manageController.DeleteAccount();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'DeleteAccountViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<DeleteAccountViewModel>());
        }

        [Test]
        public async Task Test_Email_Get_ReturnsCorrectView_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.EmailAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'EmailViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<EmailViewModel>());

            // Assert: temp data exists
            Assert.That(viewResult.TempData.ContainsKey("ConfirmedEmail"), Is.True);
        }

        [Test]
        public void Test_ChangePassword_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.manageController.ChangePassword();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ChangePasswordViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ChangePasswordViewModel>());
        }

        [Test]
        public async Task Test_MyRanks_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.MyRanksAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankPageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankPageViewModel>>());
        }

        [Test]
        public async Task Test_MyLikes_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.MyLikesAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankPageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankPageViewModel>>());
        }
    }
}
