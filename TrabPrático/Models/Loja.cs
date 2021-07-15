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
        public Loja()
        {
            // inicializar a lista de Jogos da Loja
            LojaJogos = new HashSet<Jogos>();
        }

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

        public ICollection<Jogos> LojaJogos { get; set; }
    }
}
