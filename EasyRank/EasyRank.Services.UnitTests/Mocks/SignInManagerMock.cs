// -----------------------------------------------------------------------
// <copyright file="SignInManagerMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Moq;

namespace EasyRank.Services.UnitTests.Mocks
{
    public class SignInManagerMock
    {
        public static Mock<SignInManager<EasyRankUser>> MockSignInManager()
        {
            Mock<UserManager<EasyRankUser>> userManagerMock = new Mock<UserManager<EasyRankUser>>(
                Mock.Of<IUserStore<EasyRankUser>>(),
                null, null, null, null, null, null,null, null);

            Mock<SignInManager<EasyRankUser>> signInManager = new Mock<SignInManager<EasyRankUser>>(
                userManagerMock.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<EasyRankUser>>(),
                null, null, null, null);

            signInManager.Setup(sim => sim.RefreshSignInAsync(
                    It.IsAny<EasyRankUser>()))
                .Returns(Task.CompletedTask);

            signInManager.Setup(sim => sim.SignOutAsync())
                .Returns(Task.CompletedTask);

            return signInManager;
        }
    }
}
