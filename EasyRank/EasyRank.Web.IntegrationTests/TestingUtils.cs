// -----------------------------------------------------------------------
// <copyright file="TestingUtils.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace EasyRank.Web.IntegrationTests
{
    public class TestingUtils
    {
        public static ControllerContext CreateControllerContext(
            EasyRankUser user,
            string fileName = "",
            bool shouldBeAdmin = false)
        {
            // Create user
            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
            };

            if (shouldBeAdmin)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Create test file
            IFormCollection? form = null;

            if (string.IsNullOrEmpty(fileName))
            {
                return new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = claimsPrincipal,
                    }
                };
            }

            byte[] bytes = Encoding.UTF8.GetBytes("Dummy File");
            IFormFile file = new FormFile(
                new MemoryStream(bytes),
                0,
                bytes.Length,
                "Data",
                fileName);

            // Create form collections
            Dictionary<string, StringValues> emptyFieldsDictionary = new Dictionary<string, StringValues>();
            FormFileCollection formFiles = new FormFileCollection
            {
                file,
            };

            // Create form
            form = new FormCollection(emptyFieldsDictionary, formFiles);

            // Create HTTP context
            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal,
                    Request =
                    {
                        Form = form,
                    }
                }
            };
        }
    }
}
