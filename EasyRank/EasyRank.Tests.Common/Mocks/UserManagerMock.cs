// -----------------------------------------------------------------------
// <copyright file="UserManagerMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Claims;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Web.UnitTests;

using Microsoft.AspNetCore.Identity;

using Moq;

namespace EasyRank.Tests.Common.Mocks
{
    public class UserManagerMock : IMockThis<UserManager<EasyRankUser>>
    {
        public UserManager<EasyRankUser> CreateMock(params EasyRankUser[] userList)
        {
            List<EasyRankUser> users = userList.ToList();

            Mock<UserManager<EasyRankUser>> userManager = new Mock<UserManager<EasyRankUser>>(
                Mock.Of<IUserStore<EasyRankUser>>(),
                null, null, null, null, null, null, null, null);

            userManager.Object.UserValidators.Add(new UserValidator<EasyRankUser>());
            userManager.Object.PasswordValidators.Add(new PasswordValidator<EasyRankUser>());

            userManager.Setup(um => um.GetUserAsync(
                    It.IsAny<ClaimsPrincipal>()))!
                .ReturnsAsync((ClaimsPrincipal principal) =>
                    users.FirstOrDefault(u => u.Id ==
                            Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier))));

            userManager.Setup(um => um.UpdateAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync(IdentityResult.Success);

            userManager.Setup(um => um.FindByNameAsync(
                    It.IsAny<string>()))!
                .ReturnsAsync((string username) =>
                    users.FirstOrDefault(u => u.UserName == username));

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
                .ReturnsAsync((string email) => users.FirstOrDefault(u => u.Email == email));

            userManager.Setup(um => um.GetUserIdAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync((EasyRankUser user) => user.Id.ToString());

            userManager.Setup(um => um.GenerateChangeEmailTokenAsync(
                    It.IsAny<EasyRankUser>(), It.IsAny<string>()))
                .ReturnsAsync("random-string");

            userManager.Setup(um => um.GenerateEmailConfirmationTokenAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync("random-string");

            userManager.Setup(um => um.GeneratePasswordResetTokenAsync(
                    It.IsAny<EasyRankUser>()))
                .ReturnsAsync("random-string");

            userManager.Setup(um => um.FindByIdAsync(
                    It.IsAny<string>()))!
                .ReturnsAsync((string id) =>
                    users.FirstOrDefault(u => u.Id == Guid.Parse(id)));

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

            userManager.Setup(um => um.AddToRoleAsync(
                    It.IsAny<EasyRankUser>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string role) =>
                {
                    user.UserName = $"{user.UserName}IS-ADMIN";
                    return IdentityResult.Success;
                });

            userManager.Setup(um => um.RemoveFromRoleAsync(
                    It.IsAny<EasyRankUser>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string role) =>
                {
                    user.UserName = $"{user.UserName}IS-NOT-ADMIN";
                    return IdentityResult.Success;
                });

            userManager.Setup(um => um.CreateAsync(
                    It.IsAny<EasyRankUser>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((EasyRankUser user, string password) =>
                {
                    PasswordHasher<EasyRankUser> hasher = new PasswordHasher<EasyRankUser>();
                    string hash = hasher.HashPassword(user, password);

                    user.PasswordHash = hash;
                    users.Add(user);

                    return IdentityResult.Success;
                });

            userManager.SetupGet(um => um.Users)
                .Returns(users.AsQueryable());

            return userManager.Object;
        }
    }
}
