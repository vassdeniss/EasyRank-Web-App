using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedGuestSecurityStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("2eddffeb-c4ff-4932-a404-8b4e06fc48d9"), 0, "a70f6550-becd-4267-8837-87491d1d50c3", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEE4Zf4/NJHyKQ0FABEZQGnQ8nITAoWWHfc77+8w34I6MhVTGAfswjDS/fBDrSrvr/g==", null, false, "a34ab16a-7625-4a9e-86ff-5ee0a0a08bdb", false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("222f7fa1-b4c9-4e9c-8f7e-e41cbd713771"), new Guid("2eddffeb-c4ff-4932-a404-8b4e06fc48d9"), new DateTime(2022, 10, 27, 14, 28, 38, 234, DateTimeKind.Local).AddTicks(406), "Top 10 Best Movies of 2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankPages",
                keyColumn: "Id",
                keyValue: new Guid("222f7fa1-b4c9-4e9c-8f7e-e41cbd713771"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2eddffeb-c4ff-4932-a404-8b4e06fc48d9"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9b5ee4e1-eb05-4e12-a4b1-e7556b831747"), 0, "cd91d375-5e26-4b9b-8259-9fd9c9ea91b4", "guest@mail.com", true, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAECe54P8NvnsNbsM2hs1/6IQNE/EqBrqATXYDaxuGNKi7gNqTGubDMvXAtPWvaKWYCQ==", null, false, null, false, "guest" });

            migrationBuilder.InsertData(
                table: "RankPages",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "RankingTitle" },
                values: new object[] { new Guid("aae6c5ae-9ea7-4d75-92c2-9fd1ef55e267"), new Guid("9b5ee4e1-eb05-4e12-a4b1-e7556b831747"), new DateTime(2022, 10, 27, 14, 25, 42, 876, DateTimeKind.Local).AddTicks(8821), "Top 10 Best Movies of 2022" });
        }
    }
}
