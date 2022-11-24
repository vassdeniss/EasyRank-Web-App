// -----------------------------------------------------------------------
// <copyright file="ServiceModelMappingProfile.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Linq;

using AutoMapper;

using EasyRank.Infrastructure.Models;
using EasyRank.Services.Models;

namespace EasyRank.Services.Profiles
{
    /// <summary>
    /// Class used for configuring database-to-service model AutoMapper profiles.
    /// </summary>
    public class ServiceModelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModelMappingProfile"/> class.
        /// Constructor for the controller mapping profile class.
        /// </summary>
        public ServiceModelMappingProfile()
        {
            this.CreateMap<RankPage, RankPageServiceModel>()
                .ForMember(
                    d => d.CreatedOn,
                    mo => mo.MapFrom(
                        s => s.CreatedOn.ToString("dd MMMM yyyy")))
                .ForMember(
                    d => d.LikeCount,
                    mo => mo.MapFrom(
                        s => s.LikedBy.Count(erurp => erurp.IsLiked)))
                .ForMember(
                    d => d.CreatedByUserName,
                    mo => mo.MapFrom(
                        s => s.CreatedByUser.UserName))
                .ForMember(
                    d => d.CommentCount,
                    mo => mo.MapFrom(
                        s => s.Comments.Count(c => c.IsDeleted == false)));

            this.CreateMap<Comment, CommentServiceModel>()
                .ForMember(
                    d => d.ProfilePicture,
                    mo => mo.MapFrom(
                        s => s.CreatedByUser.ProfilePicture))
                .ForMember(
                    d => d.Username,
                    mo => mo.MapFrom(
                        s => s.CreatedByUser.UserName))
                .ForMember(
                    d => d.PostedOn,
                    mo => mo.MapFrom(
                        s => s.CreatedOn.ToString("dd/MM/yyyy")));
        }
    }
}
