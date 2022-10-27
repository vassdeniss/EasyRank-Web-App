using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class MoreSeedeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("222f7fa1-b4c9-4e9c-8f7e-e41cbd713771"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2eddffeb-c4ff-4932-a404-8b4e06fc48d9"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9ff24061-b984-4be1-a40a-d9235017619c"), 0, "5cfc5275-059d-4c0f-95e1-d13e91636355", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAELt/8OSuBVNMvyzj/5Y/vhtmPPIG/6iHs0uPUMzsojv67pm3SAdL6AGafME0mXw46w==", null, false, "f5a49fe9-631a-4f8a-bc4b-74855287d8e9", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"), new Guid("9ff24061-b984-4be1-a40a-d9235017619c"), new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("c40570a9-7133-411a-aeaa-b8b288de2986"), new Guid("9ff24061-b984-4be1-a40a-d9235017619c"), new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("9c774152-d29d-41bf-bf68-dd970de2fa3d"), "Good stuff", null, 10, new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"), "Star Wars" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("9f78c718-c581-40cf-a1ae-f11ffe06bf31"), "Good stuff again", null, 9, new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"), "Star Wars2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("9c774152-d29d-41bf-bf68-dd970de2fa3d"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("9f78c718-c581-40cf-a1ae-f11ffe06bf31"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c40570a9-7133-411a-aeaa-b8b288de2986"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("add9e3e3-d51c-431c-ab91-2c6ce70db5da"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9ff24061-b984-4be1-a40a-d9235017619c"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2eddffeb-c4ff-4932-a404-8b4e06fc48d9"), 0, "a70f6550-becd-4267-8837-87491d1d50c3", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEE4Zf4/NJHyKQ0FABEZQGnQ8nITAoWWHfc77+8w34I6MhVTGAfswjDS/fBDrSrvr/g==", null, false, "a34ab16a-7625-4a9e-86ff-5ee0a0a08bdb", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("222f7fa1-b4c9-4e9c-8f7e-e41cbd713771"), new Guid("2eddffeb-c4ff-4932-a404-8b4e06fc48d9"), new DateTime(2022, 10, 27, 14, 28, 38, 234, DateTimeKind.Local).AddTicks(406), "Top 10 Best Movies of 2022" });
        }
    }
}
