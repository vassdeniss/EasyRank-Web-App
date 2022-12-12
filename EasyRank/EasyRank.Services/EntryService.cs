// -----------------------------------------------------------------------
// <copyright file="EntryService.cs" company="Denis Vasilev">
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
    /// The EntryService class responsible for dealing with ranking related business.
    /// </summary>
    /// <remarks>Implementation of <see cref="IEntryService"/>.</remarks>
    public class EntryService : IEntryService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryService"/> class.
        /// Constructor for the rank service class.
        /// </summary>
        /// <param name="repo">The implementation of a repository to be used.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public EntryService(
            IRepository repo,
            IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
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
        public async Task CreateEntryAsync(
            int placement,
            string title,
            byte[]? image,
            string imageAlt,
            string description,
            Guid rankId)
        {
            RankEntry entry = new RankEntry
            {
                Placement = placement,
                Title = title,
                Image = image,
                ImageAlt = imageAlt,
                Description = description,
                RankPageId = rankId,
            };

            await this.repo.AddAsync<RankEntry>(entry);
            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<ICollection<int>> GetAvailablePlacementsAsync(Guid rankId)
        {
            RankPage page = await this.repo.All<RankPage>(
                    rp => rp.Id == rankId && !rp.IsDeleted)
                .Include(rp => rp.Entries)
                .FirstOrDefaultAsync()
                    ?? throw new NotFoundException();

            List<int> takenPlacements = page.Entries
                .Where(e => !e.IsDeleted)
                .Select(e => e.Placement)
                .ToList();

            return Enumerable.Range(1, 10)
                .Where(n => !takenPlacements.Contains(n))
                .OrderByDescending(n => n)
                .ToList();
        }

        /// <inheritdoc />
        public async Task EditEntryAsync(
            Guid entryId,
            int placement,
            string entryTitle,
            byte[]? image,
            string imageAlt,
            string entryDescription)
        {
            RankEntry entry = await this.repo.GetByIdAsync<RankEntry>(entryId);

            if (entry == null || entry.IsDeleted)
            {
                throw new NotFoundException();
            }

            entry.Placement = placement;
            entry.Title = entryTitle;
            entry.Image = image;
            entry.ImageAlt = imageAlt;
            entry.Description = entryDescription;

            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<RankEntryServiceModel> GetRankEntryByGuidAsync(Guid entryId)
        {
            RankEntry? rankEntry = await this.repo.GetByIdAsync<RankEntry>(entryId);

            if (rankEntry == null || rankEntry.IsDeleted)
            {
                throw new NotFoundException();
            }

            return this.mapper.Map<RankEntryServiceModel>(rankEntry);
        }

        /// <inheritdoc />
        public async Task DeleteEntryAsync(Guid entryId)
        {
            RankEntry entry = await this.repo.GetByIdAsync<RankEntry>(entryId);

            if (entry == null || entry.IsDeleted)
            {
                throw new NotFoundException();
            }

            entry.IsDeleted = true;

            await this.repo.SaveChangesAsync();
        }
    }
}
