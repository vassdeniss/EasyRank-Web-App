// -----------------------------------------------------------------------
// <copyright file="ManageControllerTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;
using EasyRank.Web.Models.Manage;
using EasyRank.Web.Models.Rank;
using EasyRank.Web.UnitTests.Mocks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    public class ManageControllerTests : UnitTestBase
    {
        private ManageController manageController;

        [SetUp]
        public void SetUp()
        {
            this.manageController = new ManageController(
                Mock.Of<IEmailSender>(),
                this.mapper,
                Mock.Of<IRankService>(),
                ManageServiceMock.MockManageService(
                    this.testDb.GuestUser,
                    this.testDb.DenisUser).Object,
                AccountServiceMock.MockAccountService(
                    this.testDb.GuestUser,
                    this.testDb.UnconfirmedUser).Object);

            this.manageController.AddTempData();
            this.manageController.AddRequestScheme();
            this.manageController.AddUrlHelper();
        }

        [Test]
        public async Task Test_Index_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.IndexAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ManageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ManageViewModel>());
        }

        [Test]
        public async Task Test_Index_Post_InvalidModelState_ReturnsSameView()
        {
            // Arrange: add model error to the model state
            this.manageController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.manageController.IndexAsync(new ManageViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ManageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ManageViewModel>());
        }

        [Test]
        public async Task Test_Index_Post_ValidModelState_RedirectsToManageIndex_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with valid user and valid form
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName)
                .AddFormWithFile("image.jpg");

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.IndexAsync(new ManageViewModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public async Task Test_DeleteProfilePicture_Post_RedirectsToManageIndex_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.DeleteProfilePictureAsync();

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));

            // Assert: temp data exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public void Test_DeleteAccount_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.manageController.DeleteAccount();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'DeleteAccountViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<DeleteAccountViewModel>());
        }

        [Test]
        public async Task Test_DeleteAccount_Post_InvalidModelState_ReturnsSameView()
        {
            // Arrange: add model error to the model state
            this.manageController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.manageController.DeleteAccountAsync(new DeleteAccountViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'DeleteAccountViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<DeleteAccountViewModel>());
        }

        [Test]
        public async Task Test_DeleteAccount_Post_WrongUserPassword_ReturnsSameView_WithModelStateErrors()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.DeleteAccountAsync(new DeleteAccountViewModel
            {
                Password = "FailCheck",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'DeleteAccountViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<DeleteAccountViewModel>());

            // Assert: model errors exist
            Assert.That(this.manageController.ModelState.ErrorCount, Is.GreaterThan(0));
        }

        [Test]
        public async Task Test_DeleteAccount_Post_CorrectUserPassword_RedirectsToHomeIndex()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.DeleteAccountAsync(new DeleteAccountViewModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Home', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Home"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Test_Email_Get_ReturnsCorrectView_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.EmailAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'EmailViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<EmailViewModel>());

            // Assert: temp data exists
            Assert.That(viewResult.TempData.ContainsKey("ConfirmedEmail"), Is.True);
        }

        [Test]
        public async Task Test_Email_Post_InvalidModelState_ReturnsSameView()
        {
            // Arrange: add model error to the model state
            this.manageController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.manageController.EmailAsync(new EmailViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'EmailViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<EmailViewModel>());
        }

        [Test]
        public async Task Test_Email_Post_SameEmail_RedirectsToManageEmail_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.EmailAsync(new EmailViewModel
            {
                Email = user.Email,
                NewEmail = user.Email,
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Email'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Email"));

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("ConfirmedEmail"), Is.True);
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public async Task Test_Email_Post_TakenEmail_RedirectsToManageEmail_WithTempData()
        {
            // Arrange: get guest user, denis user from test db
            EasyRankUser user = this.testDb.GuestUser;
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.EmailAsync(new EmailViewModel
            {
                Email = user.Email,
                NewEmail = denisUser.Email,
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Email'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Email"));

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public async Task Test_Email_Post_CorrectData_RedirectsToManageEmail_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.EmailAsync(new EmailViewModel
            {
                Email = user.Email,
                NewEmail = $"{user.Email}123",
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Email'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Email"));

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [TestCase(null, "email", "123")]
        [TestCase("id", null, "123")]
        [TestCase("id", "email", null)]
        public async Task Test_ConfirmEmailChange_Get_NullParameters_RedirectsToManageIndex(
            string userId,
            string email,
            string code)
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ConfirmEmailChangeAsync(
                userId, 
                email, 
                code);

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [TestCase("RandomEmail")]
        [TestCase("FailCheck")]
        public async Task Test_ConfirmEmailChange_Get_CheckResult_ReturnsCorrectView_WithTempData(string email)
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ConfirmEmailChangeAsync(
                Guid.NewGuid().ToString(),
                email,
                "some-code");

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public async Task Test_SendVerificationEmail_Post_InvalidModelState_ReturnsToEmailView()
        {
            // Arrange: add model error to the model state
            this.manageController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.manageController.SendVerificationEmailAsync(new EmailViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'EmailViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<EmailViewModel>());

            // Assert: view name is correct
            Assert.That(viewResult.ViewName, Is.EqualTo("Email"));
        }

        [Test]
        public async Task Test_SendVerificationEmail_Post_ValidModelState_RedirectsToManageEmail_WithTempData()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.SendVerificationEmailAsync(new EmailViewModel());

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Email'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Email"));

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("ConfirmedEmail"), Is.True);
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [TestCase(null, "123")]
        [TestCase("id", null)]
        public async Task Test_ConfirmEmail_Get_NullParameters_RedirectsToManageIndex(
            string userId,
            string code)
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ConfirmEmailAsync(userId, code);

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'Index'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Test_ConfirmEmail_Get_ValidParameters_ReturnsCorrectView_WithTempData()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ConfirmEmailAsync(
                Guid.NewGuid().ToString(),
                "some-code");

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public void Test_ChangePassword_Get_ReturnsCorrectView()
        {
            // Arrange:

            // Act: invoke the controller method
            IActionResult result = this.manageController.ChangePassword();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ChangePasswordViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ChangePasswordViewModel>());
        }

        [Test]
        public async Task Test_ChangePassword_Post_InvalidModelState_ReturnsSameView()
        {
            // Arrange: add model error to the model state
            this.manageController.ModelState.AddModelError(string.Empty, "Some error");

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ChangePasswordAsync(new ChangePasswordViewModel());

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ChangePasswordViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ChangePasswordViewModel>());
        }

        [Test]
        public async Task Test_ChangePassword_Post_SamePassword_ReturnsSameView_WithTempData()
        {
            // Arrange: get guest user password
            string guestUserPassword = "guestPass";

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ChangePasswordAsync(new ChangePasswordViewModel
            {
                OldPassword = guestUserPassword,
                NewPassword = guestUserPassword,
                ConfirmPassword = guestUserPassword,
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ChangePasswordViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ChangePasswordViewModel>());

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public async Task Test_ChangePassword_Post_FailedResult_ReturnsSameView_WithModelErrors()
        {
            // Arrange: get guest user, password from test db
            EasyRankUser user = this.testDb.GuestUser;
            string guestUserPassword = "guestPass";

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ChangePasswordAsync(new ChangePasswordViewModel
            {
                OldPassword = guestUserPassword,
                NewPassword = "FailCheck",
                ConfirmPassword = "FailCheck",
            });

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is of type 'ChangePasswordViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.AssignableFrom<ChangePasswordViewModel>());

            // Assert: model state errors exists
            Assert.That(this.manageController.ModelState.ErrorCount, Is.GreaterThan(0));
        }

        [Test]
        public async Task Test_ChangePassword_Post_PassedResult_RedirectsToManageChangePassword_WithTempData()
        {
            // Arrange: get guest user, password from test db
            EasyRankUser user = this.testDb.GuestUser;
            string guestUserPassword = "guestPass";

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Arrange: clear the model state
            this.manageController.ModelState.Clear();

            // Act: invoke the controller method
            IActionResult result = await this.manageController.ChangePasswordAsync(new ChangePasswordViewModel
            {
                OldPassword = guestUserPassword,
                NewPassword = "123",
                ConfirmPassword = "123",
            });

            // Assert: returned result is not null, it is a redirect
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());

            // Assert: controller name is 'Manage', action name is 'ChangePassword'
            RedirectToActionResult redirectResult = (result as RedirectToActionResult)!;
            Assert.That(redirectResult.ControllerName, Is.EqualTo("Manage"));
            Assert.That(redirectResult.ActionName, Is.EqualTo("ChangePassword"));

            // Assert: TempData exists
            Assert.That(this.manageController.TempData.ContainsKey("StatusMessage"), Is.True);
        }

        [Test]
        public async Task Test_MyRanks_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.MyRanksAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankPageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankPageViewModel>>());
        }

        [Test]
        public async Task Test_MyLikes_Get_ReturnsCorrectView()
        {
            // Arrange: get guest user from test db
            EasyRankUser user = this.testDb.GuestUser;

            // Arrange: create controller HTTP context with logged in user
            this.manageController
                .WithAnonymousUser()
                .ButThenAuthenticateUsing(user.Id, user.UserName);

            // Act: invoke the controller method
            IActionResult result = await this.manageController.MyLikesAsync();

            // Assert: returned result is not null, it is a view
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());

            // Assert: view model is a collection of type 'RankPageViewModel'
            ViewResult viewResult = (result as ViewResult)!;
            Assert.That(viewResult.ViewData.Model, Is.InstanceOf<IEnumerable<RankPageViewModel>>());
        }
    }
}
