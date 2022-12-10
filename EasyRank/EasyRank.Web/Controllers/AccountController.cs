// -----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Web.Models.Account;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for user management.
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly IEmailSender emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// Constructor for the account controller.
        /// </summary>
        /// <param name="userManager">The user manager for the controller.</param>
        /// <param name="signInManager">The sign in manager for the controller.</param>
        /// <param name="emailSender">The email sender for the controller.</param>
        public AccountController(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
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

            EasyRankUser user = new EasyRankUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
            };

            IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);

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
        public IActionResult LoginAsync(string? returnUrl = null)
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
            // TODO: manual test

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            EasyRankUser user = await this.userManager.FindByEmailAsync(model.Email);
            if (user != null && !user.IsForgotten)
            {
                if (!await this.userManager.IsEmailConfirmedAsync(user))
                {
                    return this.View("EmailNotConfirmed");
                }

                Microsoft.AspNetCore.Identity.SignInResult result = await this.signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    false,
                    false);
                if (result.Succeeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return this.Redirect(model.ReturnUrl);
                    }

                    return this.RedirectToAction("Index", "Home");
                }
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
            await this.signInManager.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The 'VerifyEmailAsync' action for the controller.
        /// </summary>
        /// <returns>A view for requesting a verifying email.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult VerifyEmailAsync()
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

            // TODO: manual test

            EasyRankUser user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null || user.IsForgotten)
            {
                return this.View(model);
            }

            if (await this.userManager.IsEmailConfirmedAsync(user))
            {
                this.ModelState.AddModelError(string.Empty, "Email already verified!");
                return this.View(model);
            }

            string userId = await this.userManager.GetUserIdAsync(user);
            string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            string callbackUrl = this.Url.ActionLink(
                "ConfirmEmail",
                "Manage",
                new { userId, code },
                this.Request.Scheme)!;

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<h2>Hello, Denis here, founder of EasyRank!</h2>");
            builder.AppendLine("<h3>You receive this email because you requested a link to confirm your email for EasyRank.</h3>");
            builder.AppendLine($"<p>In order to do so please <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click here.</a></p>");
            builder.AppendLine("<p><strong>If this request was not made by you please ignore this email!!!</strong></p>");
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
            return this.RedirectToAction("VerifyEmail");
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

            // TODO: manual test

            EasyRankUser user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null || user.IsForgotten || !await this.userManager.IsEmailConfirmedAsync(user))
            {
                return this.RedirectToAction("ForgotPasswordConfirmation");
            }

            string code = await this.userManager.GeneratePasswordResetTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            string callbackUrl = this.Url.ActionLink(
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

            return this.RedirectToAction("ForgotPasswordConfirmation");
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

        // TODO: document
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            // TODO: manual test

            EasyRankUser user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null || user.IsForgotten)
            {
                return this.RedirectToAction("ResetPassword", model);
            }

            IdentityResult result = await this.userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return this.RedirectToAction("ResetPasswordConfirmation");
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
