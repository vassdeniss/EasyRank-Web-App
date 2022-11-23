using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class ReAddedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3c0ee041-7c31-48e7-933f-2ee006f7d951"), 0, "0290322c-f084-43aa-be2b-55bb6245ff1e", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEJE2vJtfIY2lyIESZqqhoPSsfj+kdSetrtmO8A40qHwQI4s0xdbjzkFqpUMDFRHXTg==", null, false, null, "0e585823-bd2f-4868-8ba6-09e0ff4e0cd2", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), 0, "5d98a94a-8b31-4c69-975e-809f0c048e18", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAED33/9soGGnz2M9pud7y4ehB/QSTzGjiPFKXIWNgGZMzbwLOxbHwNIpFVu7pp/Z5UA==", null, false, null, "41bef6a7-9fb0-40b7-8f8a-529284ef2a71", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("25208721-e7c1-49db-8f62-14035c335fa3"), new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("46460bbb-9923-4096-a058-5e0266d3056a"), new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("93d4d117-f8fe-4952-b749-38c7ce526182"), new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("b639c920-a456-4654-b284-4b89fd110682"), new Guid("3c0ee041-7c31-48e7-933f-2ee006f7d951"), new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("e94aa64f-450f-437e-b19e-bbf4577af4cd"), new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("23356ff7-71eb-44a7-9c1d-0d8ad1382904"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), new DateTime(2022, 11, 24, 21, 3, 2, 935, DateTimeKind.Local).AddTicks(7763), false, new Guid("25208721-e7c1-49db-8f62-14035c335fa3") },
                    { new Guid("4708e455-a4cc-40c1-b603-1dc393b9ddec"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"), new DateTime(2022, 11, 19, 21, 3, 2, 935, DateTimeKind.Local).AddTicks(7757), false, new Guid("25208721-e7c1-49db-8f62-14035c335fa3") },
                    { new Guid("73fb7dd8-4fa8-40d4-8f77-8e378363e64b"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3c0ee041-7c31-48e7-933f-2ee006f7d951"), new DateTime(2022, 11, 12, 21, 3, 2, 935, DateTimeKind.Local).AddTicks(7767), false, new Guid("25208721-e7c1-49db-8f62-14035c335fa3") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("bddb0afe-dea7-4685-9a87-6039d39e0f81"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("25208721-e7c1-49db-8f62-14035c335fa3"), "Star Wars2" },
                    { new Guid("dfd2e343-b4e6-4d1b-94ee-a4ca59aeb457"), "Good stuff", null, "Picture of star wars", 10, new Guid("25208721-e7c1-49db-8f62-14035c335fa3"), "Star Wars" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("23356ff7-71eb-44a7-9c1d-0d8ad1382904"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("4708e455-a4cc-40c1-b603-1dc393b9ddec"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("73fb7dd8-4fa8-40d4-8f77-8e378363e64b"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("bddb0afe-dea7-4685-9a87-6039d39e0f81"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("dfd2e343-b4e6-4d1b-94ee-a4ca59aeb457"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("46460bbb-9923-4096-a058-5e0266d3056a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("93d4d117-f8fe-4952-b749-38c7ce526182"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("b639c920-a456-4654-b284-4b89fd110682"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("e94aa64f-450f-437e-b19e-bbf4577af4cd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c0ee041-7c31-48e7-933f-2ee006f7d951"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("25208721-e7c1-49db-8f62-14035c335fa3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e8c02f9-f5db-44e5-b149-a2c5ef6149a9"));
        }
    }
}
