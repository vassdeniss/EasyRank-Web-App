// -----------------------------------------------------------------------
// <copyright file="EntryController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models.Entry;
using EasyRank.Web.Extensions;
using EasyRank.Web.Models.Entry;
using EasyRank.Web.Models.Rank;

using Ganss.Xss;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for rank page entry management.
    /// </summary>
    public class EntryController : BaseController
    {
        private readonly IEntryService entryService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryController"/> class.
        /// </summary>
        /// <param name="entryService">Instance of the entry service.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public EntryController(
            IEntryService entryService,
            IMapper mapper)
        {
            this.entryService = entryService;
            this.mapper = mapper;
        }

        /// <summary>
        /// The 'Create' action for the controller.
        /// </summary>
        /// <returns>A view for creating a new rank entry.</returns>
        /// <remarks>Get method.</remarks>
        /// <param name="rankId">The GUID used for retrieving the needed page.</param>
        [HttpGet]
        public async Task<IActionResult> CreateAsync(Guid rankId)
        {
            await this.entryService.IsCurrentUserPageOwnerAsync(
                this.User.Id(),
                rankId,
                this.User.IsAdmin());

            RankEntryFormModel model = new RankEntryFormModel
            {
                AvailablePlacements = await this.entryService.GetAvailablePlacementsAsync(rankId),
            };

            this.TempData["EntryCreateReturnId"] = rankId;

            return this.View(model);
        }

        /// <summary>
        /// The 'Create' action for the controller.
        /// </summary>
        /// <returns>Return with a broken model state or back to the page the user was on.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="model">The RankEntryFormModel for validation.</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(RankEntryFormModel model)
        {
            this.ModelState.Remove("AvailablePlacements");

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string sanitizedTitle = this.SanitizeString(model.EntryTitle);
            string sanitizedDescription = this.SanitizeString(model.EntryDescription);
            string sanitizedAltText = this.SanitizeString(model.ImageAlt);
            if (string.IsNullOrEmpty(sanitizedTitle) 
                || string.IsNullOrEmpty(sanitizedDescription)
                || string.IsNullOrEmpty(sanitizedAltText))
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

            string returnRankPageId = this.TempData["EntryCreateReturnId"]!.ToString()!;

            await this.entryService.CreateEntryAsync(
                model.Placement,
                sanitizedTitle,
                image,
                sanitizedAltText,
                sanitizedDescription,
                Guid.Parse(returnRankPageId));

            return this.RedirectToAction("ViewRanking", "Rank", new
            {
                rankId = returnRankPageId,
            });
        }

        /// <summary>
        /// The 'Edit' action for the controller.
        /// </summary>
        /// <returns>
        /// A view for rank entry editing with a filled rank entry form model.
        /// 404 if the entry doesn't exist, 401 if the user is not the page owner.</returns>
        /// <remarks>Get method.</remarks>
        /// <param name="rankId">The GUID used for retrieving the needed page.</param>
        /// <param name="entryId">The GUID used for retrieving the needed entry.</param>
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid rankId, Guid entryId)
        {
            await this.entryService.IsCurrentUserPageOwnerAsync(
                this.User.Id(),
                rankId,
                this.User.IsAdmin());

            RankEntryServiceModel serviceModel = await this.entryService.GetRankEntryByGuidAsync(entryId);

            RankEntryViewModel viewModel = this.mapper.Map<RankEntryViewModel>(serviceModel);

            RankEntryFormModel model = new RankEntryFormModel
            {
                Id = entryId,
                Image = viewModel.Image,
                ImageAlt = viewModel.ImageAlt,
                Placement = viewModel.Placement,
                EntryTitle = viewModel.Title,
                EntryDescription = viewModel.Description,
                AvailablePlacements = await this.entryService.GetAvailablePlacementsAsync(rankId),
            };

            this.TempData["EntryEditReturnId"] = rankId;

            return this.View(model);
        }

        /// <summary>
        /// The 'Edit' action for the controller.
        /// </summary>
        /// <returns>The same page if the model was invalid, or back to the page the user was on.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="model">The RankEntryFormModel for validation.</param>
        [HttpPost]
        public async Task<IActionResult> EditAsync(RankEntryFormModel model)
        {
            this.ModelState.Remove("AvailablePlacements");

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string sanitizedTitle = this.SanitizeString(model.EntryTitle);
            string sanitizedDescription = this.SanitizeString(model.EntryDescription);
            string sanitizedAltText = this.SanitizeString(model.ImageAlt);
            if (string.IsNullOrEmpty(sanitizedTitle)
                || string.IsNullOrEmpty(sanitizedDescription)
                || string.IsNullOrEmpty(sanitizedAltText))
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

            await this.entryService.EditEntryAsync(
                model.Id,
                model.Placement,
                sanitizedTitle,
                image,
                sanitizedAltText,
                sanitizedDescription);

            if (this.User.IsAdmin())
            {
                this.TempData.Remove("EntryEditReturnId");
                return this.RedirectToAction("All", "Entry", new { area = "Admin" });
            }

            return this.RedirectToAction("ViewRanking", "Rank", new
            {
                rankId = this.TempData["EntryEditReturnId"],
            });
        }

        /// <summary>
        /// The 'Delete' action for the controller.
        /// </summary>
        /// <returns>
        /// A view for rank entry deletion with a filled rank entry form model.
        /// 404 if the entry doesn't exist, 401 if the user is not the page owner.</returns>
        /// <remarks>Get method.</remarks>
        /// <param name="rankId">The GUID used for retrieving the needed page.</param>
        /// <param name="entryId">The GUID used for retrieving the needed entry.</param>
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(Guid rankId, Guid entryId)
        {
            await this.entryService.IsCurrentUserPageOwnerAsync(
                this.User.Id(),
                rankId,
                this.User.IsAdmin());

            RankEntryServiceModel serviceModel = await this.entryService.GetRankEntryByGuidAsync(entryId);

            RankEntryViewModel viewModel = this.mapper.Map<RankEntryViewModel>(serviceModel);

            RankEntryFormModel model = new RankEntryFormModel
            {
                Id = entryId,
                Image = viewModel.Image,
                ImageAlt = viewModel.ImageAlt,
                Placement = viewModel.Placement,
                EntryTitle = viewModel.Title,
                EntryDescription = viewModel.Description,
                AvailablePlacements = await this.entryService.GetAvailablePlacementsAsync(rankId),
            };

            this.TempData["EntryDeleteReturnId"] = rankId;

            return this.View(model);
        }

        /// <summary>
        /// The 'Delete' action for the controller.
        /// </summary>
        /// <returns>Redirects to the view the entry was deleted from.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="model">The 'RankEntryFormModel' model from the form.</param>
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(RankEntryFormModel model)
        {
            await this.entryService.DeleteEntryAsync(model.Id);

            if (this.User.IsAdmin())
            {
                this.TempData.Remove("EntryEditReturnId");
                return this.RedirectToAction("All", "Entry", new { area = "Admin" });
            }

            return this.RedirectToAction("ViewRanking", "Rank", new
            {
                rankId = this.TempData["EntryDeleteReturnId"],
            });
        }

        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
