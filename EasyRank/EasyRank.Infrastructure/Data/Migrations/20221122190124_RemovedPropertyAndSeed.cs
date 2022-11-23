using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class RemovedPropertyAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Image",
                table: "RankPages");

            migrationBuilder.AlterColumn<string>(
                name: "RankingTitle",
                table: "RankPages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Gets or sets the name of the ranking page.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Gets or sets the name of the ranking page.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RankingTitle",
                table: "RankPages",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Gets or sets the name of the ranking page.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Gets or sets the name of the ranking page.");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "RankPages",
                type: "varchar(2048)",
                unicode: false,
                maxLength: 2048,
                nullable: true,
                comment: "Gets or sets the image link for a rank entry.");

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
    }
}
