// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Data;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services;
using EasyRank.Services.Contracts;
using EasyRank.Web.Controllers;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DockerConnection");
builder.Services.AddDbContext<EasyRankDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(typeof(IRankService).Assembly, typeof(RankController).Assembly);

builder.Services.AddDefaultIdentity<EasyRankUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

    options.User.RequireUniqueEmail = true;

    options.Password.RequiredLength = 7;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
    .AddEntityFrameworkStores<EasyRankDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository, EasyRankRepository>();
builder.Services.AddScoped<IRankService, RankService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
