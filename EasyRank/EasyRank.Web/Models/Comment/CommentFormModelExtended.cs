// -----------------------------------------------------------------------
// <copyright file="CommentFormModelExtended.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Web.Models.Comment
{
    /// <summary>
    /// Extended model of the comment holding more needed properties.
    /// </summary>
    public class CommentFormModelExtended : CommentFormModel
    {
        /// <summary>
        /// Gets or sets the comment GUID.
        /// </summary>
        public Guid Id { get; set; }
    }
}
