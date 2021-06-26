using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabPrático.Migrations
{
    public partial class controller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameID",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameID",
                table: "Utilizador");
        }
    }
}
