// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Data;
using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services;
using EasyRank.Services.Contracts;
using EasyRank.Services.Contracts.Admin;
using EasyRank.Web.Controllers;
using EasyRank.Web.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// For development
//string connectionString = builder.Configuration.GetConnectionString("DockerConnection");
// For production
// string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// For docker orchestrator
//string connectionString = builder.Configuration.GetConnectionString("ProductionConnection");
builder.Services.AddDbContext<EasyRankDbContext>(options =>
    options.UseSqlServer("Server=db;Database=EasyRank;User Id=sa;Password=VerySecure!DbPassword123;Integrated Security=true;TrustServerCertificate=Yes;Trusted_Connection=false"));

//builder.Configuration.AddJsonFile("secrets.json");

builder.Services.AddAutoMapper(typeof(IRankService).Assembly, typeof(RankController).Assembly);

builder.Services.AddDefaultIdentity<EasyRankUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Account:RequireConfirmedAccount");

    options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Account:RequireUniqueEmail");

    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Account:RequiredLength");
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Account:RequireNonAlphanumeric");
    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Account:RequireDigit");
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Account:RequireUppercase");
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Account:RequireLowercase");
})
    .AddRoles<EasyRankRole>()
    .AddEntityFrameworkStores<EasyRankDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Home/Error401";
    options.LoginPath = "/Account/Login";
});

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddScoped<IRepository, EasyRankRepository>();
builder.Services.AddScoped<IRankService, RankService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IEntryService, EntryService>();
builder.Services.AddScoped<IEmailSender>(_ =>
    new SendGridEmailSender(builder.Configuration.GetValue<string>("SendGrid:ApiKey")));
builder.Services.AddScoped<IManageService, ManageService>();
builder.Services.AddScoped<IAdminService, AdminService>();

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

if ()

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdmin();

app.UseStatusCodePagesWithRedirects("/Home/Error{0}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "Account Management",
        pattern: "/Account/Manage/{action}/{id?}",
        defaults: new { controller = "Manage", action = "Index" });

    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EasyRankDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
