using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabPrático.Models
{
    public class JogosAPIViewModel
    {
        /// <summary>
        /// Id do jogo
        /// </summary>
        public int IdJogo { get; set; }

        /// <summary>
        /// Nome do jogo
        /// </summary>
        public string NomeJogo { get; set; }

        /// <summary>
        /// Imagem do Jogo
        /// </summary>
        public string ImagemFoto { get; set; }

        /// <summary>
        /// Nota dada ao jogo
        /// </summary>
        public double NotaJogo { get; set; }

        /// <summary>
        /// Descrição do Jogo
        /// </summary>
        public string DescricaoJogo { get; set; }
    }
}
