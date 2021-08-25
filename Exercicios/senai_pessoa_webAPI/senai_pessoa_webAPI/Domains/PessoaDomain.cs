using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Domains
{

    /// <summary>
    /// Classe que representa a entidade (tabela) PESSOA
    /// </summary>
    public class PessoaDomain
    {
        public int idPessoa { get; set; }
        public string nomePessoa { get; set; }

    }
}
