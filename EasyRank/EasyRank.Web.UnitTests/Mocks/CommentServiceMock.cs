// -----------------------------------------------------------------------
// <copyright file="CommentServiceMock.cs" company="Denis Vasilev">
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
    public class CommentServiceMock
    {
        public static Mock<ICommentService> MockCommentService()
        {
            Mock<ICommentService> commentService = new Mock<ICommentService>();

            commentService.Setup(ce => ce.GetCommentByIdAsync(
                    It.IsAny<Guid>()))
                .ReturnsAsync(new CommentServiceModel());

            return commentService;
        }
    }
}
