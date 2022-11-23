// -----------------------------------------------------------------------
// <copyright file="RankController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;
using EasyRank.Web.Claims;
using EasyRank.Web.Models.Comment;
using EasyRank.Web.Models.Rank;

using Ganss.Xss;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AllAsync()
        {
            ICollection<RankPageServiceModel> serviceModel = await this.rankService.GetAllRankingsAsync();

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// Method 'ViewRankingAsync' for the controller.
        /// </summary>
        /// <returns>A view with a specific rank page.</returns>
        /// <param name="rankId">The GUID of the requested page.</param>
        /// <remarks>Get method. Guest access allowed.</remarks>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewRankingAsync(Guid rankId)
        {
            RankPageServiceModelExtended serviceModel = await this.rankService.GetExtendedRankPageByGuidAsync(rankId);

            RankPageViewModelExtended model = this.mapper.Map<RankPageViewModelExtended>(serviceModel);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult CreateAsync()
        {
            RankPageFormModel model = new RankPageFormModel();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RankPageFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string sanitizedTitle = this.SanitizeString(model.RankingTitle);
            string sanitizedAltText = this.SanitizeString(model.ImageAlt);
            if (string.IsNullOrEmpty(sanitizedTitle) || string.IsNullOrEmpty(sanitizedAltText))
            {
                this.TempData["Error"] = "Please don't try to XSS :)";
                return this.View(model);
            }

            Guid userId = this.User.Id();

            byte[]? image = null;
            if (this.Request.Form.Files.Count > 0)
            {
                IFormFile file = this.Request.Form.Files.First();

                string[] acceptedExtensions = { ".png", ".jpg", ".jpeg", ".gif", ".tif" };

                if (!acceptedExtensions.Contains(Path.GetExtension(file.FileName)))
                {
                    this.TempData["Error"] = "Error: Unsupported file!";
                    return this.View(model);
                }

                using MemoryStream memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);
                image = memoryStream.ToArray();
            }

            await this.rankService.CreateRankAsync(image, sanitizedAltText, sanitizedTitle, userId);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid rankId)
        {
            await this.rankService.IsCurrentUserPageOwner(
                this.User.Id(),
                rankId);

            RankPageServiceModel serviceModel = await this.rankService.GetRankPageByGuidAsync(rankId);

            RankPageViewModel viewModel = this.mapper.Map<RankPageViewModel>(serviceModel);

            RankPageFormModel model = new RankPageFormModel
            {
                Id = rankId,
                Image = viewModel.Image,
                ImageAlt = viewModel.ImageAlt,
                RankingTitle = viewModel.RankingTitle,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RankPageFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string sanitizedTitle = this.SanitizeString(model.RankingTitle);
            string sanitizedAltText = this.SanitizeString(model.ImageAlt);
            if (string.IsNullOrEmpty(sanitizedTitle) || string.IsNullOrEmpty(sanitizedAltText))
            {
                this.TempData["Error"] = "Please don't try to XSS :)";
                return this.View(model);
            }

            byte[]? image = null;
            if (this.Request.Form.Files.Count > 0)
            {
                IFormFile file = this.Request.Form.Files.First();

                string[] acceptedExtensions = { ".png", ".jpg", ".jpeg", ".gif", ".tif" };

                if (!acceptedExtensions.Contains(Path.GetExtension(file.FileName)))
                {
                    this.TempData["Error"] = "Error: Unsupported file!";
                    return this.View(model);
                }

                using MemoryStream memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);
                image = memoryStream.ToArray();
            }

            await this.rankService.EditRankAsync(model.Id, sanitizedTitle, sanitizedAltText, image);
            return this.RedirectToAction("MyRanks", "Manage");
        }

        /// <summary>
        /// The 'EditMenu' action for the controller.
        /// </summary>
        /// <returns>A view showing all the rankings you as a user has made (for editing).</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> EditMenu()
        {
            ICollection<RankPageServiceModel> serviceModel =
                await this.rankService.GetAllRankingsByUserAsync(this.User.Id());

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }

        /// <summary>
        /// The 'Delete' action for the controller.
        /// </summary>
        /// <returns>
        /// A view for deleting a page with a filled 'RankPage' form model.
        /// 404 if the page doesn't exist, 401 if the user is not the page owner.</returns>
        /// <remarks>Get method.</remarks>
        /// <param name="rankId">The GUID used for retrieving the needed page.</param>
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(Guid rankId)
        {
            await this.rankService.IsCurrentUserPageOwner(
                this.User.Id(),
                rankId);

            RankPageServiceModel serviceModel = await this.rankService.GetRankPageByGuidAsync(rankId);

            RankPageViewModel viewModel = this.mapper.Map<RankPageViewModel>(serviceModel);

            RankPageFormModel model = new RankPageFormModel
            {
                Id = rankId,
                Image = viewModel.Image,
                ImageAlt = viewModel.ImageAlt,
                RankingTitle = viewModel.RankingTitle,
            };

            return this.View(model);
        }

        /// <summary>
        /// The 'Delete' action for the controller.
        /// </summary>
        /// <returns>Redirects to the users ranks view.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="model">The 'RankPageFormModel' model from the form.</param>
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(RankPageFormModel model)
        {
            await this.rankService.DeleteRankAsync(model.Id);

            return this.RedirectToAction("MyRanks", "Manage");
        }

        /// <summary>
        /// The 'DeleteMenu' action for the controller.
        /// </summary>
        /// <returns>A view showing all the rankings you as a user has made (for deleting).</returns>
        /// <remarks>Get method.</remarks>
        [HttpGet]
        public async Task<IActionResult> DeleteMenu()
        {
            ICollection<RankPageServiceModel> serviceModel =
                await this.rankService.GetAllRankingsByUserAsync(this.User.Id());

            ICollection<RankPageViewModel> model =
                this.mapper.Map<ICollection<RankPageViewModel>>(serviceModel);

            return this.View(model);
        }

        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
