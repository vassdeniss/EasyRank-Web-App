using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class ADdedPropertyToMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "EasyRankUsersRankPages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), 0, "2fea0fca-61b5-4172-8834-7a3e72b827fc", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAED42fLWILNC0jYNVC9EEdziw69h9Eu4c3wA3rDTyA69JdGBObZzXUAPtq8/9h1Xmxg==", null, false, null, "aec94d05-8395-489e-96e1-50f97e58471b", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"), 0, "0f7f9fd8-10f8-49b4-9705-288d7900e1b7", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAECo5rpaCvYGCGERrokAWVbNg+Hu0IouJNztU5ktPVMM2Iy6Rxl4pBJQUn1Gw5brDIg==", null, false, null, "21a8824e-0ae1-4d40-ab53-7cd2705a9964", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("0d97ab87-c2a8-41fe-a1f3-0c994214f889"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("16228778-dad6-46da-8804-13b2c297242f"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("19eb5157-95f4-4adc-a659-6958684144f2"), new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9b1a1e07-cdbf-4dea-a4bc-f53e7dd12b95"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("ab0fd370-a790-4ed9-9413-87e6bab1588d"), new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("490b440a-c842-4d59-b442-5e9ba195a566"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 21, 0, 52, 26, 648, DateTimeKind.Local).AddTicks(1209), false, new Guid("16228778-dad6-46da-8804-13b2c297242f") },
                    { new Guid("533c3d46-2e6b-4076-bd5e-3d227aec89e0"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"), new DateTime(2022, 11, 14, 0, 52, 26, 648, DateTimeKind.Local).AddTicks(1225), false, new Guid("16228778-dad6-46da-8804-13b2c297242f") },
                    { new Guid("d6f058c7-1df2-43ad-bf9d-0cb06db1f79c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"), new DateTime(2022, 11, 26, 0, 52, 26, 648, DateTimeKind.Local).AddTicks(1218), false, new Guid("16228778-dad6-46da-8804-13b2c297242f") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("6506ecc4-da2a-4c5f-b323-a0118974dd5c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("16228778-dad6-46da-8804-13b2c297242f"), "Star Wars2" },
                    { new Guid("975db738-d68c-4fb6-8eea-85130aac5ac0"), "Good stuff", null, "Picture of star wars", 10, new Guid("16228778-dad6-46da-8804-13b2c297242f"), "Star Wars" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("490b440a-c842-4d59-b442-5e9ba195a566"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("533c3d46-2e6b-4076-bd5e-3d227aec89e0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d6f058c7-1df2-43ad-bf9d-0cb06db1f79c"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("6506ecc4-da2a-4c5f-b323-a0118974dd5c"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("975db738-d68c-4fb6-8eea-85130aac5ac0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("0d97ab87-c2a8-41fe-a1f3-0c994214f889"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("19eb5157-95f4-4adc-a659-6958684144f2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9b1a1e07-cdbf-4dea-a4bc-f53e7dd12b95"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ab0fd370-a790-4ed9-9413-87e6bab1588d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("264531a7-3ef5-42fa-8857-a7343c4b2e94"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("16228778-dad6-46da-8804-13b2c297242f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1261ba5a-4167-40fb-93f9-dce2c5c1d75c"));

            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "EasyRankUsersRankPages");

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
        }
    }
}
