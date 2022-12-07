// -----------------------------------------------------------------------
// <copyright file="IAdminService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Models;
using EasyRank.Services.Models.Admin;

namespace EasyRank.Services.Contracts.Admin
{
    /// <summary>
    /// The interface for the AdminService.
    /// </summary>
    public interface IAdminService
    {
        /// <summary>
        /// Used for retrieving all rankings from the database.
        /// </summary>
        /// <returns>A collection of rank pages.</returns>
        Task<IEnumerable<RankPageServiceModel>> GetAllRankingsAsync();

        /// <summary>
        /// Used for retrieving all entries from the database.
        /// </summary>
        /// <returns>A collection of rank entries.</returns>
        Task<IEnumerable<RankEntryServiceModelExtended>> GetAllEntriesAsync();

        /// <summary>
        /// Used for retrieving all comments from the database.
        /// </summary>
        /// <returns>A collection of comments.</returns>
        Task<IEnumerable<CommentServiceModelExtended>> GetAllCommentsAsync();

        /// <summary>
        /// Used for retrieving all users from the database.
        /// </summary>
        /// <returns>A collection of users.</returns>
        Task<IEnumerable<EasyRankUserServiceModel>> GetAllUsersAsync();
    }
}
