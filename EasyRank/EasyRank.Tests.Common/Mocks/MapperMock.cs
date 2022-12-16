// -----------------------------------------------------------------------
// <copyright file="MapperMock.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using AutoMapper;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Profiles;
using EasyRank.Web.Profiles;
using EasyRank.Web.UnitTests;

namespace EasyRank.Tests.Common.Mocks
{
    public class MapperMock : IMockThis<IMapper>
    {
        public IMapper CreateMock(params EasyRankUser[] userList)
        {
            MapperConfiguration config = new MapperConfiguration(conf =>
            {
                conf.AddProfile<ServiceModelMappingProfile>();
                conf.AddProfile<ViewModelMappingProfile>();
            });

            return new Mapper(config);
        }
    }
}
