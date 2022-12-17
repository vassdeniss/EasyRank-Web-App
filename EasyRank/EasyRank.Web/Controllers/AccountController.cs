// -----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using EasyRank.Services.Contracts;
using EasyRank.Web.Models.Account;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for user management.
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly IEmailSender emailSender;
        private readonly IAccountService accountService;
        private readonly IManageService manageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// Constructor for the account controller.
        /// </summary>
        /// <param name="emailSender">The email sender for the controller.</param>
        /// <param name="accountService">The account service for the controller.</param>
        /// <param name="manageService">The manage service for the controller</param>
        public AccountController(
            IEmailSender emailSender,
            IAccountService accountService,
            IManageService manageService)
        {
            this.emailSender = emailSender;
            this.accountService = accountService;
            this.manageService = manageService;
        }

        /// <summary>
        /// The register action for the controller.
        /// </summary>
        /// <returns>A register view with an empty 'RegisterViewModel'.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (this.User.Identity!.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            RegisterViewModel model = new RegisterViewModel();

            return this.View(model);
        }

        /// <summary>
        /// The register action for the controller.
        /// </summary>
        /// <returns>A register view with an empty 'RegisterViewModel'.</returns>
        /// <param name="model">The 'RegisterViewModel' for the view.</param>
        /// <remarks>Post method. Guest access allowed.</remarks>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            IdentityResult result = await this.accountService.CreateUserAsync(
                model.Email,
                model.FirstName,
                model.LastName,
                model.Username,
                model.Password);

            if (result.Succeeded)
            {
                Guid userId = await this.accountService.GetUserIdByEmail(model.Email);
                string code = await this.accountService.GenerateEmailConfirmationTokenAsync(userId);
                string callbackUrl = this.Url.Action(
                    "ConfirmEmail",
                    "Manage",
                    new { userId, code },
                    this.Request.Scheme)!;

                StringBuilder builder = new StringBuilder();

                builder.AppendLine("<h2>Hello, Denis here, founder of EasyRank!</h2>");
                builder.AppendLine("<h3>You receive this email because you requested a link to confirm your email for EasyRank.</h3>");
                builder.AppendLine($"<p>In order to do so please <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click here.</a></p>");
                builder.AppendLine("<p><strong>If this request was not made by you please contact customer support immediately!</strong></p>");
                builder.AppendLine("<p>Have a wonderful rest of your day and welcome to <strong>EasyRank!</strong></p>");
                builder.AppendLine("<br>");
                builder.AppendLine("- Denis from EasyRank");

                await this.emailSender.SendEmailAsync(
                    "vassdeniss@gmail.com",
                    "Denis Vasilev from EasyRank",
                    model.Email,
                    "[DO NOT REPLY] Confirm your email for EasyRank!",
                    builder.ToString());

                return this.RedirectToAction("Index", "Home");
            }

            foreach (IdentityError error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.View(model);
        }

        /// <summary>
        /// The login action for the controller.
        /// </summary>
        /// <returns>A login view with an empty 'LoginViewModel'.</returns>
        /// <param name="returnUrl">The return url for the view.</param>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            if (this.User.Identity!.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
            };

            return this.View(model);
        }

        /// <summary>
        /// The login action for the controller.
        /// </summary>
        /// <returns>A redirect to either a return url, to home, or back to the login page in case of an error.</returns>
        /// <remarks>Post method. Guest access allowed.</remarks>
        /// <param name="model">The 'LoginViewModel' for the view.</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (!await this.accountService.IsEmailConfirmedAsync(model.Email))
            {
                return this.View("EmailNotConfirmed");
            }

            SignInResult result = await this.accountService.SignInUserAsync(model.Email, model.Password);
            if (result.Succeeded)
            {
                if (model.ReturnUrl != null)
                {
                    return this.Redirect(model.ReturnUrl);
                }

                return this.RedirectToAction("Index", "Home");
            }

            this.ModelState.AddModelError(string.Empty, "Invalid login!");
            return this.View(model);
        }

        /// <summary>
        /// The log out action for the controller.
        /// </summary>
        /// <returns>Redirect to the home page.</returns>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await this.accountService.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The 'VerifyEmailAsync' action for the controller.
        /// </summary>
        /// <returns>A view for requesting a verifying email.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult VerifyEmail()
        {
            VerifyEmailViewModel model = new VerifyEmailViewModel();

            return this.View(model);
        }

        /// <summary>
        /// The 'VerifyEmailAsync' action for the controller.
        /// </summary>
        /// <returns>A redirect back to the page with either a success or error message.</returns>
        /// <param name="model">The EmailViewModel for the view.</param>
        /// <remarks>Post method. Guest access allowed.</remarks>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmailAsync(VerifyEmailViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (!await this.accountService.DoesUserExist(model.Email))
            {
                this.ModelState.AddModelError(string.Empty, "User with this email doesn't exist!");
                return this.View(model);
            }

            if (await this.accountService.IsEmailConfirmedAsync(model.Email))
            {
                this.ModelState.AddModelError(string.Empty, "Email already verified!");
                return this.View(model);
            }

            Guid userId = await this.accountService.GetUserIdByEmail(model.Email);
            string code = await this.accountService.GenerateEmailConfirmationTokenAsync(userId);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            string callbackUrl = this.Url.Action(
                "ConfirmEmail",
                "Manage",
                new { userId, code },
                this.Request.Scheme)!;

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<h2>Hello, Denis here, founder of EasyRank!</h2>");
            builder.AppendLine("<h3>You receive this email because you requested a link to confirm your email for EasyRank.</h3>");
            builder.AppendLine($"<p>In order to do so please <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click here.</a></p>");
            builder.AppendLine("<p><strong>If this request was not made by you please contact customer support immediately!</strong></p>");
            builder.AppendLine("<p>Have a wonderful rest of your day and welcome to <strong>EasyRank!</strong></p>");
            builder.AppendLine("<br>");
            builder.AppendLine("- Denis from EasyRank");

            await this.emailSender.SendEmailAsync(
                "vassdeniss@gmail.com",
                "Denis Vasilev from EasyRank",
                model.Email,
                "[DO NOT REPLY] Confirm your email for EasyRank!",
                builder.ToString());

            this.TempData["StatusMessage"] = "Verification email sent. Please check your email.";
            return this.RedirectToAction("VerifyEmail", "Account");
        }

        /// <summary>
        /// The 'ForgotPassword' action for the controller.
        /// </summary>
        /// <returns>A view for requesting a password reset email.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            VerifyEmailViewModel model = new VerifyEmailViewModel();

            return this.View(model);
        }

        /// <summary>
        /// The 'ForgotPassword' action for the controller.
        /// </summary>
        /// <param name="model">The 'VerifyEmailViewModel' for the validation.</param>
        /// <returns>The same view with error or success message.</returns>
        /// <remarks>Post method. Guest access allowed.</remarks>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordAsync(VerifyEmailViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (!await this.accountService.DoesUserExist(model.Email)
                || !await this.accountService.IsEmailConfirmedAsync(model.Email))
            {
                this.ModelState.AddModelError(string.Empty, "User with this email doesn't exist!");
                return this.View(model);
            }

            Guid userId = await this.accountService.GetUserIdByEmail(model.Email);
            string code = await this.accountService.GeneratePasswordResetTokenAsync(userId);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            string callbackUrl = this.Url.Action(
                "ResetPassword",
                "Account",
                new { code },
                this.Request.Scheme)!;

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<h2>Hello, Denis here, founder of EasyRank!</h2>");
            builder.AppendLine("<h3>You receive this email because you requested a link to reset your password on EasyRank.</h3>");
            builder.AppendLine($"<p>In order to do so please <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click here.</a></p>");
            builder.AppendLine("<p><strong>If this request was not made by you please ignore this email!!!</strong></p>");
            builder.AppendLine("<p>Have a wonderful rest of your day happy ranking!</p>");
            builder.AppendLine("<br>");
            builder.AppendLine("- Denis from EasyRank");

            await this.emailSender.SendEmailAsync(
                "vassdeniss@gmail.com",
                "Denis Vasilev from EasyRank",
                model.Email,
                "[DO NOT REPLY] Reset your password for EasyRank!",
                builder.ToString());

            return this.RedirectToAction("ForgotPasswordConfirmation", "Account");
        }

        /// <summary>
        /// The 'ForgotPasswordConfirmation' for the controller.
        /// </summary>
        /// <returns>A view for confirming a password email was sent.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return this.View();
        }

        /// <summary>
        /// The 'ResetPassword' for the controller.
        /// </summary>
        /// <returns>A view for requesting a password reset email.</returns>
        /// <param name="code">The reset password token.</param>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string? code = null)
        {
            if (code == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code)),
            };

            return this.View(model);
        }

        /// <summary>
        /// The 'ResetPassword' for the controller.
        /// </summary>
        /// <returns>The same page if invalid data otherwise a confirmation page that an email was sent.</returns>
        /// <param name="model">The 'ResetPasswordViewModel' for validation.</param>
        /// <remarks>Post method. Guest access allowed.</remarks>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (!await this.accountService.DoesUserExist(model.Email))
            {
                return this.View(model);
            }

            IdentityResult result = await this.accountService.ResetPasswordAsync(
                model.Email,
                model.Code,
                model.Password);
            if (result.Succeeded)
            {
                return this.RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            foreach (IdentityError error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.View(model);
        }

        /// <summary>
        /// The 'ResetPasswordConfirmation' for the controller.
        /// </summary>
        /// <returns>A view for confirming a password reset happened.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return this.View();
        }
    }
}
