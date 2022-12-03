using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
