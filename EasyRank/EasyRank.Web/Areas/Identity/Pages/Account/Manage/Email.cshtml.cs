// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace EasyRank.Web.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// The razor page responsible for changing a users email.
    /// </summary>
    public class EmailModel : PageModel
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly IEmailSender emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailModel"/> class.
        /// </summary>
        /// <param name="userManager">The manager responsible for users.</param>
        /// <param name="emailSender">The API used for sending emails to users.</param>
        public EmailModel(
            UserManager<EasyRankUser> userManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        /// <summary>
        /// Gets or sets the users current email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the users current email is confirmed.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the property that displays a message on success or on error.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the property used as a model for the view.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// The get method for the razor page.
        /// </summary>
        /// <returns>A view for changing the users email.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The same page for changing the users email.</returns>
        /// <remarks>Post for when email is getting changed.</remarks>
        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            string email = await this.userManager.GetEmailAsync(user);
            if (this.Input.NewEmail != email)
            {
                EasyRankUser userWithGivenEmail = await this.userManager.FindByEmailAsync(this.Input.NewEmail);
                if (userWithGivenEmail != null)
                {
                    this.StatusMessage = "Error: Email taken!";
                    return this.RedirectToPage();
                }

                string userId = await this.userManager.GetUserIdAsync(user);
                string code = await this.userManager.GenerateChangeEmailTokenAsync(user, this.Input.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                string callbackUrl = this.Url.Page(
                    "/Account/ConfirmEmailChange", // TODO: CHeck functionality
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, email = this.Input.NewEmail, code = code },
                    protocol: this.Request.Scheme);

                await this.emailSender.SendEmailAsync(
                    this.Input.NewEmail,
                    "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                this.StatusMessage = "Confirmation link to change email sent. Please check your email!";
                return this.RedirectToPage();
            }

            this.StatusMessage = "Error: Your email is unchanged.";
            return this.RedirectToPage();
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The same page for changing the users email.</returns>
        /// <remarks>Post for when email is getting verified.</remarks>
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            string userId = await this.userManager.GetUserIdAsync(user);
            string email = await this.userManager.GetEmailAsync(user);
            string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            string callbackUrl = this.Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: this.Request.Scheme);

            await this.emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            this.StatusMessage = "Verification email sent. Please check your email.";
            return this.RedirectToPage();
        }

        private async Task LoadAsync(EasyRankUser user)
        {
            string email = await this.userManager.GetEmailAsync(user);

            this.Email = email;
            this.Input = new InputModel
            {
                NewEmail = email,
            };

            this.IsEmailConfirmed = await this.userManager.IsEmailConfirmedAsync(user);
        }

        /// <summary>
        /// The view model for the email change.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Gets or sets the new email the user has inputted.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "New email")]
            public string NewEmail { get; set; }
        }
    }
}
