// -----------------------------------------------------------------------
// <copyright file="CommentService.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
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
    /// The CommentService class responsible for dealing with comment related business.
    /// </summary>
    /// <remarks>Implementation of <see cref="ICommentService"/>.</remarks>
    public class CommentService : ICommentService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// Constructor for the comment service class.
        /// </summary>
        /// <param name="repo">The implementation of a repository to be used.</param>
        /// <param name="mapper">Instance of an AutoMapper.</param>
        public CommentService(
            IRepository repo,
            IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        /// <summary>
        /// Implementation of the CreateCommentAsync interface method
        /// used for retrieving the content the user inputted, creating a comment and saving it to the database.
        /// </summary>
        /// <returns>Task (void).</returns>
        /// <param name="content">The content of the comment.</param>
        /// <param name="createdByUserId">GUID used to identify the user which posted the comment.</param>
        /// <param name="rankPageId">GUID used to identify the rank page where the comment was posted.</param>
        public async Task CreateCommentAsync(
            string content,
            Guid createdByUserId,
            Guid rankPageId)
        {
            Comment comment = new Comment
            {
                Content = content,
                CreatedOn = DateTime.UtcNow,
                CreatedByUserId = createdByUserId,
                RankPageId = rankPageId,
            };

            await this.repo.AddAsync<Comment>(comment);
            await this.repo.SaveChangesAsync();
        }

        public async Task<CommentServiceModel?> GetCommentByIdAsync(Guid commentId)
        {
            return this.mapper.Map<CommentServiceModel>(
                await this.repo.AllReadonly<Comment>(c => c.Id == commentId)
                    .Include(c => c.CreatedByUser)
                    .FirstOrDefaultAsync());
        }

        public async Task EditCommentAsync(Guid commentId, string content)
        {
            Comment comment = await this.repo.GetByIdAsync<Comment>(commentId);

            comment.Content = content;

            await this.repo.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(Guid commentId)
        {
            Comment comment = await this.repo.GetByIdAsync<Comment>(commentId);

            comment.IsDeleted = true;

            await this.repo.SaveChangesAsync();
        }

        public async Task<bool> IsCurrentUserNameOwner(Guid rankId, Guid userId)
        {
            RankPage page = (await this.repo.AllReadonly<RankPage>(rp => rp.Id == rankId)
                .Include(rp => rp.CreatedByUser)
                .FirstOrDefaultAsync())!;

            return page.CreatedByUser.Id == userId;
        }
    }
}
