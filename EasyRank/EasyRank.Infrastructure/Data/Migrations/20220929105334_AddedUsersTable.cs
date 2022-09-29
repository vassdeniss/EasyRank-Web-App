using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyRank.Infrastructure.Data.Migrations
{
    /// <inheritdoc/>
    public partial class AddedUsersTable : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the unique GUID identifier for a user."),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Gets or sets the unique username for a user."),
                    FirstName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true, comment: "Gets or sets the first name for a user."),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Gets or sets the last name for a user."),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false, comment: "Gets or sets the unique email for a user.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc/>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
