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

using EasyRank.Services.Contracts;
using EasyRank.Web.Models.Comment;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="commentService">Instance of the comment service.</param>
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
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

            HtmlSanitizer sanitizer = new HtmlSanitizer();

            string sanitizedContent = sanitizer.Sanitize(model.Content);
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
    }
}
