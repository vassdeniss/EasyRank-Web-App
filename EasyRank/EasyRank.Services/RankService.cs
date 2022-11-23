// -----------------------------------------------------------------------
// <copyright file="RankService.cs" company="Denis Vasilev">
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
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services
{
    /// <summary>
    /// The RankService class responsible for dealing with ranking related business.
    /// </summary>
    /// <remarks>Implementation of <see cref="IRankService"/>.</remarks>
    public class RankService : IRankService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RankService"/> class.
        /// Constructor for the rank service class.
        /// </summary>
        /// <param name="repo">The implementation of a repository to be used.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public RankService(
            IRepository repo,
            IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ICollection<RankPageServiceModel>> GetAllRankingsAsync()
        {
            return this.mapper.Map<ICollection<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>()
                    .Where(rp => rp.IsDeleted == false)
                    .Include(rp => rp.CreatedByUser)
                    .Include(rp => rp.Comments)
                    .OrderByDescending(rp => rp.CreatedOn)
                    .ToListAsync());
        }

        /// <inheritdoc />
        public async Task<RankPageServiceModel> GetRankPageByGuidAsync(Guid rankGuid)
        {
            RankPage rankPage = await this.repo.AllReadonly<RankPage>(rp => rp.Id == rankGuid)
                .Where(rp => rp.IsDeleted == false)
                .Include(rp => rp.Comments)
                .ThenInclude(c => c.CreatedByUser)
                .Include(rp => rp.Entries)
                .Include(rp => rp.CreatedByUser)
                .FirstAsync();

            if (rankPage == null)
            {
                throw new NotFoundException();
            }

            return this.mapper.Map<RankPageServiceModel>(rankPage);
        }

        /// <inheritdoc />
        public async Task<RankPageServiceModelExtended> GetExtendedRankPageByGuidAsync(Guid rankGuid)
        {
            RankPage rankPage = await this.repo.AllReadonly<RankPage>(rp => rp.Id == rankGuid)
                .Where(rp => rp.IsDeleted == false)
                .Include(rp => rp.Comments)
                .ThenInclude(c => c.CreatedByUser)
                .Include(rp => rp.Entries)
                .Include(rp => rp.CreatedByUser)
                .FirstAsync();

            if (rankPage == null)
            {
                throw new NotFoundException();
            }

            RankPageServiceModelExtended rankPageServiceModelExtended = new RankPageServiceModelExtended
            {
                Id = rankGuid,
                RankingTitle = rankPage.RankingTitle,
                Image = rankPage.Image,
                ImageAlt = rankPage.ImageAlt,
                CreatedOn = rankPage.CreatedOn.ToString("dd MMMM yyyy"),
                LikeCount = rankPage.LikedBy.Count,
                CreatedByUserName = rankPage.CreatedByUser.UserName,
                CommentCount = rankPage.Comments.Count,
                Entries = rankPage.Entries.Select(re => new RankEntryServiceModel
                {
                    Placement = re.Placement,
                    Title = re.Title,
                    Image = re.Image,
                    ImageAlt = re.ImageAlt,
                    Description = re.Description,
                })
                .OrderByDescending(e => e.Placement)
                .ToList(),
                Comments = this.mapper.Map<ICollection<CommentServiceModel>>(rankPage.Comments
                        .Where(c => c.IsDeleted == false)
                        .OrderByDescending(c => c.CreatedOn))
                    .ToList(),
                LikedBy = new List<EasyRankUser>(), // TODO: Fix
            };

            return rankPageServiceModelExtended;
        }

        /// <inheritdoc />
        public async Task<ICollection<RankPageServiceModel>> GetAllRankingsByUserAsync(Guid userId)
        {
            return this.mapper.Map<ICollection<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>(rp => rp.CreatedByUserId == userId)
                    .Where(rp => rp.IsDeleted == false)
                    .Include(rp => rp.Comments)
                    .OrderByDescending(rp => rp.CreatedOn)
                    .ToListAsync());
        }

        /// <inheritdoc />
        public async Task CreateRankAsync(
            byte[]? image,
            string imageAlt,
            string rankingTitle,
            Guid userId)
        {
            RankPage page = new RankPage
            {
                Image = image,
                ImageAlt = imageAlt,
                RankingTitle = rankingTitle,
                CreatedOn = DateTime.UtcNow,
                CreatedByUserId = userId,
            };

            await this.repo.AddAsync<RankPage>(page);
            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task IsCurrentUserPageOwner(Guid userId, Guid rankId)
        {
            RankPage page = await this.repo.All<RankPage>(c => c.Id == rankId)
                        .Where(rp => rp.IsDeleted == false)
                        .Include(rp => rp.CreatedByUser)
                        .FirstOrDefaultAsync()
                                    ?? throw new NotFoundException();

            if (page.CreatedByUser.Id != userId)
            {
                throw new UnauthorizedUserException();
            }
        }

        /// <inheritdoc />
        public async Task EditRankAsync(Guid rankId, string rankingTitle, string imageAlt, byte[]? image)
        {
            RankPage page = await this.repo.GetByIdAsync<RankPage>(rankId);

            if (page == null || page.IsDeleted)
            {
                throw new NotFoundException();
            }

            page.RankingTitle = rankingTitle;
            page.ImageAlt = imageAlt;
            page.Image = image;

            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteRankAsync(Guid rankId)
        {
            RankPage page = await this.repo.GetByIdAsync<RankPage>(rankId);

            if (page == null || page.IsDeleted)
            {
                throw new NotFoundException();
            }

            page.IsDeleted = true;

            await this.repo.SaveChangesAsync();
        }
    }
}
