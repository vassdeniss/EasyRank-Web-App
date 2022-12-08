// -----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Services.Contracts.Admin;
using EasyRank.Services.Models.Admin;
using EasyRank.Web.Areas.Admin.Models.User;
using EasyRank.Web.Models.Manage;

using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// The controller responsible for user management (admin).
    /// </summary>
    public class UserController : BaseAdminController
    {
        private readonly IMapper mapper;
        private readonly IAdminService adminService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// Constructor for the rank controller.
        /// </summary>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        /// <param name="adminService">Instance of the admin service.</param>
        public UserController(IMapper mapper, IAdminService adminService)
        {
            this.mapper = mapper;
            this.adminService = adminService;
        }

        /// <summary>
        /// The 'All' action for the controller.
        /// </summary>
        /// <returns>A view with a collection of all users.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            IEnumerable<EasyRankUserServiceModel> serviceModel = await this.adminService.GetAllUsersAsync();

            IEnumerable<EasyRankUserViewModel> model =
                this.mapper.Map<IEnumerable<EasyRankUserViewModel>>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// The 'Forget' action for the controller.
        /// </summary>
        /// <returns>A confirmation view for user deletion.</returns>
        /// <param name="userId">The ID of the user to be deleted.</param>
        /// <param name="username">The username of the user to be deleted.</param>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult ForgetAsync(Guid userId, string username)
        {
            ActionUserViewModel model = new ActionUserViewModel
            {
                Id = userId,
                Username = username,
            };

            return this.View(model);
        }

        /// <summary>
        /// The 'Forget' action for the controller.
        /// </summary>
        /// <returns>Back to all users view.</returns>
        /// <param name="model">The 'ActionUserViewModel' for the action.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> ForgetAsync(ActionUserViewModel model)
        {
            await this.adminService.DeleteUserAsync(model.Id);

            return this.RedirectToAction("All", "User");
        }

        /// <summary>
        /// The 'MakeAdmin' action for the controller.
        /// </summary>
        /// <returns>A confirmation view for making user admin.</returns>
        /// <param name="userId">The ID of the user to be made admin.</param>
        /// <param name="username">The username of the user to be made admin.</param>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult MakeAdminAsync(Guid userId, string username)
        {
            ActionUserViewModel model = new ActionUserViewModel
            {
                Id = userId,
                Username = username,
            };

            return this.View(model);
        }

        /// <summary>
        /// The 'MakeAdmin' action for the controller.
        /// </summary>
        /// <returns>Back to all users view.</returns>
        /// <param name="model">The 'ActionUserViewModel' for the action.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> MakeAdminAsync(ActionUserViewModel model)
        {
            await this.adminService.MakeUserAdminAsync(model.Id);

            return this.RedirectToAction("All", "User");
        }

        /// <summary>
        /// The 'RemoveAdmin' action for the controller.
        /// </summary>
        /// <returns>A confirmation view for removing admin user.</returns>
        /// <param name="userId">The ID of the user to be removed.</param>
        /// <param name="username">The username of the user to be removed.</param>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public IActionResult RemoveAdminAsync(Guid userId, string username)
        {
            ActionUserViewModel model = new ActionUserViewModel
            {
                Id = userId,
                Username = username,
            };

            return this.View(model);
        }

        /// <summary>
        /// The 'RemoveAdmin' action for the controller.
        /// </summary>
        /// <returns>Back to all users view.</returns>
        /// <param name="model">The 'ActionUserViewModel' for the action.</param>
        /// <remarks>Post method.</remarks>
        [HttpPost]
        public async Task<IActionResult> RemoveAdminAsync(ActionUserViewModel model)
        {
            await this.adminService.RemoveAdminUserAsync(model.Id);

            return this.RedirectToAction("All", "User");
        }
    }
}
