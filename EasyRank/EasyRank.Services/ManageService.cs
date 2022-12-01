// -----------------------------------------------------------------------
// <copyright file="ManageService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for the service.</param>
        /// <param name="signInManager">The sign in manager for the service.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public ManageService(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ManageServiceModel> GetUserInfoAsync(ClaimsPrincipal currentUser)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(currentUser);
            if (user == null)
            {
                throw new NotFoundException();
            }

            //string phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            return this.mapper.Map<ManageServiceModel>(user);
        }

        /// <inheritdoc />
        public async Task DeleteProfilePictureAsync(ClaimsPrincipal currentUser)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(currentUser);
            if (user == null)
            {
                throw new NotFoundException();
            }

            user.ProfilePicture = null;

            await this.userManager.UpdateAsync(user);
            await this.signInManager.RefreshSignInAsync(user);
        }

        /// <inheritdoc />
        public async Task UpdateUserDataAsync(
            ClaimsPrincipal currentUser,
            string? inputFirstName,
            string? inputLastName,
            string inputUserName,
            IFormFileCollection inputFiles)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(currentUser);
            if (user == null)
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
                EasyRankUser userWithGivenUsername = await this.userManager.FindByNameAsync(inputUserName);
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
        public async Task<bool> CheckPasswordAsync(ClaimsPrincipal currentUser, string currentPassword)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(currentUser);
            if (user == null)
            {
                throw new NotFoundException();
            }

            return await this.userManager.CheckPasswordAsync(user, currentPassword);
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(ClaimsPrincipal currentUser)
        {
            EasyRankUser user = await this.userManager.GetUserAsync(currentUser);
            if (user == null)
            {
                throw new NotFoundException();
            }

            //RequirePassword = await this.userManager.HasPasswordAsync(user);
            //if (RequirePassword)
            //{
            //    if (!await this.userManager.CheckPasswordAsync(user, Input.Password))
            //    {
            //        ModelState.AddModelError(string.Empty, "Incorrect password.");
            //        return Page();
            //    }
            //}

            //string userId = await this.userManager.GetUserIdAsync(user);
            await this.userManager.DeleteAsync(user);
            //this.logger.LogInformation($"User with ID '{userId}' deleted themselves.");
            await this.signInManager.SignOutAsync();
        }
    }
}
