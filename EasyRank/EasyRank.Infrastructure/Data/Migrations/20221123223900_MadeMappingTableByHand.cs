using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class MadeMappingTableByHand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyRankUserRankPage");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("175fe165-8c72-4716-a1fe-eda994e6c743"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9db4ec1e-35c0-432b-b474-c91217a51ab6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cb99031b-088d-40c1-bf96-abd6ae40d971"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("a2dbd006-8f9b-4aa1-b5fb-535e3434474c"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("a8a998f2-2ff0-4754-a059-9187e317e5ea"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("07de8b17-8334-40fc-9c48-f8159721b74a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("b33a9dc0-542e-433e-8af6-5701480a36e0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("cdae09c6-d0d7-4868-b45d-4f1ccbee0c1e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d7851877-ef6e-42f3-abde-70278000cb6b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"));

            migrationBuilder.CreateTable(
                name: "EasyRankUsersRankPages",
                columns: table => new
                {
                    EasyRankUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RankPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyRankUsersRankPages", x => new { x.EasyRankUserId, x.RankPageId });
                    table.ForeignKey(
                        name: "FK_EasyRankUsersRankPages_AspNetUsers_EasyRankUserId",
                        column: x => x.EasyRankUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EasyRankUsersRankPages_RankPages_RankPageId",
                        column: x => x.RankPageId,
                        principalTable: "RankPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), 0, "1ba6b171-b6ce-4b78-919d-c0c368dc350b", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEPQPcHuM8N9mCDo8b+4iEfmzB+YGVHl8PoIR8CeIaKaPgVMPPGUiwP13/29eDZREwA==", null, false, null, "f70cfaa1-6497-4316-a2b0-c5c3cb8a9484", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("bf408892-3c4b-450a-bbdb-c4f9ca0bf8af"), 0, "8ce5e126-3996-451f-a667-ad12a1ab4e45", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEPeCxoDioW1uC98Gzd5lWBZ9lSf0f3HpFtWLtYfNqedIEUu4kfm7jc/k+QJ188EteA==", null, false, null, "12fdb1b1-d2f0-4c28-9e26-0fd1ba7409dd", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("4df68c12-c9c3-46a5-b336-7853ec49e050"), new Guid("bf408892-3c4b-450a-bbdb-c4f9ca0bf8af"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("6082c4b3-9a75-40f2-9657-c2931faaf672"), new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("75f04b80-1692-4a1e-9283-86a48d6e5d0a"), new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f"), new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("ff6653ca-7c2c-4572-a1da-d910b2e8dde9"), new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("35ead869-1ee5-4560-8675-af664f2ddfb6"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), new DateTime(2022, 11, 21, 0, 38, 59, 333, DateTimeKind.Local).AddTicks(373), false, new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f") },
                    { new Guid("5e29a5bd-fa80-410b-bdf4-4e9edbbe5d46"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("bf408892-3c4b-450a-bbdb-c4f9ca0bf8af"), new DateTime(2022, 11, 14, 0, 38, 59, 333, DateTimeKind.Local).AddTicks(383), false, new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f") },
                    { new Guid("95322b93-ccfd-4361-92c6-e74dcdc24188"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"), new DateTime(2022, 11, 26, 0, 38, 59, 333, DateTimeKind.Local).AddTicks(379), false, new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("4041f85f-dc71-48c2-a167-cf898a8f1664"), "Good stuff", null, "Picture of star wars", 10, new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f"), "Star Wars" },
                    { new Guid("b45d6642-d83b-4d24-9a37-38dd560fdfc5"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f"), "Star Wars2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyRankUsersRankPages_RankPageId",
                table: "EasyRankUsersRankPages",
                column: "RankPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyRankUsersRankPages");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("35ead869-1ee5-4560-8675-af664f2ddfb6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5e29a5bd-fa80-410b-bdf4-4e9edbbe5d46"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("95322b93-ccfd-4361-92c6-e74dcdc24188"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("4041f85f-dc71-48c2-a167-cf898a8f1664"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("b45d6642-d83b-4d24-9a37-38dd560fdfc5"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("4df68c12-c9c3-46a5-b336-7853ec49e050"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("6082c4b3-9a75-40f2-9657-c2931faaf672"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("75f04b80-1692-4a1e-9283-86a48d6e5d0a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ff6653ca-7c2c-4572-a1da-d910b2e8dde9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bf408892-3c4b-450a-bbdb-c4f9ca0bf8af"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a764458f-8fdf-40ba-84dd-e44b2680134f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("558e8da2-4733-4b76-9e3f-01320eea55fd"));

            migrationBuilder.CreateTable(
                name: "EasyRankUserRankPage",
                columns: table => new
                {
                    LikedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikedRankingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyRankUserRankPage", x => new { x.LikedById, x.LikedRankingsId });
                    table.ForeignKey(
                        name: "FK_EasyRankUserRankPage_AspNetUsers_LikedById",
                        column: x => x.LikedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EasyRankUserRankPage_RankPages_LikedRankingsId",
                        column: x => x.LikedRankingsId,
                        principalTable: "RankPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), 0, "386dc240-eab1-4da6-a8e0-40bada576f6b", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEFmxACBeS/iTpKDKdsEmlEqNX/Hf6KLADGXFzrpuwxmgxagbsF/8gpMDilFFKbhZ+A==", null, false, null, "463009f7-3009-4416-9613-f4e84106242f", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"), 0, "a73d087b-7b55-4a1b-a3e9-f27dfa29feb2", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEP93MYW9ofv6m+ooljrAHNe0MWCNo6tymD0KBcyffA8Uoud/C7hOZptqvZqvIEInAQ==", null, false, null, "d945a01b-9d0f-4a7a-91c3-0b20eea61678", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("07de8b17-8334-40fc-9c48-f8159721b74a"), new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("b33a9dc0-542e-433e-8af6-5701480a36e0"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("cdae09c6-d0d7-4868-b45d-4f1ccbee0c1e"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d7851877-ef6e-42f3-abde-70278000cb6b"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("175fe165-8c72-4716-a1fe-eda994e6c743"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 20, 23, 12, 7, 260, DateTimeKind.Local).AddTicks(6171), false, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2") },
                    { new Guid("9db4ec1e-35c0-432b-b474-c91217a51ab6"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"), new DateTime(2022, 11, 13, 23, 12, 7, 260, DateTimeKind.Local).AddTicks(6215), false, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2") },
                    { new Guid("cb99031b-088d-40c1-bf96-abd6ae40d971"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 25, 23, 12, 7, 260, DateTimeKind.Local).AddTicks(6187), false, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("a2dbd006-8f9b-4aa1-b5fb-535e3434474c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"), "Star Wars2" },
                    { new Guid("a8a998f2-2ff0-4754-a059-9187e317e5ea"), "Good stuff", null, "Picture of star wars", 10, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"), "Star Wars" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyRankUserRankPage_LikedRankingsId",
                table: "EasyRankUserRankPage",
                column: "LikedRankingsId");
        }
    }
}
