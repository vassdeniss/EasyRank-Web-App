// -----------------------------------------------------------------------
// <copyright file="UserManagerMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;

using Moq;

namespace EasyRank.Web.IntegrationTests.Mocks
{
    public class UserManagerMock
    {
        public static Mock<UserManager<EasyRankUser>> MockUserManager(List<EasyRankUser> userList)
        {
            Mock<UserManager<EasyRankUser>> userManager = new Mock<UserManager<EasyRankUser>>(
                Mock.Of<IUserStore<EasyRankUser>>(),
                null, null, null, null, null, null, null, null);

            userManager.Object.UserValidators.Add(new UserValidator<EasyRankUser>());
            userManager.Object.PasswordValidators.Add(new PasswordValidator<EasyRankUser>());

            userManager.Setup(um => um.GetUserAsync(
                    It.IsAny<ClaimsPrincipal>()))!
                .ReturnsAsync((ClaimsPrincipal principal) =>
                    userList.FirstOrDefault(u => u.Id ==
                            Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier))));

            userManager.Setup(um => um.UpdateAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync(IdentityResult.Success);

            userManager.Setup(um => um.FindByNameAsync(
                    It.IsAny<string>()))!
                .ReturnsAsync((string username) =>
                    userList.FirstOrDefault(u => u.UserName == username));

            userManager.Setup(um => um.SetUserNameAsync(
                    It.IsAny<EasyRankUser>(), It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string newUsername) =>
                {
                    user.UserName = newUsername;
                    return IdentityResult.Success;
                });

            userManager.Setup(um => um.CheckPasswordAsync(
                    It.IsAny<EasyRankUser>(), It.IsAny<string>()))
                .ReturnsAsync((EasyRankUser user, string givenPassword) =>
                {
                    PasswordHasher<EasyRankUser> hasher = new PasswordHasher<EasyRankUser>();

                    PasswordVerificationResult result = 
                        hasher.VerifyHashedPassword(user, user.PasswordHash, givenPassword);

                    return result == PasswordVerificationResult.Success;
                });

            userManager.Setup(um => um.DeleteAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync((EasyRankUser user) =>
                {
                    user.UserName = $"DELETED{user.UserName}";

                    return IdentityResult.Success;
                });

            userManager.Setup(um => um.IsEmailConfirmedAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync((EasyRankUser user) => user.EmailConfirmed);

            userManager.Setup(um => um.GetEmailAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync((EasyRankUser user) => user.Email);

            userManager.Setup(um => um.FindByEmailAsync(
                    It.IsAny<string>()))!
                .ReturnsAsync((string email) => userList.FirstOrDefault(u => u.Email == email));

            userManager.Setup(um => um.GetUserIdAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync((EasyRankUser user) => user.Id.ToString());

            userManager.Setup(um => um.GenerateChangeEmailTokenAsync(
                    It.IsAny<EasyRankUser>(), It.IsAny<string>()))
                .ReturnsAsync("random-string");

            userManager.Setup(um => um.GenerateEmailConfirmationTokenAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync("random-string");

            userManager.Setup(um => um.FindByIdAsync(
                    It.IsAny<string>()))!
                .ReturnsAsync((string id) =>
                    userList.FirstOrDefault(u => u.Id == Guid.Parse(id)));

            userManager.Setup(um => um.ChangeEmailAsync(
                    It.IsAny<EasyRankUser>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string email, string token) =>
                {
                    user.Email = email;
                    return IdentityResult.Success;
                });

            userManager.Setup(um => um.ConfirmEmailAsync(
                    It.IsAny<EasyRankUser>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string token) =>
                {
                    user.EmailConfirmed = true;
                    return IdentityResult.Success;
                });

            userManager.Setup(um => um.ChangePasswordAsync(
                    It.IsAny<EasyRankUser>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string oldPass, string newPass) =>
                {
                    PasswordHasher<EasyRankUser> hasher = new PasswordHasher<EasyRankUser>();
                    user.PasswordHash = hasher.HashPassword(user, newPass);
                    return IdentityResult.Success;
                });

            return userManager;
        }
    }
}
