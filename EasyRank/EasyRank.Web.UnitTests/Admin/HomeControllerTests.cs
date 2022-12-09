// -----------------------------------------------------------------------
// <copyright file="HomeControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Web.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests.Admin
{
    [TestFixture]
    public class HomeControllerTests : IntegrationTestBase
    {
        private HomeController homeController;

        [SetUp]
        public void SetUp()
        {
            this.homeController = new HomeController();
        }

        [Test]
        public void Test_Index_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.homeController.Index();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
