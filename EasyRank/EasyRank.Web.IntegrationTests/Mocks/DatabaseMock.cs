﻿// -----------------------------------------------------------------------
// <copyright file="DatabaseMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

using EasyRank.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Web.IntegrationTests.Mocks
{
    public static class DatabaseMock
    {
        public static EasyRankDbContext Instance
        {
            get
            {
                DbContextOptionsBuilder<EasyRankDbContext> optionsBuilder = 
                        new DbContextOptionsBuilder<EasyRankDbContext>();

                optionsBuilder.UseInMemoryDatabase($"EasyRank-TestDb-{DateTime.Now.Ticks}");

                return new EasyRankDbContext(optionsBuilder.Options, false);
            }
        }
    }
}