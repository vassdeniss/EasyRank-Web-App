// -----------------------------------------------------------------------
// <copyright file="ICommentService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    /// <summary>
    /// The interface for the CommentService.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Retrieves the content the user inputted, creating a comment and saving it to the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="content">The content of the comment.</param>
        /// <param name="createdByUserId">GUID used to identify the user which posted the comment.</param>
        /// <param name="rankPageId">GUID used for retrieving the rank page where the comment was posted.</param>
        Task CreateCommentAsync(
            string content,
            Guid createdByUserId,
            Guid rankPageId);

        /// <summary>
        /// Retrieves a specific comment by its id from the database.
        /// </summary>
        /// <returns>A comment service model.</returns>
        /// <exception cref="NotFoundException">Throws the 'NotFoundException' if the comment was not found.</exception>
        /// <param name="commentId">GUID used for retrieving the needed comment.</param>
        Task<CommentServiceModel> GetCommentByIdAsync(Guid commentId);

        /// <summary>
        /// Edits the content of a comment and saving it back to the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="commentId">GUID used for retrieving the needed comment.</param>
        /// <param name="content">The (sanitized) content of the comment to be replaced.</param>
        Task EditCommentAsync(
            Guid commentId,
            string content);

        /// <summary>
        /// Deletes a comment from the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="commentId">GUID used for retrieving the needed comment.</param>
        /// <remarks>Sets a 'IsDeleted' flag. Doesn't actually delete.</remarks>
        Task DeleteCommentAsync(Guid commentId);

        Task IsCurrentUserCommentOwner(
            Guid userId,
            Guid commentId);

        Task IsCurrentUserPageOwner(
            Guid userId,
            Guid commentId);

        Task<Guid> GetCommentPageId(Guid commentId);
    }
}
