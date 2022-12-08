// -----------------------------------------------------------------------
// <copyright file="CommentControllerTests.cs" company="Denis Vasilev">
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
using EasyRank.Web.Areas.Admin.Controllers;
using EasyRank.Web.Areas.Admin.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests.Admin
{
    [TestFixture]
    public class CommentControllerTests : IntegrationTestBase
    {
        private IAdminService adminService;
        private CommentController commentController;

        [SetUp]
        public void SetUp()
        {
            this.adminService = new AdminService(this.repo, this.mapper, this.userManager.Object);
            this.commentController = new CommentController(this.mapper, this.adminService);
        }

        [Test]
        public async Task Test_All_ReturnsCorrectView()
        {
            // Arrange: get count of comments from db
            int commentCount = await this.repo.AllReadonly<Comment>(c => !c.IsDeleted)
                .CountAsync();

            // Act: invoke the controller method
            IActionResult result = await this.commentController.AllAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'CommentViewModelExtended'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<CommentViewModelExtended>>());

            // Assert: collection count is correct
            IEnumerable<CommentViewModelExtended> modelCollection = 
                (viewResult.ViewData.Model as IEnumerable<CommentViewModelExtended>)!;
            Assert.That(modelCollection.Count(), Is.EqualTo(commentCount));
        }
    }
}
