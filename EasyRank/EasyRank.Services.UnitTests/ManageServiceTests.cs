// -----------------------------------------------------------------------
// <copyright file="ManageServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Claims;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class ManageServiceTests : UnitTestBase
    {
        private IManageService manageService;

        [SetUp]
        public void SetUp()
        {
            this.manageService = new ManageService(
                this.userManager.Object, 
                this.signInManager.Object,
                this.mapper);
        }

        [Test]
        public void Test_GetUserInfo_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GetUserInfoAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserInfo_ReturnsCorrectInfo()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            ManageServiceModel serviceModel = await this.manageService.GetUserInfoAsync(userPrincipal);

            // Assert: the guest user and service user are the same
            Assert.That(serviceModel.Username, Is.EqualTo(guestUser.UserName));
            Assert.That(serviceModel.FirstName, Is.EqualTo(guestUser.FirstName));
            Assert.That(serviceModel.LastName, Is.EqualTo(guestUser.LastName));
        }

        [Test]
        public void Test_DeleteProfilePicture_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.DeleteProfilePictureAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteProfilePicture_RemovesCorrectly()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;
            
            // Arrange: put an empty byte array on the guest user
            guestUser.ProfilePicture = Array.Empty<byte>();
            await this.repo.SaveChangesAsync();
            Assert.That(guestUser.ProfilePicture, Is.Not.Null);

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            await this.manageService.DeleteProfilePictureAsync(userPrincipal);

            // Assert: the guest user profile picture has been deleted
            Assert.That(guestUser.ProfilePicture, Is.Null);
        }

        private ClaimsPrincipal CreateClaimsPrincipal(EasyRankUser user)
        {
            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
