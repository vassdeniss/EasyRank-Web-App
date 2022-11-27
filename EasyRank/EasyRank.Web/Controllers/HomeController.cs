// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
        /// Method 'Index' for the controller.
        /// </summary>
        /// <returns>The home page view.</returns>
        public IActionResult Index()
        {
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
        /// Method 'Error' for the controller.
        /// </summary>
        /// <returns>An error page depending on the error.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature? exceptionHandlerPathFeature = this.HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            int statusCode = 0;
            string exceptionMessage = string.Empty;
            if (exceptionHandlerPathFeature?.Error is NotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                exceptionMessage = "The requested data was not found on the server!";
            }
            else if (exceptionHandlerPathFeature?.Error is UnauthorizedUserException)
            {
                statusCode = (int)HttpStatusCode.Unauthorized;
                exceptionMessage = "You do not have permission to execute this action!";
            }
            else
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                exceptionMessage = "An error occurred while processing your request.";
            }

            return this.View(new ErrorViewModel
            {
                ExceptionMessage = exceptionMessage,
                StatusCode = statusCode,
            });
        }
    }
}
