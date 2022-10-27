using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("681065bc-6a34-4dea-b258-594f3257350e"), 0, "9ad78906-9f83-4fcb-ae5c-c3c3a58d8239", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEHQDYnmoU6DaR0pwPSdcZBOSD1b7v7kVf3yflKSXO0VqAlKur/GQdEEJEfMPQRf5NQ==", null, false, null, false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("d75cd22f-6b8f-4470-afa0-da3aaf11c922"), new Guid("681065bc-6a34-4dea-b258-594f3257350e"), new DateTime(2022, 10, 27, 14, 23, 50, 183, DateTimeKind.Local).AddTicks(2127), "Top 10 Best Movies of 2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("d75cd22f-6b8f-4470-afa0-da3aaf11c922"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("681065bc-6a34-4dea-b258-594f3257350e"));
        }
    }
}
