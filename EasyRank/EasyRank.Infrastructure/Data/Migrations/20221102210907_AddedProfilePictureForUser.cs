using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedProfilePictureForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                comment: "Gets or sets the profile picture of the user.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), 0, "db389528-89c7-4181-b390-5f06e128e532", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEBhDOovxdmhiappCCl6dD28rrNtkCsZqfld1tT/7Tw4GQGVXb1KPJLtQ4yN8oeEvQQ==", null, false, null, "06d18279-45e8-4df3-8aae-c886aad06195", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("1532d654-3b5c-4bfd-8a06-f34597b8e6a1"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("210e36ad-7662-4258-8d80-c71b7019d227"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("36fb4c65-147c-4c5e-b2e6-0ed68befb975"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("5c0883c7-0ff2-47a5-86fb-308adcb7ace8"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("9589b1e9-e2dd-4a2a-ad49-3c7764591a55"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("a4c602df-69a2-4ce3-bdfb-c3d28b7da3b4"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("b5084cd7-23ef-4207-96a1-ab77b3f153c0"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("d70b46f8-8e0c-4a74-83e4-aac82f8f0b9b"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("ba984c37-f963-49cc-bb90-037143655be0"), "Good stuff again", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"), "Star Wars2" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("dacb54fa-952f-4997-b536-e51a1a134928"), "Good stuff", null, "Picture of star wars", 10, new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"), "Star Wars" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("ba984c37-f963-49cc-bb90-037143655be0"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("dacb54fa-952f-4997-b536-e51a1a134928"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1532d654-3b5c-4bfd-8a06-f34597b8e6a1"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("210e36ad-7662-4258-8d80-c71b7019d227"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("36fb4c65-147c-4c5e-b2e6-0ed68befb975"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5c0883c7-0ff2-47a5-86fb-308adcb7ace8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9589b1e9-e2dd-4a2a-ad49-3c7764591a55"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a4c602df-69a2-4ce3-bdfb-c3d28b7da3b4"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("b5084cd7-23ef-4207-96a1-ab77b3f153c0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d70b46f8-8e0c-4a74-83e4-aac82f8f0b9b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("caad7053-04af-4264-be81-c8980f19f5b7"));

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

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
    }
}
