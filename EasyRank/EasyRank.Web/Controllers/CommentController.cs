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
using EasyRank.Web.Claims;
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

        /// <summary>
        /// The create action for the controller.
        /// </summary>
        /// <returns>Back to the page the user was on, either with a new successfully posted comment or an error message.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="rankId">The GUID which will be used to go back to the same page the user was.</param>
        /// <param name="model">The CommentFormModel for validation.</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Guid rankId, CommentFormModel model)
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
                this.User.Id(),
                rankId);

            return this.RedirectToAction("ViewRanking", "Rank", new { rankId });
        }

        /// <summary>
        /// The edit action for the controller.
        /// </summary>
        /// <returns>
        /// A view for comment editing with a filled extended comment form model.
        /// 404 if the comment doesn't exist, 401 if the user is not the comments owner. </returns>
        /// <remarks>Get method.</remarks>
        /// <param name="commentId">The GUID used for retrieving the needed comment.</param>
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid commentId)
        {
            await this.commentService.IsCurrentUserCommentOwner(
                this.User.Id(),
                commentId);

            CommentServiceModel serviceModel = await this.commentService.GetCommentByIdAsync(commentId);

            CommentViewModel viewModel = this.mapper.Map<CommentViewModel>(serviceModel);

            CommentFormModelExtended model = new CommentFormModelExtended
            {
                Id = viewModel.Id,
                Content = viewModel.Content,
            };

            return this.View(model);
        }

        /// <summary>
        /// The edit action for the controller.
        /// </summary>
        /// <returns>The same page if the model was invalid, or back to the page the user was on.</returns>
        /// <remarks>Post method.</remarks>
        /// <param name="model">The CommentFormModelExtended for validation.</param>
        [HttpPost]
        public async Task<IActionResult> EditAsync(CommentFormModelExtended model)
        {
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
            return this.RedirectToAction("ViewRanking", "Rank", new
            {
                rankId = await this.commentService.GetCommentPageId(model.Id),
            });
        }

        /// <summary>
        /// The delete action for the controller.
        /// </summary>
        /// <returns>
        /// A view for comment deleting with a filled extended comment form model.
        /// 404 if the comment doesn't exist, 401 if the user is not the comments owner. </returns>
        /// <remarks>Get method.</remarks>
        /// <param name="commentId">The GUID used for retrieving the needed comment.</param>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid commentId)
        {
            await this.commentService.IsCurrentUserCommentOwner(
                this.User.Id(),
                commentId);

            await this.commentService.IsCurrentUserPageOwner(
                this.User.Id(),
                commentId);

            CommentServiceModel serviceModel = await this.commentService.GetCommentByIdAsync(commentId);

            CommentViewModel viewModel = this.mapper.Map<CommentViewModel>(serviceModel);

            CommentFormModelExtended model = new CommentFormModelExtended
            {
                Id = viewModel.Id,
                Content = viewModel.Content,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentFormModelExtended model)
        {
            await this.commentService.DeleteCommentAsync(model.Id);

            return this.RedirectToAction("ViewRanking", "Rank", new
            {
                rankId = await this.commentService.GetCommentPageId(model.Id),
            });
        }

        private string SanitizeString(string content)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();

            return sanitizer.Sanitize(content);
        }
    }
}
