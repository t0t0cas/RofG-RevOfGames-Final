using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrabPrático.Models;

namespace TrabPrático.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "c", Name = "Cliente", NormalizedName = "CLIENTE" },
            new IdentityRole { Id = "g", Name = "Gestor", NormalizedName = "GESTOR" }
         );

            modelBuilder.Entity<Jogos>().HasData(
           new Jogos { IdJogo = 1, Nome = "FIFA 21", Tipo = "Desporto, Simulação", CategoriaIdade = "3+", Nota = 74 , DataLancamento= new DateTime(2020, 10, 9) , Imagem = "FIFA21.jpg", Descricao = "FIFA 21 é um videojogo de simulação de futebol desenvolvido e publicado pela Electronic Arts, tendo como estrela da capa o jogador Kylian Mbappé." +
           "O jogo foi anunciado em 19 de junho de 2020, sendo, no mesmo ano, oficialmente publicado no dia 9 de outubro. Lançado de acordo com a temporada 2020-2021, o jogo apresenta como grandes novidades as novas mecânicas de simulação no modo carreira, junto com um editor de estádios no modo Ultimate Team." +
           "FIFA 21 foi o primeiro título da série de videojogos FIFA, pertencente à EA Sports, a receber uma versão para as consolar da nova geração. Intitulado de Next Level Realism, o upgrade garantiu uma maior velocidade dos menus, menor tempo de loadings, novo relvado, novas faces, atualizações de estádios, atualização da neve, novos detalhes extracampo e melhorias nas texturas."},
           new Jogos { IdJogo = 2, Nome = "CyberPunk2077", Tipo = "Ação, Aventura, Mundo Aberto", CategoriaIdade = "17+", Nota = 85 , DataLancamento = new DateTime(2020, 12, 10), Imagem = "cyberpunk2077.jpg", Descricao = "Cyberpunk 2077 é um jogo eletrónico de RPG de ação desenvolvido e publicado pela CD Projekt. " +
           "Lançado a 10 de dezembro de 2020 para Google Stadia, Microsoft Windows, PlayStation 4 e Xbox One, e previsto para 2021 para PlayStation 5 e Xbox Series X / S, sendo que nesses já está disponível via retrocompatibilidade.A história do jogo é ambientada em Night City, um mundo aberto com seis regiões distintas situado no universo da franquia Cyberpunk.Ele é jogado a partir de uma perspectiva em primeira pessoa, com os jogadores a controlar um mercenário personalizável conhecido como V, que pode adquirir habilidades de hacking e maquinários, um arsenal de armas de longo alcance e opções de combate no estilo corpo a corpo."},
           new Jogos { IdJogo = 3, Nome = "The Witcher 3: Wild Hunt", Tipo = "Ação, RPG", CategoriaIdade = "17+", Nota = 93, DataLancamento = new DateTime(2015, 05, 19), Imagem = "TW3_Wild_Hunt.jpg", Descricao = "The Witcher 3: Wild Hunt é um jogo eletrónico de ação do subgénero RPG desenvolvido pela CD Projekt RED e lançado no dia 19 de maio de 2015 para as plataformas Microsoft Windows, PlayStation 4, Xbox One e em outubro de 2019 para a Nintendo Switch, sendo o terceiro título da série de jogos The Witcher." +
           "Ele sucede The Witcher e The Witcher 2: Assassins of Kings(2011), que foram baseados na série de livros de fantasia Wiedźmin, do escritor polonês Andrzej Sapkowski."},
           new Jogos { IdJogo = 4, Nome = "Assassin's Creed Origins", Tipo = "Ação, Aventura, RPG", CategoriaIdade = "17+", Nota = 84, DataLancamento = new DateTime(2017, 10, 27), Imagem = "AssassinsCreedOrigins.jpg", Descricao = "Assassin's Creed Origins é um jogo eletrónico de ação-aventura, produzido pela Ubisoft Montreal e publicado pela Ubisoft. É o décimo título principal da série Assassin's Creed e teve o seu lançamento a 27 de Outubro de 2017, para Microsoft Windows, PlayStation 4 e Xbox One, o jogo recebeu uma porta para o Google Stadia a 15 de Dezembro de 2020."},
           new Jogos { IdJogo = 5, Nome = "Grand Thef Auto V", Tipo = "Ação, Aventura, Mundo Aberto", CategoriaIdade = "17+", Nota = 96 , DataLancamento = new DateTime(2013, 09, 17), Imagem = "GTAV.jpg", Descricao = "Grand Theft Auto V é um jogo eletrónico de ação-aventura desenvolvido pela Rockstar North e publicado pela Rockstar Games. É o sétimo título principal da série Grand Theft Auto e foi lançado originalmente a 17 de setembro de 2013 para PlayStation 3 e Xbox 360, com remasterizações lançadas em 2014 para PlayStation 4 e Xbox One, em 2015 para Microsoft Windows e em 2021 para PlayStation 5 e Xbox Series X. O jogo passa-se no estado ficcional de San Andreas, com a história da campanha um jogador seguindo três criminosos e os seus esforços para realizarem assaltos sob a pressão de uma agência governamental. O mundo aberto permite que os jogadores naveguem livremente pelas áreas rurais e urbanas de San Andreas."},
           new Jogos { IdJogo = 6, Nome = "Football Manager 2021", Tipo = "Desporto, Simulação", CategoriaIdade = "3+", Nota = 85, DataLancamento = new DateTime(2020, 11, 24), Imagem = "FootballManager_2021.jpg", Descricao = "Football Manager 2021 é um videojogo de simulação de gestão de futebol desenvolvido pela Sports Interactive e publicado pela Sega. Foi lançado mundialmente para iOS, Android, macOS e Windows em 24 de novembro de 2020."},
           new Jogos { IdJogo = 7, Nome = "Dark Souls III", Tipo = "Ação, RPG", CategoriaIdade = "17+", Nota = 89, DataLancamento = new DateTime(2016, 04, 12), Imagem = "DarkSouls3.jpg", Descricao = "Dark Souls III é um jogo do género RPG de ação, o quarto da série Souls, desenvolvido pela FromSoftware e co-realizado por Hidetaka Miyazaki, o criador da série. Dark Souls III foi lançado para Microsoft Windows, PlayStation 4 e Xbox One no dia 24 de março de 2016 no Japão, e a 12 de abril de 2016 no resto do mundo."},
           new Jogos { IdJogo = 8, Nome = "Need for Speed Heat", Tipo = "Corrida, Mundo Aberto", CategoriaIdade = "3+", Nota = 72, DataLancamento = new DateTime(2019, 11, 08), Imagem = "NeedForSpeedHeat.jpg", Descricao = "Need for Speed Heat é um jogo eletrónico de corrida desenvolvido pela Ghost Games e publicado pela Electronic Arts para Microsoft Windows, PlayStation 4 e Xbox One. Este é o vigésimo quarto jogo de série Need for Speed e comemora o aniversário de 25 anos da série."},
           new Jogos { IdJogo = 9, Nome = "Ori and the Will of the Wisps", Tipo = "Plataforma", CategoriaIdade = "3+", Nota = 88, DataLancamento = new DateTime(2020, 03, 11), Imagem = "OriWillOfTheWisps.jpg", Descricao = "Ori and the Will of the Wisps é um jogo eletrónico metroidvania de aventura e plataforma desenvolvido pela Moon Studios e publicado pela Xbox Game Studios Europe para Xbox One, Nintendo Switch e Windows 10. É a sequência de Ori and the Blind Forest e foi lançado a 11 de março de 2020."},
           new Jogos { IdJogo = 10, Nome = "FarCry 5", Tipo = "Ação, Aventura, First Person Shooter", CategoriaIdade = "17+", Nota = 78, DataLancamento = new DateTime(2018, 03, 27), Imagem = "Far_Cry5.jpg", Descricao = "Far Cry 5 é um jogo eletrónico de tiro em primeira pessoa de ação-aventura ambientado num mundo aberto.  Foi desenvolvido pela Ubisoft Montreal e publicado pela Ubisoft para Microsoft Windows, PlayStation 4 e Xbox One a 27 de março de 2018 e foi lançado a 3 de Novembro para o Google Stadia, junto com o Far Cry: New Dawn. É o décimo titulo da serie Far Cry e o quinto jogo principal."}
        );


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Loja>().HasData(
           new Loja
           {
               IdLoja = 1,
               Nome = "Steam",
               ImagemLoja =  "steamlogo.jpg",
               JogoFK = 1,
               Link = "https://store.steampowered.com/app/1313860/EA_SPORTS_FIFA_21/"

           },
           new Loja
           {
               IdLoja = 2,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 2,
               Link = "https://store.steampowered.com/app/1091500/Cyberpunk_2077/"
           },
           new Loja
           {
               IdLoja = 3,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 3,
               Link = "https://store.steampowered.com/app/292030/The_Witcher_3_Wild_Hunt/"
           },
           new Loja { IdLoja = 4,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 4,
               Link = "https://store.steampowered.com/app/582160/Assassins_Creed_Origins/"
           },
           new Loja { IdLoja = 5,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 5,
               Link = "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/"
           },
           new Loja { IdLoja = 6,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 6,
               Link = "https://store.steampowered.com/app/1263850/Football_Manager_2021/"
           },
           new Loja { IdLoja = 7,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 7,
               Link = "https://store.steampowered.com/app/374320/DARK_SOULS_III/"
           },
           new Loja { IdLoja = 8,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 8,
               Link = "https://store.steampowered.com/app/1222680/Need_for_Speed_Heat/"
           },
           new Loja { IdLoja = 9,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 9,
               Link = "https://store.steampowered.com/app/1057090/Ori_and_the_Will_of_the_Wisps/"
           },
           new Loja { IdLoja = 10,
               Nome = "Steam",
               ImagemLoja = "steamlogo.jpg",
               JogoFK = 10,
               Link = "https://store.steampowered.com/app/552520/Far_Cry_5/"
           }
        );
        }

        public DbSet<TrabPrático.Models.Jogos> Jogos { get; set; }
        public DbSet<TrabPrático.Models.Loja> Loja { get; set; }
        public DbSet<TrabPrático.Models.Review> Review{ get; set; }
        public DbSet<TrabPrático.Models.Utilizador> Utilizador{ get; set; }
    }
}
