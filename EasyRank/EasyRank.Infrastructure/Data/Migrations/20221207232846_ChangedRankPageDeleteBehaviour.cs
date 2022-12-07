using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class ChangedRankPageDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "RankPages",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Gets or sets the guid of the user who created the ranking page.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Gets or sets the guid of the user who created the ranking page.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4efeafa2-7213-4151-9316-377840734170"), 0, "54233e0e-15a1-4894-98bb-205d8a274007", "vassdeniss@gmail.com", true, "Denis", "Vasilev", false, null, "VASSDENISS@GMAIL.COM", "VASSDENISS", "AQAAAAEAACcQAAAAEDjsHm/2m3OOMcUsfdTrmfNF90PZTqbGs596jKBuCQWZUD86yEJZhit0NNUfRqFWVw==", null, false, null, "6f76144d-2ebc-4ecd-9ee7-ad3451fbf75f", false, "vassdeniss" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), 0, "1b2f07a5-1961-4444-9e27-723695e8fa89", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEJrLAGjzbAJiS2+1Nq7uXlWaxF/G/6M9Q0kxxaLsGGFonsYfU1fEgSzhuK9qUh2hiQ==", null, false, null, "dfedbf50-9345-4296-b8fe-cc70238434a1", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), 0, "a4d2bbdf-ee74-4938-84ca-a062fda90aa1", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEJ2CoKF9VNKML5kljxlkIhcR/IlfwnTF8EmiUoh0Ps85+46pMbEX7F+OqN65+k2FkA==", null, false, null, "2ba4d786-c4b9-46d1-a5e4-1899449eb727", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("03ba95a8-7bff-4a5a-8b70-88bfa84a247b"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("04d1b688-8910-4fd4-a960-a32a9af11da3"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("139ce8c0-0905-4cf5-adca-908ddfd0ea2d"), new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("25e45137-dc51-4dae-843a-c3dfb524df9d"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("2a566321-9066-4f92-b06d-d020a12738dd"), new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("30a45222-2241-42a9-af13-0e51dffaedfb"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("3cce8473-5e9b-4979-90f5-e522288aaf03"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("4f5969c0-6421-426e-9183-156d4ccc4543"), new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("54fa920f-b230-4cf4-b069-a83a5be0bebb"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("7def91b1-c2a4-4f31-a16c-06df3240d1e3"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("97449969-4d8f-4602-a71a-b2594bd10150"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("c501227a-7cd6-4fd6-853e-abac2b4c9038"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("c56ac3a8-251b-4fd5-9323-4c18cdba1e35"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("f4017f73-2801-446a-a73c-29b3ad4d0b0d"), new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("f4654b0f-cf79-4247-b9ce-04805485a1b4"), new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("5c3e668d-073b-49eb-b29c-3e35c55fde75"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), new DateTime(2022, 12, 5, 1, 28, 46, 130, DateTimeKind.Local).AddTicks(3386), false, false, new Guid("4f5969c0-6421-426e-9183-156d4ccc4543") },
                    { new Guid("79f2781c-cc23-41a8-ba69-3f7536f9dc8c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"), new DateTime(2022, 11, 28, 1, 28, 46, 130, DateTimeKind.Local).AddTicks(3395), false, false, new Guid("4f5969c0-6421-426e-9183-156d4ccc4543") },
                    { new Guid("c5c70bf8-9356-4be7-bdd9-f9401366f8a6"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"), new DateTime(2022, 12, 10, 1, 28, 46, 130, DateTimeKind.Local).AddTicks(3391), false, false, new Guid("4f5969c0-6421-426e-9183-156d4ccc4543") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("6f04331f-35d0-43ed-a224-ac4802eaaff3"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("4f5969c0-6421-426e-9183-156d4ccc4543"), "Star Wars2" },
                    { new Guid("db3c058e-ee53-4b05-a400-078fe8eb1b77"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("4f5969c0-6421-426e-9183-156d4ccc4543"), "Star Wars" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4efeafa2-7213-4151-9316-377840734170"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5c3e668d-073b-49eb-b29c-3e35c55fde75"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("79f2781c-cc23-41a8-ba69-3f7536f9dc8c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c5c70bf8-9356-4be7-bdd9-f9401366f8a6"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("6f04331f-35d0-43ed-a224-ac4802eaaff3"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("db3c058e-ee53-4b05-a400-078fe8eb1b77"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("03ba95a8-7bff-4a5a-8b70-88bfa84a247b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("04d1b688-8910-4fd4-a960-a32a9af11da3"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("139ce8c0-0905-4cf5-adca-908ddfd0ea2d"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("25e45137-dc51-4dae-843a-c3dfb524df9d"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("2a566321-9066-4f92-b06d-d020a12738dd"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("30a45222-2241-42a9-af13-0e51dffaedfb"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3cce8473-5e9b-4979-90f5-e522288aaf03"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("54fa920f-b230-4cf4-b069-a83a5be0bebb"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7def91b1-c2a4-4f31-a16c-06df3240d1e3"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("97449969-4d8f-4602-a71a-b2594bd10150"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c501227a-7cd6-4fd6-853e-abac2b4c9038"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c56ac3a8-251b-4fd5-9323-4c18cdba1e35"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f4017f73-2801-446a-a73c-29b3ad4d0b0d"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f4654b0f-cf79-4247-b9ce-04805485a1b4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a500dd48-f84f-4bcd-8d3c-12361d266dce"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("4f5969c0-6421-426e-9183-156d4ccc4543"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5cebd2fe-34c3-4c5f-8346-76f35d1fbfe1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "RankPages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Gets or sets the guid of the user who created the ranking page.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Gets or sets the guid of the user who created the ranking page.");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
