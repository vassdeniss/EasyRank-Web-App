using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class ForgotToActuallyAddFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("58e0ac98-1cef-48c1-bcc7-97e086501654"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d1a02bf3-420a-46ba-85ae-5352a129a8b1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d4bcd7bd-b653-4083-a6c7-f99738390a0f"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("85586218-e1b7-4423-8fe7-bd14b011da4b"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("e6f96d64-f6e0-4ab7-8667-4137a5a9625a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("00f15c41-2ecf-4704-9b01-59d237ade788"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("10ec8773-9a9f-4044-82ad-99b58b33d031"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("3e3bf295-8f17-4736-9a32-dd94d7fe1c6c"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("98113a90-cbb3-4335-9e29-c3dbbdf66dfa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbc6e472-f785-49e4-b7f3-a20bdc76c623"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RankPages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Gets or sets a value indicating whether a rank page has been deleted.");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), 0, "386dc240-eab1-4da6-a8e0-40bada576f6b", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEFmxACBeS/iTpKDKdsEmlEqNX/Hf6KLADGXFzrpuwxmgxagbsF/8gpMDilFFKbhZ+A==", null, false, null, "463009f7-3009-4416-9613-f4e84106242f", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"), 0, "a73d087b-7b55-4a1b-a3e9-f27dfa29feb2", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEP93MYW9ofv6m+ooljrAHNe0MWCNo6tymD0KBcyffA8Uoud/C7hOZptqvZqvIEInAQ==", null, false, null, "d945a01b-9d0f-4a7a-91c3-0b20eea61678", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "IsDeleted", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("07de8b17-8334-40fc-9c48-f8159721b74a"), new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 10 Best Movies of 2022" },
                    { new Guid("b33a9dc0-542e-433e-8af6-5701480a36e0"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("cdae09c6-d0d7-4868-b45d-4f1ccbee0c1e"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" },
                    { new Guid("d7851877-ef6e-42f3-abde-70278000cb6b"), new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", false, "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("175fe165-8c72-4716-a1fe-eda994e6c743"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 20, 23, 12, 7, 260, DateTimeKind.Local).AddTicks(6171), false, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2") },
                    { new Guid("9db4ec1e-35c0-432b-b474-c91217a51ab6"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"), new DateTime(2022, 11, 13, 23, 12, 7, 260, DateTimeKind.Local).AddTicks(6215), false, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2") },
                    { new Guid("cb99031b-088d-40c1-bf96-abd6ae40d971"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"), new DateTime(2022, 11, 25, 23, 12, 7, 260, DateTimeKind.Local).AddTicks(6187), false, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("a2dbd006-8f9b-4aa1-b5fb-535e3434474c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"), "Star Wars2" },
                    { new Guid("a8a998f2-2ff0-4754-a059-9187e317e5ea"), "Good stuff", null, "Picture of star wars", 10, new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"), "Star Wars" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("175fe165-8c72-4716-a1fe-eda994e6c743"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9db4ec1e-35c0-432b-b474-c91217a51ab6"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cb99031b-088d-40c1-bf96-abd6ae40d971"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("a2dbd006-8f9b-4aa1-b5fb-535e3434474c"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("a8a998f2-2ff0-4754-a059-9187e317e5ea"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("07de8b17-8334-40fc-9c48-f8159721b74a"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("b33a9dc0-542e-433e-8af6-5701480a36e0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("cdae09c6-d0d7-4868-b45d-4f1ccbee0c1e"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d7851877-ef6e-42f3-abde-70278000cb6b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c1cc38ae-fdba-4e28-97dd-1ee59068e409"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9767b1e8-782c-4283-98d9-2892df5c74c2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3172cfa2-fd86-44ab-bc64-936fac0b6b80"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RankPages");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), 0, "e47702da-d875-49c2-a996-6ea7d5dc593e", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAENVgam7fWgBLQd31EVTQqk8Aeezom43E9d0RplBqUioNPRLIr2RKIIvGqKE8eBViHA==", null, false, null, "e499785b-0205-4fad-916d-6e697badb91d", false, "guest" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("cbc6e472-f785-49e4-b7f3-a20bdc76c623"), 0, "7ec7fd63-0272-4b65-b237-dbbe0aba52b2", "guestTwo@mail.com", true, "GuestTwo", "UserTwo", false, null, "GUESTTWO@MAIL.COM", "GUESTTWO", "AQAAAAEAACcQAAAAEPsy+ebdK5tTbe7lmuDxL3xAYnc6oauTPh2ePL5myaavPHBWtAEhASsiPf1LFgkbmg==", null, false, null, "f7443c25-19d9-4b6c-895a-d05d173e7365", false, "guestTwo" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("00f15c41-2ecf-4704-9b01-59d237ade788"), new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("10ec8773-9a9f-4044-82ad-99b58b33d031"), new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("3e3bf295-8f17-4736-9a32-dd94d7fe1c6c"), new Guid("cbc6e472-f785-49e4-b7f3-a20bdc76c623"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("98113a90-cbb3-4335-9e29-c3dbbdf66dfa"), new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142"), new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), null, "Yoda", "Top 10 Best Movies of 2022" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedByUserId", "CreatedOn", "IsDeleted", "RankPageId" },
                values: new object[,]
                {
                    { new Guid("58e0ac98-1cef-48c1-bcc7-97e086501654"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), new DateTime(2022, 11, 20, 21, 13, 17, 846, DateTimeKind.Local).AddTicks(8202), false, new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142") },
                    { new Guid("d1a02bf3-420a-46ba-85ae-5352a129a8b1"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("cbc6e472-f785-49e4-b7f3-a20bdc76c623"), new DateTime(2022, 11, 13, 21, 13, 17, 846, DateTimeKind.Local).AddTicks(8224), false, new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142") },
                    { new Guid("d4bcd7bd-b653-4083-a6c7-f99738390a0f"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("c6c63299-45a0-42f7-b8a4-40bc12a29bc6"), new DateTime(2022, 11, 25, 21, 13, 17, 846, DateTimeKind.Local).AddTicks(8217), false, new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142") }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[,]
                {
                    { new Guid("85586218-e1b7-4423-8fe7-bd14b011da4b"), "Good stuff", null, "Picture of star wars", 10, new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142"), "Star Wars" },
                    { new Guid("e6f96d64-f6e0-4ab7-8667-4137a5a9625a"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque interdum iaculis arcu et pellentesque. Aliquam at venenatis libero. Suspendisse non suscipit mi, in ullamcorper magna. Donec imperdiet urna et aliquet placerat. Donec faucibus dolor id velit sagittis congue. In hac habitasse platea dictumst. Suspendisse vitae sodales diam. Mauris in erat magna. Cras molestie lectus felis, eget convallis lectus mollis ac. Proin posuere nec magna at accumsan. Etiam quis magna pulvinar, eleifend purus a, fringilla eros.", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("bf4ab15a-7d46-46f2-b680-04cbc7aa3142"), "Star Wars2" }
                });
        }
    }
}
