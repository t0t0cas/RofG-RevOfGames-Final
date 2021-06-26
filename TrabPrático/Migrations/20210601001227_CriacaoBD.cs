using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabPrático.Migrations
{
    public partial class CriacaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    IdJogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaIdade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Media = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.IdJogo);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    IdUtilizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.IdUtilizador);
                });

            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    IdLoja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemLoja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JogoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.IdLoja);
                    table.ForeignKey(
                        name: "FK_Loja_Jogos_JogoFK",
                        column: x => x.JogoFK,
                        principalTable: "Jogos",
                        principalColumn: "IdJogo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    IdReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaReview = table.Column<double>(type: "float", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataReview = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visivel = table.Column<bool>(type: "bit", nullable: false),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    JogoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.IdReview);
                    table.ForeignKey(
                        name: "FK_Review_Jogos_JogoFK",
                        column: x => x.JogoFK,
                        principalTable: "Jogos",
                        principalColumn: "IdJogo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Utilizador_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizador",
                        principalColumn: "IdUtilizador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "IdJogo", "CategoriaIdade", "DataLancamento", "Descricao", "Imagem", "Media", "Nome", "Nota", "Tipo" },
                values: new object[,]
                {
                    { 1, "3+", new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "FIFA 21 é um videojogo de simulação de futebol desenvolvido e publicado pela Electronic Arts, tendo como estrela da capa o jogador Kylian Mbappé.O jogo foi anunciado em 19 de junho de 2020, sendo, no mesmo ano, oficialmente publicado no dia 9 de outubro. Lançado de acordo com a temporada 2020-2021, o jogo apresenta como grandes novidades as novas mecânicas de simulação no modo carreira, junto com um editor de estádios no modo Ultimate Team.FIFA 21 foi o primeiro título da série de videojogos FIFA, pertencente à EA Sports, a receber uma versão para as consolar da nova geração. Intitulado de Next Level Realism, o upgrade garantiu uma maior velocidade dos menus, menor tempo de loadings, novo relvado, novas faces, atualizações de estádios, atualização da neve, novos detalhes extracampo e melhorias nas texturas.", "FIFA21.jpg", 0.0, "FIFA 21", 74.0, "Desporto, Simulação" },
                    { 2, "17+", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077 é um jogo eletrónico de RPG de ação desenvolvido e publicado pela CD Projekt. Lançado a 10 de dezembro de 2020 para Google Stadia, Microsoft Windows, PlayStation 4 e Xbox One, e previsto para 2021 para PlayStation 5 e Xbox Series X / S, sendo que nesses já está disponível via retrocompatibilidade.A história do jogo é ambientada em Night City, um mundo aberto com seis regiões distintas situado no universo da franquia Cyberpunk.Ele é jogado a partir de uma perspectiva em primeira pessoa, com os jogadores a controlar um mercenário personalizável conhecido como V, que pode adquirir habilidades de hacking e maquinários, um arsenal de armas de longo alcance e opções de combate no estilo corpo a corpo.", "Cyberpunk2077.jpg", 0.0, "CyberPunk2077", 85.0, "Ação, Aventura, Mundo Aberto" },
                    { 3, "17+", new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt é um jogo eletrónico de ação do subgénero RPG desenvolvido pela CD Projekt RED e lançado no dia 19 de maio de 2015 para as plataformas Microsoft Windows, PlayStation 4, Xbox One e em outubro de 2019 para a Nintendo Switch, sendo o terceiro título da série de jogos The Witcher.Ele sucede The Witcher e The Witcher 2: Assassins of Kings(2011), que foram baseados na série de livros de fantasia Wiedźmin, do escritor polonês Andrzej Sapkowski.", "TW3_Wild_Hunt.jpg", 0.0, "The Witcher 3: Wild Hunt", 93.0, "Ação, RPG" },
                    { 4, "17+", new DateTime(2017, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin's Creed Origins é um jogo eletrónico de ação-aventura, produzido pela Ubisoft Montreal e publicado pela Ubisoft. É o décimo título principal da série Assassin's Creed e teve o seu lançamento a 27 de Outubro de 2017, para Microsoft Windows, PlayStation 4 e Xbox One, o jogo recebeu uma porta para o Google Stadia a 15 de Dezembro de 2020.", "AssassinsCreedOrigins.jpg", 0.0, "Assassin's Creed Origins", 84.0, "Ação, Aventura, RPG" },
                    { 5, "17+", new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto V é um jogo eletrónico de ação-aventura desenvolvido pela Rockstar North e publicado pela Rockstar Games. É o sétimo título principal da série Grand Theft Auto e foi lançado originalmente a 17 de setembro de 2013 para PlayStation 3 e Xbox 360, com remasterizações lançadas em 2014 para PlayStation 4 e Xbox One, em 2015 para Microsoft Windows e em 2021 para PlayStation 5 e Xbox Series X. O jogo passa-se no estado ficcional de San Andreas, com a história da campanha um jogador seguindo três criminosos e os seus esforços para realizarem assaltos sob a pressão de uma agência governamental. O mundo aberto permite que os jogadores naveguem livremente pelas áreas rurais e urbanas de San Andreas.", "GTAV.jpg", 0.0, "Grand Thef Auto V", 96.0, "Ação, Aventura, Mundo Aberto" },
                    { 6, "3+", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Football Manager 2021 é um videojogo de simulação de gestão de futebol desenvolvido pela Sports Interactive e publicado pela Sega. Foi lançado mundialmente para iOS, Android, macOS e Windows em 24 de novembro de 2020.", "FootballManager_2021.jpg", 0.0, "Football Manager 2021", 85.0, "Desporto, Simulação" },
                    { 7, "17+", new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark Souls III é um jogo do género RPG de ação, o quarto da série Souls, desenvolvido pela FromSoftware e co-realizado por Hidetaka Miyazaki, o criador da série. Dark Souls III foi lançado para Microsoft Windows, PlayStation 4 e Xbox One no dia 24 de março de 2016 no Japão, e a 12 de abril de 2016 no resto do mundo.", "DarkSouls3.jpg", 0.0, "Dark Souls III", 89.0, "Ação, RPG" },
                    { 8, "3+", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Need for Speed Heat é um jogo eletrónico de corrida desenvolvido pela Ghost Games e publicado pela Electronic Arts para Microsoft Windows, PlayStation 4 e Xbox One. Este é o vigésimo quarto jogo de série Need for Speed e comemora o aniversário de 25 anos da série.", "NeedForSpeedHeat.jpg", 0.0, "Need for Speed Heat", 72.0, "Corrida, Mundo Aberto" },
                    { 9, "3+", new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ori and the Will of the Wisps é um jogo eletrónico metroidvania de aventura e plataforma desenvolvido pela Moon Studios e publicado pela Xbox Game Studios Europe para Xbox One, Nintendo Switch e Windows 10. É a sequência de Ori and the Blind Forest e foi lançado a 11 de março de 2020.", "OriWillOfTheWisps.jpg", 0.0, "Ori and the Will of the Wisps", 88.0, "Plataforma" },
                    { 10, "17+", new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Far Cry 5 é um jogo eletrónico de tiro em primeira pessoa de ação-aventura ambientado num mundo aberto.  Foi desenvolvido pela Ubisoft Montreal e publicado pela Ubisoft para Microsoft Windows, PlayStation 4 e Xbox One a 27 de março de 2018 e foi lançado a 3 de Novembro para o Google Stadia, junto com o Far Cry: New Dawn. É o décimo titulo da serie Far Cry e o quinto jogo principal.", "Far_Cry5.jpg", 0.0, "FarCry 5", 78.0, "Ação, Aventura, First Person Shooter" }
                });

            migrationBuilder.InsertData(
                table: "Loja",
                columns: new[] { "IdLoja", "ImagemLoja", "JogoFK", "Link", "Nome" },
                values: new object[,]
                {
                    { 1, "steamlogo.jpg", 1, "https://store.steampowered.com/app/1313860/EA_SPORTS_FIFA_21/", "Steam" },
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

            migrationBuilder.CreateIndex(
                name: "IX_Review_JogoFK",
                table: "Review",
                column: "JogoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UtilizadorFK",
                table: "Review",
                column: "UtilizadorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
