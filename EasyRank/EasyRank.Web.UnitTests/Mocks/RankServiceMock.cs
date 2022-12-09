// -----------------------------------------------------------------------
// <copyright file="RankServiceMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using Moq;

namespace EasyRank.Web.UnitTests.Mocks
{
    public class RankServiceMock
    {
        public static Mock<IRankService> MockRankService()
        {
            Mock<IRankService> rankService = new Mock<IRankService>();

            rankService.Setup(rs => rs.GetAllRankingsAsync(
                It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new AllRanksServiceModel());

            rankService.Setup(rs => rs.GetRankPageByGuidAsync(
                    It.IsAny<Guid>()))
                .ReturnsAsync(new RankPageServiceModel());

            rankService.Setup(rs => rs.GetExtendedRankPageByGuidAsync(
                    It.IsAny<Guid>()))
                .ReturnsAsync(new RankPageServiceModelExtended());

            return rankService;
        }
    }
}
