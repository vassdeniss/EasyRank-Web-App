// -----------------------------------------------------------------------
// <copyright file="ClaimsExtensions.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Security.Claims;

namespace EasyRank.Web.Extensions
{
    /// <summary>
    /// The class for different claim extensions.
    /// </summary>
    public static class ClaimsExtensions
    {
        /// <summary>
        /// An extension 'Id' for getting the Guid of the user.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <returns>The Guid of the user.</returns>
        public static Guid Id(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        /// <summary>
        /// An extension 'IsAdmin' for getting a flag if the user is an admin.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <returns>Flag indicating if the user is an admin.</returns>
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole("Administrator");
        }
    }
}
