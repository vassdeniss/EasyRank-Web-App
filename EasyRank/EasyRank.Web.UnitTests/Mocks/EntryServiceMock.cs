// -----------------------------------------------------------------------
// <copyright file="EntryServiceMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models.Entry;

using Moq;

namespace EasyRank.Web.UnitTests.Mocks
{
    public class EntryServiceMock
    {
        public static Mock<IEntryService> MockEntryService()
        {
            Mock<IEntryService> entryService = new Mock<IEntryService>();

            entryService.Setup(re => re.GetRankEntryByGuidAsync(
                It.IsAny<Guid>()))
                .ReturnsAsync(new RankEntryServiceModel());

            return entryService;
        }
    }
}
