// -----------------------------------------------------------------------
// <copyright file="IAccountService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using EasyRank.Services.Exceptions;

using Microsoft.AspNetCore.Identity;

namespace EasyRank.Services.Contracts
{
    // TODO: document

    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(
            string email,
            string? firstName,
            string? lastName,
            string userName,
            string password);

        Task<bool> IsEmailConfirmedAsync(string email);

        /// <summary>
        /// Used for signing the current user to the app.
        /// </summary>
        /// <param name="email">The email of the current user.</param>
        /// <param name="password">The password of the current user.</param>
        /// <returns>A 'SignInResult' to be verified by the controller.</returns>
        /// <exception cref="NotFoundException">NotFoundException is thrown when the user is not found.</exception>
        Task<SignInResult> SignInUserAsync(string email, string password);

        /// <summary>
        /// Used for checking if a user exists.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>A flag indicating whether the user exists or not.</returns>
        Task<bool> DoesUserExist(string email);

        /// <summary>
        /// Used for retrieving the ID of an user by their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The ID of the user.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        Task<Guid> GetUserIdByEmail(string email);

        /// <summary>
        /// Used for signing out the current user.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <remarks>EXCLUDED FROM TESTS: WRAPPER AROUND USER MANAGER METHOD.</remarks>
        Task SignOutAsync();

        /// <summary>
        /// Used for generating a change email token for the current user.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <param name="newEmail">The new email for the user.</param>
        /// <returns>The token as a string.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        Task<string> GenerateChangeEmailTokenAsync(Guid userId, string newEmail);

        /// <summary>
        /// Used for generating an email confirmation token for the current user.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>The token as a string.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        Task<string> GenerateEmailConfirmationTokenAsync(Guid userId);

        /// <summary>
        /// Used for generating a password reset token for the current user.
        /// </summary>
        /// <param name="userId">The ID of the current user.</param>
        /// <returns>The token as a string.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        Task<string> GeneratePasswordResetTokenAsync(Guid userId);

        /// <summary>
        /// Used for resetting the password for the current user.
        /// </summary>
        /// <param name="email">The email of the current user.</param>
        /// <param name="code">The token generated earlier for the user.</param>
        /// <param name="password">The password of the current user.</param>
        /// <returns>Identity Result from the operation.</returns>
        /// <exception cref="NotFoundException">Thrown when the user was not found.</exception>
        Task<IdentityResult> ResetPasswordAsync(string email, string code, string password);
    }
}
