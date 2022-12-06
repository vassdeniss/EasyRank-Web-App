// -----------------------------------------------------------------------
// <copyright file="AdminServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class AdminServiceTests : UnitTestBase
    {
        private IAdminService adminService;

        [SetUp]
        public void SetUp()
        {
            this.adminService = new AdminService(this.repo, this.mapper);
        }

        [Test]
        public async Task Test_GetAllRankings_ReturnsCorrectCount()
        {
            // Arrange: get rank pages count from database (where pages are not deleted)
            int databaseCount = await this.repo.AllReadonly<RankPage>(rp => !rp.IsDeleted)
                .CountAsync();

            // Act: call service method and get count
            ICollection<RankPageServiceModel> serviceModel = await this.adminService.GetAllRankingsAsync();
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }

        [Test]
        public async Task Test_GetAllEntries_ReturnsCorrectCount()
        {
            // Arrange: get rank entries count from database (where entries are not deleted)
            int databaseCount = await this.repo.AllReadonly<RankEntry>(
                    re => !re.IsDeleted)
                .CountAsync();

            // Act: call service method and get count
            ICollection<RankEntryServiceModelExtended> serviceModel = await this.adminService.GetAllEntriesAsync();
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }

        [Test]
        public async Task Test_GetAllComments_ReturnsCorrectCount()
        {
            // Arrange: get comments count from database (where comments are not deleted)
            int databaseCount = await this.repo.AllReadonly<Comment>(c => !c.IsDeleted)
                .CountAsync();

            // Act: call service method and get count
            ICollection<CommentServiceModelExtended> serviceModel = await this.adminService.GetAllCommentsAsync();
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }
    }
}
