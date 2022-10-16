using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedRankEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages");

            migrationBuilder.RenameColumn(
                name: "RankingName",
                table: "RankPages",
                newName: "RankingTitle");

            migrationBuilder.CreateTable(
                name: "RankEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the unique GUID identifier for a rank entry."),
                    Placement = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the placement in the ranking of the ranking entry."),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Gets or sets the title for a rank entry."),
                    Image = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "Gets or sets the image link for a rank entry."),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Gets or sets the description for a rank entry."),
                    RankPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the guid of the rank page which the entry belongs to.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankEntries_RankPages_RankPageId",
                        column: x => x.RankPageId,
                        principalTable: "RankPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "The 'RankEntry' model for the database.");

            migrationBuilder.CreateIndex(
                name: "IX_RankEntries_RankPageId",
                table: "RankEntries",
                column: "RankPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages");

            migrationBuilder.DropTable(
                name: "RankEntries");

            migrationBuilder.RenameColumn(
                name: "RankingTitle",
                table: "RankPages",
                newName: "RankingName");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedByUserId",
                table: "Comments",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RankPages_AspNetUsers_CreatedByUserId",
                table: "RankPages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
