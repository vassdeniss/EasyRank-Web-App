// -----------------------------------------------------------------------
// <copyright file="UserControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Contracts.Admin;
using EasyRank.Web.Areas.Admin.Controllers;
using EasyRank.Web.Areas.Admin.Models.User;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests.Admin
{
    [TestFixture]
    public class UserControllerTests : IntegrationTestBase
    {
        private UserController userController;

        [SetUp]
        public void SetUp()
        {
            this.userController = new UserController(this.mapper, new Mock<IAdminService>().Object);
        }

        [Test]
        public async Task Test_All_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.userController.AllAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'EasyRankUserViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<EasyRankUserViewModel>>());
        }

        [Test]
        public void Test_Forget_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.userController.Forget(Guid.NewGuid(), "Username");

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ActionUserViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ActionUserViewModel>());
        }

        [Test]
        public async Task Test_Forget_Post_RedirectsToAllUsers()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.userController.ForgetAsync(new ActionUserViewModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'User', action name is 'All'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("User"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
        }

        [Test]
        public void Test_MakeAdmin_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.userController.MakeAdmin(Guid.NewGuid(), "Username");

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ActionUserViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ActionUserViewModel>());
        }

        [Test]
        public async Task Test_MakeAdmin_Post_RedirectsToAllUsers()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.userController.MakeAdminAsync(new ActionUserViewModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'User', action name is 'All'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("User"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
        }

        [Test]
        public void Test_RemoveAdmin_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.userController.RemoveAdmin(Guid.NewGuid(), "Username");

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ActionUserViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ActionUserViewModel>());
        }

        [Test]
        public async Task Test_RemoveAdmin_Post_RedirectsToAllUsers()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.userController.RemoveAdminAsync(new ActionUserViewModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'User', action name is 'All'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("User"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
        }
    }
}
