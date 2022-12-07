// -----------------------------------------------------------------------
// <copyright file="ActionUserViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Web.Areas.Admin.Models.User
{
    /// <summary>
    /// The view model used for performing actions on user.
    /// </summary>
    public class ActionUserViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = null!;
    }
}
