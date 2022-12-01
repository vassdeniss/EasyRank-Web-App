// -----------------------------------------------------------------------
// <copyright file="IManageService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Security.Claims;
using System.Threading.Tasks;

using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.AspNetCore.Http;

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
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<ManageServiceModel> GetUserInfoAsync(ClaimsPrincipal currentUser);

        /// <summary>
        /// Used for deleting the current users profile picture.
        /// </summary>
        /// <param name="currentUser">The claims principal of the current user.</param>
        /// <returns>Task (void).</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task DeleteProfilePictureAsync(ClaimsPrincipal currentUser);

        /// <summary>
        /// Used for updating the current users profile settings.
        /// </summary>
        /// <param name="currentUser">The claims principal of the current user.</param>
        /// <param name="inputFirstName">The first name inputted by the user.</param>
        /// <param name="inputLastName">The last name inputted by the user.</param>
        /// <param name="inputUserName">The user name inputted by the user.</param>
        /// <param name="inputFiles">The profile picture file if uploaded by the user.</param>
        /// <returns>Task (void).</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        /// <exception cref="UsernameTakenException">Thrown when the username the user wants to use is taken.</exception>
        /// <exception cref="FileFormatException">
        /// Thrown when the user's uploaded profile picture is in invalid format.
        /// </exception>
        public Task UpdateUserDataAsync(
            ClaimsPrincipal currentUser,
            string? inputFirstName,
            string? inputLastName,
            string inputUserName,
            IFormFileCollection inputFiles);

        /// <summary>
        /// Used for checking if the inputted password matches the current user's password.
        /// </summary>
        /// <param name="currentUser">The claims principal of the current user.</param>
        /// <param name="currentPassword">The password of the current user.</param>
        /// <returns>Flag indicating if the passwords match.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<bool> CheckPasswordAsync(
            ClaimsPrincipal currentUser,
            string currentPassword);

        /// <summary>
        /// Used for deleting a user from the database.
        /// </summary>
        /// <param name="currentUser">The claims principal of the current user.</param>
        /// <returns>Task (void).</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        /// <exception cref="InvalidOperationException">Throws when the delete operation failed.</exception>
        public Task DeleteUserAsync(ClaimsPrincipal currentUser);
    }
}
