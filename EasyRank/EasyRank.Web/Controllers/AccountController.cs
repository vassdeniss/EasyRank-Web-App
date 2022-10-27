// -----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for user management.
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for the controller.</param>
        /// <param name="signInManager">The sign in manager for the controller.</param>
        public AccountController(
            UserManager<EasyRankUser> userManager, 
            SignInManager<EasyRankUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// The register action for the controller.
        /// </summary>
        /// <returns>A register view with an empty 'RegisterViewModel'.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();

            return this.View(model);
        }

        /// <summary>
        /// The register action for the controller.
        /// </summary>
        /// <returns>A register view with an empty 'RegisterViewModel'.</returns>
        /// <param name="model">The 'RegisterViewModel' for the view.</param>
        /// <remarks>Post method.</remarks>
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
                EmailConfirmed = true // DEVELOPMENT PLEASE REMOVE ON PRODUCTION
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
        /// <remarks>Get method.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return this.View(model);
        }

        /// <summary>
        /// The login action for the controller.
        /// </summary>
        /// <returns>A redirect to either a return url, to home, or back to the login page in case of an error.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="model">The 'LoginViewModel' for the view.</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            EasyRankUser user = await this.userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
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
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
