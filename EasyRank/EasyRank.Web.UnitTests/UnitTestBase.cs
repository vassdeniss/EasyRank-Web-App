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
using EasyRank.Tests.Common.Mocks;

using Microsoft.AspNetCore.Identity;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.UnitTests
{
    public class UnitTestBase
    {
        private EasyRankDbContext dbContext;
        protected EasyRankTestDb testDb;
        protected IMapper mapper;
        protected IRepository repo;
        protected Mock<UserManager<EasyRankUser>> userManager;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContext = DatabaseMock.MockDatabase();
            this.testDb = new EasyRankTestDb(this.dbContext);
            this.mapper = MapperMock.MockMapper();
            this.repo = new RepoMock(this.dbContext);
            this.userManager = UserManagerMock.MockUserManager(new List<EasyRankUser>
            {
                this.testDb.GuestUser,
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.dbContext.Dispose();
        }
    }
}
