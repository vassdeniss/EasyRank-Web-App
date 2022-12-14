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
        public async Task<AllRanksServiceModel> GetAllRankingsAsync(int page, int perPage)
        {
            ICollection<RankPageServiceModel> pages = this.mapper.Map<ICollection<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>(rp => !rp.IsDeleted)
                    .Include(rp => rp.CreatedByUser)
                    .Include(rp => rp.Comments)
                    .Include(rp => rp.LikedBy)
                    .OrderByDescending(rp => rp.CreatedOn)
                    .Skip((page - 1) * perPage)
                    .Take(perPage)
                    .ToListAsync());

            return new AllRanksServiceModel
            {
                CurrentPage = page,
                Ranks = pages,
                TotalRankCount = await this.repo.AllReadonly<RankPage>().CountAsync(),
            };
        }

        /// <inheritdoc />
        public async Task<RankPageServiceModel> GetRankPageByGuidAsync(Guid rankGuid)
        {
            RankPage? rankPage = await this.repo.AllReadonly<RankPage>(
                    rp => rp.Id == rankGuid && !rp.IsDeleted)
                .Include(rp => rp.Comments)
                .ThenInclude(c => c.CreatedByUser)
                .Include(rp => rp.Entries)
                .Include(rp => rp.CreatedByUser)
                .FirstOrDefaultAsync();

            if (rankPage == null)
            {
                throw new NotFoundException();
            }

            return this.mapper.Map<RankPageServiceModel>(rankPage);
        }

        /// <inheritdoc />
        public async Task<RankPageServiceModelExtended> GetExtendedRankPageByGuidAsync(Guid rankGuid)
        {
            RankPage? rankPage = await this.repo.AllReadonly<RankPage>(
                    rp => rp.Id == rankGuid && !rp.IsDeleted)
                .Include(rp => rp.Comments)
                .ThenInclude(c => c.CreatedByUser)
                .Include(rp => rp.Entries)
                .Include(rp => rp.CreatedByUser)
                .Include(rp => rp.LikedBy)
                .ThenInclude(erurp => erurp.EasyRankUser)
                .FirstOrDefaultAsync();

            if (rankPage == null)
            {
                throw new NotFoundException();
            }

            return this.mapper.Map<RankPageServiceModelExtended>(rankPage);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RankPageServiceModel>> GetAllRankingsByUserAsync(Guid userId)
        {
            return this.mapper.Map<IEnumerable<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>(
                        rp => rp.CreatedByUserId == userId && !rp.IsDeleted)
                    .Include(rp => rp.Comments)
                    .Include(rp => rp.LikedBy)
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
        public async Task IsCurrentUserPageOwnerAsync(Guid userId, Guid rankId, bool isAdmin)
        {
            RankPage page = await this.repo.All<RankPage>(
                    rp => rp.Id == rankId && !rp.IsDeleted)
                    .Include(rp => rp.CreatedByUser)
                    .FirstOrDefaultAsync()
                        ?? throw new NotFoundException();

            if (page.CreatedByUser.Id != userId && !isAdmin)
            {
                throw new ForbiddenException();
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
            RankPage page = await this.repo.All<RankPage>(
                rp => rp.Id == rankId && !rp.IsDeleted)
                .Include(rp => rp.Entries)
                .Include(rp => rp.Comments)
                .FirstOrDefaultAsync() 
                        ?? throw new NotFoundException();

            page.IsDeleted = true;

            foreach (Comment comment in page.Comments)
            {
                comment.IsDeleted = true;
            }

            foreach (RankEntry entry in page.Entries)
            {
                entry.IsDeleted = true;
            }

            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task LikeCommentAsync(Guid userId, Guid rankId)
        {

            RankPage page = await this.repo.All<RankPage>(
                    rp => rp.Id == rankId && !rp.IsDeleted)
                .Include(rp => rp.LikedBy)
                .FirstOrDefaultAsync() 
                    ?? throw new NotFoundException();

            EasyRankUserRankPage? mappedModel = page.LikedBy
                .FirstOrDefault(erurp => erurp.EasyRankUserId == userId);

            if (mappedModel == null)
            {
                await this.repo.AddAsync<EasyRankUserRankPage>(new EasyRankUserRankPage
                {
                    EasyRankUserId = userId,
                    RankPageId = rankId,
                    IsLiked = true,
                });
            }
            else
            {
                mappedModel.IsLiked = !mappedModel.IsLiked;
            }

            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<RankPageServiceModel>> GetAllLikesByUserAsync(Guid userId)
        {
            List<Guid> likedPageIds = await this.repo.AllReadonly<EasyRankUserRankPage>()
                .Where(erurp => erurp.EasyRankUserId == userId)
                .Where(erurp => erurp.IsLiked)
                .Select(erurp => erurp.RankPageId)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>(rp => likedPageIds.Contains(rp.Id))
                    .Where(rp => !rp.IsDeleted)
                    .Include(rp => rp.Comments)
                    .Include(rp => rp.LikedBy)
                    .OrderByDescending(rp => rp.CreatedOn)
                    .ToListAsync());
        }
    }
}
