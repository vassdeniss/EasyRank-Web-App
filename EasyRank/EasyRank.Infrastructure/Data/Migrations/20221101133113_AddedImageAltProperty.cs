using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedImageAltProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "RankEntries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Gets or sets the alternative text if the image is broken.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), 0, "8fd3eb65-84a3-405f-86f9-02e71753f9cc", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEMTZCwIJP63KJqCoU3QhIF7fgTn/FPaU55fAwmvtEqyDYaraD16pv2F1ptdl1RAUDw==", null, false, "4582c410-90dc-4ca8-8071-e863f08dde23", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("05df0840-413c-4a48-99a8-958d889d5b4d"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("1b592efb-68d6-4012-985e-2644da86f2ae"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("370321b8-e49e-4438-bdf2-448683c56ccd"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("3ab60b78-381e-414d-a1e5-41a263c6abd2"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("4589435d-fd7d-45ab-b76e-34b872d36088"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("55b54646-d26f-4bdc-8f9a-fa15090f5152"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" },
                    { new Guid("7792eeef-d88b-4021-9d3d-835ee80cc2ad"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("a00d1a3e-ea39-48e8-bcbf-558d655d4934"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("a3684dd3-2047-43f8-a8d3-bec47c483652"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("a98526a4-5bbb-4d23-992a-c46bd8f549bb"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("e3cee434-c52a-448e-b0ca-fca8e7d6671e"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("f5cb5fd5-ca23-4244-a7fb-8095aa691617"), new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("5e7db3fd-e17a-412f-b408-af3f1a4307cf"), "Good stuff again", null, "Picture of star wars", 9, new Guid("55b54646-d26f-4bdc-8f9a-fa15090f5152"), "Star Wars2" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("6de457e5-3b57-42ce-a8e4-f3eb9c1d781c"), "Good stuff", null, "Picture of star wars", 10, new Guid("55b54646-d26f-4bdc-8f9a-fa15090f5152"), "Star Wars" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("5e7db3fd-e17a-412f-b408-af3f1a4307cf"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("6de457e5-3b57-42ce-a8e4-f3eb9c1d781c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("05df0840-413c-4a48-99a8-958d889d5b4d"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1b592efb-68d6-4012-985e-2644da86f2ae"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("370321b8-e49e-4438-bdf2-448683c56ccd"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3ab60b78-381e-414d-a1e5-41a263c6abd2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("4589435d-fd7d-45ab-b76e-34b872d36088"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7792eeef-d88b-4021-9d3d-835ee80cc2ad"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a00d1a3e-ea39-48e8-bcbf-558d655d4934"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a3684dd3-2047-43f8-a8d3-bec47c483652"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a98526a4-5bbb-4d23-992a-c46bd8f549bb"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("e3cee434-c52a-448e-b0ca-fca8e7d6671e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f5cb5fd5-ca23-4244-a7fb-8095aa691617"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("55b54646-d26f-4bdc-8f9a-fa15090f5152"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e2c90f1e-7807-4fc7-8ed1-3fe36bf6f535"));

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "RankEntries");

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
    }
}
