// -----------------------------------------------------------------------
// <copyright file="EntryController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Services.Contracts.Admin;
using EasyRank.Services.Models;
using EasyRank.Web.Areas.Admin.Models.Entry;

using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// The controller responsible for entry management (admin).
    /// </summary>
    public class EntryController : BaseAdminController
    {
        private readonly IMapper mapper;
        private readonly IAdminService adminService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryController"/> class.
        /// Constructor for the rank controller.
        /// </summary>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        /// <param name="adminService">Instance of the admin service.</param>
        public EntryController(IMapper mapper, IAdminService adminService)
        {
            this.mapper = mapper;
            this.adminService = adminService;
        }

        /// <summary>
        /// The 'All' action for the controller.
        /// </summary>
        /// <returns>A view with a collection of all rank entries.</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            IEnumerable<RankEntryServiceModelExtended> serviceModel = await this.adminService.GetAllEntriesAsync();

            IEnumerable<RankEntryViewModelExtended> model =
                this.mapper.Map<IEnumerable<RankEntryViewModelExtended>>(serviceModel);

            return this.View(model);
        }
    }
}
