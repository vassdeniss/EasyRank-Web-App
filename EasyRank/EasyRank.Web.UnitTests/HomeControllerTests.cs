// -----------------------------------------------------------------------
// <copyright file="HomeControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Castle.Components.DictionaryAdapter;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Web.Controllers;
using EasyRank.Web.UnitTests.Mocks;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    [TestFixture]
    public class HomeControllerTests : UnitTestBase
    {
        private HomeController homeController;

        [SetUp]
        public void SetUp()
        {
            IManageService manageService = ManageServiceMock.MockManageService(new List<EasyRankUser>
            {
                this.testDb.GuestUser,
            }).Object;

            this.homeController = new HomeController(manageService);
            this.homeController.AddTempData();
        }

        [Test]
        public async Task Test_Index_Admin_RedirectsToAdminIndex()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with admin
            this.homeController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName)
                .AndMakeAdmin();

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index', area is 'Admin'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
            Assert.That(redirectResult.RouteValues!.ContainsKey("area"), Is.True);
            Assert.That(redirectResult.RouteValues["area"], Is.EqualTo("Admin"));
        }

        [Test]
        public async Task Test_Index_UserNotLoggedIn_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.homeController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task Test_Index_UserLoggedIn_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.homeController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public async Task Test_Index_UserLoggedIn_FirstNameNullLastNameNull_ReturnsCorrectView_WithViewBag()
        {
            // Arrange: get guest user from test db and set him up
            EasyRankUser user = this.testDb.GuestUser;
            string? oldFirstName = user.FirstName;
            string? oldLastName = user.LastName;
            user.FirstName = null;
            user.LastName = null;

            // Arrange: create controller HTTP context with logged in user
            this.homeController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: ViewBag exists
            Assert.That(this.homeController.ViewBag.PersonName, Is.Not.Null);

            // Cleanup: revert user back for other tests
            user.FirstName = oldFirstName;
            user.LastName = oldLastName;
        }

        [Test]
        public async Task Test_Index_UserLoggedIn_FirstNameNotNullLastNameNull_ReturnsCorrectView_WithViewBag()
        {
            // Arrange: get guest user from test db and set him up
            EasyRankUser user = this.testDb.GuestUser;
            string? oldLastName = user.LastName;
            user.LastName = null;

            // Arrange: create controller HTTP context with logged in user
            this.homeController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: ViewBag exists
            Assert.That(this.homeController.ViewBag.PersonName, Is.Not.Null);

            // Cleanup: revert user back for other tests
            user.LastName = oldLastName;
        }

        [Test]
        public async Task Test_Index_UserLoggedIn_FirstNameNullLastNameNotNull_ReturnsCorrectView_WithViewBag()
        {
            // Arrange: get guest user from test db and set him up
            EasyRankUser user = this.testDb.GuestUser;
            string? oldFirstName = user.FirstName;
            user.FirstName = null;

            // Arrange: create controller HTTP context with logged in user
            this.homeController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: ViewBag exists
            Assert.That(this.homeController.ViewBag.PersonName, Is.Not.Null);

            // Cleanup: revert user back for other tests
            user.FirstName = oldFirstName;
        }

        [Test]
        public async Task Test_Index_UserLoggedIn_FirstNameNotNullLastNameNotNull_ReturnsCorrectView_WithViewBag()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.homeController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.homeController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: ViewBag exists
            Assert.That(this.homeController.ViewBag.PersonName, Is.Not.Null);
        }

        [Test]
        public void Test_Error_NotFoundException_RedirectsToHomeError404()
        {
            // Arrange: add error to controller
            this.homeController
                .AddExceptionFeatureWithExceptionType<NotFoundException, HomeController>();

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Error404'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Error404"));
        }

        [Test]
        public void Test_Error_ForbiddenException_RedirectsToHomeError403()
        {
            // Arrange: add error to controller
            this.homeController
                .AddExceptionFeatureWithExceptionType<ForbiddenException, HomeController>();

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Error403'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Error403"));
        }

        [Test]
        public void Test_Error_FileFormatException_RedirectsToManageIndex_WithTempData()
        {
            // Arrange: add error to controller
            this.homeController
                .AddExceptionFeatureWithExceptionType<FileFormatException, HomeController>();

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));

            // Assert: TempData exists
            Assert.That(this.homeController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public void Test_Error_UsernameTakenException_RedirectsToManageIndex_WithTempData()
        {
            // Arrange: add error to controller
            this.homeController
                .AddExceptionFeatureWithExceptionType<UsernameTakenException, HomeController>();

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));

            // Assert: TempData exists
            Assert.That(this.homeController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public void Test_Error_UnhandledError_RedirectsToHomeError500()
        {
            // Arrange: add error to controller
            this.homeController
                .AddExceptionFeatureWithExceptionType<ArgumentException, HomeController>();

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Error500'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Error500"));
        }

        [Test]
        public void Test_Error404_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error404();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_Error403_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error403();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_Error500_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.homeController.Error500();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
