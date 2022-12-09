using System;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using Moq;

namespace EasyRank.Web.IntegrationTests.Mocks
{
    public class EntryServiceMock
    {
        public static Mock<IEntryService> MockEntryService()
        {
            Mock<IEntryService> entryService = new Mock<IEntryService>();

            entryService.Setup(re => re.GetRankEntryByGuidAsync(
                It.IsAny<Guid>()))
                .ReturnsAsync(new RankEntryServiceModel());

            //rankService.Setup(rs => rs.GetRankPageByGuidAsync(
            //        It.IsAny<Guid>()))
            //    .ReturnsAsync(new RankPageServiceModel());

            //rankService.Setup(rs => rs.GetExtendedRankPageByGuidAsync(
            //        It.IsAny<Guid>()))
            //    .ReturnsAsync(new RankPageServiceModelExtended());

            return entryService;
        }
    }
}
