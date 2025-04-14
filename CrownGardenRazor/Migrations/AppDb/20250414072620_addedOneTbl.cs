using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrownGardenRazor.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class addedOneTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShouldEditComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShouldEditComment", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShouldEditComment");
        }
    }
}
