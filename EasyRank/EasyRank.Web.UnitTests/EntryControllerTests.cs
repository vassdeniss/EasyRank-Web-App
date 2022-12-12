// -----------------------------------------------------------------------
// <copyright file="EntryControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Entry;
using EasyRank.Web.UnitTests.Mocks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    [TestFixture]
    public class EntryControllerTests : UnitTestBase
    {
        private IEntryService entryService;
        private EntryController entryController;

        [OneTimeSetUp]
        public void SetUp()
        {
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            this.entryService = EntryServiceMock.MockEntryService().Object;
            this.entryController = new EntryController(this.entryService, this.mapper)
            {
                TempData = tempData,
            };
        }

        [Test]
        public async Task Test_Create_Get_ReturnsCorrectView_WithTempData()
        {
            // Arrange: get guest user, guest page from test db
            EasyRankUser user = this.testDb.GuestUser;
            RankPage page = this.testDb.GuestPage;

            // Arrange: create controller HTTP context with valid user
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = await this.entryController.CreateAsync(page.Id);

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("EntryCreateReturnId"), Is.True);
        }

        [Test]
        public async Task Test_Create_Post_InvalidModelState_ReturnsToSameView()
        {
            // Arrange: add model error to the model state
            this.entryController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.entryController.CreateAsync(new RankEntryFormModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_EmptySanitize_ReturnsToSameView_WithTempData()
        {
            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.CreateAsync(new RankEntryFormModel
            {
                EntryTitle = "<script></script>",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_InvalidFileExtension_ReturnsToSameView_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user, "appsettings.json");

            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.CreateAsync(new RankEntryFormModel
            {
                EntryTitle = "No JS",
                EntryDescription = "No JS",
                ImageAlt = "No JS",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_RedirectsToAll()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user, "image.jpg");

            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.CreateAsync(new RankEntryFormModel
            {
                EntryTitle = "No JS",
                EntryDescription = "No JS",
                ImageAlt = "No JS",
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
        public async Task Test_Edit_Get_ReturnsCorrectView_WithTempData()
        {
            // Arrange: get guest user, guest page, guest entry from test db
            EasyRankUser user = this.testDb.GuestUser;
            RankPage page = this.testDb.GuestPage;
            RankEntry entry = this.testDb.GuestEntry;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = await this.entryController.EditAsync(page.Id, entry.Id);

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data exists
            Assert.That(viewResult.TempData.ContainsKey("EntryEditReturnId"), Is.True);
        }

        [Test]
        public async Task Test_Edit_Post_InvalidModelState_ReturnsToSameView()
        {
            // Arrange: add model error to the model state
            this.entryController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.entryController.EditAsync(new RankEntryFormModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_EmptySanitize_ReturnsToSameView_WithTempData()
        {
            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.EditAsync(new RankEntryFormModel
            {
                EntryTitle = "<script></script>",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_InvalidFileExtension_ReturnsToSameView_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user, "appsettings.json");

            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.EditAsync(new RankEntryFormModel
            {
                EntryTitle = "No JS",
                EntryDescription = "No JS",
                ImageAlt = "No JS",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_Admin_RedirectsToAllEntries()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(
                user,
                "image.jpg",
                true);

            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.EditAsync(new RankEntryFormModel
            {
                EntryTitle = "No JS",
                EntryDescription = "No JS",
                ImageAlt = "No JS",
                Image = Array.Empty<byte>(),
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Entry', action name is 'All', area is 'Admin'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Entry"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.RouteValues!.ContainsKey("area"), Is.True);
            Assert.That(redirectResult.RouteValues["area"], Is.EqualTo("Admin"));

            // Assert: TempData is removed
            Assert.That(this.entryController.TempData.ContainsKey("EntryEditReturnId"), Is.False);
        }

        [Test]
        public async Task Test_Edit_Post_ValidModelState_RedirectsToViewRank()
        {
            // Arrange: get guest user, guest page from test db
            EasyRankUser user = this.testDb.GuestUser;
            RankPage page = this.testDb.GuestPage;

            // Arrange: create controller HTTP context with valid user and valid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user, "avatar.jpg");

            // Arrange: clear the model state
            this.entryController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.entryController.EditAsync(new RankEntryFormModel
            {
                Id = page.Id,
                Placement = 2,
                EntryTitle = "No JS",
                EntryDescription = "No JS",
                ImageAlt = "No JS",
                Image = Array.Empty<byte>(),
                AvailablePlacements = Enumerable.Empty<int>().ToList(),
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
            // Arrange: get guest user, guest page, guest entry from test db
            EasyRankUser user = this.testDb.GuestUser;
            RankPage page = this.testDb.GuestPage;
            RankEntry entry = this.testDb.GuestEntry;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = await this.entryController.DeleteAsync(page.Id, entry.Id);

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankEntryFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankEntryFormModel>());

            // Assert: temp data exists
            Assert.That(viewResult.TempData.ContainsKey("EntryDeleteReturnId"), Is.True);
        }

        [Test]
        public async Task Test_Delete_Post_Admin_RedirectsToAllEntries()
        {
            // Arrange: get guest user, guest page from test db
            EasyRankUser user = this.testDb.GuestUser;
            RankPage page = this.testDb.GuestPage;

            // Arrange: create controller HTTP context with valid user and valid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(
                user,
                "image.jpg",
                true);

            // Act: invoke the controller method
            IActionResult result = await this.entryController.DeleteAsync(new RankEntryFormModel
            {
                Id = page.Id,
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Entry', action name is 'All', area is 'Admin'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Entry"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
            Assert.That(redirectResult.RouteValues!.ContainsKey("area"), Is.True);
            Assert.That(redirectResult.RouteValues["area"], Is.EqualTo("Admin"));

            // Assert: TempData is removed
            Assert.That(this.entryController.TempData.ContainsKey("EntryEditReturnId"), Is.False);
        }

        [Test]
        public async Task Test_Delete_Post_RedirectsToViewRank()
        {
            // Arrange: get guest user, guest page from test db
            EasyRankUser user = this.testDb.GuestUser;
            RankPage page = this.testDb.GuestPage;

            // Arrange: create controller HTTP context with valid user and valid form
            this.entryController.ControllerContext = TestingUtils.CreateControllerContext(user, "image.jpg");

            // Act: invoke the controller method
            IActionResult result = await this.entryController.DeleteAsync(new RankEntryFormModel
            {
                Id = page.Id,
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Rank', action name is 'ViewRanking'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
        }
    }
}
