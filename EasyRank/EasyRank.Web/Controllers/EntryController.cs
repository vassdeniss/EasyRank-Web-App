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

using EasyRank.Services.Contracts;
using EasyRank.Web.Claims;
using EasyRank.Web.Models.Entry;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryController"/> class.
        /// </summary>
        /// <param name="entryService">Instance of the entry service.</param>
        public EntryController(IEntryService entryService)
        {
            this.entryService = entryService;
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
                rankId);

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

        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
