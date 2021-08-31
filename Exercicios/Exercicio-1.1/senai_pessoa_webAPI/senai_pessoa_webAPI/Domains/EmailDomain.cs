using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoa_webAPI.Domains
{

    /// <summary>
    /// Classe que representa a entidade (tabela) EMAIL
    /// </summary>
    public class EmailDomain
    {
        public int idEmail { get; set; }
        public int idPessoa { get; set; }
        public string end_email { get; set; }

    }
}
