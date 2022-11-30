// -----------------------------------------------------------------------
// <copyright file="IManageService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Claims;
using System.Threading.Tasks;

using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    /// <summary>
    /// The interface for the ManageService.
    /// </summary>
    public interface IManageService
    {
        /// <summary>
        /// Used for retrieving information about the current user.
        /// </summary>
        /// <param name="currentUser">The claims principal of the current user.</param>
        /// <returns>A ManageServiceModel with user info.</returns>
        public Task<ManageServiceModel> GetUserInfoAsync(ClaimsPrincipal currentUser);

        /// <summary>
        /// Used for deleting the current users profile picture.
        /// </summary>
        /// <param name="currentUser">The claims principal of the current user.</param>
        /// <returns>Task (void).</returns>
        public Task DeleteProfilePictureAsync(ClaimsPrincipal currentUser);
    }
}
