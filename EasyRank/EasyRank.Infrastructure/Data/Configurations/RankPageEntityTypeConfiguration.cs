// -----------------------------------------------------------------------
// <copyright file="RankPageEntityTypeConfiguration.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyRank.Infrastructure.Data.Configurations
{
    /// <summary>
    /// The fluent API configuration for the 'RankPage' model.
    /// </summary>
    public class RankPageEntityTypeConfiguration : IEntityTypeConfiguration<RankPage>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<RankPage> builder)
        {
            builder.HasOne(p => p.CreatedByUser)
                .WithMany(u => u.UserRankings)
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
