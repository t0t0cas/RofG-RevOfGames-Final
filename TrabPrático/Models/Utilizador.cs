using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabPrático.Models
{
    public class Utilizador
    {
        public Utilizador(){
             // inicializar a lista de review que o utilizador dá
            UserReview = new HashSet<Review>();    
        }

        /// <summary>
        /// Id do utilizador 
        /// </summary>
        [Key]
        public int IdUtilizador { get; set; }

        ///// <summary>
        ///// Nome do utilizador
        ///// </summary>
        //[Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        //[StringLength(60, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        //public string Nome { get; set; }

        /// <summary>
        /// Email do Utilizador
        /// </summary>
        [Required(ErrorMessage = "O email é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Email { get; set; }

        /// <summary>
        /// Ligação entre os Utilizadores e a tabela de Autenticação
        /// </summary>
        public string UserNameID { get; set; }

        ///// <summary>
        ///// Password do utilizador
        ///// </summary>
        //[Required(ErrorMessage = "A password é de preenchimento obrigatório")]
        //[StringLength(12, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        //public string Pass { get; set; }

        /// <summary>
        /// Data de nascimento do utilizador
        /// </summary>
        public DateTime DataNascimento { get; set; }

        //***********************

        public ICollection<Review> UserReview { get; set; }

    }
}
