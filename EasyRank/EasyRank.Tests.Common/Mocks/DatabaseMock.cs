// -----------------------------------------------------------------------
// <copyright file="DatabaseMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Data;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Web.UnitTests;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Tests.Common.Mocks
{
    public class DatabaseMock : IMockThis<EasyRankDbContext>
    {
        public EasyRankDbContext CreateMock(params EasyRankUser[] userList)
        {
            DbContextOptionsBuilder<EasyRankDbContext> optionsBuilder
                = new DbContextOptionsBuilder<EasyRankDbContext>();

            optionsBuilder.UseInMemoryDatabase($"EasyRank-TestDb-{DateTime.Now.Ticks}");

            return new EasyRankDbContext(optionsBuilder.Options, false);
        }
    }
}
