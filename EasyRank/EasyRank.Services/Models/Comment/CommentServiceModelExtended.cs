// -----------------------------------------------------------------------
// <copyright file="CommentServiceModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Models.Comment
{
    /// <summary>
    /// Extended model of the comment holding more needed properties.
    /// </summary>
    public class CommentServiceModelExtended : CommentServiceModel
    {
        /// <summary>
        /// Gets or sets the ID of the rank page.
        /// </summary>
        public Guid RankPageId { get; set; }
    }
}
