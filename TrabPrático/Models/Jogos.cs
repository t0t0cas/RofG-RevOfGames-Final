using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabPrático.Models
{
    /// <summary>
    /// Informações sobre os jogos
    /// </summary>
    public class Jogos
    {
        public Jogos()
        {
            // inicializar a lista de Reviews do Jogo
            JogosReview = new HashSet<Review>();
        }

        /// <summary>
        /// Id do jogo
        /// </summary>
        [Key]
        public int IdJogo { get; set; }

        /// <summary>
        /// Nome do jogo
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Categoria do jogo
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Categoria de idade do jogo Ex: Dark Souls III é +18
        /// </summary>
        public string CategoriaIdade { get; set; }

        /// <summary>
        /// Nota dada ao jogo
        /// </summary>
        public double Nota { get; set; }

        /// <summary>
        /// Data de lançamento do jogo
        /// </summary>
        public DateTime DataLancamento { get; set; }

        /// <summary>
        /// Imagem do Jogo
        /// </summary>
        public string Imagem { get; set; }

        /// <summary>
        /// Descrição do Jogo
        /// </summary>
        public string Descricao { get; set; }
        
        /// <summary>
        /// Média da nota dada aos jogos pelos utilizadores 
        /// </summary>
        public double Media { get; set; }

        //**********************************
        public ICollection<Review> JogosReview { get; set;}
    }
}
