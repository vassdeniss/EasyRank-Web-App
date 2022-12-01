// -----------------------------------------------------------------------
// <copyright file="UserManagerMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Claims;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Identity;
using Moq;

namespace EasyRank.Services.UnitTests.Mocks
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
                .ReturnsAsync((EasyRankUser rankUser, string newUsername) =>
                {
                    rankUser.UserName = newUsername;
                    return IdentityResult.Success;
                });

            return userManager;
        }
    }
}
