// -----------------------------------------------------------------------
// <copyright file="ManageService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services
{
    /// <summary>
    /// The ManageService class responsible for dealing with account management business.
    /// </summary>
    /// <remarks>Implementation of <see cref="IManageService"/>.</remarks>
    public class ManageService : IManageService
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly IMapper mapper;
        private readonly IRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for the service.</param>
        /// <param name="signInManager">The sign in manager for the service.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        /// <param name="repo">The implementation of a repository to be used.</param>
        public ManageService(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IMapper mapper,
            IRepository repo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.repo = repo;
        }

        /// <inheritdoc />
        public async Task<ManageServiceModel> GetUserInfoAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            //string phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            return this.mapper.Map<ManageServiceModel>(user);
        }

        /// <inheritdoc />
        public async Task DeleteProfilePictureAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            user.ProfilePicture = null;

            await this.userManager.UpdateAsync(user);
            await this.signInManager.RefreshSignInAsync(user);
        }

        /// <inheritdoc />
        public async Task UpdateUserDataAsync(
            Guid userId,
            string? inputFirstName,
            string? inputLastName,
            string inputUserName,
            IFormFileCollection inputFiles)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            //var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            string? firstName = user.FirstName;
            if (inputFirstName != firstName)
            {
                user.FirstName = inputFirstName;
            }

            string? lastName = user.LastName;
            if (inputLastName != lastName)
            {
                user.LastName = inputLastName;
            }

            string username = user.UserName;
            if (inputUserName != username)
            {
                EasyRankUser? userWithGivenUsername = await this.repo.AllReadonly<EasyRankUser>(
                        u => u.UserName == inputUserName)
                    .FirstOrDefaultAsync();

                if (userWithGivenUsername != null)
                {
                    throw new UsernameTakenException();
                }

                await this.userManager.SetUserNameAsync(user, inputUserName);
            }

            if (inputFiles.Count > 0)
            {
                IFormFile file = inputFiles.First();

                string[] acceptedExtensions = { ".png", ".jpg", ".jpeg", ".gif", ".tif" };

                if (!acceptedExtensions.Contains(Path.GetExtension(file.FileName)))
                {
                    throw new FileFormatException();
                }

                using MemoryStream memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);
                user.ProfilePicture = memoryStream.ToArray();
            }

            await this.userManager.UpdateAsync(user);
            await this.signInManager.RefreshSignInAsync(user);
        }

        /// <inheritdoc />
        public async Task<bool> CheckPasswordAsync(Guid userId, string currentPassword)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return await this.userManager.CheckPasswordAsync(user, currentPassword);
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            user.FirstName = null;
            user.LastName = null;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.Email = null;
            user.NormalizedEmail = null;
            user.EmailConfirmed = false;
            user.PasswordHash = null;
            user.SecurityStamp = null;
            user.ConcurrencyStamp = null;
            user.PhoneNumber = null;
            user.PhoneNumberConfirmed = false;
            user.TwoFactorEnabled = false;
            user.LockoutEnd = null;
            user.LockoutEnabled = false;
            user.AccessFailedCount = 0;
            user.ProfilePicture = null;

            user.IsForgotten = true;

            //RequirePassword = await this.userManager.HasPasswordAsync(user);
            //if (RequirePassword)
            //{
            //    if (!await this.userManager.CheckPasswordAsync(user, Input.Password))
            //    {
            //        ModelState.AddModelError(string.Empty, "Incorrect password.");
            //        return Page();
            //    }
            //}

            List<RankPage> userRanks = await this.repo.All<RankPage>(
                    rp => !rp.IsDeleted && rp.CreatedByUserId == user.Id)
                .Include(rp => rp.Entries)
                .Include(rp => rp.Comments)
                .ToListAsync();

            foreach (RankPage page in userRanks)
            {
                foreach (Comment comment in page.Comments)
                {
                    comment.IsDeleted = true;
                }

                foreach (RankEntry entry in page.Entries)
                {
                    entry.IsDeleted = true;
                }

                page.IsDeleted = true;
            }

            List<Comment> userComments = await this.repo.All<Comment>(
                    c => !c.IsDeleted && c.CreatedByUserId == user.Id)
                .ToListAsync();

            foreach (Comment comment in userComments)
            {
                comment.IsDeleted = true;
            }

            await this.repo.SaveChangesAsync();

            //string userId = await this.userManager.GetUserIdAsync(user);
            //this.logger.LogInformation($"User with ID '{userId}' deleted themselves.");
            await this.signInManager.SignOutAsync();
        }

        /// <inheritdoc />
        public async Task<bool> IsEmailConfirmedAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return await this.userManager.IsEmailConfirmedAsync(user);
        }

        /// <inheritdoc />
        public async Task<EmailServiceModel> GetUserEmailAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            string email = await this.userManager.GetEmailAsync(user);
            return new EmailServiceModel { Email = email, NewEmail = email, };
        }

        /// <inheritdoc />
        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email) != null;
        }

        /// <inheritdoc />
        public async Task<string> GetUserIdAsync(Guid userId)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return await this.userManager.GetUserIdAsync(user);
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
        public async Task<IdentityResult> ChangeEmailAsync(Guid userId, string newEmail, string code)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            string token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            IdentityResult result = await this.userManager.ChangeEmailAsync(user, newEmail, token);
            if (result.Succeeded)
            {
                await this.signInManager.RefreshSignInAsync(user);
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<IdentityResult> ConfirmEmailAsync(Guid userId, string code)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            string token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            return await this.userManager.ConfirmEmailAsync(user, token);
        }

        /// <inheritdoc />
        public async Task<IdentityResult> ChangePasswordAsync(Guid userId, string oldPass, string newPass)
        {
            EasyRankUser user = await this.repo.GetByIdAsync<EasyRankUser>(userId);
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            IdentityResult result = await this.userManager.ChangePasswordAsync(user,
                oldPass,
                newPass);
            if (result.Succeeded)
            {
                await this.signInManager.RefreshSignInAsync(user);
            }

            //this.logger.LogInformation("User changed their password successfully.");
            return result;
        }
    }
}
