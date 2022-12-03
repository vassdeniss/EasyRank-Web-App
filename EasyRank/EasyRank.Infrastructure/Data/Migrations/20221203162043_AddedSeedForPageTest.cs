using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedSeedForPageTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("837c2ec5-f09e-42db-9570-dad27381bade"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2cf94b6c-be65-42c2-a546-2c98f01ec1f2"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("48cc7ddc-2db6-42f0-9293-4cb68d6938d3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("953a97bf-c404-450e-8ec6-787e7906a2a3"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("30d4129c-b08e-4a9f-84b7-71f6e246ef85"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("b1d87160-25af-4ae0-a277-d9683ee51823"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("55d14ca6-2eba-418a-b7ff-e8171dea6295"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("6a550a66-6ced-4cf0-bdb5-9112a3bc9598"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("e95be6d8-51a7-4e9c-836d-69351b485d60"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("fa93588b-9188-42d0-a4ce-8d1eeec3ae09"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3149651-3cf2-44ef-9ede-8a6300500b5a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2f468865-2653-4e78-8413-6295e017c1f7"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2a4be477-858d-4865-9819-97c326324e87"), 0, "ef336af9-a7b2-4fde-8465-bf8e8bea4900", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEGhS+Jkk0bR/uPgllkx4vZWCuI8mBkewDTtk0LYIHIBBdZKzQMCYVdZpFwb1GuhA3w==", null, false, null, "681517e2-991c-4017-8bf6-5fb9d7f60511", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8c01156e-ce88-4b3b-9db5-40114c56adbf"), 0, "ca7f8613-d6a1-48fd-bed8-6dca96e64a4d", "vassdeniss@gmail.com", true, "Denis", "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAEDtwmnKbVttTVkwGXRwgVbxbCx3yJFbAcpAZgumgef0ehvUD1fwMLhiX73DDQnx7PQ==", null, false, null, "3bd5b968-a857-45e4-a2bb-d80c7d2288a8", false, "vassdeniss" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), 0, "a4334fc0-262f-4605-9924-d32c88a84c14", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEBRPZNbW9haS6Ffd9SrLd1gL5Z/vOrkC41hnslKUf3Y6bRwbkP7MliJ+FLu/0AU0Xw==", null, false, null, "9946df9f-90b8-4530-bb75-a00b76a1e44f", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("1942ad00-d61a-4aed-a745-001de176e9b6"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("224d2e32-8621-4d2f-96f8-cac781a5958e"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("30f1c5f0-3dab-479d-a127-8a605a2640cf"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("32d7b600-8d86-4d99-85ca-0063dc20061c"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("62cbd76a-78e9-48c2-956b-351f37c24d5a"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("7dc172ee-2263-4e6a-8fb4-cafebe056cbb"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("85a16897-5767-45dc-9bc7-075fade58487"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("8a4fbb46-e455-444f-ace2-94ab83c664a2"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("96808fac-4345-4284-b848-5dd1be055af7"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9c34d38b-8633-4d5b-ace9-06580e52988a"), new Guid("2a4be477-858d-4865-9819-97c326324e87"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9e4ef54b-ac13-468c-946a-fd2055177359"), new Guid("2a4be477-858d-4865-9819-97c326324e87"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("a3ef4857-a28a-4b50-853e-a59dc91b86da"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("c5713437-504c-4a71-ac63-fe2b4fe87e08"), new Guid("2a4be477-858d-4865-9819-97c326324e87"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d7a54530-fe81-4621-9db9-663269a9577a"), new Guid("2a4be477-858d-4865-9819-97c326324e87"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("fb2c2ede-ef76-4588-82d8-766ca3f10a4d"), new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("1f26c8ad-7dff-4085-b2d1-e5d645a7327a"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("2a4be477-858d-4865-9819-97c326324e87"), new DateTime(2022, 12, 5, 18, 20, 42, 387, DateTimeKind.Local).AddTicks(3877), false, false, new Guid("d7a54530-fe81-4621-9db9-663269a9577a") },
                    { new Guid("533d2b67-f72b-48bb-84e0-2df65ad7eccc"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"), new DateTime(2022, 11, 23, 18, 20, 42, 387, DateTimeKind.Local).AddTicks(3887), false, false, new Guid("d7a54530-fe81-4621-9db9-663269a9577a") },
                    { new Guid("9dc1c77f-bc53-4735-a0f3-fb3a9aaf8433"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("2a4be477-858d-4865-9819-97c326324e87"), new DateTime(2022, 11, 30, 18, 20, 42, 387, DateTimeKind.Local).AddTicks(3868), false, false, new Guid("d7a54530-fe81-4621-9db9-663269a9577a") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("03ec1421-909e-409e-89f2-c723c8162ea3"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("d7a54530-fe81-4621-9db9-663269a9577a"), "Star Wars2" },
                    { new Guid("d510b449-3073-4591-b0ab-383cfe641aed"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("d7a54530-fe81-4621-9db9-663269a9577a"), "Star Wars" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c01156e-ce88-4b3b-9db5-40114c56adbf"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1f26c8ad-7dff-4085-b2d1-e5d645a7327a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("533d2b67-f72b-48bb-84e0-2df65ad7eccc"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9dc1c77f-bc53-4735-a0f3-fb3a9aaf8433"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("03ec1421-909e-409e-89f2-c723c8162ea3"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("d510b449-3073-4591-b0ab-383cfe641aed"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1942ad00-d61a-4aed-a745-001de176e9b6"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("224d2e32-8621-4d2f-96f8-cac781a5958e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("30f1c5f0-3dab-479d-a127-8a605a2640cf"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("32d7b600-8d86-4d99-85ca-0063dc20061c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("62cbd76a-78e9-48c2-956b-351f37c24d5a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7dc172ee-2263-4e6a-8fb4-cafebe056cbb"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("85a16897-5767-45dc-9bc7-075fade58487"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("8a4fbb46-e455-444f-ace2-94ab83c664a2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("96808fac-4345-4284-b848-5dd1be055af7"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9c34d38b-8633-4d5b-ace9-06580e52988a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9e4ef54b-ac13-468c-946a-fd2055177359"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a3ef4857-a28a-4b50-853e-a59dc91b86da"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c5713437-504c-4a71-ac63-fe2b4fe87e08"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("fb2c2ede-ef76-4588-82d8-766ca3f10a4d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e1eb8808-ca71-4981-8866-da1a3ff29d25"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d7a54530-fe81-4621-9db9-663269a9577a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2a4be477-858d-4865-9819-97c326324e87"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), 0, "db22c180-26ec-4a52-aedc-c5466a08cf00", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEDCSX65jAhW+EwQlX+vDFKxjMY87dl2rrcrcRBKUIJNr+2mUUJlEE3/Gyl1OZCXQbw==", null, false, null, "7920b807-fdb8-49d8-9dce-0d0a80322896", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("837c2ec5-f09e-42db-9570-dad27381bade"), 0, "fe6a9ec1-f04f-40ea-8db2-7f80c936dbab", "vassdeniss@gmail.com", true, "Denis", "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAENHIkHnTjB7r1G4b77wp53YVjeB8QXCWuNqnp6FGmlAoSUHEQM8WM8edAOFhd+DBFw==", null, false, null, "481d8a94-d7ea-439e-b7a4-41722edb0f07", false, "vassdeniss" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c3149651-3cf2-44ef-9ede-8a6300500b5a"), 0, "875807fe-08df-440a-aca9-d48ee39c4830", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAECEIHzKB2ZlhqMnzuOk0sn82hxei9XPfK6YxG9E8MOpDHa1LyJcrRP1xDXZWlDP6oA==", null, false, null, "3dd37676-10c4-48d8-9e17-c632e9552e8b", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("55d14ca6-2eba-418a-b7ff-e8171dea6295"), new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("6a550a66-6ced-4cf0-bdb5-9112a3bc9598"), new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("e95be6d8-51a7-4e9c-836d-69351b485d60"), new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20"), new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("fa93588b-9188-42d0-a4ce-8d1eeec3ae09"), new Guid("c3149651-3cf2-44ef-9ede-8a6300500b5a"), new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("2cf94b6c-be65-42c2-a546-2c98f01ec1f2"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("c3149651-3cf2-44ef-9ede-8a6300500b5a"), new DateTime(2022, 11, 23, 13, 51, 42, 497, DateTimeKind.Local).AddTicks(4101), false, false, new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20") },
                    { new Guid("48cc7ddc-2db6-42f0-9293-4cb68d6938d3"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), new DateTime(2022, 11, 30, 13, 51, 42, 497, DateTimeKind.Local).AddTicks(4092), false, false, new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20") },
                    { new Guid("953a97bf-c404-450e-8ec6-787e7906a2a3"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("2f468865-2653-4e78-8413-6295e017c1f7"), new DateTime(2022, 12, 5, 13, 51, 42, 497, DateTimeKind.Local).AddTicks(4097), false, false, new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("30d4129c-b08e-4a9f-84b7-71f6e246ef85"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20"), "Star Wars2" },
                    { new Guid("b1d87160-25af-4ae0-a277-d9683ee51823"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("ef252a97-6d2d-4c58-aa9d-2b2480af9d20"), "Star Wars" }
                });
        }
    }
}
