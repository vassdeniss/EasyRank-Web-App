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

        /// <summary>
        /// Initializes a new instance of the <see cref="RankService"/> class.
        /// Constructor for the rank service class.
        /// </summary>
        /// <param name="repo">The implementation of a repository to be used.</param>
        public RankService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Implementation of the GetAllRankingsAsync interface method
        /// used for retrieving all rankings from the database.
        /// </summary>
        /// <returns>A collection of rank page service models.</returns>
        public async Task<ICollection<RankPageServiceModel>> GetAllRankingsAsync()
        {
            ICollection<RankPage> rankPages = await this.repo.AllReadonly<RankPage>()
                .Include(rp => rp.CreatedByUser)
                .ToListAsync();

            return rankPages.Select(p => new RankPageServiceModel
            {
                Id = p.Id,
                Image = p.Image,
                ImageAlt = p.ImageAlt,
                RankingTitle = p.RankingTitle,
                CreatedOn = p.CreatedOn.ToString("dd MMMM yyyy"),
                LikeCount = p.LikedBy.Count,
                CreatedByUserName = p.CreatedByUser.UserName,
                CommentCount = p.Comments.Count,
            })
            .ToList();
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
            ICollection<RankPage> rankPages = await this.repo.AllReadonly<RankPage>(rp => rp.CreatedByUserId == userId)
                .ToListAsync();

            return rankPages.Select(rp => new RankPageServiceModel
            {
                RankingTitle = rp.RankingTitle,
                Image = rp.Image,
                ImageAlt = rp.ImageAlt,
                CreatedOn = rp.CreatedOn.ToString("dd MMMM yyyy"),
                LikeCount = rp.LikedBy.Count,
                CreatedByUserName = rp.CreatedByUser.UserName,
                CommentCount = rp.Comments.Count,
            })
            .ToList();
        }
    }
}
