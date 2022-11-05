using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedSeededText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("ba984c37-f963-49cc-bb90-037143655be0"));

            migrationBuilder.DeleteData(
                table: "RankEntries",
                keyColumn: "Id",
                keyValue: new Guid("dacb54fa-952f-4997-b536-e51a1a134928"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("1532d654-3b5c-4bfd-8a06-f34597b8e6a1"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("210e36ad-7662-4258-8d80-c71b7019d227"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("36fb4c65-147c-4c5e-b2e6-0ed68befb975"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("5c0883c7-0ff2-47a5-86fb-308adcb7ace8"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("9589b1e9-e2dd-4a2a-ad49-3c7764591a55"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("a4c602df-69a2-4ce3-bdfb-c3d28b7da3b4"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("b5084cd7-23ef-4207-96a1-ab77b3f153c0"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d70b46f8-8e0c-4a74-83e4-aac82f8f0b9b"));

            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("caad7053-04af-4264-be81-c8980f19f5b7"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), 0, "db389528-89c7-4181-b390-5f06e128e532", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEBhDOovxdmhiappCCl6dD28rrNtkCsZqfld1tT/7Tw4GQGVXb1KPJLtQ4yN8oeEvQQ==", null, false, null, "06d18279-45e8-4df3-8aae-c886aad06195", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "Image", "ImageAlt", "RankingTitle" },
                values: new object[,]
                {
                    { new Guid("1532d654-3b5c-4bfd-8a06-f34597b8e6a1"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("210e36ad-7662-4258-8d80-c71b7019d227"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 10 Best Movies of 2022" },
                    { new Guid("36fb4c65-147c-4c5e-b2e6-0ed68befb975"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("5c0883c7-0ff2-47a5-86fb-308adcb7ace8"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("9589b1e9-e2dd-4a2a-ad49-3c7764591a55"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("a4c602df-69a2-4ce3-bdfb-c3d28b7da3b4"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("b5084cd7-23ef-4207-96a1-ab77b3f153c0"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" },
                    { new Guid("d70b46f8-8e0c-4a74-83e4-aac82f8f0b9b"), new Guid("caad7053-04af-4264-be81-c8980f19f5b7"), new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Local), "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Yoda", "Top 5 Favorite Characters" }
                });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("ba984c37-f963-49cc-bb90-037143655be0"), "Good stuff again", "https://images.immediate.co.uk/production/volatile/sites/3/2017/12/yoda-the-empire-strikes-back-28a7558.jpg?quality=90&webp=true&resize=800,534", "Picture of star wars2", 9, new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"), "Star Wars2" });

            migrationBuilder.InsertData(
                table: "RankEntries",
                columns: new[] { "Id", "Description", "Image", "ImageAlt", "Placement", "RankPageId", "Title" },
                values: new object[] { new Guid("dacb54fa-952f-4997-b536-e51a1a134928"), "Good stuff", null, "Picture of star wars", 10, new Guid("25e7d657-54e2-4d3b-bfab-f5dd1253df80"), "Star Wars" });
        }
    }
}
