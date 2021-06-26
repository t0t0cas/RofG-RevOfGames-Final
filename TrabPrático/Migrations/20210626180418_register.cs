using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabPrático.Migrations
{
    public partial class register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Utilizador");

            migrationBuilder.DropColumn(
                name: "Pass",
                table: "Utilizador");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "74982855-a380-4ba2-beb6-1f6447cbc209");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "e35da04e-96c0-4d9d-a4d9-81e78740abd1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Utilizador",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "Utilizador",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "4d44cfc4-e195-4c9a-8775-b997d5f1513c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "1c67af1a-6e09-4b97-9a13-8a07f089f4ec");
        }
    }
}
