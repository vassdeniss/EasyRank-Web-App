using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class MoreSeededPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("ef3bddd7-4e19-45ae-9278-68dbdddfbbfa"), 0, "3ba10c38-9450-4660-a7b1-b88f7d956131", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEJchyytSpONDohrt7uTX5u/hw6P9/X2DbcvI3AGR9oPlhF9Q8ybq8up1dUPuIrZUTg==", null, false, "3dfb568a-1e56-4cf0-a46d-11ecdccd6206", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("21176c38-c076-4cd1-a2af-8d96659c4ad8"), new Guid("ef3bddd7-4e19-45ae-9278-68dbdddfbbfa"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("5977e841-b151-43e2-91cb-4beedb8a66ea"), new Guid("ef3bddd7-4e19-45ae-9278-68dbdddfbbfa"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("ef6d2809-be30-46e0-b034-06b4ed78f2a6"), new Guid("ef3bddd7-4e19-45ae-9278-68dbdddfbbfa"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" },
                    { new Guid("f834d87c-5cd2-474d-8cea-4f8bb98f3d01"), new Guid("ef3bddd7-4e19-45ae-9278-68dbdddfbbfa"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("c59f4129-32c2-4e79-a1eb-5171a9d82765"), "Good stuff", null, 10, new Guid("ef6d2809-be30-46e0-b034-06b4ed78f2a6"), "Star Wars" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("d61b7add-2890-46df-b4c2-3281e64715d8"), "Good stuff again", null, 9, new Guid("ef6d2809-be30-46e0-b034-06b4ed78f2a6"), "Star Wars2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("c59f4129-32c2-4e79-a1eb-5171a9d82765"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("d61b7add-2890-46df-b4c2-3281e64715d8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("21176c38-c076-4cd1-a2af-8d96659c4ad8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5977e841-b151-43e2-91cb-4beedb8a66ea"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f834d87c-5cd2-474d-8cea-4f8bb98f3d01"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ef6d2809-be30-46e0-b034-06b4ed78f2a6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ef3bddd7-4e19-45ae-9278-68dbdddfbbfa"));

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
    }
}
