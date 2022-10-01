using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    public partial class AddedCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Users",
                comment: "The 'user' model for the database.");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the unique GUID identifier for a comment."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Gets or sets the date & time a comment has been created on."),
                    CreatedByUserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the guid of the user who created the comment.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CreatedByUserGuid",
                        column: x => x.CreatedByUserGuid,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The 'comment' model for the database.");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedByUserGuid",
                table: "Comments",
                column: "CreatedByUserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterTable(
                name: "Users",
                oldComment: "The 'user' model for the database.");
        }
    }
}
