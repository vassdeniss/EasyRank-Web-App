// -----------------------------------------------------------------------
// <copyright file="ApplicationBuilderExtensions.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyRank.Web.Extensions
{
    /// <summary>
    /// Class used for adding additional logic to the app builder.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Used for getting a user and making him an administrator.
        /// </summary>
        /// <param name="app">The current app.</param>
        /// <returns>The same app with the executed logic.</returns>
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<EasyRankUser> userManager = services.GetRequiredService<UserManager<EasyRankUser>>();
            RoleManager<EasyRankRole> roleManager = services.GetRequiredService<RoleManager<EasyRankRole>>();

            Task.Run(async () =>
            {
                if (!await roleManager.RoleExistsAsync("Administrator"))
                {
                    EasyRankRole role = new EasyRankRole("Administrator");
                    await roleManager.CreateAsync(role);
                }

                EasyRankUser admin = await userManager.FindByEmailAsync("vassdeniss@gmail.com");
                await userManager.AddToRoleAsync(admin, "Administrator");
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
