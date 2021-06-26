using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabPrático.Models
{
    public class Loja
    {
        /// <summary>
        /// Identificador da loja
        /// </summary>
        [Key]
        public int IdLoja { get; set; }

        /// <summary>
        /// Nome da loja
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Imagem da loja
        /// </summary>
        public string ImagemLoja { get; set; }

        /// <summary>
        /// Link do jogo na loja
        /// </summary>
        public string Link { get; set; }

        //***********************************

        /// <summary>
        /// FK para os Jogos
        /// </summary>
        [ForeignKey(nameof(Jogo))]
        public int JogoFK { get; set; }
        public Jogos Jogo { get; set; }
    }
}
