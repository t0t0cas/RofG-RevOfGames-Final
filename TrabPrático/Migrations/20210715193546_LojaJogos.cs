using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabPrático.Migrations
{
    public partial class LojaJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loja_Jogos_JogoFK",
                table: "Loja");

            migrationBuilder.DropIndex(
                name: "IX_Loja_JogoFK",
                table: "Loja");

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "JogoFK",
                table: "Loja");

            migrationBuilder.AddColumn<string>(
                name: "LinkJogo",
                table: "Jogos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LojaFK",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "55d23bc0-ad51-429e-b3f5-c08672b5d152");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "189e0d70-5e6f-4e84-a29f-5629d1b45d74");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 1,
                columns: new[] { "Descricao", "LinkJogo", "LojaFK" },
                values: new object[] { "FIFA 21 é um videojogo de simulação de futebol desenvolvido e publicado pela Electronic Arts, tendo como estrela da capa o jogador Kylian Mbappé.O jogo foi anunciado a 19 de junho de 2020, sendo, no mesmo ano, oficialmente publicado no dia 9 de outubro. Lançado de acordo com a temporada 2020-2021, o jogo apresenta como grandes novidades as novas mecânicas de simulação no modo carreira, junto com um editor de estádios no modo Ultimate Team.FIFA 21 foi o primeiro título da série de videojogos FIFA, pertencente à EA Sports, a receber uma versão para as consolas da nova geração. Intitulado de Next Level Realism, o upgrade garantiu uma maior velocidade dos menus, menor tempo de loadings, novo relvado, novas faces, atualizações de estádios, atualização da neve, novos detalhes extracampo e melhorias nas texturas.", "https://store.steampowered.com/app/1313860/EA_SPORTS_FIFA_21/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 2,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/1091500/Cyberpunk_2077/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 3,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/292030/The_Witcher_3_Wild_Hunt/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 4,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/582160/Assassins_Creed_Origins/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 5,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 6,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/1263850/Football_Manager_2021/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 7,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/374320/DARK_SOULS_III/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 8,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/1222680/Need_for_Speed_Heat/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 9,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/1057090/Ori_and_the_Will_of_the_Wisps/", 1 });

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 10,
                columns: new[] { "LinkJogo", "LojaFK" },
                values: new object[] { "https://store.steampowered.com/app/552520/Far_Cry_5/", 1 });

            migrationBuilder.UpdateData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 1,
                column: "Link",
                value: "https://store.steampowered.com/");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_LojaFK",
                table: "Jogos",
                column: "LojaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Loja_LojaFK",
                table: "Jogos",
                column: "LojaFK",
                principalTable: "Loja",
                principalColumn: "IdLoja",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Loja_LojaFK",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_LojaFK",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "LinkJogo",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "LojaFK",
                table: "Jogos");

            migrationBuilder.AddColumn<int>(
                name: "JogoFK",
                table: "Loja",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "5d0642ed-6a21-4f3b-a3ed-8491bc7f9d58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "153c9c91-7652-4a05-ae67-7d7917d73aab");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "IdJogo",
                keyValue: 1,
                column: "Descricao",
                value: "FIFA 21 é um videojogo de simulação de futebol desenvolvido e publicado pela Electronic Arts, tendo como estrela da capa o jogador Kylian Mbappé.O jogo foi anunciado em 19 de junho de 2020, sendo, no mesmo ano, oficialmente publicado no dia 9 de outubro. Lançado de acordo com a temporada 2020-2021, o jogo apresenta como grandes novidades as novas mecânicas de simulação no modo carreira, junto com um editor de estádios no modo Ultimate Team.FIFA 21 foi o primeiro título da série de videojogos FIFA, pertencente à EA Sports, a receber uma versão para as consolar da nova geração. Intitulado de Next Level Realism, o upgrade garantiu uma maior velocidade dos menus, menor tempo de loadings, novo relvado, novas faces, atualizações de estádios, atualização da neve, novos detalhes extracampo e melhorias nas texturas.");

            migrationBuilder.UpdateData(
                table: "Loja",
                keyColumn: "IdLoja",
                keyValue: 1,
                columns: new[] { "JogoFK", "Link" },
                values: new object[] { 1, "https://store.steampowered.com/app/1313860/EA_SPORTS_FIFA_21/" });

            migrationBuilder.InsertData(
                table: "Loja",
                columns: new[] { "IdLoja", "ImagemLoja", "JogoFK", "Link", "Nome" },
                values: new object[,]
                {
                    { 2, "steamlogo.jpg", 2, "https://store.steampowered.com/app/1091500/Cyberpunk_2077/", "Steam" },
                    { 3, "steamlogo.jpg", 3, "https://store.steampowered.com/app/292030/The_Witcher_3_Wild_Hunt/", "Steam" },
                    { 4, "steamlogo.jpg", 4, "https://store.steampowered.com/app/582160/Assassins_Creed_Origins/", "Steam" },
                    { 5, "steamlogo.jpg", 5, "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/", "Steam" },
                    { 6, "steamlogo.jpg", 6, "https://store.steampowered.com/app/1263850/Football_Manager_2021/", "Steam" },
                    { 7, "steamlogo.jpg", 7, "https://store.steampowered.com/app/374320/DARK_SOULS_III/", "Steam" },
                    { 8, "steamlogo.jpg", 8, "https://store.steampowered.com/app/1222680/Need_for_Speed_Heat/", "Steam" },
                    { 9, "steamlogo.jpg", 9, "https://store.steampowered.com/app/1057090/Ori_and_the_Will_of_the_Wisps/", "Steam" },
                    { 10, "steamlogo.jpg", 10, "https://store.steampowered.com/app/552520/Far_Cry_5/", "Steam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loja_JogoFK",
                table: "Loja",
                column: "JogoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Loja_Jogos_JogoFK",
                table: "Loja",
                column: "JogoFK",
                principalTable: "Jogos",
                principalColumn: "IdJogo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
