using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedImagePropertyToPageRedo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "RankPages",
                type: "varchar(2048)",
                unicode: false,
                maxLength: 2048,
                nullable: true,
                comment: "Gets or sets the image link for a rank entry.");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "RankPages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Gets or sets the alternative text if the image is broken.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), 0, "5510f606-b1b3-4dad-af86-ffda6eb612fb", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEOd/iRXht42DWtqn46EE0dwwR+WoUJh+vUTx4VNz+YFBzNsfSW+ODjKOMmhRtyeFmQ==", null, false, "2ecdd7ef-cc88-43a6-b365-1713edf56348", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("0b656c22-7356-40e7-abcf-86e4d7a008a0"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("45a35159-9e1f-4a91-860c-1ad3dd20f7f8"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("4caa6a17-6869-411c-af73-52f0130f23f0"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("5532aba4-c459-4057-86be-1effb970cac8"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("85235e21-2d1f-49ee-94e8-6b2535b93830"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("c0d7ac01-5fc4-4341-99cb-a025e671271a"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("cf45e749-1575-4d64-9c8b-3f7ab7ea30a2"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("d068d347-b187-432d-bc9b-c45b74ad570b"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("ee4c578b-bb76-4c57-81c0-a65e1a518aba"), new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("5f91e369-79c2-43ee-84cd-a1e7a2949167"), "Good stuff again", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("5532aba4-c459-4057-86be-1effb970cac8"), "Star Wars2" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("b28f2bf7-210f-4305-b9c2-30c8db0af661"), "Good stuff", null, "Picture of star wars", 10, new Guid("5532aba4-c459-4057-86be-1effb970cac8"), "Star Wars" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("5f91e369-79c2-43ee-84cd-a1e7a2949167"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("b28f2bf7-210f-4305-b9c2-30c8db0af661"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("0b656c22-7356-40e7-abcf-86e4d7a008a0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("45a35159-9e1f-4a91-860c-1ad3dd20f7f8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("4caa6a17-6869-411c-af73-52f0130f23f0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("85235e21-2d1f-49ee-94e8-6b2535b93830"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c0d7ac01-5fc4-4341-99cb-a025e671271a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("cf45e749-1575-4d64-9c8b-3f7ab7ea30a2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d068d347-b187-432d-bc9b-c45b74ad570b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ee4c578b-bb76-4c57-81c0-a65e1a518aba"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5532aba4-c459-4057-86be-1effb970cac8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ca047fd4-d52c-4ccb-bab0-50a6f7d1c0f9"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "RankPages");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "RankPages");

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
    }
}
