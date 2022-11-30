// -----------------------------------------------------------------------
// <copyright file="ManageService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

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
    }
}
