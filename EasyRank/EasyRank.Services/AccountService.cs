// -----------------------------------------------------------------------
// <copyright file="AccountService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services
{
    /// <summary>
    /// The AccountService class responsible for dealing with user accounts.
    /// </summary>
    /// <remarks>Implementation of <see cref="IAccountService"/>.</remarks>
    public class AccountService : IAccountService
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly IRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// Constructor for the account service class.
        /// </summary>
        /// <param name="userManager">The user manager for the service.</param>
        /// <param name="signInManager">The sign in manager for the service.</param>
        /// <param name="repo">The implementation of a repository to be used.</param>
        public AccountService(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IRepository repo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repo = repo;
        }

        /// <inheritdoc />
        public async Task<IdentityResult> CreateUserAsync(
            string email,
            string? firstName,
            string? lastName,
            string userName,
            string password)
        {
            EasyRankUser user = new EasyRankUser
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
            };

            IdentityResult result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<bool> IsEmailConfirmedAsync(string email)
        {
            EasyRankUser? user = await this.repo.AllReadonly<EasyRankUser>(
                    u => u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return user.EmailConfirmed;
        }

        /// <inheritdoc />
        public async Task<SignInResult> SignInUserAsync(string email, string password)
        {
            EasyRankUser? user = await this.repo.AllReadonly<EasyRankUser>(
                    u => u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return await this.signInManager.PasswordSignInAsync(
                user,
                password,
                false,
                false);
        }

        /// <inheritdoc />
        public async Task<bool> DoesUserExist(string email)
        {
            return await this.repo.AllReadonly<EasyRankUser>(u => u.Email == email)
                .FirstOrDefaultAsync() != null;
        }

        /// <inheritdoc />
        public async Task<Guid> GetUserIdByEmail(string email)
        {
            EasyRankUser? user = await this.repo.AllReadonly<EasyRankUser>(
                    u => u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return user.Id;
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public async Task SignOutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        /// <inheritdoc />
        public async Task<string> GenerateChangeEmailTokenAsync(Guid userId, string newEmail)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            string code = await this.userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }

        /// <inheritdoc />
        public async Task<string> GenerateEmailConfirmationTokenAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            string code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }

        /// <inheritdoc />
        public async Task<string> GeneratePasswordResetTokenAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            string code = await this.userManager.GeneratePasswordResetTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }

        /// <inheritdoc />
        public async Task<IdentityResult> ResetPasswordAsync(string email, string code, string password)
        {
            EasyRankUser? user = await this.repo.AllReadonly<EasyRankUser>(
                    u => u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return await this.userManager.ResetPasswordAsync(user, code, password);
        }
    }
}
