// -----------------------------------------------------------------------
// <copyright file="RankControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models;
using EasyRank.Services;
using EasyRank.Services.Contracts.Admin;
using EasyRank.Services.Models;
using EasyRank.Web.Areas.Admin.Controllers;
using EasyRank.Web.Models.Rank;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests.Admin
{
    [TestFixture]
    public class RankControllerTests : IntegrationTestBase
    {
        private IAdminService adminService;
        private RankController rankController;

        [SetUp]
        public void SetUp()
        {
            this.adminService = new AdminService(this.repo, this.mapper, this.userManager.Object);
            this.rankController = new RankController(this.mapper, this.adminService);
        }

        [Test]
        public async Task Test_All_ReturnsCorrectView()
        {
            // Arrange: get count of pages from db
            int rankPageCount = await this.repo.AllReadonly<RankPage>(rp => !rp.IsDeleted)
                .CountAsync();

            // Act: invoke the controller method
            IActionResult result = await this.rankController.AllAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankPageServiceModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankPageViewModel>>());

            // Assert: collection count is correct
            IEnumerable<RankPageViewModel> modelCollection = 
                (viewResult.ViewData.Model as IEnumerable<RankPageViewModel>)!;
            Assert.That(modelCollection.Count(), Is.EqualTo(rankPageCount));
        }
    }
}
