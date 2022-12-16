// -----------------------------------------------------------------------
// <copyright file="TestingUtils.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

using EasyRank.Services.Exceptions;
using EasyRank.Web.Extensions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Primitives;

using Moq;

namespace EasyRank.Web.UnitTests
{
    public static class TestingUtils
    {
        public static T AddExceptionFeatureWithExceptionType<TException, T>(this T controller)
            where T : Controller 
            where TException : Exception, new()
        {
            controller.EnsureHttpContext();

            controller.ControllerContext.HttpContext.Features.Set<IExceptionHandlerFeature>(
                new ExceptionHandlerFeature
                {
                    Path = "/error/path",
                    Error = new TException(),
                });

            return controller;
        }

        public static T AddFormWithFile<T>(this T controller, string fileName)
            where T : Controller
        {
            controller.EnsureHttpContext();

            byte[] bytes = Encoding.UTF8.GetBytes("Dummy File");
            IFormFile file = new FormFile(
                new MemoryStream(bytes),
                0,
                bytes.Length,
                "Data",
                fileName);

            Dictionary<string, StringValues> emptyFieldsDictionary = new Dictionary<string, StringValues>();
            FormFileCollection formFiles = new FormFileCollection
            {
                file,
            };

            IFormCollection form = new FormCollection(emptyFieldsDictionary, formFiles);

            controller.HttpContext.Request.Form = form;

            return controller;
        }

        public static T AddRequestScheme<T>(this T controller)
            where T : Controller
        {
            controller.EnsureHttpContext();

            controller.HttpContext.Request.Scheme = "https";

            return controller;
        }

        public static T AddUrlHelper<T>(this T controller)
            where T : Controller
        {
            controller.EnsureHttpContext();

            Mock<IUrlHelper> urlHelperMock = new Mock<IUrlHelper>();
            urlHelperMock.Setup(helper => helper.Action(
                    It.IsAny<UrlActionContext>()))
                .Returns("callbackUrl");

            controller.Url = urlHelperMock.Object;

            return controller;
        }

        public static T AddTempData<T>(this T controller)
            where T : Controller
        {
            controller.EnsureHttpContext();

            ITempDataProvider tempDataProvider = Mock.Of<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            controller.TempData = tempData;

            return controller;
        }

        public static T AndMakeAdmin<T>(this T controller) 
            where T : Controller
        {
            controller.EnsureHttpContext();

            ClaimsIdentity identity = (ClaimsIdentity)controller.Request.HttpContext.User.Identity!;

            identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));

            return controller;
        }

        public static T ButThenAuthenticateUsing<T>(this T controller, Guid nameIdentifier, string username) 
            where T : Controller
        {
            controller.EnsureHttpContext();

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier.ToString()),
                new Claim(ClaimTypes.Name, username)
            }, "TestAuthentication"));

            controller.ControllerContext.HttpContext.User = principal;

            return controller;
        }

        public static T WithAnonymousUser<T>(this T controller) 
            where T : Controller
        {
            controller.EnsureHttpContext();

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity());

            controller.ControllerContext.HttpContext.User = principal;

            return controller;
        }

        private static T EnsureHttpContext<T>(this T controller) 
            where T : Controller
        {
            if (controller.ControllerContext == null)
            {
                controller.ControllerContext = new ControllerContext();
            }

            if (controller.ControllerContext.HttpContext == null)
            {
                controller.ControllerContext.HttpContext = new DefaultHttpContext();
            }

            return controller;
        }
    }
}
