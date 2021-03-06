using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filme_webAPI.Domains
{

    /// <summary>
    /// Classe representa a entidade (tabela) GENERO
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }
        [Required(ErrorMessage ="O nomeGenero é obrigatorio!")]
        public string nomeGenero { get; set; }
    }
}
