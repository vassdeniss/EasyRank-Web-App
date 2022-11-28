using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedCommentEditFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Gets or sets a value indicating whether a comment has been edited.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), 0, "7ec57404-0b96-4e2d-9677-fda754882cd4", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEGv8V4H0CJ1U5q37cmYB2OWxUysQuDiVE3HJEHArGQkyoGDKW7KC55BtdAZ+JEA3ZA==", null, false, null, "1e0da33b-97b0-47d7-8bf0-0e915082bbc6", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4f680074-dabf-440d-b8d6-e9d13ac2f53b"), 0, "ee13655e-d807-42a1-948c-e1f4f32a2266", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEMxcOphzk0oAyQm6vIbm7q5mwI+r3n2zGTpDytKgb4dJFZ6ACbpwmlKnEI8fPsfmSA==", null, false, null, "f724644a-cb35-4b2c-a3d0-f22170d17dee", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("7e000e7a-7738-4c8f-b2b1-9e329ef0e756"), new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("874a2cf3-8caf-49df-8357-6dac630a4ffc"), new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a"), new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("cf021f77-4a3d-4bc5-98e9-2252f1e4708b"), new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("f9dc3739-c2e9-4ceb-b704-a8d1643e5bef"), new Guid("4f680074-dabf-440d-b8d6-e9d13ac2f53b"), new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "IsEdited", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("80933013-3493-4bad-9484-9b976b790acb"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), new DateTime(2022, 12, 1, 0, 11, 21, 435, DateTimeKind.Local).AddTicks(4472), false, false, new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a") },
                    { new Guid("90b35ec2-b961-48be-877c-dd0f34b50da3"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"), new DateTime(2022, 11, 26, 0, 11, 21, 435, DateTimeKind.Local).AddTicks(4465), false, false, new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a") },
                    { new Guid("fe262935-f6c7-41e8-8094-c290fa9adc91"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("4f680074-dabf-440d-b8d6-e9d13ac2f53b"), new DateTime(2022, 11, 19, 0, 11, 21, 435, DateTimeKind.Local).AddTicks(4476), false, false, new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "IsDeleted", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("961cfe12-50a7-4f95-9c81-c7f2b30e99ed"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", null, "Picture of star wars2", false, 9, new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a"), "Star Wars2" },
                    { new Guid("c5f656a3-ec4c-4e31-ad15-41491f979509"), "Good stuff", null, "Picture of star wars", false, 10, new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a"), "Star Wars" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("80933013-3493-4bad-9484-9b976b790acb"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("90b35ec2-b961-48be-877c-dd0f34b50da3"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fe262935-f6c7-41e8-8094-c290fa9adc91"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("961cfe12-50a7-4f95-9c81-c7f2b30e99ed"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("c5f656a3-ec4c-4e31-ad15-41491f979509"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7e000e7a-7738-4c8f-b2b1-9e329ef0e756"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("874a2cf3-8caf-49df-8357-6dac630a4ffc"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("cf021f77-4a3d-4bc5-98e9-2252f1e4708b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f9dc3739-c2e9-4ceb-b704-a8d1643e5bef"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f680074-dabf-440d-b8d6-e9d13ac2f53b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9ca69694-4784-4b7d-8778-9cc1617f066a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("46d9367c-ca78-41f5-bb32-c654cbd7e19c"));

            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "Comments");

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
        }
    }
}
