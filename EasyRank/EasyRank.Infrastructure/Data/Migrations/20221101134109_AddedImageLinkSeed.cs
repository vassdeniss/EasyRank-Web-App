using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedImageLinkSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), 0, "b718b2ba-120d-4bc0-9213-f1b422625da5", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEDrgf7dNMKHsgkVMF/2ZaQy26ducnmJPHOrbgCzO0WGAx4EMsZ3HE4IcPpknvybXdA==", null, false, "ea910058-9d65-402e-b86d-62b5d22fa825", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("044e0df7-f74a-421e-a71b-4073ca80b365"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("1a1c10c8-8035-43c4-aee7-31ea476014dd"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("1fdaf6d5-5d68-4ef9-8d5e-6c651288384a"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("3daedf2f-cca3-4105-9c15-1a4fdfef8ff5"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("62b975dc-80cf-4ee2-844a-0e41216f38e2"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("66153e3c-04f9-4450-a39a-1a39c84598b3"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" },
                    { new Guid("6a2df9dd-5f0a-4826-b54a-f64db17c1cb6"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("774a2a59-bd63-4e47-8355-2afc2ac86b02"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("82184112-0f8f-4417-8da2-08c7d4bcd105"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("ce937df8-c219-4bc4-a545-74f9ee7a2cd1"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("d03cf1af-3b8c-4c47-96e9-8defea586acf"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("d6df7c8b-560f-48d1-ba95-c2c51c3b5504"), new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("35949544-f26d-477c-ba6e-d7cbb7888da8"), "Good stuff again", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("66153e3c-04f9-4450-a39a-1a39c84598b3"), "Star Wars2" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("9adfb0d3-7de2-4d36-8d07-255923eb5313"), "Good stuff", null, "Picture of star wars", 10, new Guid("66153e3c-04f9-4450-a39a-1a39c84598b3"), "Star Wars" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("35949544-f26d-477c-ba6e-d7cbb7888da8"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("9adfb0d3-7de2-4d36-8d07-255923eb5313"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("044e0df7-f74a-421e-a71b-4073ca80b365"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1a1c10c8-8035-43c4-aee7-31ea476014dd"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1fdaf6d5-5d68-4ef9-8d5e-6c651288384a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3daedf2f-cca3-4105-9c15-1a4fdfef8ff5"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("62b975dc-80cf-4ee2-844a-0e41216f38e2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("6a2df9dd-5f0a-4826-b54a-f64db17c1cb6"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("774a2a59-bd63-4e47-8355-2afc2ac86b02"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("82184112-0f8f-4417-8da2-08c7d4bcd105"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ce937df8-c219-4bc4-a545-74f9ee7a2cd1"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d03cf1af-3b8c-4c47-96e9-8defea586acf"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d6df7c8b-560f-48d1-ba95-c2c51c3b5504"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("66153e3c-04f9-4450-a39a-1a39c84598b3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("741a81c9-8166-4646-9cc6-51dd0dbb1ad3"));

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
    }
}
