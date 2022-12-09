using System.Collections.Generic;
using System.Security.Claims;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Exceptions;
using EasyRank.Web.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests
{
    [TestFixture]
    public class HomeControllerTests : IntegrationTestBase
    {
        private HomeController homeController;

        [SetUp]
        public void SetUp()
        {
            this.homeController = new HomeController(this.userManager.Object);
        }

        [Test]
        public void Test_Index_Admin_RedirectsToAdminIndex()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user
            this.homeController.ControllerContext = TestingUtils.CreateControllerContext(
                user,
                shouldBeAdmin: true);

            // Act: invoke the controller method
            IActionResult result = this.homeController.Index();

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
        public void Test_Index_UserNotLoggedIn_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>()));
            this.homeController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal,
                }
            };

            // Act: invoke the controller method
            IActionResult result = this.homeController.Index();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_Index_UserLoggedIn_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with not logged in user
            this.homeController.ControllerContext = TestingUtils.CreateControllerContext(user);

            // Act: invoke the controller method
            IActionResult result = this.homeController.Index();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
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

        //[Test]
        //public void Test_Index_NotAuthenticated_ReturnsCorrectView()
        //{
        //    // Arrange:

        //    // Act: invoke the controller method
        //    IActionResult result = this.homeController.Index();

        //    // Assert: returned result is not null, it is a view
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf<ViewResult>());
        //}

        //[Test]
        //public void a()
        //{
        //    EasyRankUser user = this.testDb.GuestUser;

        //    List<Claim> userClaims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.UserName),
        //        new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
        //    };

        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims);
        //    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        //    this.homeController.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = new DefaultHttpContext
        //        {
        //            User = claimsPrincipal,
        //        }
        //    };

        //    IActionResult result

        //    Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        //    RedirectToActionResult redirectToActionResult = result as RedirectToActionResult;
        //    Assert.That(redirectToActionResult!.ControllerName, Is.EqualTo("Home"));
        //    Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Error404"));
        //}
    }
}
