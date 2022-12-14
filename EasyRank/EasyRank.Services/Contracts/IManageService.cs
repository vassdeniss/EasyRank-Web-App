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
using Microsoft.AspNetCore.Identity;

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
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>A ManageServiceModel with user info.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<ManageServiceModel> GetUserInfoAsync(Guid userId);

        /// <summary>
        /// Used for deleting the current users profile picture.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>Task (void).</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task DeleteProfilePictureAsync(Guid userId);

        /// <summary>
        /// Used for updating the current users profile settings.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
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
            Guid userId,
            string? inputFirstName,
            string? inputLastName,
            string inputUserName,
            IFormFileCollection inputFiles);

        /// <summary>
        /// Used for checking if the inputted password matches the current user's password.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <param name="currentPassword">The password of the current user.</param>
        /// <returns>Flag indicating if the passwords match.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<bool> CheckPasswordAsync(
            Guid userId,
            string currentPassword);

        /// <summary>
        /// Used for deleting a user from the database.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>Task (void).</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task DeleteUserAsync(Guid userId);

        /// <summary>
        /// Used for checking if the current user's email is confirmed.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>Flag indicating if the email is confirmed.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<bool> IsEmailConfirmedAsync(Guid userId);

        /// <summary>
        /// Used for retrieving the current user's email.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>An EmailServiceModel with the users email.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<EmailServiceModel> GetUserEmailAsync(Guid userId);

        /// <summary>
        /// Used for checking if a given email is taken by some user.
        /// </summary>
        /// <param name="email">The email to be checked.</param>
        /// <returns>A flag indicating if a user with this email exists.</returns>
        public Task<bool> IsEmailTakenAsync(string email);

        /// <summary>
        /// Used for generating a change email token for the current user.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <param name="newEmail">The new email for the user.</param>
        /// <returns>The token as a string.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<string> GenerateChangeEmailTokenAsync(Guid userId, string newEmail);

        /// <summary>
        /// Used for generating an email confirmation token for the current user.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>The token as a string.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<string> GenerateEmailConfirmationTokenAsync(Guid userId);

        /// <summary>
        /// Used for changing the current user's email.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <param name="newEmail">The new email for the user.</param>
        /// <param name="code">The change email verification token for the user.</param>
        /// <returns>Result indicating success or failure.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<IdentityResult> ChangeEmailAsync(
            Guid userId,
            string newEmail,
            string code);

        /// <summary>
        /// Used for confirming the current user's email.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <param name="code">The change email verification token for the user.</param>
        /// <returns>Result indicating success or failure.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<IdentityResult> ConfirmEmailAsync(
            Guid userId,
            string code);

        /// <summary>
        /// Used for changing the password of the current user.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <param name="oldPass">The old password of the current user.</param>
        /// <param name="newPass">The new password of the current user.</param>
        /// <returns>Result indicating success or failure.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        public Task<IdentityResult> ChangePasswordAsync(
            Guid userId,
            string oldPass,
            string newPass);
    }
}
