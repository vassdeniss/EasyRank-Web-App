// -----------------------------------------------------------------------
// <copyright file="CommentViewModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

using EasyRank.Web.Models.Rank;

namespace EasyRank.Web.Areas.Admin.Models.Comment
{
    /// <summary>
    /// Extended model of the comment holding more needed properties.
    /// </summary>
    public class CommentViewModelExtended : CommentViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the rank page.
        /// </summary>
        public Guid RankPageId { get; set; }
    }
}
