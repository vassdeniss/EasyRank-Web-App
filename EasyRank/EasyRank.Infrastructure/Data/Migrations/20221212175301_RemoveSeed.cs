using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class RemoveSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d3a689bb-afc2-4f16-9597-7a09cfa8f493"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("19a17aa9-c2d5-41bd-8d88-61e2ab25485f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("89752489-3d63-4601-8bd7-5990f7f78644"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9fc0a467-304b-4d3a-9b9d-57b603646bc9"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("c3906c2b-0906-4174-8d80-380cd731729e"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("c6d767f8-d6fd-4678-be70-c605d6aabf19"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("121f2e75-7077-4b67-844d-67bbdef6760a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3e901b27-2e50-4693-bf8d-4badb26a2b58"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3f2faa30-fddb-4bca-bd06-b88e441fbb7b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("694699c2-b73c-47f9-9430-19392d5984ee"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("77d69dbc-9f7a-47b8-9806-1dfe28f50130"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("79eda052-7d29-4de0-9576-d30692055b2c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("835689f4-5980-407d-ba70-1c3ecea380c5"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("925e9486-45e3-48f6-add1-d396405540c4"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("96b64284-2705-4f56-bb6d-b7592bf03c2d"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9c4d5ca1-216b-4026-89ba-48a4b9e110d3"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d3ea690c-16da-4ed2-80b2-49132e28e8d0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d84948aa-b0e8-433a-9e1b-cf5bb5e9132b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("dcbea405-d5c3-41a7-899d-159e137635e4"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("e3f75100-d177-4e18-a1a0-8e40d86ffe6b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c3472a59-e3c4-49ee-b859-066114eb222d"), 0, "627ce48e-3edb-4f4d-93ef-b9d8d02cd66a", "vassdeniss@gmail.com", true, "Denis", false, "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAECamK0s7oh8OIYomw8TOCxACCXJS6/mX5OhUp2Y+IVMuzWYSYUVC3XTIRZp90zGsnA==", null, false, null, "757be0b6-b8a0-49ef-969a-94952411ae87", false, "vassdeniss" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3472a59-e3c4-49ee-b859-066114eb222d"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), 0, "004d62b0-b542-42c4-9897-0252feb5cd1b", "guestTwo@mail.com", true, "GuestTwo", false, "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEMxZ2/i9tHhjEwKT/BWyAq8Li9epC6PtevO5x19F8qdhkfPwi8yzS7HwUDYDIhq3uw==", null, false, null, "6343f0f7-8156-4218-942b-fd3664df7019", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d3a689bb-afc2-4f16-9597-7a09cfa8f493"), 0, "33c5d18f-5620-4405-9777-339256d0a46c", "vassdeniss@gmail.com", true, "Denis", false, "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAELdpWFiVL6KysE66OZK6ToOOU/Y0mLVSE2MpDcuEvypCoWoO+qF2hnrpBFnA/ToT9w==", null, false, null, "56cfe652-7b83-4471-a088-2cd8e7dde229", false, "vassdeniss" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), 0, "a3017da0-f350-4ab4-972a-8e668c3467db", "guest@mail.com", true, "Guest", false, "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEMgqmEvLPz0cSb6jAOFlGyaBuPNRXJ2pZKQfnEMjO4EpmJszq60t5EO2tZdNE6FNjA==", null, false, null, "9d3719dc-51e9-4936-ac08-b296206e18f0", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("121f2e75-7077-4b67-844d-67bbdef6760a"), new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("3e901b27-2e50-4693-bf8d-4badb26a2b58"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("3f2faa30-fddb-4bca-bd06-b88e441fbb7b"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("694699c2-b73c-47f9-9430-19392d5984ee"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("77d69dbc-9f7a-47b8-9806-1dfe28f50130"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("79eda052-7d29-4de0-9576-d30692055b2c"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("835689f4-5980-407d-ba70-1c3ecea380c5"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("925e9486-45e3-48f6-add1-d396405540c4"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("96b64284-2705-4f56-bb6d-b7592bf03c2d"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9c4d5ca1-216b-4026-89ba-48a4b9e110d3"), new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d3ea690c-16da-4ed2-80b2-49132e28e8d0"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d84948aa-b0e8-433a-9e1b-cf5bb5e9132b"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("dcbea405-d5c3-41a7-899d-159e137635e4"), new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("e3f75100-d177-4e18-a1a0-8e40d86ffe6b"), new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c"), new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("19a17aa9-c2d5-41bd-8d88-61e2ab25485f"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), new DateTime(2022, 12, 7, 2, 8, 28, 154, DateTimeKind.Local).AddTicks(8222), false, false, new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c") },
                    { new Guid("89752489-3d63-4601-8bd7-5990f7f78644"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("e36d10ca-523c-4ecf-a3ce-036504df0f93"), new DateTime(2022, 12, 12, 2, 8, 28, 154, DateTimeKind.Local).AddTicks(8228), false, false, new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c") },
                    { new Guid("9fc0a467-304b-4d3a-9b9d-57b603646bc9"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("96ff51da-d19e-4e0e-91d0-16a73d00dfbe"), new DateTime(2022, 11, 30, 2, 8, 28, 154, DateTimeKind.Local).AddTicks(8231), false, false, new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("c3906c2b-0906-4174-8d80-380cd731729e"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c"), "Star Wars" },
                    { new Guid("c6d767f8-d6fd-4678-be70-c605d6aabf19"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("f45effdb-d88f-4c92-b1cb-4c78af65a65c"), "Star Wars2" }
                });
        }
    }
}
