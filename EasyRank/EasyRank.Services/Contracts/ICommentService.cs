// -----------------------------------------------------------------------
// <copyright file="ICommentService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    /// <summary>
    /// The interface for the CommentService.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Interface declaration for method.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="content">The content of the comment.</param>
        /// <param name="createdByUserId">The GUID of the user who created the comment.</param>
        /// <param name="rankPageId">The GUID of the rank page where the comment was posted.</param>
        Task CreateCommentAsync(
            string content,
            Guid createdByUserId,
            Guid rankPageId);

        Task<CommentServiceModel?> GetCommentByIdAsync(Guid commentId);

        Task EditCommentAsync(
            Guid commentId,
            string content);

        Task DeleteCommentAsync(Guid commentId);

        Task<bool> IsCurrentUserNameOwner(
            Guid rankId,
            Guid userId);
    }
}
