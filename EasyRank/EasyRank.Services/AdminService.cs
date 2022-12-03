// -----------------------------------------------------------------------
// <copyright file="AdminService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminService"/> class.
        /// Constructor for the rank service class.
        /// </summary>
        /// <param name="repo">The implementation of a repository to be used.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public AdminService(
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
                    .Include(rp => rp.LikedBy)
                    .OrderByDescending(rp => rp.CreatedOn)
                    .ToListAsync());
        }
    }
}
