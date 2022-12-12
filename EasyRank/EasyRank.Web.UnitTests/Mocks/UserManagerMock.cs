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

namespace EasyRank.Web.UnitTests.Mocks
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

            return userManager;
        }
    }
}
