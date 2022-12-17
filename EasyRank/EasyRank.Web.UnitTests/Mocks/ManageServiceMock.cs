// -----------------------------------------------------------------------
// <copyright file="ManageServiceMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models.Email;
using EasyRank.Services.Models.User;

using Microsoft.AspNetCore.Identity;

using Moq;

namespace EasyRank.Web.UnitTests.Mocks
{
    public class ManageServiceMock
    {
        public static Mock<IManageService> MockManageService(params EasyRankUser[] userList)
        {
            Mock<IManageService> manageServiceMock = new Mock<IManageService>();

            manageServiceMock.Setup(ms => ms.GetUserInfoAsync(
                    It.IsAny<Guid>()))!
                .ReturnsAsync((Guid id) =>
                {
                    EasyRankUser user = userList.First(u => u.Id == id);

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

            manageServiceMock.Setup(ms => ms.CheckPasswordAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((Guid id, string pass) => pass != "FailCheck");

            manageServiceMock.Setup(ms => ms.IsEmailTakenAsync(
                    It.IsAny<string>()))!
                .ReturnsAsync((string email) 
                    => userList.FirstOrDefault(u => u.Email == email) != null);

            manageServiceMock.Setup(ms => ms.ChangeEmailAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((Guid id, string email, string code) => email == "FailCheck"
                    ? IdentityResult.Failed()
                    : IdentityResult.Success);

            manageServiceMock.Setup(ms => ms.ConfirmEmailAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>()))!
                .ReturnsAsync(IdentityResult.Success);

            manageServiceMock.Setup(ms => ms.ChangePasswordAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))!
                .ReturnsAsync((Guid id, string oldPass, string newPass) => newPass == "FailCheck"
                    ? IdentityResult.Failed(new IdentityError
                    {
                        Code = "123",
                        Description = "error",
                    }) 
                    : IdentityResult.Success);

            return manageServiceMock;
        }
    }
}
