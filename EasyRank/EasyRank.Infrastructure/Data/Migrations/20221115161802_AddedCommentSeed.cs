using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedCommentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("3261fdd3-c0ab-4a0b-99a2-4a0a21cfb50e"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("836464be-a10a-4b88-b064-d702f9f71023"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("137772a1-90e7-4455-ac43-0a507464bf0f"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("16fc253a-b891-421b-9263-05158d03ee89"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("22ed0893-8385-4998-97f4-eba0bc9a2087"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("63dea657-a8a2-4707-a99d-bdd436365143"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("7c684489-1296-48b2-aa55-cf13edda7eab"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("86f41bee-78f0-4302-bb10-1c3d766defc9"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("ad2af004-cd17-4a0f-af64-73286c5f9029"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("f48b4d45-a5d5-4429-9735-879c4729f358"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("389a4233-d40c-4cc0-b97f-965daf04e37e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Gets or sets the content of the comment.",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Gets or sets the content of the comment.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2fe10533-76ad-4050-b5e4-0afe8ed08413"), 0, "88d8f834-bb14-486a-9516-e11d759818d7", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAELyeuVkzVGeICv7RmhN2OUwihJVtEHBKrK91uh0Hmc87K/UsfZvgYp8QHuqHUXeX6w==", null, false, null, "8418ef21-6411-46af-937d-36022bb2a93f", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), 0, "eca677f3-424a-4b64-9168-a1ee09f51b63", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAENP6mrYKbTSueXNFLs9I44C6+DmsqaFJP+euHjKnPTRRpDXkvWk6AZhgjACpeQy9TQ==", null, false, null, "05e88ea2-628e-474c-9fc3-21ed376a6225", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("28db51fd-fe96-45a8-be8b-c035b12162c8"), new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9"), new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("53ae49d4-d7ec-429c-a9e9-074723d0c82c"), new Guid("2fe10533-76ad-4050-b5e4-0afe8ed08413"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("5814b00e-61ab-44de-b6fb-cc2c0a1721c9"), new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("bea7cd29-2440-49ba-9387-8ea11557bc40"), new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("c1fedd5a-5bce-42c5-9dc8-c056a8929807"), new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("c3dac892-b507-49a1-80d2-b06ad4c34728"), new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("2636a317-31c4-46e4-9db1-5f6b8208a308"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 5, 18, 18, 1, 210, DateTimeKind.Local).AddTicks(8897), new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9") },
                    { new Guid("3ba4f42d-a8db-459a-a1d1-28dc92b9c2e9"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 12, 18, 18, 1, 210, DateTimeKind.Local).AddTicks(8883), new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9") },
                    { new Guid("eccf0481-9c51-4ae4-994d-79d0d40b77c5"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"), new DateTime(2022, 11, 17, 18, 18, 1, 210, DateTimeKind.Local).AddTicks(8894), new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("580851d8-8e3d-42b7-bc96-545575b3afcf"), "Good stuff", null, "Picture of star wars", 10, new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9"), "Star Wars" },
                    { new Guid("7a8b5a3c-5e8d-4ead-ad6f-54476d1ac78a"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9"), "Star Wars2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2636a317-31c4-46e4-9db1-5f6b8208a308"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3ba4f42d-a8db-459a-a1d1-28dc92b9c2e9"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("eccf0481-9c51-4ae4-994d-79d0d40b77c5"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("580851d8-8e3d-42b7-bc96-545575b3afcf"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("7a8b5a3c-5e8d-4ead-ad6f-54476d1ac78a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("28db51fd-fe96-45a8-be8b-c035b12162c8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("53ae49d4-d7ec-429c-a9e9-074723d0c82c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5814b00e-61ab-44de-b6fb-cc2c0a1721c9"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("bea7cd29-2440-49ba-9387-8ea11557bc40"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c1fedd5a-5bce-42c5-9dc8-c056a8929807"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("c3dac892-b507-49a1-80d2-b06ad4c34728"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2fe10533-76ad-4050-b5e4-0afe8ed08413"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3109e5ee-9067-4292-a397-0fa4f0946fe9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8753222f-7070-45b1-9af6-31a4a67a3c2b"));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Gets or sets the content of the comment.",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Gets or sets the content of the comment.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), 0, "1af5d104-914b-402d-bc7e-6af3d26aee31", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEIDMWDWHVDVVgJ2N9jIfRq3CxnPE7J7JvAvnnSoZ6ki2MREGX4Ze8ZjiUL451XPxmA==", null, false, null, "1dea0831-3143-4b42-a0a0-58eadc462016", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("137772a1-90e7-4455-ac43-0a507464bf0f"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("16fc253a-b891-421b-9263-05158d03ee89"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("22ed0893-8385-4998-97f4-eba0bc9a2087"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("389a4233-d40c-4cc0-b97f-965daf04e37e"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("63dea657-a8a2-4707-a99d-bdd436365143"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("7c684489-1296-48b2-aa55-cf13edda7eab"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("86f41bee-78f0-4302-bb10-1c3d766defc9"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("ad2af004-cd17-4a0f-af64-73286c5f9029"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("f48b4d45-a5d5-4429-9735-879c4729f358"), new Guid("b190e0c8-dc9d-4d8d-b047-d0b855c8eabd"), new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("3261fdd3-c0ab-4a0b-99a2-4a0a21cfb50e"), "Good stuff", null, "Picture of star wars", 10, new Guid("389a4233-d40c-4cc0-b97f-965daf04e37e"), "Star Wars" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("836464be-a10a-4b88-b064-d702f9f71023"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("389a4233-d40c-4cc0-b97f-965daf04e37e"), "Star Wars2" });
        }
    }
}
