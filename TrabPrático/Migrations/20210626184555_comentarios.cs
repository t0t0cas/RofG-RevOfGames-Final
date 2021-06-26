using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabPrático.Migrations
{
    public partial class comentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "00dcb0c8-1649-4d1a-afef-ed0016a51a49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "755a656d-c395-4278-8337-f1ba72867c3d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "dc827f05-5edd-4743-a17d-6101bc5c6986");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "85231563-b3ae-4277-86ba-ecfb66f374bb");
        }
    }
}
