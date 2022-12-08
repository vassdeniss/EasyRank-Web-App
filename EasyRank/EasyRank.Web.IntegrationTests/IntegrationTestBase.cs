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
using EasyRank.Web.IntegrationTests.Mocks;

using Microsoft.AspNetCore.Identity;

using Moq;

using NUnit.Framework;

namespace EasyRank.Web.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected EasyRankTestDb testDb;
        private EasyRankDbContext dbContext;
        protected IMapper mapper;
        protected IRepository repo;
        protected Mock<UserManager<EasyRankUser>> userManager;
        //protected Mock<SignInManager<EasyRankUser>> signInManager;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbContext = DatabaseMock.Instance;
            this.testDb = new EasyRankTestDb(this.dbContext);
            this.mapper = MapperMock.Instance;
            this.repo = new RepoMock(this.dbContext);
            this.userManager = UserManagerMock.MockUserManager(new List<EasyRankUser>
            {
                this.testDb.GuestUser,
                this.testDb.DenisUser,
                this.testDb.UnconfirmedUser,
            });
            //this.signInManager = SignInManagerMock.MockSignInManager();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.dbContext.Dispose();
        }
    }
}
