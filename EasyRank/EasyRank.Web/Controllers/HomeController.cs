// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models.User;
using EasyRank.Web.Extensions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// Main controller of the app.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IManageService manageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="manageService">The manage service for the controller.</param>
        public HomeController(IManageService manageService)
        {
            this.manageService = manageService;
        }

        /// <summary>
        /// The 'Index' action for the controller.
        /// </summary>
        /// <returns>The home page view.</returns>
        public async Task<IActionResult> IndexAsync()
        {
            if (this.User.IsInRole("Administrator"))
            {
                return this.RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            if (!this.User.Identity!.IsAuthenticated)
            {
                return this.View();
            }

            ManageServiceModel user = await this.manageService.GetUserInfoAsync(this.User.Id());
            string username = user.Username;
            string? firstName = user.FirstName;
            string? lastName = user.LastName;

            if (firstName == null && lastName == null)
            {
                this.ViewBag.PersonName = username;
            }
            else if (firstName != null && lastName == null)
            {
                this.ViewBag.PersonName = firstName;
            }
            else if (firstName == null && lastName != null)
            {
                this.ViewBag.PersonName = $"Mr. / Ms. {lastName}";
            }
            else
            {
                this.ViewBag.PersonName = $"{firstName} {lastName}";
            }

            return this.View();
        }

        /// <summary>
        /// The 'Error' action for the controller.
        /// </summary>
        /// <returns>An error page depending on the error.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            IExceptionHandlerFeature? exceptionHandlerPathFeature = 
                this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            Exception error = exceptionHandlerPathFeature?.Error!;
            switch (error)
            {
                case NotFoundException:
                    return this.RedirectToAction("Error404", "Home");
                case ForbiddenException:
                    return this.RedirectToAction("Error403", "Home");
                case FileFormatException:
                    this.TempData["StatusMessage"] = "Error: Unsupported file!";
                    return this.RedirectToAction("Index", "Manage");
                case UsernameTakenException:
                    this.TempData["StatusMessage"] = "Error: Username taken!";
                    return this.RedirectToAction("Index", "Manage");
                default: return this.RedirectToAction("Error500", "Home");
            }
        }

        /// <summary>
        /// The 'Error404' action for the controller.
        /// </summary>
        /// <returns>A 404 error page.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult Error404()
        {
            return this.View();
        }

        /// <summary>
        /// The 'Error403' action for the controller.
        /// </summary>
        /// <returns>A 403 error page.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult Error403()
        {
            return this.View();
        }

        /// <summary>
        /// The 'Error500' action for the controller.
        /// </summary>
        /// <returns>A 500 error page.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult Error500()
        {
            return this.View();
        }
    }
}
