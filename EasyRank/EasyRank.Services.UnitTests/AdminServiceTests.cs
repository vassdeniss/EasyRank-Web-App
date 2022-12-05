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
            // Arrange: get 'RankPage' count from database (where pages are not deleted)
            int databaseCount = await this.repo.AllReadonly<RankPage>()
                .Where(rp => !rp.IsDeleted)
                .CountAsync();

            // Act: call service method and get ranks count (take only first page)
            ICollection<RankPageServiceModel> serviceModel = await this.adminService.GetAllRankingsAsync();
            int serviceCount = serviceModel.Count;

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }
    }
}
