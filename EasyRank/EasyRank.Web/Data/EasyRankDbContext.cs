// -----------------------------------------------------------------------
// <copyright file="EasyRankDbContext.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Web.Data
{
    /// <summary>
    /// The databse context for the app.
    /// </summary>
    public class EasyRankDbContext : IdentityDbContext
    {
        public EasyRankDbContext(DbContextOptions<EasyRankDbContext> options)
            : base(options)
        {
        }
    }
}
