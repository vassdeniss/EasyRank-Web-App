using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedCommentDeleteFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Gets or sets a value indicating whether a comment has been deleted.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), 0, "b1d4ea10-a555-42ea-992f-b312e751cc8d", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEOpsvYEDDyohSAMofbveB9ppyp0L/PTCZKealOQxaV/L8I2PkKyKf4xJ4VHyyesaCA==", null, false, null, "c66b9fa5-4d1e-4ece-90cb-b70da61c6962", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("827ac13c-e189-4cb2-9fb2-a6c2d565244a"), 0, "b161a147-76b4-4e16-becf-6f0c46827800", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEL4lQ7UV8nAteIyNKBbMNwRJ0hxCgXOtAphUQ8zQkd7l1aIKpCwr6lm0m14K62lnKw==", null, false, null, "e3320e0d-44e0-42cc-9ec6-4c3728967742", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("3e8b4066-2678-4344-abba-6f757111433a"), new Guid("827ac13c-e189-4cb2-9fb2-a6c2d565244a"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042"), new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("44b34f9e-bc7f-459c-953f-49dbc7e33389"), new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("63e7f151-8229-446b-b11d-62a453f33bc2"), new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("d43e704c-bf97-4ef5-8541-ec6869d4f210"), new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("368e3c40-9bf1-479d-b350-b33c4689b9f7"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), new DateTime(2022, 11, 16, 22, 53, 18, 704, DateTimeKind.Local).AddTicks(8015), false, new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042") },
                    { new Guid("8f3194f4-daef-49f3-84a9-2034e3916dac"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3471b187-3897-442e-9048-0071eb37cfd4"), new DateTime(2022, 11, 21, 22, 53, 18, 704, DateTimeKind.Local).AddTicks(8022), false, new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042") },
                    { new Guid("ea18c48b-f76c-48f8-8dc1-dbd3a4104117"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("827ac13c-e189-4cb2-9fb2-a6c2d565244a"), new DateTime(2022, 11, 9, 22, 53, 18, 704, DateTimeKind.Local).AddTicks(8026), false, new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("c3f9f562-9222-4658-a8c1-8996ec5c95fc"), "Good stuff", null, "Picture of star wars", 10, new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042"), "Star Wars" },
                    { new Guid("f6e2b711-fcca-4f33-b9f2-c21add1b45f4"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042"), "Star Wars2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("368e3c40-9bf1-479d-b350-b33c4689b9f7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("8f3194f4-daef-49f3-84a9-2034e3916dac"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ea18c48b-f76c-48f8-8dc1-dbd3a4104117"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("c3f9f562-9222-4658-a8c1-8996ec5c95fc"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("f6e2b711-fcca-4f33-b9f2-c21add1b45f4"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3e8b4066-2678-4344-abba-6f757111433a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("44b34f9e-bc7f-459c-953f-49dbc7e33389"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("63e7f151-8229-446b-b11d-62a453f33bc2"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d43e704c-bf97-4ef5-8541-ec6869d4f210"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("827ac13c-e189-4cb2-9fb2-a6c2d565244a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("42ffaa67-1c32-43ce-87c7-cd5aff798042"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3471b187-3897-442e-9048-0071eb37cfd4"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

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
    }
}
