using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedEntryDeleteFlag : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RankEntries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Gets or sets a value indicating whether a rank entry has been deleted.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6520a520-6658-4fa4-bd09-136af100ff25"), 0, "3c4f26ce-4a71-4482-b10a-b3d43eea701a", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEIEGA6/0m0o5pXWvmuPSKe1nMa8czz4MKgeVVjOfLeXkkwi9Jf3zyrjMhoQTACk8xA==", null, false, null, "b75f8243-9bb1-4a08-a743-d0b965951853", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), 0, "31d88ac1-35c7-4367-99b5-dac3765da779", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEJ7kO5l3qMxZOHvFHA410GHMC7R6AsRCld9OIWUx4UYTOVznk0zt2SkLLNHh6rknIQ==", null, false, null, "0f3775aa-62ce-47ec-9715-7ba233003a98", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("988effcd-d069-42c7-8b17-b192709a75ab"), new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("a7053062-07e5-451f-afe7-7cd444dd32e6"), new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("bcc19f85-7173-4746-bd9e-066cc5420098"), new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("cdcfe08d-2512-4cfb-b46c-57d5baf37993"), new Guid("6520a520-6658-4fa4-bd09-136af100ff25"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("f15e1a70-0d7e-42b6-857a-1d03debe81d9"), new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("2402043d-ab97-49c9-8da0-2a9436d31448"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), new DateTime(2022, 11, 29, 21, 4, 48, 210, DateTimeKind.Local).AddTicks(1813), false, new Guid("bcc19f85-7173-4746-bd9e-066cc5420098") },
                    { new Guid("6bf9b3ed-1410-4985-92c1-450eb08775d8"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("6520a520-6658-4fa4-bd09-136af100ff25"), new DateTime(2022, 11, 17, 21, 4, 48, 210, DateTimeKind.Local).AddTicks(1821), false, new Guid("bcc19f85-7173-4746-bd9e-066cc5420098") },
                    { new Guid("8c14bfaf-a9fb-44c6-9297-a9f3890d30a5"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"), new DateTime(2022, 11, 24, 21, 4, 48, 210, DateTimeKind.Local).AddTicks(1805), false, new Guid("bcc19f85-7173-4746-bd9e-066cc5420098") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("30c99386-041e-4624-9284-68a1a79b61ac"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("bcc19f85-7173-4746-bd9e-066cc5420098"), "Star Wars2" },
                    { new Guid("362e80c1-4468-48b6-bccb-2342b38c1e5b"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("bcc19f85-7173-4746-bd9e-066cc5420098"), "Star Wars" }
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

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2402043d-ab97-49c9-8da0-2a9436d31448"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6bf9b3ed-1410-4985-92c1-450eb08775d8"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("8c14bfaf-a9fb-44c6-9297-a9f3890d30a5"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("30c99386-041e-4624-9284-68a1a79b61ac"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("362e80c1-4468-48b6-bccb-2342b38c1e5b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("988effcd-d069-42c7-8b17-b192709a75ab"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a7053062-07e5-451f-afe7-7cd444dd32e6"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("cdcfe08d-2512-4cfb-b46c-57d5baf37993"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f15e1a70-0d7e-42b6-857a-1d03debe81d9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6520a520-6658-4fa4-bd09-136af100ff25"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("bcc19f85-7173-4746-bd9e-066cc5420098"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("65bd6f38-41cc-4b6b-99c2-133d5996b845"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RankEntries");

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
        }
    }
}
