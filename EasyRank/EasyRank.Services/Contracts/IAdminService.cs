// -----------------------------------------------------------------------
// <copyright file="IAdminService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
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
        Task<ICollection<RankPageServiceModel>> GetAllRankingsAsync();

        /// <summary>
        /// Used for retrieving all entries from the database.
        /// </summary>
        /// <returns>A collection of rank entries.</returns>
        Task<ICollection<RankEntryServiceModelExtended>> GetAllEntriesAsync();

        /// <summary>
        /// Used for retrieving all comments from the database.
        /// </summary>
        /// <returns>A collection of comments.</returns>
        Task<ICollection<CommentServiceModelExtended>> GetAllCommentsAsync();
    }
}
