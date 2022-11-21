﻿// -----------------------------------------------------------------------
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
using EasyRank.Web.Models.Rank;

using Microsoft.AspNetCore.Authorization;
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
        /// Method 'All' for the controller.
        /// </summary>
        /// <returns>A view with a collection of all rank pages.</returns>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            ICollection<RankPageServiceModel> serviceModel = await this.rankService.GetAllRankingsAsync();

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// Method 'ViewRanking' for the controller.
        /// </summary>
        /// <returns>A view with a specific rank page.</returns>
        /// <param name="rankId">The GUID of the requested page.</param>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewRanking(Guid rankId)
        {
            RankPageServiceModelExtended serviceModel = await this.rankService.GetRankPageByGuidAsync(rankId);

            RankPageViewModelExtended model = this.mapper.Map<RankPageViewModelExtended>(serviceModel);

            return this.View(model);
        }
    }
}
