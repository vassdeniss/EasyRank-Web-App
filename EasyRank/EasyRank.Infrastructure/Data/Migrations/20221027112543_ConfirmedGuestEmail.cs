using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class ConfirmedGuestEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d75cd22f-6b8f-4470-afa0-da3aaf11c922"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("681065bc-6a34-4dea-b258-594f3257350e"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9b5ee4e1-eb05-4e12-a4b1-e7556b831747"), 0, "cd91d375-5e26-4b9b-8259-9fd9c9ea91b4", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAECe54P8NvnsNbsM2hs1/6IQNE/EqBrqATXYDaxuGNKi7gNqTGubDMvXAtPWvaKWYCQ==", null, false, null, false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("aae6c5ae-9ea7-4d75-92c2-9fd1ef55e267"), new Guid("9b5ee4e1-eb05-4e12-a4b1-e7556b831747"), new DateTime(2022, 10, 27, 14, 25, 42, 876, DateTimeKind.Local).AddTicks(8821), "Top 10 Best Movies of 2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("aae6c5ae-9ea7-4d75-92c2-9fd1ef55e267"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b5ee4e1-eb05-4e12-a4b1-e7556b831747"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("681065bc-6a34-4dea-b258-594f3257350e"), 0, "9ad78906-9f83-4fcb-ae5c-c3c3a58d8239", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEHQDYnmoU6DaR0pwPSdcZBOSD1b7v7kVf3yflKSXO0VqAlKur/GQdEEJEfMPQRf5NQ==", null, false, null, false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("d75cd22f-6b8f-4470-afa0-da3aaf11c922"), new Guid("681065bc-6a34-4dea-b258-594f3257350e"), new DateTime(2022, 10, 27, 14, 23, 50, 183, DateTimeKind.Local).AddTicks(2127), "Top 10 Best Movies of 2022" });
        }
    }
}
