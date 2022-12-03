using System;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyRank.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<EasyRankUser> userManager = services.GetRequiredService<UserManager<EasyRankUser>>();
            RoleManager<EasyRankRole> roleManager = services.GetRequiredService<RoleManager<EasyRankRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync("Administrator"))
                {
                    return;
                }

                EasyRankRole role = new EasyRankRole("Administrator");
                await roleManager.CreateAsync(role);

                EasyRankUser admin = await userManager.FindByEmailAsync("vassdeniss@gmail.com");
                await userManager.AddToRoleAsync(admin, role.Name);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
