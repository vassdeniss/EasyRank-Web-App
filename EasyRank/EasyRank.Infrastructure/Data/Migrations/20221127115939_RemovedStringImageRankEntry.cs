using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class RemovedStringImageRankEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("490b440a-c842-4d59-b442-5e9ba195a566"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("533c3d46-2e6b-4076-bd5e-3d227aec89e0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d6f058c7-1df2-43ad-bf9d-0cb06db1f79c"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("6506ecc4-da2a-4c5f-b323-a0118974dd5c"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("975db738-d68c-4fb6-8eea-85130aac5ac0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("0d97ab87-c2a8-41fe-a1f3-0c994214f889"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("19eb5157-95f4-4adc-a659-6958684144f2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9b1a1e07-cdbf-4dea-a4bc-f53e7dd12b95"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ab0fd370-a790-4ed9-9413-87e6bab1588d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("16228778-dad6-46da-8804-13b2c297242f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "RankEntries",
                type: "varchar(2048)",
                unicode: false,
                maxLength: 2048,
                nullable: true,
                comment: "Gets or sets the image link for a rank entry.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), 0, "2fea0fca-61b5-4172-8834-7a3e72b827fc", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAED42fLWILNC0jYNVC9EEdziw69h9Eu4c3wA3rDTyA69JdGBObZzXUAPtq8/9h1Xmxg==", null, false, null, "aec94d05-8395-489e-96e1-50f97e58471b", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"), 0, "0f7f9fd8-10f8-49b4-9705-288d7900e1b7", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAECo5rpaCvYGCGERrokAWVbNg+Hu0IouJNztU5ktPVMM2Iy6Rxl4pBJQUn1Gw5brDIg==", null, false, null, "21a8824e-0ae1-4d40-ab53-7cd2705a9964", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("0d97ab87-c2a8-41fe-a1f3-0c994214f889"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("16228778-dad6-46da-8804-13b2c297242f"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("19eb5157-95f4-4adc-a659-6958684144f2"), new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9b1a1e07-cdbf-4dea-a4bc-f53e7dd12b95"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("ab0fd370-a790-4ed9-9413-87e6bab1588d"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("490b440a-c842-4d59-b442-5e9ba195a566"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 21, 0, 52, 26, 648, DateTimeKind.Local).AddTicks(1209), false, new Guid("16228778-dad6-46da-8804-13b2c297242f") },
                    { new Guid("533c3d46-2e6b-4076-bd5e-3d227aec89e0"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"), new DateTime(2022, 11, 14, 0, 52, 26, 648, DateTimeKind.Local).AddTicks(1225), false, new Guid("16228778-dad6-46da-8804-13b2c297242f") },
                    { new Guid("d6f058c7-1df2-43ad-bf9d-0cb06db1f79c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 26, 0, 52, 26, 648, DateTimeKind.Local).AddTicks(1218), false, new Guid("16228778-dad6-46da-8804-13b2c297242f") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("6506ecc4-da2a-4c5f-b323-a0118974dd5c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("16228778-dad6-46da-8804-13b2c297242f"), "Star Wars2" },
                    { new Guid("975db738-d68c-4fb6-8eea-85130aac5ac0"), "Good stuff", null, "Picture of star wars", 10, new Guid("16228778-dad6-46da-8804-13b2c297242f"), "Star Wars" }
                });
        }
    }
}
