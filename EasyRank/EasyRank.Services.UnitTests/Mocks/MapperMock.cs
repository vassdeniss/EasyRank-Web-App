// -----------------------------------------------------------------------
// <copyright file="MapperMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

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
