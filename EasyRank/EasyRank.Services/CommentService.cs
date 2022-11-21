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
using EasyRank.Services.Exceptions;
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<CommentServiceModel> GetCommentByIdAsync(Guid commentId)
        {
            CommentServiceModel serviceModel = this.mapper.Map<CommentServiceModel>(
                await this.repo.AllReadonly<Comment>(c => c.Id == commentId)
                    .Include(c => c.CreatedByUser)
                    .FirstOrDefaultAsync());

            return serviceModel ?? throw new NotFoundException();
        }

        /// <inheritdoc />
        public async Task EditCommentAsync(Guid commentId, string content)
        {
            Comment comment = await this.repo.GetByIdAsync<Comment>(commentId);

            if (comment == null)
            {
                throw new NotFoundException();
            }

            comment.Content = content;

            await this.repo.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteCommentAsync(Guid commentId)
        {
            Comment comment = await this.repo.GetByIdAsync<Comment>(commentId);

            if (comment == null)
            {
                throw new NotFoundException();
            }

            comment.IsDeleted = true;

            await this.repo.SaveChangesAsync();
        }

        public async Task IsCurrentUserCommentOwner(
            Guid userId, 
            Guid commentId)
        {
            Comment comment = await this.repo.GetByIdAsync<Comment>(commentId);

            if (comment == null)
            {
                throw new NotFoundException();
            }

            if (comment.CreatedByUserId != userId)
            {
                throw new UnauthorizedUserException();
            }
        }

        public async Task IsCurrentUserPageOwner(
            Guid userId,
            Guid commentId)
        {
            Comment comment = await this.repo.All<Comment>(c => c.Id == commentId)
                .Include(c => c.RankPage)
                .ThenInclude(rp => rp.CreatedByUser)
                .FirstOrDefaultAsync() 
                              ?? throw new NotFoundException();

            if (comment.RankPage.CreatedByUser.Id != userId)
            {
                throw new UnauthorizedUserException();
            }
        }

        public async Task<Guid> GetCommentPageId(Guid commentId)
        {
            Comment comment = await this.repo.GetByIdAsync<Comment>(commentId);

            return comment?.RankPageId ?? throw new NotFoundException();
        }
    }
}
