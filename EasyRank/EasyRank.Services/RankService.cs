// -----------------------------------------------------------------------
// <copyright file="RankService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
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

        /// <summary>
        /// Implementation of the GetAllRankingsAsync interface method
        /// used for retrieving all rankings from the database.
        /// </summary>
        /// <returns>A collection of rank page service models.</returns>
        public async Task<ICollection<RankPageServiceModel>> GetAllRankingsAsync()
        {
            return this.mapper.Map<ICollection<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>()
                    .Include(rp => rp.CreatedByUser)
                    .ToListAsync());
        }

        /// <summary>
        /// Implementation of the GetRankPageByGuidAsync interface method
        /// used for retrieving a rank page from the database by its GUID.
        /// </summary>
        /// <returns>An extended rank page service model.</returns>
        /// <param name="rankGuid">GUID used to search for the rank page.</param>
        public async Task<RankPageServiceModelExtended> GetRankPageByGuidAsync(Guid rankGuid)
        {
            RankPage rankPage = await this.repo.AllReadonly<RankPage>(rp => rp.Id == rankGuid)
                .Include(rp => rp.Entries)
                .Include(rp => rp.CreatedByUser)
                .FirstAsync();

            RankPageServiceModelExtended rankPageServiceModelExtended = new RankPageServiceModelExtended
            {
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
                Comments = new List<Comment>(), // TODO: Fix
                LikedBy = new List<EasyRankUser>(), // TODO: Fix
            };

            return rankPageServiceModelExtended;
        }

        /// <summary>
        /// Implementation of the GetAllRankingsByUserAsync interface method
        /// used for retrieving a collection of rank pages for a specified user from the database.
        /// </summary>
        /// <returns>A collection of rank page service models.</returns>
        /// <param name="userId">GUID used to search for the users rankings.</param>
        public async Task<ICollection<RankPageServiceModel>> GetAllRankingsByUserAsync(Guid userId)
        {
            return this.mapper.Map<ICollection<RankPageServiceModel>>(
                await this.repo.AllReadonly<RankPage>(rp => rp.CreatedByUserId == userId)
                    .ToListAsync()); ;
        }
    }
}
