// -----------------------------------------------------------------------
// <copyright file="IntegrationTestBase.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

using AutoMapper;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Data;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Tests.Common;
using EasyRank.Tests.Common.Contracts;
using EasyRank.Tests.Common.Mocks;

using Microsoft.AspNetCore.Identity;

using Moq;

using NUnit.Framework;

using MapperMock = EasyRank.Web.UnitTests.Mocks.MapperMock;
using UserManagerMock = EasyRank.Web.UnitTests.Mocks.UserManagerMock;

namespace EasyRank.Web.UnitTests
{
    public class UnitTestBase
    {
        private EasyRankDbContext dbContext;
        protected EasyRankTestDb testDb;
        protected IMockThis<IMapper> mapper;
        protected IRepository repo;
        protected IMockThis<UserManager<EasyRankUser>> userManager;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            IMockThis<EasyRankDbContext> dbMock = new DatabaseMock();
            this.dbContext = dbMock.CreateMock();

            this.testDb = new EasyRankTestDb(this.dbContext);
            this.mapper = MapperMock.Instance;
            this.repo = new RepoMock(this.dbContext);
            this.userManager = new UserManagerMock();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.dbContext.Dispose();
        }
    }
}
