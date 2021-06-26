using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabPrático.Migrations
{
    public partial class DadosAct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 6,
                column: "Imagem",
                value: "FootballManager_2021.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 8,
                column: "Imagem",
                value: "NeedForSpeedHeat.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 9,
                column: "Imagem",
                value: "OriWillOfTheWisps.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 10,
                column: "Imagem",
                value: "Far_Cry5.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 6,
                column: "Imagem",
                value: "FootballManager2021.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 8,
                column: "Imagem",
                value: "NeedForSpeed.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 9,
                column: "Imagem",
                value: "OriAndTheWillOfTheWisps.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 10,
                column: "Imagem",
                value: "FarCry5.jpg");
        }
    }
}
