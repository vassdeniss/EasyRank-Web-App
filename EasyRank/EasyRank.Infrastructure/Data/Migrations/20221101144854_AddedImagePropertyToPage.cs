using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedImagePropertyToPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), 0, "38a59001-7d4f-4ccf-a70f-3af66a7ac858", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAENukCzDdcI/ZYRo1ztr8byHlcX5Yzp4QbAEFFzNmd8ValEzIAN54QXuJ+1irklguZw==", null, false, "d01a9f5a-865f-48d1-8a74-ceee3b39fb6c", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("4990285f-9673-4336-84a9-782a9372b0d9"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("535c6a39-e0fe-478b-bf09-743fc88ed36d"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("5d77d43a-15f9-44e4-ba4b-6ae073edc40f"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 10 Best Movies of 2022" },
                    { new Guid("6c7b8e32-0035-4345-a139-93446543c188"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("ac447768-3fc2-49d1-bc33-45565575e934"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("add80f94-7933-4369-ab2d-988ed711cb7e"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("c1d5122f-ab64-47df-828c-d6d06c36e1ae"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("d7ba5d7f-91c7-4832-8834-b826e6fcd500"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" },
                    { new Guid("d8fa0a67-1b69-4c06-b209-c77162ac901b"), new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("0d83d6bc-2495-4467-b589-219787036cee"), "Good stuff", null, "Picture of star wars", 10, new Guid("5d77d43a-15f9-44e4-ba4b-6ae073edc40f"), "Star Wars" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("c0c11e89-76a8-4123-81a4-e380648afa0f"), "Good stuff again", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("5d77d43a-15f9-44e4-ba4b-6ae073edc40f"), "Star Wars2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("0d83d6bc-2495-4467-b589-219787036cee"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("c0c11e89-76a8-4123-81a4-e380648afa0f"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("4990285f-9673-4336-84a9-782a9372b0d9"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("535c6a39-e0fe-478b-bf09-743fc88ed36d"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("6c7b8e32-0035-4345-a139-93446543c188"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ac447768-3fc2-49d1-bc33-45565575e934"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("add80f94-7933-4369-ab2d-988ed711cb7e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c1d5122f-ab64-47df-828c-d6d06c36e1ae"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d7ba5d7f-91c7-4832-8834-b826e6fcd500"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d8fa0a67-1b69-4c06-b209-c77162ac901b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5d77d43a-15f9-44e4-ba4b-6ae073edc40f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bec7f22d-da9c-4b4d-9b61-dd1294189f90"));

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
    }
}
