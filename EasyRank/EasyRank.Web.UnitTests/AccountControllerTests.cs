// -----------------------------------------------------------------------
// <copyright file="AccountControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Account;
using EasyRank.Web.UnitTests.Mocks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    public class AccountControllerTests : UnitTestBase
    {
        private IAccountService accountService;
        private AccountController accountController;

        [OneTimeSetUp]
        public void SetUp()
        {
            Mock<UserManager<EasyRankUser>> userManagerMock = new Mock<UserManager<EasyRankUser>>(
                Mock.Of<IUserStore<EasyRankUser>>(),
                null, null, null, null, null, null, null, null);

            Mock<SignInManager<EasyRankUser>> signInManager = new Mock<SignInManager<EasyRankUser>>(
                userManagerMock.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<EasyRankUser>>(),
                null, null, null, null);

            Mock<IManageService> manageServiceMock = new Mock<IManageService>();

            this.accountService = AccountServiceMock.MockAccountService(new List<EasyRankUser>
            {
                this.testDb.GuestUser,
                this.testDb.UnconfirmedUser,
            }).Object;

            this.accountController = new AccountController(
                userManagerMock.Object,
                signInManager.Object,
                Mock.Of<IEmailSender>(),
                this.accountService,
                manageServiceMock.Object);

            this.accountController.AddUrlHelper();
            this.accountController.AddRequestScheme();
            this.accountController.AddTempData();
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
        public async Task Test_Register_Post_InvalidModelState_ReturnsSameView()
        {
            // Arrange: add model error to the model state
            this.accountController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.accountController.Register(new RegisterViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RegisterViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RegisterViewModel>());
        }

        [Test]
        public async Task Test_Register_Post_ValidModelState_SucceededIdentityResult_RedirectsToHomeIndex()
        {
            // Arrange: clear the model state
            this.accountController.ModelState.Clear();

            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user
            this.accountController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.accountController.Register(new RegisterViewModel
            {
                Password = "RandomPassword",
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Test_Register_Post_ValidModelState_FailedIdentityResult_ReturnsSameView_WithModelErrors()
        {
            // Arrange: clear the model state
            this.accountController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.accountController.Register(new RegisterViewModel
            {
                Password = "ReturnInvalidResult",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'RegisterViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<RegisterViewModel>());

            // Assert: model state has errors   
            Assert.That(this.accountController.ModelState.ErrorCount, Is.GreaterThan(0));
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
        public async Task Test_Login_Post_InvalidModelState_ReturnsSameView()
        {
            // Arrange: add model error to the model state
            this.accountController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.accountController.LoginAsync(new LoginViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'LoginViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<LoginViewModel>());
        }

        [Test]
        public async Task Test_Login_Post_ValidModelState_NotConfirmedEmail_ReturnsEmailNotConfirmedView()
        {
            // Arrange: get unconfirmed user email from test db
            string unconfirmedEmail = this.testDb.UnconfirmedUser.Email;

            // Arrange: clear the model state
            this.accountController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.accountController.LoginAsync(new LoginViewModel
            {
                Email = unconfirmedEmail,
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view name is 'EmailNotConfirmed'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewName, Is.EqualTo("EmailNotConfirmed"));
        }

        [Test]
        public async Task Test_Login_Post_ValidModelState_FailedSignInResult_ReturnsSameView_WithModelErrors()
        {
            // Arrange: get guest user email from test db
            string guestEmail = this.testDb.GuestUser.Email;

            // Arrange: clear the model state
            this.accountController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.accountController.LoginAsync(new LoginViewModel
            {
                Email = guestEmail,
                Password = "ReturnInvalidResult",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'LoginViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<LoginViewModel>());

            // Assert: model state has errors   
            Assert.That(this.accountController.ModelState.ErrorCount, Is.GreaterThan(0));
        }

        [Test]
        public async Task Test_Login_Post_ValidModelState_SuccessfulSignInResult_RedirectsToReturnUrl_WithReturnUrl()
        {
            // Arrange: get guest user email from test db
            string guestEmail = this.testDb.GuestUser.Email;

            // Arrange: clear the model state
            this.accountController.ModelState.Clear();

            // Act: invoke the controller method
            string exampleUrl = "https://www.exampleUrl.com";
            IActionResult result = await this.accountController.LoginAsync(new LoginViewModel
            {
                Email = guestEmail,
                Password = "123456",
                ReturnUrl = exampleUrl,
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectResult>());

            // Assert: URL redirect matches
            RedirectResult redirectResult = (result as RedirectResult)!;
            Assert.That(redirectResult.Url, Is.EqualTo(exampleUrl));
        }

        [Test]
        public async Task Test_Login_Post_ValidModelState_SuccessfulSignInResult_RedirectsToIndexHome_WithoutReturnUrl()
        {
            // Arrange: get guest user email from test db
            string guestEmail = this.testDb.GuestUser.Email;

            // Arrange: clear the model state
            this.accountController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.accountController.LoginAsync(new LoginViewModel
            {
                Email = guestEmail,
                Password = "123456",
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Test_Logout_Post_LoggedInUser_RedirectsToHomeIndex()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user
            this.accountController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.accountController.LogoutAsync();

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
            // Arrange:

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
            // Arrange:

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
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.accountController.ForgotPasswordConfirmation();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        [Test]
        public void Test_ResetPassword_Get_NullCode_RedirectsToHomeIndex()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.accountController.ResetPassword();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Test_ResetPassword_Get_Code_ReturnsCorrectView()
        {
            // Arrange: create valid code
            string codeString = "test-string";
            string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(codeString));

            // Act: invoke the controller method
            IActionResult result = this.accountController.ResetPassword(code);

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ResetPasswordViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ResetPasswordViewModel>());
        }

        [Test]
        public void Test_ResetPasswordConfirmation_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.accountController.ResetPasswordConfirmation();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        //[Test]
        //public async Task Test_Create_Post_ValidModelState_RedirectsToViewRank()
        //{
        //    // Arrange: get guest user from test db
        //    EasyRankUser user = this.testDb.GuestUser;

        //    // Arrange: create controller HTTP context with valid user and valid form
        //    this.commentController.ControllerContext = TestingUtils.CreateControllerContext(user);

        //    // Arrange: clear the model state
        //    this.commentController.ModelState.Clear();

        //    // Act: invoke the controller method
        //    IActionResult result = await this.commentController.CreateAsync(Guid.NewGuid(),
        //        new CommentFormModel
        //        {
        //            Content = "No js",
        //        });

        //    // Assert: returned result is not null, it is a redirect
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.TypeOf<RedirectToActionResult>());

        //    // Assert: controller name is 'Rank', action name is 'ViewRanking'
        //    RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
        //    Assert.That(redirectResult.ControllerName, Is.EqualTo("Rank"));
        //    Assert.That(redirectResult.ActionName, Is.EqualTo("ViewRanking"));
        //    Assert.That(redirectResult.RouteValues, Is.Not.Null);
        //}
    }
}
