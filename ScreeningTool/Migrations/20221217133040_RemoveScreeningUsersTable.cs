using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreeningTool.Migrations
{
    public partial class RemoveScreeningUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreeningUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Questionnaires",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_UserId",
                table: "Questionnaires",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_AspNetUsers_UserId",
                table: "Questionnaires",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_AspNetUsers_UserId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_UserId",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Questionnaires");

            migrationBuilder.CreateTable(
                name: "ScreeningUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningUsers", x => x.Id);
                });
        }
    }
}
