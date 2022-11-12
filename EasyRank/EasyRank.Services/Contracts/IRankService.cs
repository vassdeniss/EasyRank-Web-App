// -----------------------------------------------------------------------
// <copyright file="IRankService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    /// <summary>
    /// The interface for the RankService.
    /// </summary>
    public interface IRankService
    {
        /// <summary>
        /// Interface declaration for method.
        /// </summary>
        /// <returns>Collection of service models.</returns>
        Task<ICollection<RankPageServiceModel>> GetAllRankingsAsync();

        /// <summary>
        /// Interface declaration for method.
        /// </summary>
        /// <returns>Service model.</returns>
        /// <param name="rankGuid">The GUID to be used with the method.</param>
        Task<RankPageServiceModelExtended> GetRankPageByGuidAsync(Guid rankGuid);

        Task<ICollection<RankPageServiceModel>> GetAllRankingsByUserAsync(Guid userId);
    }
}
