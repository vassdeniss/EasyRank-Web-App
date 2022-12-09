// -----------------------------------------------------------------------
// <copyright file="EntryControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services;
using EasyRank.Services.Contracts.Admin;
using EasyRank.Web.Areas.Admin.Controllers;
using EasyRank.Web.Areas.Admin.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests.Admin
{
    [TestFixture]
    public class EntryControllerTests : IntegrationTestBase
    {
        private IAdminService adminService;
        private EntryController entryController;

        [SetUp]
        public void SetUp()
        {
            this.adminService = new AdminService(this.repo, this.mapper, userManager.Object);
            this.adminService = new AdminService(this.repo, this.mapper, this.userManager.Object);
            this.entryController = new EntryController(this.mapper, this.adminService);
        }

        [Test]
        public async Task Test_All_ReturnsCorrectView()
        {
            // Arrange: get count of entries from db
            int entriesCount = await this.repo.AllReadonly<RankEntry>(
                    re => !re.IsDeleted)
                .CountAsync();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.AllAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankEntryViewModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankEntryViewModelExtended>>());

            // Assert: collection count is correct
            IEnumerable<RankEntryViewModelExtended> modelCollection =
                (viewResult.ViewData.Model as IEnumerable<RankEntryViewModelExtended>)!;
            Assert.That(modelCollection.Count(), Is.EqualTo(entriesCount));
        }
    }
}
