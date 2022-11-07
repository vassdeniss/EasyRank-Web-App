// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Web.Models;

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

        public HomeController(UserManager<EasyRankUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Method 'Index' for the controller. Visualizes the home page of the app.
        /// </summary>
        /// <returns>The home page view.</returns>
        public IActionResult Index()
        {
            if (this.User.Identity!.IsAuthenticated)
            {
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
            }

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier,
            });
        }
    }
}
