using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class FixedComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: true,
                comment: "Gets or sets the guid of the user who created the rank page.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Gets or sets the guid of the user who created the ranking page.");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedByUserId",
                table: "RankPages",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Gets or sets the guid of the user who created the ranking page.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Gets or sets the guid of the user who created the rank page.");

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
        }
    }
}
