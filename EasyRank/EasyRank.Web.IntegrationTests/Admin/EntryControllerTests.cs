// -----------------------------------------------------------------------
// <copyright file="EntryControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Contracts.Admin;
using EasyRank.Web.Areas.Admin.Controllers;
using EasyRank.Web.Areas.Admin.Models;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests.Admin
{
    [TestFixture]
    public class EntryControllerTests : IntegrationTestBase
    {
        private EntryController entryController;

        [SetUp]
        public void SetUp()
        {
            this.entryController = new EntryController(this.mapper, new Mock<IAdminService>().Object);
        }

        [Test]
        public async Task Test_All_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.entryController.AllAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankEntryViewModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankEntryViewModelExtended>>());
        }
    }
}
