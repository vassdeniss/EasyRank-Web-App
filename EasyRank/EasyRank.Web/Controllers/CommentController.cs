// -----------------------------------------------------------------------
// <copyright file="CommentController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models;
using EasyRank.Web.Models.Comment;
using EasyRank.Web.Models.Rank;

using Ganss.Xss;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// The controller responsible for comment management.
    /// </summary>
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="commentService">Instance of the comment service.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public CommentController(
            ICommentService commentService,
            IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid rankId, CommentFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                foreach (ModelError error in this.ModelState.Values.SelectMany(entry => entry.Errors))
                {
                    this.TempData["Error"] = error.ErrorMessage;
                }

                return this.RedirectToAction("ViewRanking", "Rank", new { rankId });
            }

            string sanitizedContent = this.SanitizeString(model.Content);
            if (string.IsNullOrEmpty(sanitizedContent))
            {
                this.TempData["Error"] = "Please don't try to XSS :)";
                return this.RedirectToAction("ViewRanking", "Rank", new { rankId });
            }

            await this.commentService.CreateCommentAsync(
                sanitizedContent,
                Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                rankId);

            return this.RedirectToAction("ViewRanking", "Rank", new { rankId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid commentId, Guid rankId)
        {
            CommentServiceModel? serviceModel = await this.commentService.GetCommentByIdAsync(commentId);
            if (serviceModel == null)
            {
                // BadRequest?
                return this.NotFound();
            }

            CommentViewModel viewModel = this.mapper.Map<CommentViewModel>(serviceModel);
            if (viewModel.Username != this.User.FindFirstValue(ClaimTypes.Name))
            {
                return this.Unauthorized();
            }

            CommentFormModelExtended model = new CommentFormModelExtended
            {
                Id = viewModel.Id,
                RankPageId = rankId,
                Content = viewModel.Content,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentFormModelExtended model)
        {
            // TODO: Verify

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string sanitizedContent = this.SanitizeString(model.Content);
            if (string.IsNullOrEmpty(sanitizedContent))
            {
                this.TempData["Error"] = "Please don't try to XSS :)";
                return this.View();
            }

            await this.commentService.EditCommentAsync(model.Id, sanitizedContent);
            return this.RedirectToAction("ViewRanking", "Rank", new { rankId = model.RankPageId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid rankId, Guid commentId)
        {
            CommentServiceModel? serviceModel = await this.commentService.GetCommentByIdAsync(commentId);
            if (serviceModel == null)
            {
                // BadRequest?
                return this.NotFound();
            }

            string currentUserName = this.User.FindFirstValue(ClaimTypes.Name);
            Guid currentUserId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            CommentViewModel viewModel = this.mapper.Map<CommentViewModel>(serviceModel);
            if (viewModel.Username != currentUserName
                && !await this.commentService.IsCurrentUserNameOwner(rankId, currentUserId))
            {
                return this.Unauthorized();
            }

            CommentFormModelExtended model = new CommentFormModelExtended
            {
                Id = viewModel.Id,
                RankPageId = rankId,
                Content = viewModel.Content,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentFormModelExtended model)
        {
            // TODO: Verify

            await this.commentService.DeleteCommentAsync(model.Id);
            return this.RedirectToAction("ViewRanking", "Rank", new { rankId = model.RankPageId });
        }

        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
