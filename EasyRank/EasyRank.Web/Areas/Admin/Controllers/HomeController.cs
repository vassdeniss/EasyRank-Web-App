// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Main controller of the app (admin area).
    /// </summary>
    public class HomeController : BaseAdminController
    {
        /// <summary>
        /// Method 'Index' for the controller.
        /// </summary>
        /// <returns>The home page view.</returns>
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
