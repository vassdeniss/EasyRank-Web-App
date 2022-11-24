using AutoMapper;

using EasyRank.Services.Profiles;

namespace EasyRank.Services.UnitTests.Mocks
{
    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                MapperConfiguration mapperConfiguration = 
                    new MapperConfiguration(config =>
                    {
                        config.AddProfile<ServiceModelMappingProfile>();
                    });

                return new Mapper(mapperConfiguration);
            }
        }
    }
}
