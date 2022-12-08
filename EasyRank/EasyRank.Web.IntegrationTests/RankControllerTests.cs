using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Rank;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Primitives;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests
{
    public class RankControllerTests : IntegrationTestBase
    {
        private IRankService rankService;
        private RankController rankController;

        [SetUp]
        public void SetUp()
        {
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            this.rankService = new RankService(this.repo, this.mapper);
            this.rankController = new RankController(this.mapper, this.rankService)
            {
                TempData = tempData,
            };
        }

        [Test]
        public async Task Test_All_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.rankController.AllAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'AllRanksViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<AllRanksViewModel>());
        }

        [Test]
        public async Task Test_Create_Post_InvalidModelState_ReturnsToSameView()
        {
            // Arrange: add model error to the model state
            this.rankController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.rankController.CreateAsync(new RankPageFormModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankPageFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankPageFormModel>());
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_EmptySanitize_ReturnsToSameView_WithTempData()
        {
            // Arrange: clear the model state
            this.rankController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.rankController.CreateAsync(new RankPageFormModel
            {
                RankingTitle = "<script></script>",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankPageFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankPageFormModel>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_InvalidFileExtension_ReturnsToSameView_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and invalid form
            this.rankController.ControllerContext = this.CreateControllerContext(user, "appsettings.json");

            // Arrange: clear the model state
            this.rankController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.rankController.CreateAsync(new RankPageFormModel
            {
                RankingTitle = "No JS",
                ImageAlt = "No JS",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RankPageFormModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RankPageFormModel>());

            // Assert: temp data error exists
            Assert.That(viewResult.TempData.ContainsKey("Error"), Is.True);
        }

        [Test]
        public async Task Test_Create_Post_ValidModelState_RedirectsToAll()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.rankController.ControllerContext = this.CreateControllerContext(user, "image.jpg");

            // Arrange: clear the model state
            this.rankController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.rankController.CreateAsync(new RankPageFormModel
            {
                RankingTitle = "No JS",
                ImageAlt = "No JS", 
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is the same (or null), action name is 'All'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.Null);
            Assert.That(redirectResult.ActionName, Is.EqualTo("All"));
        }

        private ControllerContext CreateControllerContext(EasyRankUser user, string fileName)
        {
            // Create user
            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Create test file
            byte[] bytes = Encoding.UTF8.GetBytes("Dummy File");
            IFormFile file = new FormFile(
                new MemoryStream(bytes),
                0,
                bytes.Length,
                "Data",
                fileName);

            // Create form collections
            Dictionary<string, StringValues> emptyFieldsDictionary = new Dictionary<string, StringValues>();
            FormFileCollection formFiles = new FormFileCollection
            {
                file,
            };

            // Create form
            IFormCollection form = new FormCollection(emptyFieldsDictionary, formFiles);

            // Create HTTP context
            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal,
                    Request =
                    {
                        Form = form,
                    }
                }
            };
        }
    }
}
