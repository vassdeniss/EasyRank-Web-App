// -----------------------------------------------------------------------
// <copyright file="RankController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models;
using EasyRank.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for ranks management.
    /// </summary>
    public class RankController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IRankService rankService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RankController"/> class.
        /// Constructor for the rank controller.
        /// </summary>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        /// <param name="rankService">Instance of the rank service.</param>
        public RankController(IMapper mapper, IRankService rankService)
        {
            this.mapper = mapper;
            this.rankService = rankService;
        }

        /// <summary>
        /// Method 'All' for the controller. Visualizes a page with all rankings from the database.
        /// </summary>
        /// <returns>A view with a collection of all rank pages.</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<RankPageServiceModel> serviceModel = await this.rankService.GetAllRankingsAsync();

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// Method 'ViewRanking' for the controller. Visualizes a page with the contents of a ranking.
        /// </summary>
        /// <returns>A view with a specific rank page.</returns>
        /// <param name="rankId">The GUID of the requested page.</param>
        [HttpPost]
        public async Task<IActionResult> ViewRanking(Guid rankId)
        {
            RankPageServiceModel serviceModel = await this.rankService.GetRankPageByGuidAsync(rankId);

            RankPageViewModel model = this.mapper.Map<RankPageViewModel>(serviceModel);

            return this.View(model);
        }
    }
}
