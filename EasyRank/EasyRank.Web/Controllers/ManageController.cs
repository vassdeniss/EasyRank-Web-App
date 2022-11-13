﻿// -----------------------------------------------------------------------
// <copyright file="ManageController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Web.Models.Manage;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace EasyRank.Web.Controllers
{
    [Route("Account/Manage")]
    public class ManageController : BaseController
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly IEmailSender emailSender;

        public ManageController(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
        }

        /// <summary>
        /// The get method for the razor page.
        /// </summary>
        /// <returns>A view for changing basic user account settings.</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> IndexAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            string userName = await this.userManager.GetUserNameAsync(user);
            //string phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            string firstName = user.FirstName!;
            string lastName = user.LastName!;
            byte[] profilePicture = user.ProfilePicture!;

            ManageViewModel model = new ManageViewModel
            {
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
            };

            return this.View(model);
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The same page for changing user settings with a success / failure message.</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> IndexAsync(ManageViewModel model)
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

            //var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            string firstName = user.FirstName!;
            if (model.FirstName != firstName)
            {
                user.FirstName = model.FirstName;
            }

            string lastName = user.LastName!;
            if (model.LastName != lastName)
            {
                user.LastName = model.LastName;
            }

            //if (model.Username == null)
            //{
            //    this.StatusMessage = "Error: Username is empty!";
            //    return this.RedirectToPage();
            //}

            string username = user.UserName;
            if (model.Username != username)
            {
                EasyRankUser userWithGivenUsername = await this.userManager.FindByNameAsync(model.Username);
                if (userWithGivenUsername != null)
                {
                    this.TempData["StatusMessage"] = "Error: Username taken!";
                    return this.RedirectToAction("Index");
                }

                await this.userManager.SetUserNameAsync(user, model.Username);
            }

            if (this.Request.Form.Files.Count > 0)
            {
                IFormFile file = this.Request.Form.Files.First();

                using MemoryStream memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);
                user.ProfilePicture = memoryStream.ToArray();
            }

            await this.userManager.UpdateAsync(user);

            await this.signInManager.RefreshSignInAsync(user);
            this.TempData["StatusMessage"] = "Your profile has been updated";

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The same page for changing user settings with a deleted profile picture.</returns>
        /// <remarks>Post for when profile picture is getting deleted.</remarks>
        [HttpPost]
        [Route("DeleteProfilePicture")]
        public async Task<IActionResult> DeleteProfilePictureAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            user.ProfilePicture = null;

            await this.userManager.UpdateAsync(user);

            await this.signInManager.RefreshSignInAsync(user);
            this.TempData["StatusMessage"] = "Your profile picture has been updated";

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The get method for the razor page.
        /// </summary>
        /// <returns>A view for deleting the users account.</returns>
        [HttpGet]
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccountAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            //RequirePassword = await this.userManager.HasPasswordAsync(user);
            return this.View();
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The home view after the user has been deleted.</returns>
        [HttpPost]
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccountAsync(DeleteAccountViewModel model)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            //RequirePassword = await this.userManager.HasPasswordAsync(user);
            //if (RequirePassword)
            //{
            //    if (!await this.userManager.CheckPasswordAsync(user, Input.Password))
            //    {
            //        ModelState.AddModelError(string.Empty, "Incorrect password.");
            //        return Page();
            //    }
            //}

            if (!await this.userManager.CheckPasswordAsync(user, model.Password))
            {
                this.ModelState.AddModelError(string.Empty, "Incorrect password.");
                return this.View(model);
            }

            IdentityResult result = await this.userManager.DeleteAsync(user);
            string userId = await this.userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Unexpected error occurred deleting user.");
            }

            await this.signInManager.SignOutAsync();

            //this.logger.LogInformation($"User with ID '{userId}' deleted themselves.");

            return this.RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The change email action for the controller.
        /// </summary>
        /// <returns>A change email view for changing the users email.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        [Route("Email")]
        public async Task<IActionResult> EmailAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            string email = await this.userManager.GetEmailAsync(user);

            this.TempData["ConfirmedEmail"] = await this.userManager.IsEmailConfirmedAsync(user);

            EmailViewModel model = new EmailViewModel
            {
                Email = email,
                NewEmail = email,
            };

            return this.View(model);
        }

        /// <summary>
        /// The change email action for the controller.
        /// </summary>
        /// <returns>A redirect back to the change email page with either a success or error message.</returns>
        /// <param name="model">The email view model for the view.</param>
        /// <remarks>Post for when email is getting changed.</remarks>
        [HttpPost]
        [Route("Email")]
        public async Task<IActionResult> EmailAsync(EmailViewModel model)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            string email = await this.userManager.GetEmailAsync(user);

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (model.NewEmail != email)
            {
                EasyRankUser userWithGivenEmail = await this.userManager.FindByEmailAsync(model.NewEmail);
                if (userWithGivenEmail != null)
                {
                    this.TempData["StatusMessage"] = "Error: Email taken!";
                    return this.RedirectToAction("Email");
                }

                string userId = await this.userManager.GetUserIdAsync(user);
                string code = await this.userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                string callbackUrl = this.Url.Page(
                    "/Account/ConfirmEmailChange", // TODO: CHeck functionality
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, email = model.NewEmail, code = code },
                    protocol: this.Request.Scheme)!;

                await this.emailSender.SendEmailAsync(
                    model.NewEmail,
                    "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                this.TempData["StatusMessage"] = "Confirmation link to change email sent. Please check your email!";
                return this.RedirectToAction("Email");
            }

            this.TempData["ConfirmedEmail"] = await this.userManager.IsEmailConfirmedAsync(user);
            this.TempData["StatusMessage"] = "Error: Your email is unchanged.";
            return this.RedirectToAction("Email");
        }

        /// <summary>
        /// The verify email action for the controller.
        /// </summary>
        ///// <returns>The same page for changing the users email.</returns>
        ///// <remarks>Post for when email is getting verified.</remarks>
        [HttpPost]
        [Route("VerifyEmail")]
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
                values: new { area = "Identity", userId = userId, code = code },
                protocol: this.Request.Scheme)!;

            await this.emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            this.TempData["ConfirmedEmail"] = await this.userManager.IsEmailConfirmedAsync(user);
            this.TempData["StatusMessage"] = "Verification email sent. Please check your email.";
            return this.RedirectToAction("Email");
        }

        /// <summary>
        /// The change password action for the controller.
        /// </summary>
        /// <returns>A change password view for changing the users password.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            //bool hasPassword = await this.userManager.HasPasswordAsync(user);
            //if (!hasPassword)
            //{
            //    return this.RedirectToPage("./SetPassword");
            //}

            return this.View();
        }

        /// <summary>
        /// The change password action for the controller.
        /// </summary>
        /// <returns>A redirect back to the change password page with either a success or error message.</returns>
        /// <param name="model">The change password view model for the view.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (model.OldPassword == model.NewPassword)
            {
                this.TempData["StatusMessage"] = "Error: Password is the same!";
                return this.View();
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

                return this.View();
            }

            await this.signInManager.RefreshSignInAsync(user);
            //this.logger.LogInformation("User changed their password successfully.");
            this.TempData["StatusMessage"] = "Your password has been changed.";

            return this.RedirectToAction("ChangePassword");
        }
    }
}