using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedUserForgottenFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c4eabcc6-7366-4eaf-a37d-71cad1738004"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e2de8ba1-e2e0-4569-9b09-a635f028af8f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e7cdd3bf-9125-4e5d-95f3-47a41d0ab714"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f3148d7c-9225-4e65-8c7f-9c601c1f8e10"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("e0e68c21-1250-48ea-835d-4417016c79f1"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3533fc4-496c-4d13-a920-124489b5cc58"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("05ae182a-bf4c-4619-b390-d336a7e5e1ee"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("241d2e6a-4669-490d-8090-b7193177fef8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("2bc31027-9ba2-48be-9934-5855f9641b7a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("2fcd25d3-6a29-4300-bb36-385d922f58cc"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("37f26a8b-6ac8-4abd-9f66-ed2ee07bed63"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3e588a44-77e1-4697-bfa8-3d3a143a37de"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("494ad971-4c3a-4deb-aa0b-89d8d48621ea"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("67a33376-40a8-40c5-9ede-9d8101a64292"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("80c7492e-2d79-4dbb-b486-1d29fcf11cfe"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("8a6a3e3b-363a-47b6-b3f4-e7d2930f53ad"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("cacc203e-ef52-41f0-a1a7-6336d2415fce"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d7de8b67-d622-4014-a1d3-8df8f4c0d55a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("dd0190e9-7331-499c-ab28-1367cfe8049a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("fc1d1476-aed1-4b65-9006-5201dd70556f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"));

            migrationBuilder.AddColumn<bool>(
                name: "IsForgotten",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Gets or sets a value indicating whether a user has been forgotten (deleted).");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "IsForgotten",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), 0, "81f9f1ca-504a-4576-a16e-88e1ba9cf075", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEIkKTtAyqBs0ZgRV5cZIPsiq5x/zZObune1dTV3Earl5EAAMiJC0V1ZCI2C7GvBJ4w==", null, false, null, "c099ff53-49bf-41b9-861a-2efc2282f03c", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), 0, "f083cb7d-d1a4-4f8c-9643-2c5ea05d8b2c", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEI0aNJNFgfs/o06k3QlJtGZ1VPZa7bR3gDeew9atA3LvGqfR8aF12DHKQgBGSMHpCw==", null, false, null, "a4804555-0b61-446d-b0e1-3e3c3b621eec", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c4eabcc6-7366-4eaf-a37d-71cad1738004"), 0, "be697dd0-a061-4505-9b26-5cd3e24ea2b6", "vassdeniss@gmail.com", true, "Denis", "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAENYG+3HqP+wIdlw84P4Rctw3xt1eO73eVBkPO1sMzFx6zTKK9F0SAztP0ltRiaVECw==", null, false, null, "d88c7d3b-5a67-42eb-a73a-846a2e78146b", false, "vassdeniss" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("05ae182a-bf4c-4619-b390-d336a7e5e1ee"), new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("241d2e6a-4669-490d-8090-b7193177fef8"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("2bc31027-9ba2-48be-9934-5855f9641b7a"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("2fcd25d3-6a29-4300-bb36-385d922f58cc"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("37f26a8b-6ac8-4abd-9f66-ed2ee07bed63"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("3e588a44-77e1-4697-bfa8-3d3a143a37de"), new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("494ad971-4c3a-4deb-aa0b-89d8d48621ea"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("67a33376-40a8-40c5-9ede-9d8101a64292"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("80c7492e-2d79-4dbb-b486-1d29fcf11cfe"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("8a6a3e3b-363a-47b6-b3f4-e7d2930f53ad"), new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("cacc203e-ef52-41f0-a1a7-6336d2415fce"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d7de8b67-d622-4014-a1d3-8df8f4c0d55a"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("dd0190e9-7331-499c-ab28-1367cfe8049a"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a"), new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("fc1d1476-aed1-4b65-9006-5201dd70556f"), new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("e2de8ba1-e2e0-4569-9b09-a635f028af8f"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), new DateTime(2022, 12, 10, 1, 35, 43, 756, DateTimeKind.Local).AddTicks(9899), false, false, new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a") },
                    { new Guid("e7cdd3bf-9125-4e5d-95f3-47a41d0ab714"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("063bc9cd-8424-4312-8d5a-5df7c0ef4e50"), new DateTime(2022, 12, 5, 1, 35, 43, 756, DateTimeKind.Local).AddTicks(9886), false, false, new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a") },
                    { new Guid("f3148d7c-9225-4e65-8c7f-9c601c1f8e10"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("40c23b14-e7cb-4ea7-a405-3d4ca8f5c9e6"), new DateTime(2022, 11, 28, 1, 35, 43, 756, DateTimeKind.Local).AddTicks(9905), false, false, new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("e0e68c21-1250-48ea-835d-4417016c79f1"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a"), "Star Wars2" },
                    { new Guid("e3533fc4-496c-4d13-a920-124489b5cc58"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("df5accb7-f588-4361-b2ed-a6d5e7c67b5a"), "Star Wars" }
                });
        }
    }
}
