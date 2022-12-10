using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class RestoredOldOnDeleteSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_RankPages_RankPageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_RankEntries_RankPages_RankPageId",
                table: "RankEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("56d7b046-a494-4ca4-bc9a-1689274adc6d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2ed6a2e4-e69c-4996-8be5-b760489eeb89"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("4cd91ec8-6c08-48bf-b678-e225b6cae76e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e2d86f38-5222-44f7-8ec3-a8ca61880f92"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("0bb58cdb-b35c-40cf-abd4-b38fc4ab4289"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("667cd68e-8d56-4e35-89c4-ba8a4b1e040e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("09299c95-f379-46b0-8289-ffd73c3aeb5e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3bc1dd9f-10e0-4dab-a98c-cf7a16f27659"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("602cbc35-3c31-4723-86bf-2cd277ed42c8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("6cbe3e58-aed5-4362-9d78-0440d78f871e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("72568a40-d044-477a-9c77-50fcfaf6c794"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7b398bcf-d75f-4aab-ab68-61eed483f1d1"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7dc8b324-f3d8-4bbd-b5a7-87a63de5ee0f"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a0b19af5-6bc5-4b68-92c5-deccc8ff909e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("acbaaad8-f5d7-4253-b2d9-85058846f6bf"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ad951ce9-d337-4aa9-85b5-18c3a1deed3b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c06b3f9f-5da2-4f56-86be-52f2290e862f"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c81a5fa4-9824-4ee6-b4c7-d1b4d557810c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("e4e92bd4-380e-46e8-add6-6b17ce0b4d60"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ee473563-f81b-4797-add5-13f109ac4d6f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("00302d44-25b1-4d29-892d-3a50adbb5916"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "RankPages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Gets or sets the guid of the user who created the rank page.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Gets or sets the guid of the user who created the rank page.");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_RankPages_RankPageId",
                table: "Comments",
                column: "RankPageId",
                principalTable: "RankPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RankEntries_RankPages_RankPageId",
                table: "RankEntries",
                column: "RankPageId",
                principalTable: "RankPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_RankPages_RankPageId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_RankEntries_RankPages_RankPageId",
                table: "RankEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "RankPages",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Gets or sets the guid of the user who created the rank page.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Gets or sets the guid of the user who created the rank page.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("56d7b046-a494-4ca4-bc9a-1689274adc6d"), 0, "c627b064-8125-4488-b2ab-f64c37690e09", "vassdeniss@gmail.com", true, "Denis", false, "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAEJbJd/KoBDVXWI/FafNwBOJwPJrvFbxWB2TBH0/yDii1ycArBbphGnGw5m5SXGACWg==", null, false, null, "493db34e-a778-44b4-8ba5-57a25d62c505", false, "vassdeniss" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), 0, "5d3e55d8-d911-4414-943b-5ef1d921e716", "guestTwo@mail.com", true, "GuestTwo", false, "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEK6btrAJw6GzB+ms3fBoYmcGn3iP2O4NUTqt2jCkrdBaFlNQcTciiT3OHgSJla48oQ==", null, false, null, "1819166a-7aa8-4419-9108-1f86208e6dbf", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsForgotten", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), 0, "10ae6bc8-f58b-40c3-912b-ec21e3fe9b3a", "guest@mail.com", true, "Guest", false, "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAELkAPVJKeX2fm79WAAYph3PLYUJWBuxyG3ZsHQ/txm0xhU+UUE79/4E6IFrOPiGk5w==", null, false, null, "d89768c5-8f8c-471f-a276-26e4a1b13d65", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("00302d44-25b1-4d29-892d-3a50adbb5916"), new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("09299c95-f379-46b0-8289-ffd73c3aeb5e"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("3bc1dd9f-10e0-4dab-a98c-cf7a16f27659"), new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("602cbc35-3c31-4723-86bf-2cd277ed42c8"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("6cbe3e58-aed5-4362-9d78-0440d78f871e"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("72568a40-d044-477a-9c77-50fcfaf6c794"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("7b398bcf-d75f-4aab-ab68-61eed483f1d1"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("7dc8b324-f3d8-4bbd-b5a7-87a63de5ee0f"), new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("a0b19af5-6bc5-4b68-92c5-deccc8ff909e"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("acbaaad8-f5d7-4253-b2d9-85058846f6bf"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("ad951ce9-d337-4aa9-85b5-18c3a1deed3b"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("c06b3f9f-5da2-4f56-86be-52f2290e862f"), new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("c81a5fa4-9824-4ee6-b4c7-d1b4d557810c"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("e4e92bd4-380e-46e8-add6-6b17ce0b4d60"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("ee473563-f81b-4797-add5-13f109ac4d6f"), new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("2ed6a2e4-e69c-4996-8be5-b760489eeb89"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), new DateTime(2022, 12, 11, 22, 18, 16, 174, DateTimeKind.Local).AddTicks(9997), false, false, new Guid("00302d44-25b1-4d29-892d-3a50adbb5916") },
                    { new Guid("4cd91ec8-6c08-48bf-b678-e225b6cae76e"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("a0790ac4-8b69-43a8-a6c7-f4ca6f835173"), new DateTime(2022, 11, 29, 22, 18, 16, 175, DateTimeKind.Local).AddTicks(1), false, false, new Guid("00302d44-25b1-4d29-892d-3a50adbb5916") },
                    { new Guid("e2d86f38-5222-44f7-8ec3-a8ca61880f92"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("b54091aa-7e94-4378-881f-10b88a66ea22"), new DateTime(2022, 12, 6, 22, 18, 16, 174, DateTimeKind.Local).AddTicks(9991), false, false, new Guid("00302d44-25b1-4d29-892d-3a50adbb5916") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("0bb58cdb-b35c-40cf-abd4-b38fc4ab4289"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("00302d44-25b1-4d29-892d-3a50adbb5916"), "Star Wars" },
                    { new Guid("667cd68e-8d56-4e35-89c4-ba8a4b1e040e"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("00302d44-25b1-4d29-892d-3a50adbb5916"), "Star Wars2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_RankPages_RankPageId",
                table: "Comments",
                column: "RankPageId",
                principalTable: "RankPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RankEntries_RankPages_RankPageId",
                table: "RankEntries",
                column: "RankPageId",
                principalTable: "RankPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
