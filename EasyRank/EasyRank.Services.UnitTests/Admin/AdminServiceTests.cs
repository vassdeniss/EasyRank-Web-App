// -----------------------------------------------------------------------
// <copyright file="AdminServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts.Admin;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;
using EasyRank.Services.Models.Admin;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests.Admin
{
    [TestFixture]
    public class AdminServiceTests : UnitTestBase
    {
        private IAdminService adminService;

        [SetUp]
        public void SetUp()
        {
            this.adminService = new AdminService(this.repo, this.mapper, this.userManager.Object);
        }

        [Test]
        public async Task Test_GetAllRankings_ReturnsCorrectCount()
        {
            // Arrange: get rank pages count from database (where pages are not deleted)
            int databaseCount = await this.repo.AllReadonly<RankPage>(rp => !rp.IsDeleted)
                .CountAsync();

            // Act: call service method and get count
            IEnumerable<RankPageServiceModel> serviceModel = await this.adminService.GetAllRankingsAsync();
            int serviceCount = serviceModel.Count();

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
            IEnumerable<RankEntryServiceModelExtended> serviceModel = await this.adminService.GetAllEntriesAsync();
            int serviceCount = serviceModel.Count();

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
            IEnumerable<CommentServiceModelExtended> serviceModel = await this.adminService.GetAllCommentsAsync();
            int serviceCount = serviceModel.Count();

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }

        [Test]
        public async Task Test_GetAllUsers_ReturnsCorrectCount()
        {
            // Arrange: get users count from database (not forgotten)
            int databaseCount = await this.repo.AllReadonly<EasyRankUser>()
                .Where(u => !u.IsForgotten)
                .CountAsync();

            // Act: call service method and get count
            IEnumerable<EasyRankUserServiceModel> serviceModel = await this.adminService.GetAllUsersAsync();
            int serviceCount = serviceModel.Count();

            // Assert: service count equals database count
            Assert.That(serviceCount, Is.EqualTo(databaseCount));
        }

        [Test]
        public void Test_DeleteUser_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.adminService.DeleteUserAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_DeleteUser_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async() => await this.adminService.DeleteUserAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteUser_ValidUserId_RemovesSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Act: call service method
            await this.adminService.DeleteUserAsync(guestUser.Id);

            // Assert: user ranks are deleted
            List<RankPage> userPages = await this.repo.AllReadonly<RankPage>(
                    rp => rp.CreatedByUserId == guestUser.Id && !rp.IsDeleted)
                .Include(rp => rp.Entries)
                .Include(rp => rp.Comments)
                .ToListAsync();

            Assert.That(userPages.Count, Is.Zero);

            // Assert: user rank entries, comments are deleted
            foreach (RankPage page in userPages)
            {
                Assert.That(page.Entries.Count, Is.Zero);
                Assert.That(page.Comments.Count, Is.Zero);
            }

            // Assert: user comments are deleted
            List<Comment> userComments = await this.repo.AllReadonly<Comment>(
                    c => c.CreatedByUserId == guestUser.Id && !c.IsDeleted)
                .ToListAsync();

            Assert.That(userComments.Count, Is.Zero);

            // Assert: user is deleted
            Assert.That(guestUser.IsForgotten, Is.True);
        }

        [Test]
        public void Test_MakeUserAdmin_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.adminService.MakeUserAdminAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_MakeUserAdmin_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async() => await this.adminService.MakeUserAdminAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_MakeUserAdmin_CorrectlyAddsAdmin()
        {
            // Arrange: get disliked user from test db
            EasyRankUser dislikedUser = this.testDb.DislikedUser;
            string usernameBefore = dislikedUser.UserName;

            // Act: call service method
            await this.adminService.MakeUserAdminAsync(dislikedUser.Id);

            // Assert: user is made admin
            Assert.That(dislikedUser.UserName, Is.EqualTo($"{usernameBefore}IS-ADMIN"));
        }

        [Test]
        public void Test_RemoveAdminUser_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.adminService.RemoveAdminUserAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_RemoveAdminUser_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async() => await this.adminService.RemoveAdminUserAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_RemoveAdminUser_TriesToRemoveOwner_ThrowsForbiddenException()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act:

            // Assert: ForbiddenException is thrown with owner of site
            Assert.That(
                async() => await this.adminService.RemoveAdminUserAsync(denisUser.Id),
                Throws.Exception.TypeOf<ForbiddenException>());
        }

        [Test]
        public async Task Test_RemoveAdminUser_CorrectlyRemovesAdmin()
        {
            // Arrange: get liked user from test db
            EasyRankUser likedUser = this.testDb.LikedUser;
            string usernameBefore = likedUser.UserName;

            // Act: call service method
            await this.adminService.RemoveAdminUserAsync(likedUser.Id);

            // Assert: user is made admin
            Assert.That(likedUser.UserName, Is.EqualTo($"{usernameBefore}IS-NOT-ADMIN"));
        }
    }
}
