// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EasyRank.Web.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// The razor page responsible for deleting a users account.
    /// </summary>
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly ILogger<DeletePersonalDataModel> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePersonalDataModel"/> class.
        /// </summary>
        /// <param name="userManager">The manager responsible for users.</param>
        /// <param name="signInManager">The manager responsible for sign ins.</param>
        /// <param name="logger">The logger to log messages.</param>
        public DeletePersonalDataModel(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            ILogger<DeletePersonalDataModel> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets the property used as a model for the view.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        //public bool RequirePassword { get; set; }

        /// <summary>
        /// The get method for the razor page.
        /// </summary>
        /// <returns>A view for deleting the users account.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            //RequirePassword = await this.userManager.HasPasswordAsync(user);
            return this.Page();
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The home view after the user has been deleted.</returns>
        public async Task<IActionResult> OnPostAsync()
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

            if (!await this.userManager.CheckPasswordAsync(user, this.Input.Password))
            {
                this.ModelState.AddModelError(string.Empty, "Incorrect password.");
                return this.Page();
            }

            IdentityResult result = await this.userManager.DeleteAsync(user);
            string userId = await this.userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Unexpected error occurred deleting user.");
            }

            await this.signInManager.SignOutAsync();

            this.logger.LogInformation($"User with ID '{userId}' deleted themselves.");

            return this.Redirect("~/");
        }

        /// <summary>
        /// The view model for the account deletion.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Gets or sets the current password of the user.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
