using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class SeededPagesForLayoutTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), 0, "5417663e-d540-4d89-a457-96703ba36495", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEKcUwYma2XoKMkaVDKupWoOsSS4Qs8nwkyO2NwH4KnHg2NzzyDU4fw4miK3ngpxOzQ==", null, false, "cb1aa266-a833-476c-ad69-4d2a7b4ea4b7", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("0802c4e5-beb9-4289-8859-5288a37b9bf8"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("1c7ee704-e700-477e-ba17-061b7e18cc2f"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" },
                    { new Guid("2f4ab5dd-b2f6-449a-9f90-90465f12f010"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("40f1940a-51e5-4d83-9286-f6d420b7494e"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("5e37209a-a6aa-436a-80ec-d40e11ba864a"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("5f9651c4-e111-42d8-a54d-1d9ebdb7444b"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("654e7821-23db-4a6c-9a2c-f01190581d6f"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("733ced6f-803d-4033-9731-43d179850c3e"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("7b5d9191-168d-46bf-9a90-254d2d234326"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("a9e9988e-f9fc-4776-ba00-22c11ff43b21"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("a9ff9e3b-8292-47a8-87b6-ce3e9a16d890"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("de6e7cfd-fb4c-4713-9589-90dfdf54ed64"), new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("7802a300-7bb1-4d71-bc35-20ec4ed1b2a6"), "Good stuff", null, 10, new Guid("1c7ee704-e700-477e-ba17-061b7e18cc2f"), "Star Wars" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("f36b72b9-0003-4aa9-b9e0-0056a1381f95"), "Good stuff again", null, 9, new Guid("1c7ee704-e700-477e-ba17-061b7e18cc2f"), "Star Wars2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("7802a300-7bb1-4d71-bc35-20ec4ed1b2a6"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("f36b72b9-0003-4aa9-b9e0-0056a1381f95"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("0802c4e5-beb9-4289-8859-5288a37b9bf8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("2f4ab5dd-b2f6-449a-9f90-90465f12f010"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("40f1940a-51e5-4d83-9286-f6d420b7494e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5e37209a-a6aa-436a-80ec-d40e11ba864a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5f9651c4-e111-42d8-a54d-1d9ebdb7444b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("654e7821-23db-4a6c-9a2c-f01190581d6f"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("733ced6f-803d-4033-9731-43d179850c3e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7b5d9191-168d-46bf-9a90-254d2d234326"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a9e9988e-f9fc-4776-ba00-22c11ff43b21"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a9ff9e3b-8292-47a8-87b6-ce3e9a16d890"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("de6e7cfd-fb4c-4713-9589-90dfdf54ed64"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1c7ee704-e700-477e-ba17-061b7e18cc2f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ab3aea5-f9e7-4b01-85f7-ecc145c76337"));

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
    }
}
