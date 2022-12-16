// -----------------------------------------------------------------------
// <copyright file="ManageServiceMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using Moq;

namespace EasyRank.Web.UnitTests.Mocks
{
    public class ManageServiceMock
    {
        public static Mock<IManageService> MockManageService(List<EasyRankUser> usersList)
        {
            Mock<IManageService> manageServiceMock = new Mock<IManageService>();

            manageServiceMock.Setup(ms => ms.GetUserInfoAsync(
                    It.IsAny<Guid>()))!
                .ReturnsAsync((Guid id) =>
                {
                    EasyRankUser user = usersList.First(u => u.Id == id);

                    return new ManageServiceModel
                    {
                        Username = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    };
                });

            manageServiceMock.Setup(ms => ms.GetUserEmailAsync(
                    It.IsAny<Guid>()))!
                .ReturnsAsync(new EmailServiceModel());

            return manageServiceMock;
        }
    }
}
