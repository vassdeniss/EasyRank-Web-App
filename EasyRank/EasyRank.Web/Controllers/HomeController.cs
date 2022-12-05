﻿// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Net;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Exceptions;
using EasyRank.Web.Models;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// Main controller of the app.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly UserManager<EasyRankUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="userManager">The manager responsible for users.</param>
        public HomeController(UserManager<EasyRankUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// The 'Index' action for the controller.
        /// </summary>
        /// <returns>The home page view.</returns>
        public IActionResult Index()
        {
            if (this.User.IsInRole("Administrator"))
            {
                return this.RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            if (!this.User.Identity!.IsAuthenticated)
            {
                return this.View();
            }

            EasyRankUser user = this.userManager.GetUserAsync(this.User).Result;
            string username = user.UserName;
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
            IExceptionHandlerPathFeature? exceptionHandlerPathFeature = this.HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            Exception error = exceptionHandlerPathFeature?.Error!;
            switch (error)
            {
                case NotFoundException:
                    return this.RedirectToAction("Error404");
                case UnauthorizedUserException:
                    return this.RedirectToAction("Error401");
                case FileFormatException:
                    this.TempData["StatusMessage"] = "Error: Unsupported file!";
                    return this.RedirectToAction("Index", "Manage");
                case UsernameTakenException:
                    this.TempData["StatusMessage"] = "Error: Username taken!";
                    return this.RedirectToAction("Index", "Manage");
                default: return this.RedirectToAction("Error500");
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
        /// The 'Error401' action for the controller.
        /// </summary>
        /// <returns>A 401 error page.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult Error401()
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
