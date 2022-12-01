// -----------------------------------------------------------------------
// <copyright file="ManageController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;
using EasyRank.Web.Claims;
using EasyRank.Web.Models.Manage;
using EasyRank.Web.Models.Rank;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for account management.
    /// </summary>
    public class ManageController : BaseController
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;
        private readonly IRankService rankService;
        private readonly IManageService manageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for the controller.</param>
        /// <param name="signInManager">The sign in manager for the controller.</param>
        /// <param name="emailSender">The email sender for the controller.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        /// <param name="rankService">Instance of the rank service.</param>
        /// <param name="manageService">Instance of the manage service.</param>
        public ManageController(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IEmailSender emailSender,
            IMapper mapper,
            IRankService rankService,
            IManageService manageService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.mapper = mapper;
            this.rankService = rankService;
            this.manageService = manageService;
        }

        /// <summary>
        /// The 'Index' action for the controller.
        /// </summary>
        /// <returns>A view for changing basic user account settings.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            ManageServiceModel serviceModel = await this.manageService.GetUserInfoAsync(this.User);

            ManageViewModel model = this.mapper.Map<ManageViewModel>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// The 'Index' action for the controller.
        /// </summary>
        /// <returns>Redirects to the same page with either a success / failure message.</returns>
        /// <param name="model">The 'ManageViewModel' for verification.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> IndexAsync(ManageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.manageService.UpdateUserDataAsync(
                this.User,
                model.FirstName,
                model.LastName,
                model.Username,
                this.Request.Form.Files);

            this.TempData["StatusMessage"] = "Your profile has been updated";

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The 'DeleteProfilePicture' action for the controller.
        /// </summary>
        /// <returns>Redirects to the same page with the profile picture deleted.</returns>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> DeleteProfilePictureAsync()
        {
            await this.manageService.DeleteProfilePictureAsync(this.User);

            this.TempData["StatusMessage"] = "Your profile picture has been updated";

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The 'DeleteAccount' action for the controller.
        /// </summary>
        /// <returns>A view for deleting the users account.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult DeleteAccountAsync()
        {
            DeleteAccountViewModel model = new DeleteAccountViewModel();

            //RequirePassword = await this.userManager.HasPasswordAsync(user);

            return this.View(model);
        }

        /// <summary>
        /// The 'DeleteAccount' action for the controller.
        /// </summary>
        /// <returns>The 'Home' controller's Index' view after the user has been deleted.</returns>
        /// <param name="model">The DeleteAccountViewModel for validation.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> DeleteAccountAsync(DeleteAccountViewModel model)
        {
            if (!await this.manageService.CheckPasswordAsync(this.User, model.Password))
            {
                this.ModelState.AddModelError(string.Empty, "Incorrect password.");
                return this.View(model);
            }

            await this.manageService.DeleteUserAsync(this.User);

            return this.RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The 'EmailAsync' action for the controller.
        /// </summary>
        /// <returns>A view for changing the users email.</returns>
        /// <remarks>Get method.</remarks>
        /// <remarks>For changing email.</remarks>
        [HttpGet]
        public async Task<IActionResult> EmailAsync()
        {
            EmailServiceModel serviceModel = await this.manageService.GetUserEmailAsync(this.User);

            EmailViewModel model = this.mapper.Map<EmailViewModel>(serviceModel);
            this.TempData["ConfirmedEmail"] = await this.manageService.IsEmailConfirmedAsync(this.User);

            return this.View(model);
        }

        /// <summary>
        /// The 'EmailAsync' action for the controller.
        /// </summary>
        /// <returns>A redirect back to the same page with either a success or error message.</returns>
        /// <param name="model">The EmailViewModel for validation.</param>
        /// <remarks>Post method.</remarks>
        /// <remarks>For changing email.</remarks>
        [HttpPost]
        public async Task<IActionResult> EmailAsync(EmailViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            EmailServiceModel serviceModel = await this.manageService.GetUserEmailAsync(this.User);

            string email = serviceModel.Email;
            if (model.NewEmail != email)
            {
                if (await this.manageService.IsEmailTakenAsync(model.NewEmail))
                {
                    this.TempData["StatusMessage"] = "Error: Email taken!";
                    return this.RedirectToAction("Email");
                }

                string userId = await this.manageService.GetUserIdAsync(this.User);
                string code = await this.manageService.GenerateChangeEmailTokenAsync(this.User, model.NewEmail);

                string callbackUrl = this.Url.ActionLink(
                    "ConfirmEmailChange",
                    "Manage",
                    new { userId, email = model.NewEmail, code },
                    this.Request.Scheme)!;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("<h2>Hello, Denis here, founder of EasyRank!</h2>");
                builder.AppendLine("<h3>You receive this email because you wished to change your email address for your account.</h3>");
                builder.AppendLine($"<p>In order to do so please confirm that this is the new email you wish to use by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here.</a></p>");
                builder.AppendLine("<p><strong>If this request was not made by you please ignore this email!!!</strong></p>");
                builder.AppendLine("<p>Have a wonderful rest of your day and happy ranking!</p>");
                builder.AppendLine("<br>");
                builder.AppendLine("- Denis from EasyRank");

                await this.emailSender.SendEmailAsync(
                    "vassdeniss@gmail.com",
                    "Denis Vasilev from EasyRank",
                    model.NewEmail,
                    "[DO NOT REPLY] Confirm your new email for EasyRank!",
                    builder.ToString());

                this.TempData["StatusMessage"] = "Confirmation link to change email sent. Please check your email!";
                return this.RedirectToAction("Email");
            }

            this.TempData["ConfirmedEmail"] = await this.manageService.IsEmailConfirmedAsync(this.User);
            this.TempData["StatusMessage"] = "Error: Your email is unchanged.";
            return this.RedirectToAction("Email");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmailChangeAsync(string? userId, string? email, string? code)
        {
            if (userId == null || email == null || code == null)
            {
                return this.RedirectToAction("Index", "Manage");
            }

            EasyRankUser user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
               // throw
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            IdentityResult result = await this.userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                this.TempData["StatusMessage"] = "Error changing email.";
                return this.View();
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.TempData["StatusMessage"] = "Thank you for confirming your email change.";
            return this.View();
        }

        /// <summary>
        /// The verify email action for the controller.
        /// </summary>
        /// <returns>A redirect back to the change email page with either a success or error message.</returns>
        /// <param name="model">The email view model for the view.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> SendVerificationEmailAsync(EmailViewModel model)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string userId = await this.userManager.GetUserIdAsync(user);
            string email = await this.userManager.GetEmailAsync(user);
            string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            string callbackUrl = this.Url.Page(
                "/Account/ConfirmEmail", // TODO: Test
                pageHandler: null,
                values: new { area = "Identity", userId, code },
                protocol: this.Request.Scheme)!;

            await this.emailSender.SendEmailAsync(
                "vassdeniss@gmail.com",
                "Denis Vasilev from EasyRank",
                email,
                "[DO NOT REPLY] Confirm your email for EasyRank!",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            this.TempData["ConfirmedEmail"] = await this.userManager.IsEmailConfirmedAsync(user);
            this.TempData["StatusMessage"] = "Verification email sent. Please check your email.";
            return this.RedirectToAction("Email");
        }

        /// <summary>
        /// The 'ChangePassword' action for the controller.
        /// </summary>
        /// <returns>A view for changing the users password.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult ChangePasswordAsync()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();

            //bool hasPassword = await this.userManager.HasPasswordAsync(user);
            //if (!hasPassword)
            //{
            //    return this.RedirectToPage("./SetPassword");
            //}

            return this.View(model);
        }

        /// <summary>
        /// The 'ChangePassword' action for the controller.
        /// </summary>
        /// <returns>A redirect back to the same page with either a success or error message.</returns>
        /// <param name="model">The 'ChangePassword' view model for the validation.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (model.OldPassword == model.NewPassword)
            {
                this.TempData["StatusMessage"] = "Error: Password is the same!";
                return this.View();
            }

            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            IdentityResult changePasswordResult = await this.userManager.ChangePasswordAsync(user,
                model.OldPassword,
                model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (IdentityError error in changePasswordResult.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.View(model);
            }

            await this.signInManager.RefreshSignInAsync(user);
            //this.logger.LogInformation("User changed their password successfully.");
            this.TempData["StatusMessage"] = "Your password has been changed.";

            return this.RedirectToAction("ChangePassword");
        }

        /// <summary>
        /// The 'MyRanks' action for the controller.
        /// </summary>
        /// <returns>A view showing all the rankings you as a user has made.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> MyRanksAsync()
        {
            ICollection<RankPageServiceModel> serviceModel =
                await this.rankService.GetAllRankingsByUserAsync(this.User.Id());

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// The 'MyLikes' action for the controller.
        /// </summary>
        /// <returns>A view showing all the rankings you as a user has liked.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> MyLikesAsync()
        {
            ICollection<RankPageServiceModel> serviceModel =
                await this.rankService.GetAllLikesByUserAsync(this.User.Id());

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }
    }
}
