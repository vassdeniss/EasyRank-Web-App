// -----------------------------------------------------------------------
// <copyright file="ControllerMappingProfile.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using AutoMapper;

using EasyRank.Services.Models;
using EasyRank.Web.Models;

namespace EasyRank.Web.Profiles
{
    /// <summary>
    /// Class used for configuring AutoMapper profiles.
    /// </summary>
    public class ControllerMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerMappingProfile"/> class.
        /// Constructor for the controller mapping profile class.
        /// </summary>
        public ControllerMappingProfile()
        {
            this.CreateMap<RankPageServiceModel, RankPageViewModel>();
            this.CreateMap<RankEntryServiceModel, RankEntryViewModel>();
            this.CreateMap<RankPageServiceModelExtended, RankPageViewModelExtended>();
        }
    }
}
