// -----------------------------------------------------------------------
// <copyright file="AdminService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts.Admin;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;
using EasyRank.Services.Models.Admin;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services
{
    /// <summary>
    /// The AdminService class responsible for dealing with admin related business.
    /// </summary>
    /// <remarks>Implementation of <see cref="IAdminService"/>.</remarks>
    public class AdminService : IAdminService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;
        private readonly UserManager<EasyRankUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminService"/> class.
        /// Constructor for the rank service class.
        /// </summary>
        /// <param name="repo">The implementation of a repository to be used.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        /// <param name="userManager">The user manager for the service.</param>
        public AdminService(
            IRepository repo,
            IMapper mapper,
            UserManager<EasyRankUser> userManager)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RankPageServiceModel>> GetAllRankingsAsync()
        {
            return this.mapper.Map<IEnumerable<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>(rp => !rp.IsDeleted)
                    .Include(rp => rp.CreatedByUser)
                    .Include(rp => rp.Comments)
                    .Include(rp => rp.LikedBy)
                    .OrderByDescending(rp => rp.CreatedOn)
                    .ToListAsync());
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RankEntryServiceModelExtended>> GetAllEntriesAsync()
        {
            return this.mapper.Map<IEnumerable<RankEntryServiceModelExtended>>(
                await this.repo.AllReadonly<RankEntry>(re => !re.IsDeleted)
                    .Include(re => re.RankPage)
                    .ThenInclude(rp => rp.CreatedByUser)
                    .ToListAsync());
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CommentServiceModelExtended>> GetAllCommentsAsync()
        {
            return this.mapper.Map<IEnumerable<CommentServiceModelExtended>>(
                await this.repo.AllReadonly<Comment>(c => !c.IsDeleted)
                    .Include(c => c.CreatedByUser)
                    .OrderByDescending(c => c.CreatedOn)
                    .ToListAsync());
        }

        /// <inheritdoc />
        public async Task<IEnumerable<EasyRankUserServiceModel>> GetAllUsersAsync()
        {
            IEnumerable<EasyRankUser> users = await this.repo.AllReadonly<EasyRankUser>().ToListAsync();

            return users.Select(u => new EasyRankUserServiceModel
            {
                Id = u.Id,
                Username = u.UserName,
                FullName = $"{u.FirstName} {u.LastName}",
                Email = u.Email,
                IsEmailConfirmed = u.EmailConfirmed,
                IsAdmin = this.userManager.IsInRoleAsync(u, "Administrator")
                    .GetAwaiter()
                    .GetResult(),
            })
            .ToList();
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(Guid userId)
        {
            EasyRankUser user = await this.userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new NotFoundException();
            }

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

            await this.repo.SaveChangesAsync();
            await this.userManager.DeleteAsync(user);
        }

        /// <inheritdoc />
        public async Task MakeUserAdminAsync(Guid userId)
        {
            EasyRankUser user = await this.userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new NotFoundException();
            }

            await this.userManager.AddToRoleAsync(user, "Administrator");
        }

        /// <inheritdoc />
        public async Task RemoveAdminUserAsync(Guid userId)
        {
            EasyRankUser user = await this.userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new NotFoundException();
            }

            EasyRankUser adminUser = await this.userManager.FindByEmailAsync("vassdeniss@gmail.com");
            if (user.Id == adminUser.Id)
            {
                throw new ForbiddenException();
            }

            await this.userManager.RemoveFromRoleAsync(user, "Administrator");
        }
    }
}
