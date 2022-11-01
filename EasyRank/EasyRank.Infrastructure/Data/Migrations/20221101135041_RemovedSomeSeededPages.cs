using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class RemovedSomeSeededPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), 0, "b4b5f726-1e23-45b0-9947-bb7301b627de", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAECQDeOcF06z4iTDWkYckPiQbdG3HhIVXM7zcdskz1l76ng71H0X90IUDntoxxcKDEw==", null, false, "384dc55e-876d-44b5-9c13-f1998f50f55d", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("150b97c6-510a-423f-839e-888f7e8c2207"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("2d375900-ea0b-47eb-b3f1-1769bade5c91"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("3e65df35-befb-49d9-893b-a22873145b53"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("4e685493-5539-4de8-a075-24d7b87216db"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("5d4a4298-a82e-4793-8722-bde544b5fc1f"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("5d88bb3c-b3e2-4bc4-bfef-96ea71a82eb4"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("a07975aa-609f-4684-9458-60565608f4f9"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" },
                    { new Guid("ae6b03fe-e238-437f-86ed-ceca958df258"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("c54a2fa4-6ee5-466a-ae6c-cd063d8d61f8"), new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("48ee1523-304e-423d-b64a-d232fec8649f"), "Good stuff again", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("a07975aa-609f-4684-9458-60565608f4f9"), "Star Wars2" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("50813bc1-c4b1-4ab2-a822-32de6fe61dd5"), "Good stuff", null, "Picture of star wars", 10, new Guid("a07975aa-609f-4684-9458-60565608f4f9"), "Star Wars" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("48ee1523-304e-423d-b64a-d232fec8649f"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("50813bc1-c4b1-4ab2-a822-32de6fe61dd5"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("150b97c6-510a-423f-839e-888f7e8c2207"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("2d375900-ea0b-47eb-b3f1-1769bade5c91"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3e65df35-befb-49d9-893b-a22873145b53"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("4e685493-5539-4de8-a075-24d7b87216db"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5d4a4298-a82e-4793-8722-bde544b5fc1f"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5d88bb3c-b3e2-4bc4-bfef-96ea71a82eb4"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ae6b03fe-e238-437f-86ed-ceca958df258"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c54a2fa4-6ee5-466a-ae6c-cd063d8d61f8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a07975aa-609f-4684-9458-60565608f4f9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5cae3d99-bf3e-4994-b0e2-6e6df7dc8279"));

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
    }
}
