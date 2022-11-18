using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class EditedCommentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("51424a7b-466c-4f48-ab75-0488714314da"), 0, "492cb73a-d07d-4dff-91f2-d0c31ee26145", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEAUftOZDvmVJ6EjQ7mRDe4CqfDSEXn2r7CkoDsiJf6P2O8q6jbntvAbgdPxVUCk3YA==", null, false, null, "a55f52d9-5f67-4060-9933-15e2e6f5933b", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("62f0c7a6-b499-474b-938d-accace47926c"), 0, "07f49c44-0931-4b22-8973-f7b24d3dd6af", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEDQ7oXlHQu3ekaXDa3TU1+U9EUk+AvKYaactAhaRTVmq7QVIBVWL266OitazBkZiUg==", null, false, null, "ebb10a03-7c37-4c8d-b6c3-e92ff5cb1a9c", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("0a5da684-f8aa-4d41-90a7-eae8ec32b5c0"), new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("17d725ec-4975-44c3-8c21-73cfacbf51e5"), new Guid("62f0c7a6-b499-474b-938d-accace47926c"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("1dbb1259-3078-4896-878e-1038b2d285a8"), new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("37eb69e3-9034-4361-94a2-47f68b9741de"), new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"), new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("bdfbce24-0b50-4bdb-8dbf-9a99357b261a"), new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("eb39cc37-e8e7-4a9c-8f0f-6410f54db3c1"), new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("0a69c6e2-133a-4a14-8698-ddc063c7b1bb"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 12, 18, 40, 40, 150, DateTimeKind.Local).AddTicks(413), new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b") },
                    { new Guid("21c0c8e8-efa2-4215-b67a-0d234baa8760"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("51424a7b-466c-4f48-ab75-0488714314da"), new DateTime(2022, 11, 17, 18, 40, 40, 150, DateTimeKind.Local).AddTicks(429), new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b") },
                    { new Guid("b1d63def-c2b2-488c-a4ee-cadc583bf6f6"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("62f0c7a6-b499-474b-938d-accace47926c"), new DateTime(2022, 11, 5, 18, 40, 40, 150, DateTimeKind.Local).AddTicks(437), new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("12895621-717a-4de7-82db-cc438ec5d97d"), "Good stuff", null, "Picture of star wars", 10, new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"), "Star Wars" },
                    { new Guid("ccd6173f-d4c9-4b4e-a075-9ea741a3cb1c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"), "Star Wars2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("0a69c6e2-133a-4a14-8698-ddc063c7b1bb"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("21c0c8e8-efa2-4215-b67a-0d234baa8760"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b1d63def-c2b2-488c-a4ee-cadc583bf6f6"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("12895621-717a-4de7-82db-cc438ec5d97d"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("ccd6173f-d4c9-4b4e-a075-9ea741a3cb1c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("0a5da684-f8aa-4d41-90a7-eae8ec32b5c0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("17d725ec-4975-44c3-8c21-73cfacbf51e5"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1dbb1259-3078-4896-878e-1038b2d285a8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("37eb69e3-9034-4361-94a2-47f68b9741de"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("bdfbce24-0b50-4bdb-8dbf-9a99357b261a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("eb39cc37-e8e7-4a9c-8f0f-6410f54db3c1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("62f0c7a6-b499-474b-938d-accace47926c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3e94c098-eae4-44a7-be18-7b4efb1f759b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("51424a7b-466c-4f48-ab75-0488714314da"));

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
    }
}
