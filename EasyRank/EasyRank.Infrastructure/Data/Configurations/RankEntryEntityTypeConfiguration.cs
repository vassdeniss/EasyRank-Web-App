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
    /// The fluent API configuration for the 'RankEntity' model.
    /// </summary>
    public class RankEntryEntityTypeConfiguration : IEntityTypeConfiguration<RankEntry>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<RankEntry> builder)
        {
            builder.HasOne(e => e.RankPage)
                .WithMany(p => p.Entries)
                .HasForeignKey(c => c.RankPageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
