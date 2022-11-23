// -----------------------------------------------------------------------
// <copyright file="EasyRankUserRankPageEntityTypeConfiguration.cs" company="Denis Vasilev">
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
    /// The fluent API configuration for the 'EasyRankUserRankPage' model.
    /// </summary>
    public class EasyRankUserRankPageEntityTypeConfiguration : IEntityTypeConfiguration<EasyRankUserRankPage>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<EasyRankUserRankPage> builder)
        {
            builder.HasKey(erurp => new
            {
                erurp.EasyRankUserId,
                erurp.RankPageId,
            });
        }
    }
}
