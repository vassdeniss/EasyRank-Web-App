using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Account;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    // TODO: header

    public class AccountControllerTests : UnitTestBase
    {
        private AccountController accountController;

        [OneTimeSetUp]
        public void SetUp()
        {
            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            Mock<UserManager<EasyRankUser>> userManagerMock = new Mock<UserManager<EasyRankUser>>(
                Mock.Of<IUserStore<EasyRankUser>>(),
                null, null, null, null, null, null, null, null);

            Mock<SignInManager<EasyRankUser>> signInManager = new Mock<SignInManager<EasyRankUser>>(
                userManagerMock.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<EasyRankUser>>(),
                null, null, null, null);

            //this.commentService = CommentServiceMock.MockCommentService().Object;
            this.accountController = new AccountController(
                userManagerMock.Object,
                signInManager.Object,
                Mock.Of<IEmailSender>(),
                Mock.Of<IAccountService>())
            {
                TempData = tempData,
            };
        }

        [Test]
        public void Test_Register_Get_UserNotLoggedIn_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.accountController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = this.accountController.Register();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RegisterViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RegisterViewModel>());
        }

        [Test]
        public void Test_Register_Get_LoggedInUser_RedirectsToHomeIndex()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user
            this.accountController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = this.accountController.Register();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Test_Login_Get_UserNotLoggedIn_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.accountController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = this.accountController.Login();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'LoginViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<LoginViewModel>());
        }

        [Test]
        public void Test_Login_Get_LoggedInUser_RedirectsToHomeIndex()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user
            this.accountController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = this.accountController.Login();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Test_VerifyEmail_Get_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.accountController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = this.accountController.VerifyEmail();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'VerifyEmailViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<VerifyEmailViewModel>());
        }

        [Test]
        public void Test_ForgotPassword_Get_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.accountController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = this.accountController.ForgotPassword();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'VerifyEmailViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<VerifyEmailViewModel>());
        }

        [Test]
        public void Test_ForgotPasswordConfirmation_Get_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.accountController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = this.accountController.ForgotPasswordConfirmation();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_ResetPasswordConfirmation_Get_ReturnsCorrectView()
        {
            // Arrange: create controller HTTP context with not logged in user
            this.accountController.WithAnonymousUser();

            // Act: invoke the controller method
            IActionResult result = this.accountController.ResetPasswordConfirmation();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
