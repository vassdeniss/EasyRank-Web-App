// -----------------------------------------------------------------------
// <copyright file="IRankService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    /// <summary>
    /// The interface for the RankService.
    /// </summary>
    public interface IRankService
    {
        /// <summary>
        /// Used for retrieving all rankings from the database.
        /// </summary>
        /// <returns>A collection of rank page service models.</returns>
        /// <param name="page">The current page to take ranks for.</param>
        /// <param name="perPage">Number of ranks per page.</param>
        Task<AllRanksServiceModel> GetAllRankingsAsync(int page, int perPage);

        /// <summary>
        /// Used for retrieving a rank page from the database by its GUID.
        /// </summary>
        /// <returns>A rank page service model.</returns>
        /// <param name="rankGuid">GUID used to search for the rank page.</param>
        /// <exception cref="NotFoundException">Throws 'NotFoundException' if the rank page was not found.</exception>
        Task<RankPageServiceModel> GetRankPageByGuidAsync(Guid rankGuid);

        /// <summary>
        /// Used for retrieving a (extended) rank page from the database by its GUID.
        /// </summary>
        /// <returns>An extended rank page service model.</returns>
        /// <param name="rankGuid">GUID used to search for the rank page.</param>
        /// <exception cref="NotFoundException">Throws 'NotFoundException' if the rank page was not found.</exception>
        Task<RankPageServiceModelExtended> GetExtendedRankPageByGuidAsync(Guid rankGuid);

        /// <summary>
        /// Used for retrieving a collection of rank pages for a specific user from the database.
        /// </summary>
        /// <returns>A collection of rank page service models.</returns>
        /// <param name="userId">GUID used to search for the users rankings.</param>
        Task<ICollection<RankPageServiceModel>> GetAllRankingsByUserAsync(Guid userId);

        /// <summary>
        /// Retrieves the form the user inputted, creates a page and saves it to the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="image">The byte array containing the cover image.</param>
        /// <param name="imageAlt">The text to display when the image doesn't exist / load.</param>
        /// <param name="rankingTitle">The rank page title.</param>
        /// <param name="userId">GUID used to search for the needed user.</param>
        Task CreateRankAsync(
            byte[]? image,
            string imageAlt,
            string rankingTitle,
            Guid userId);

        /// <summary>
        /// Checks if the current user owns the page.
        /// </summary>
        /// <returns>Task(void).</returns>
        /// <param name="userId">GUID used for retrieving the needed user.</param>
        /// <param name="rankId">GUID used for retrieving the needed page.</param>
        /// <exception cref="NotFoundException">Throws 'NotFoundException' if the page was not found.</exception>
        /// <exception cref="UnauthorizedUserException">Throws 'UnauthorizedUserException' if the user
        /// is not the owner of the page.</exception>
        Task IsCurrentUserPageOwnerAsync(
            Guid userId,
            Guid rankId);

        /// <summary>
        /// Edits the page and saves it back to the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="rankId">GUID used for retrieving the needed page.</param>
        /// <param name="rankingTitle">The page title.</param>
        /// <param name="imageAlt">The text to display when the image doesn't exist / load.</param>
        /// <param name="image">The byte array containing the cover image.</param>
        /// <exception cref="NotFoundException">Throws 'NotFoundException' if the page was not found.</exception>
        Task EditRankAsync(
            Guid rankId,
            string rankingTitle,
            string imageAlt,
            byte[]? image);

        /// <summary>
        /// Deletes a rank from the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="rankId">GUID used for retrieving the needed rank page.</param>
        /// <exception cref="NotFoundException">Throws 'NotFoundException' if the rank was not found.</exception>
        /// <remarks>Sets a 'IsDeleted' flag. Doesn't actually delete.</remarks>
        Task DeleteRankAsync(Guid rankId);

        /// <summary>
        /// Like or unlike the page for the current user.
        /// Adds a record to the mapping table if the user has never liked the page before
        /// </summary>
        /// <param name="userId">GUID used for retrieving the needed user.</param>
        /// <param name="rankId">GUID used for retrieving the needed page.</param>
        /// <exception cref="NotFoundException">Throws 'NotFoundException' if the rank was not found.</exception>
        /// <returns>Task (void).</returns>
        Task LikeCommentAsync(Guid userId, Guid rankId);

        /// <summary>
        /// Used for retrieving a collection of liked rank pages for a specific user from the database.
        /// </summary>
        /// <returns>A collection of rank page service models.</returns>
        /// <param name="userId">GUID used to search for the users rankings.</param>
        Task<ICollection<RankPageServiceModel>> GetAllLikesByUserAsync(Guid userId);
    }
}
