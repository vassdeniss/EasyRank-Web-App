using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedImageRankEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("33d9b8ec-39b4-4393-8889-18ee8e95fa58"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5404577f-382a-4d6d-9cb1-75feeed31cb0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("8c45056d-d437-4f1f-952f-827ab6dbdf14"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("a339bec8-bf77-4ed9-a069-87da8ecf9fdd"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("ad81b331-8472-471e-838e-cc80f9da032c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("8da8f07e-df21-4aba-ae5e-7cc1bf91db6e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a6fc078c-a915-4c8b-9828-4dffb0c3a538"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("bcf477cc-6183-41cb-ae19-f564946a3fdc"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f40c9b3f-1948-4a4a-9f10-e4aad7c677f4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ee6cf398-e3ac-4a96-8b22-e3a2a2a4c1c8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a424eb83-e98d-4567-adf4-343410276bd1"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "RankEntries",
                type: "varbinary(max)",
                nullable: true,
                comment: "Gets or sets the image for a rank entry.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), 0, "ab4e61e6-f534-491d-9eab-23377c5849ff", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEI7J9trAwicuMJNuZJhUc99CCfH8zay77h+FnUvD64I9ptZ3Jb73fqUMe4bkKh2NaA==", null, false, null, "2337d7b8-cc6b-4add-844c-4ffeac03ec8f", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6a1d3521-d20e-47da-8fcc-67af012547e6"), 0, "922ed46a-0987-4f99-ae36-1e79612462db", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAECE9P/LSuCtHau+YR0Z6oViqmqAl9ld81hRRosZunvGsByVCMToEgrsjOCImI3Tk1A==", null, false, null, "c1e3d194-d476-4745-adad-ba7902b2e7e5", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca"), new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("042eb1ca-4915-41bf-9feb-77e33ce4ddf3"), new Guid("6a1d3521-d20e-47da-8fcc-67af012547e6"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("0f6bf11b-24c9-413c-a3f5-a27445e61c27"), new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("8e149084-2727-4fbc-b068-7bd6b545e865"), new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d4a9b7bd-3b04-4dff-8d7f-9960564fac80"), new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("4b40f1e6-b198-49d5-9709-6576f29f8624"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), new DateTime(2022, 11, 29, 16, 12, 21, 445, DateTimeKind.Local).AddTicks(6407), false, new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca") },
                    { new Guid("9b40091d-b32d-4c41-8c34-bf0eb16027cb"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"), new DateTime(2022, 11, 24, 16, 12, 21, 445, DateTimeKind.Local).AddTicks(6397), false, new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca") },
                    { new Guid("cc757eff-5b6e-43cd-9667-201ecca28439"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("6a1d3521-d20e-47da-8fcc-67af012547e6"), new DateTime(2022, 11, 17, 16, 12, 21, 445, DateTimeKind.Local).AddTicks(6413), false, new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("107386a6-d295-4146-b3f7-678b2bf47b67"), "Good stuff", null, "Picture of star wars", 10, new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca"), "Star Wars" },
                    { new Guid("6970c349-567f-4668-80f4-4e98302b1699"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", 9, new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca"), "Star Wars2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("4b40f1e6-b198-49d5-9709-6576f29f8624"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9b40091d-b32d-4c41-8c34-bf0eb16027cb"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cc757eff-5b6e-43cd-9667-201ecca28439"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("107386a6-d295-4146-b3f7-678b2bf47b67"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("6970c349-567f-4668-80f4-4e98302b1699"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("042eb1ca-4915-41bf-9feb-77e33ce4ddf3"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("0f6bf11b-24c9-413c-a3f5-a27445e61c27"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("8e149084-2727-4fbc-b068-7bd6b545e865"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d4a9b7bd-3b04-4dff-8d7f-9960564fac80"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a1d3521-d20e-47da-8fcc-67af012547e6"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("03567aa0-0979-4b6f-a255-a5431b2006ca"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("07a60ca2-9115-4017-ad7f-d9889778ca06"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "RankEntries");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), 0, "6f340bd6-9288-4af6-976d-a3a1edc656ad", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEPLe5q+BYi+0mD3/EZ/ztAzFrlnxgDCDeYezSliAI0XIYFBjiETlYfxDdSMwnw7rmQ==", null, false, null, "4e0ca773-058b-4940-9714-2c9ccd91b1a1", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ee6cf398-e3ac-4a96-8b22-e3a2a2a4c1c8"), 0, "42b676b7-c3bb-42d8-a1df-2d73fe7c9521", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEMFG0mAuTkKAR1MMcQ9YcCbv4IhWVwKLkQetHabDUiCcBYSi7RP8YZgr7uVqjp0KBA==", null, false, null, "2f538a41-ec29-4ca0-bf0f-4b656274ca5b", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6"), new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("8da8f07e-df21-4aba-ae5e-7cc1bf91db6e"), new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("a6fc078c-a915-4c8b-9828-4dffb0c3a538"), new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("bcf477cc-6183-41cb-ae19-f564946a3fdc"), new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("f40c9b3f-1948-4a4a-9f10-e4aad7c677f4"), new Guid("ee6cf398-e3ac-4a96-8b22-e3a2a2a4c1c8"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("33d9b8ec-39b4-4393-8889-18ee8e95fa58"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), new DateTime(2022, 11, 29, 13, 59, 39, 334, DateTimeKind.Local).AddTicks(3306), false, new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6") },
                    { new Guid("5404577f-382a-4d6d-9cb1-75feeed31cb0"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("ee6cf398-e3ac-4a96-8b22-e3a2a2a4c1c8"), new DateTime(2022, 11, 17, 13, 59, 39, 334, DateTimeKind.Local).AddTicks(3310), false, new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6") },
                    { new Guid("8c45056d-d437-4f1f-952f-827ab6dbdf14"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("a424eb83-e98d-4567-adf4-343410276bd1"), new DateTime(2022, 11, 24, 13, 59, 39, 334, DateTimeKind.Local).AddTicks(3298), false, new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("a339bec8-bf77-4ed9-a069-87da8ecf9fdd"), "Good stuff", "Picture of star wars", 10, new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6"), "Star Wars" },
                    { new Guid("ad81b331-8472-471e-838e-cc80f9da032c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "Picture of star wars2", 9, new Guid("7cd8e81c-d20e-4104-9aaa-1fa42d07aae6"), "Star Wars2" }
                });
        }
    }
}
