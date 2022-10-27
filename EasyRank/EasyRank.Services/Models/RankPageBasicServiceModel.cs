// -----------------------------------------------------------------------
// <copyright file="RankPageServiceModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Models
{
    public class RankPageBasicServiceModel
    {
        public Guid Id { get; set; }

        public string RankingTitle { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public int LikeCount { get; set; }

        public string CreatedByUserName { get; set; } = null!;

        public int CommentCount { get; set; }
    }
}
